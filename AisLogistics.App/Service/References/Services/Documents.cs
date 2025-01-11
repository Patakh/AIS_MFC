using AisLogistics.App.Models.DTO.References;
using AisLogistics.DataLayer.Common.Dto.Reference;
using AisLogistics.DataLayer.Entities.Models;
using DataTables.AspNet.Core;
using Microsoft.EntityFrameworkCore;

namespace AisLogistics.App.Service
{
    /// <summary>
    /// Справочники - Услуги - Документы
    /// </summary>
    public partial class ReferencesService : IReferencesService
    {
        /// <summary>
        /// Поучить список документов услуги
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="serviceId">Id услуги</param>
        public async Task<(List<ServiceDocumentDto>, int, int)> GetServiceDocuments(IDataTablesRequest request, Guid serviceId)
        {

            Guid? procedureId = null;
            var procedureColumn = request?.Columns?.Where(w => w.Name == "sServicesProcedureName").Select(s => s.Search.Value).FirstOrDefault();

            if (procedureColumn != null) procedureId = new Guid(procedureColumn);

            var results = _context.SServicesDocuments
                .AsNoTracking()
                .Where(x => !x.IsRemove && x.SServices.Id == serviceId && (!procedureId.HasValue ||x.SServicesProcedureId == procedureId));

            int totalCount = await results.CountAsync();

            var filteredResult = string.IsNullOrEmpty(request.Search.Value)
                ? results
                : results.Where(x => x.SDocuments.DocumentName.Contains(request.Search.Value, StringComparison.OrdinalIgnoreCase));

            int filteredCount = string.IsNullOrEmpty(request.Search.Value) ? totalCount : await filteredResult.CountAsync();

            var dataPage = filteredResult
                .OrderBy(x => x.DateAdd)
                .Skip(request.Start)
                .Take(request.Length)
                .Select(x => new ServiceDocumentDto()
                {
                    Id = x.Id,
                    SServicesId = serviceId,
                    DocumentNeeds = x.DocumentNeeds,
                    DocumentType = x.DocumentType,
                    DocumentCount = x.DocumentCount,
                    SDocumentsId = x.SDocumentsId,
                    DocumentName = x.SDocuments.DocumentName,
                    ProcedureName = x.SServicesProcedureId.HasValue ? x.SServicesProcedures.ProcedureName : null,
                    IsUploadingSite = x.IsUploadingSite
                }).ToList();

            return (dataPage, totalCount, filteredCount);
        }

        /// <summary>
        /// Поучить список всех документов услуги
        /// </summary>
        /// <param name="serviceId">Id услуги</param>
        public async Task<List<ServiceDocumentDto>> GetAllServiceDocumentsAsync(Guid serviceId)
        {
            return await _context.SServicesDocuments
                .AsNoTracking()
                .Where(x => !x.IsRemove && x.SServices.Id == serviceId)
                .OrderBy(x => x.DateAdd)
                .Select(x => new ServiceDocumentDto()
                {
                    Id = x.Id,
                    SServicesId = serviceId,
                    DocumentNeeds = x.DocumentNeeds,
                    DocumentType = x.DocumentType,
                    DocumentCount = x.DocumentCount,
                    SDocumentsId = x.SDocumentsId,
                    DocumentName = x.SDocuments.DocumentName,
                    ProcedureName = x.SServicesProcedures.ProcedureName
                }).ToListAsync();

        }

        /// <summary>
        /// Модель для добавления / редактирования документа услуги
        /// </summary>
        public async Task<ServiceDocumentModelDto> GetServiceDocumentDtoAsync(Guid? Id)
        {
            if (Id is null)
                throw new ArgumentNullException(nameof(Id));

            var result = await _context.SServicesDocuments
                .FirstOrDefaultAsync(x => x.Id == Id);
            if (result == null)
                throw new Exception("Данные не найдены!");

            return _mapper.Map<ServiceDocumentModelDto>(result);
        }

        /// <summary>
        /// Добавить документ услуги
        /// </summary>
        public async Task AddServiceDocumentAsync(ServiceDocumentModelDto model)
        {
            try
            {
                var entity = _mapper.Map<SServicesDocument>(model);

                /*var customer = await _context.SServicesCustomers.FirstOrDefaultAsync(x => x.SServicesId == model.SServicesId &&
                  x.SServicesCustomerTypeId == model.SServicesCustomerTypeId);

                entity.SServicesCustomer = customer;*/

                await _context.SServicesDocuments.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
        }

        /// <summary>
        /// Обновить документ услуги
        /// </summary>
        public async Task UpdateServiceDocumentAsync(ServiceDocumentModelDto model)
        {
            var entity = await _context.SServicesDocuments.FindAsync(model.Id);
            if (entity == null)
                throw new Exception("Данные не найдены!");

            //var customer = await _context.SServicesCustomers.FirstOrDefaultAsync(x => x.SServicesId == model.SServicesId &&
            //    x.SServicesCustomerTypeId == model.SServicesCustomerTypeId);

            //entity.SServicesCustomer = customer;

            _mapper.Map<ServiceDocumentModelDto, SServicesDocument>(model, entity);

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Пометить на удаление документ услуги
        /// </summary>
        /// <param name="Id">Id записи</param>
        /// <param name="comment">Причина удаления</param>
        public async Task RemoveServiceDocumentAsync(Guid Id, string comment)
        {
            var entity = await _context.SServicesDocuments.FindAsync(Id);
            if (entity == null)
                throw new Exception("Запись не найдена!");

            entity.IsRemove = true;

            await _context.SaveChangesAsync();
        }
    }
}
