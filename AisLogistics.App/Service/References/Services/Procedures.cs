using AisLogistics.App.Models.DTO.References;
using AisLogistics.DataLayer.Common.Dto.Reference;
using AisLogistics.DataLayer.Entities.Models;
using DataTables.AspNet.Core;
using Microsoft.EntityFrameworkCore;
using NUglify.Helpers;

namespace AisLogistics.App.Service
{
    /// <summary>
    /// Справочники - Услуги - Процедуры
    /// </summary>
    public partial class ReferencesService : IReferencesService
    {
        /// <summary>
        /// Поучить список процедур услуги
        /// </summary>
        /// <param name="serviceId">Id услуги</param>
        /// <param name="start">Брать начиная с</param>
        /// <param name="length">Кол-во элементов</param>
        public async Task<(List<ServicesProcedureDto>, int, int)> GetServiceProceduresAsync(IDataTablesRequest request, Guid serviceId)
        {
            var result = _context.SServicesProcedures
                .AsNoTracking()
                .Where(x => !x.IsRemove && x.SServices.Id == serviceId);

            int totalCount = await result.CountAsync();

            var dataPage = await result
                .OrderBy(x => x.DateAdd)
                .Skip(request.Start)
                .Take(request.Length)
                .Select(x => new ServicesProcedureDto()
                {
                    Id = x.Id,
                    SServicesId = serviceId,
                    ProcedureName = x.ProcedureName,
                    ExtraFormPath = x.ExtraFormPath,
                    FrguTargetId = x.FrguTargetId,
                    EmployeesFioAdd = x.EmployeesFioAdd,
                    ProcedureActive = x.ProcedureActive,
                    IsMdm = x.IsMdm,
                    DateAdd = x.DateAdd.ToString("dd.MM.yyyy")
                }).ToListAsync();

            return (dataPage, totalCount, totalCount);
        }

        /// <summary>
        /// Поучить список всех процедур услуги
        /// </summary>
        /// <param name="serviceId">Id услуги</param>
        public async Task<List<ServicesProcedureDto>> GetAllServiceProceduresAsync(Guid serviceId)
        {
            return await _context.SServicesProcedures
                .Where(x => x.SServicesId == serviceId && !x.IsRemove)
                .OrderBy(x => x.ProcedureName)
                .Select(x => new ServicesProcedureDto()
                {
                    Id = x.Id,
                    SServicesId = serviceId,
                    ProcedureName = x.ProcedureName,
                }).ToListAsync();
        }

        /// <summary>
        /// Модель для добавления / редактирования процедуры услуги
        /// </summary>
        public async Task<ServiceProcedureModelDto> GetServiceProcedureDtoAsync(Guid? Id)
        {
            if (Id is null)
                throw new ArgumentNullException(nameof(Id));

            var result = await _context.SServicesProcedures.FindAsync(Id);
            if (result == null)
                throw new InvalidOperationException("Данные не найдены!");

            return _mapper.Map<ServiceProcedureModelDto>(result);
        }

        /// <summary>
        /// Пометить на удаление процедуру услуги
        /// </summary>
        /// <param name="Id">Id записи</param>
        /// <param name="comment">Причина удаления</param>
        public async Task RemoveServiceProcedureAsync(Guid Id, string comment)
        {
            var entity = await _context.SServicesProcedures
                .Include(i=>i.SServicesCustomerTariffs)
                .Include(i=>i.SServicesDocuments)
                .Include(i=>i.SServicesDocumentsResults)
                .Include(i=>i.SServicesFiles)
                .Include(i=>i.SServicesForms)
                .FirstOrDefaultAsync(f=>f.Id==Id);
            if (entity == null)
                throw new InvalidOperationException("Запись не найдена!");


            entity.SServicesCustomerTariffs.ForEach(f =>
            {
                f.IsRemove = true;
            });

            entity.SServicesDocuments.ForEach(f =>
            {
                f.IsRemove = true;
            });

            entity.SServicesDocumentsResults.ForEach(f =>
            {
                f.IsRemove = true;
            });

            entity.SServicesFiles.ForEach(f =>
            {
                f.IsRemove = true;
            });

            entity.SServicesForms.ForEach(f =>
            {
                f.IsRemove = true;
            });

            entity.IsRemove = true;

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Добавить процедуру услуги
        /// </summary>
        public async Task AddServiceProcedureAsync(ServiceProcedureModelDto model)
        {
            var entity = _mapper.Map<SServicesProcedure>(model);

            await _context.SServicesProcedures.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Обновить данные процедуры услуги
        /// </summary>
        public async Task UpdateServiceProcedureAsync(ServiceProcedureModelDto model)
        {
            var entity = await _context.SServicesProcedures.FindAsync(model.Id);
            if (entity == null)
                throw new InvalidOperationException("Данные не найдены!");

            _mapper.Map<ServiceProcedureModelDto, SServicesProcedure>(model, entity);

            await _context.SaveChangesAsync();
        }
    }
}
