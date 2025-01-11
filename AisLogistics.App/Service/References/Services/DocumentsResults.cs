using AisLogistics.App.Models.DTO.References;
using AisLogistics.DataLayer.Common.Dto.Reference;
using AisLogistics.DataLayer.Entities.Models;
using DataTables.AspNet.Core;
using Microsoft.EntityFrameworkCore;

namespace AisLogistics.App.Service
{
    /// <summary>
    /// Справочники - Услуги - Результаты услуг
    /// </summary>
    public partial class ReferencesService : IReferencesService
    {
        /// <summary>
        /// Поучить список результатов документов услуги
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="serviceId">Id услуги</param>
        public async Task<(List<ServiceDocumentResultDto>, int, int)> GetServiceDocumentsResults(IDataTablesRequest request, Guid serviceId)
        {
            Guid? procedureId = null;
            var procedureColumn = request?.Columns?.Where(w => w.Name == "sServicesProcedureName").Select(s => s.Search.Value).FirstOrDefault();

            if (procedureColumn != null) procedureId = new Guid(procedureColumn);

            var results = _context.SServicesDocumentsResults
                .AsNoTracking()
                .Where(x => !x.IsRemove && x.SServices.Id == serviceId && x.SServicesProcedureId == procedureId);

            int totalCount = await results.CountAsync();

            var filteredResult = string.IsNullOrEmpty(request.Search.Value)
                ? results
                : results.Where(x => x.SDocuments.DocumentName.Contains(request.Search.Value, StringComparison.OrdinalIgnoreCase));

            int filteredCount = string.IsNullOrEmpty(request.Search.Value) ? totalCount : await filteredResult.CountAsync();

            var dataPage = await filteredResult
                .OrderBy(x => x.DateAdd)
                .Skip(request.Start)
                .Take(request.Length)
                .Select(x => new ServiceDocumentResultDto()
                {
                    Id = x.Id,
                    SServicesId = serviceId,
                    SDocumentsId = x.SDocumentsId,
                    DocumentName = x.SDocuments.DocumentName,
                    DocumentMethod = x.DocumentMethod,
                    DocumentPeriodMfc = x.DocumentPeriodMfc,
                    DocumentPeriodProvider = x.DocumentPeriodProvider,
                    DocumentResult = x.DocumentResult,
                    ProcedureName = x.SServicesProcedureId.HasValue ? x.SServicesProcedures.ProcedureName : null
                }).ToListAsync();

            return (dataPage, totalCount, filteredCount);
        }



        /// <summary>
        /// Поучить список всех результатов документов услуги
        /// </summary>
        /// <param name="serviceId">Id услуги</param>
        public async Task<List<ServiceDocumentResultDto>> GetAllServiceDocumentsResults(Guid serviceId)
        {
            return await _context.SServicesDocumentsResults
                .AsNoTracking()
                .Where(x => !x.IsRemove && x.SServices.Id == serviceId)
                .Include(i => i.SDocuments)
                .OrderBy(x => x.DateAdd)
                .Select(x => new ServiceDocumentResultDto()
                {
                    Id = x.Id,
                    SServicesId = serviceId,
                    SDocumentsId = x.SDocumentsId,
                    DocumentName = x.SDocuments.DocumentName,
                    DocumentMethod = x.DocumentMethod,
                    DocumentPeriodMfc = x.DocumentPeriodMfc,
                    DocumentPeriodProvider = x.DocumentPeriodProvider,
                    DocumentResult = x.DocumentResult,
                    ProcedureName = x.SServicesProcedures.ProcedureName
                }).ToListAsync();
        }

        /// <summary>
        /// Модель для добавления / редактирования результата документа услуги
        /// </summary>
        public async Task<ServiceDocumentResultModelDto> GetServiceDocumentResultDtoAsync(Guid? Id)
        {
            if (Id is null)
                throw new ArgumentNullException(nameof(Id));

            var result = await _context.SServicesDocumentsResults
                .FirstOrDefaultAsync(x => x.Id == Id);
            if (result == null)
                throw new Exception("Данные не найдены!");

            return _mapper.Map<ServiceDocumentResultModelDto>(result);
        }

        /// <summary>
        /// Пометить на удаление результат документа услуги
        /// </summary>
        /// <param name="Id">Id записи</param>
        /// <param name="comment">Причина удаления</param>
        public async Task RemoveServiceDocumentResultAsync(Guid Id, string comment)
        {
            var entity = await _context.SServicesDocumentsResults.FindAsync(Id);
            if (entity == null)
                throw new Exception("Запись не найдена!");

            entity.IsRemove = true;

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Добавить результат документа услуги
        /// </summary>
        public async Task AddServiceDocumentResultAsync(ServiceDocumentResultModelDto model)
        {
            var entity = _mapper.Map<SServicesDocumentsResult>(model);

            await _context.SServicesDocumentsResults.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Обновить результат документа услуги
        /// </summary>
        public async Task UpdateServiceDocumentResultAsync(ServiceDocumentResultModelDto model)
        {
            var entity = await _context.SServicesDocumentsResults.FindAsync(model.Id);
            if (entity == null)
                throw new Exception("Данные не найдены!");

            _mapper.Map<ServiceDocumentResultModelDto, SServicesDocumentsResult>(model, entity);

            await _context.SaveChangesAsync();
        }
    }
}
