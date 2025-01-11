using AisLogistics.App.Models.DTO.References;
using AisLogistics.DataLayer.Common.Dto.Reference;
using AisLogistics.DataLayer.Entities.Models;
using DataTables.AspNet.Core;
using Microsoft.EntityFrameworkCore;

namespace AisLogistics.App.Service
{
    // Справочники - Услуги - Тарифы получателя

    public partial class ReferencesService : IReferencesService
    {
        /// <summary>
        /// Поучить список тарифов получателей услуги
        /// </summary>
        /// <param name="serviceId">Id услуги</param>
        /// <param name="start">Брать начиная с</param>
        /// <param name="length">Кол-во элементов</param>
        public async Task<(List<ServiceCustomerTariffDto>, int, int)> GetServiceCustomerTariffs(IDataTablesRequest request, Guid serviceId)
        {
            int? customerTypeId = null;
            var customerTypeColumn = request?.Columns?.Where(w => w.Name == "customerType").Select(s => s.Search.Value).FirstOrDefault();

            if (customerTypeColumn != null) customerTypeId = int.Parse(customerTypeColumn);

            Guid? procedureId = null;
            var procedureColumn = request?.Columns?.Where(w => w.Name == "sServicesProcedureName").Select(s => s.Search.Value).FirstOrDefault();

            if (procedureColumn != null) procedureId = new Guid(procedureColumn);

            var result = _context.SServicesCustomerTariffs
                .AsNoTracking()
                 .Where(x => !x.IsRemove && x.SServicesCustomer.SServicesId == serviceId &&
                 (!customerTypeId.HasValue || x.SServicesCustomer.SServicesCustomerTypeId == customerTypeId) &&
                 (!procedureId.HasValue || x.SServicesProcedureId == procedureId))
               ;

            int totalCount = await result.CountAsync();

            var dataPage = await result
                .OrderBy(x => x.DateAdd)
                .Skip(request.Start)
                .Take(request.Length)
                .Select(x => new ServiceCustomerTariffDto
                {
                    Id = x.Id,
                    SServicesCustomerId = x.SServicesCustomerId,
                    SServicesTariffTypeId = x.SServicesTariffTypeId,
                    CustomerTypeName = x.SServicesCustomer.SServicesCustomerType.TypeName,
                    TariffTypeName = x.SServicesTariffType.TariffTypeName,
                    WeekTypeName = x.SServicesWeek.TypeName,
                    CountDayProcessing = x.CountDayProcessing,
                    CountDayExecution = x.CountDayExecution,
                    CountDayReturn = x.CountDayReturn,
                    Tariff = x.Tariff,
                    TariffMfc = x.TariffMfc,
                    Commentt = x.Commentt,
                    SServicesProcedureName = x.SServicesProcedure.ProcedureName
                }).ToListAsync();

            return (dataPage, totalCount, totalCount);
        }

        public List<ServiceCustomerTariffDto> GetAllServiceCustomerTariffs(Guid serviceId)
        {
            var result = _context.SServicesCustomerTariffs
                .AsNoTracking()
                .Where(x => !x.IsRemove && x.SServicesCustomer.SServicesId == serviceId)
                .Include(i => i.SServicesCustomer)
                .ThenInclude(i => i.SServicesCustomerType)
                .Include(i => i.SServicesTariffType)
                .Include(i => i.SServicesWeek)
                .OrderBy(x => x.DateAdd);

            int totalCount = result.Count();

            var dataPage = result
               .Select(x => new ServiceCustomerTariffDto()
               {
                   Id = x.Id,
                   SServicesCustomerId = x.SServicesCustomerId,
                   SServicesTariffTypeId = x.SServicesTariffTypeId,
                   CustomerTypeName = x.SServicesCustomer.SServicesCustomerType.TypeName,
                   TariffTypeName = x.SServicesTariffType.TariffTypeName,
                   WeekTypeName = x.SServicesWeek.TypeName,
                   CountDayProcessing = x.CountDayProcessing,
                   CountDayExecution = x.CountDayExecution,
                   CountDayReturn = x.CountDayReturn,
                   Tariff = x.Tariff,
                   TariffMfc = x.TariffMfc,
                   Commentt = x.Commentt
               }).ToList();

            return dataPage;
        }

        /// <summary>
        /// Модель для добавления / редактирования тарифа получателя услуги
        /// </summary>
        public async Task<ServiceCustomerTariffModelDto> GetServiceCustomerTariffAsync(Guid? Id)
        {
            if (Id is null)
                throw new ArgumentNullException(nameof(Id));

            var result = await _context.SServicesCustomerTariffs.FindAsync(Id);
            if (result == null)
                throw new InvalidOperationException("Данные не найдены!");

            return _mapper.Map<ServiceCustomerTariffModelDto>(result);
        }

        /// <summary>
        /// Пометить на удаление тариф получателя услуги
        /// </summary>
        /// <param name="Id">Id записи</param>
        /// <param name="comment">Причина удаления</param>
        public async Task RemoveServiceCustomerTariffAsync(Guid Id, string comment)
        {
            var entity = await _context.SServicesCustomerTariffs.FindAsync(Id);
            if (entity == null)
                throw new InvalidOperationException("Запись не найдена!");

            entity.IsRemove = true;

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Добавить тариф получателя услуги
        /// </summary>
        public async Task AddServiceCustomerTariffAsync(ServiceCustomerTariffModelDto model)
        {
            var entity = _mapper.Map<SServicesCustomerTariff>(model);

            await _context.SServicesCustomerTariffs.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Обновить тариф получателя услуги
        /// </summary>
        public async Task UpdateServiceCustomerTariffAsync(ServiceCustomerTariffModelDto model)
        {
            var entity = await _context.SServicesCustomerTariffs.FindAsync(model.Id);
            if (entity == null)
                throw new InvalidOperationException("Данные не найдены!");

            _mapper.Map<ServiceCustomerTariffModelDto, SServicesCustomerTariff>(model, entity);

            await _context.SaveChangesAsync();
        }
    }
}
