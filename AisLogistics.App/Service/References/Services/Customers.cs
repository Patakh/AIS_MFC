using AisLogistics.App.Models.DTO.References;
using AisLogistics.DataLayer.Common.Dto.Reference;
using AisLogistics.DataLayer.Entities.Models;
using DataTables.AspNet.Core;
using Microsoft.EntityFrameworkCore;

namespace AisLogistics.App.Service
{
    /// <summary>
    /// Справочники - Услуги - Получатели услуг
    /// </summary>
    public partial class ReferencesService : IReferencesService
    {
        /// <summary>
        /// Поучить список получателей услуги
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="serviceId">Id услуги</param>
        public async Task<(List<ServiceCustomerDto>, int, int)> GetServiceCustomers(IDataTablesRequest request, Guid serviceId)
        {
            var results = _context.SServicesCustomers
                .AsNoTracking()
                .AsSplitQuery()
                .Where(x => !x.IsRemove && x.SServices.Id == serviceId);

            int totalCount = await results.CountAsync();

            var filteredResult = string.IsNullOrEmpty(request.Search.Value)
                ? results
                : results.Where(x => x.SServicesCustomerType.TypeName.Contains(request.Search.Value, StringComparison.OrdinalIgnoreCase));

            int filteredCount = string.IsNullOrEmpty(request.Search.Value) ? totalCount : await filteredResult.CountAsync();

            var dataPage = await filteredResult
                .OrderBy(x => x.DateAdd)
                .Skip(request.Start)
                .Take(request.Length)
                .Select(x => new ServiceCustomerDto()
                {
                    Id = x.Id,
                    SServicesCustomerTypeId = x.SServicesCustomerTypeId,
                    SServicesId = serviceId,
                    TypeName = x.SServicesCustomerType.TypeName
                }).ToListAsync();

            return (dataPage, totalCount, filteredCount);
        }

        /// <summary>
        /// Поучить список получателей услуги
        /// </summary>
        /// <param name="searchPredicate">Условие поиска</param>
        /// <param name="serviceId">Id услуги</param>
        /// <param name="start">Брать начиная с</param>
        /// <param name="length">Кол-во элементов</param>
        public (List<ServiceCustomerDto>, int, int) GetServiceCustomers(Func<SServicesCustomer, bool> searchPredicate, Guid serviceId, int start, int length)
        {
            var result = _context.SServicesCustomers
                .AsNoTracking()
                .Where(x => !x.IsRemove && x.SServices.Id == serviceId)
                .Include(i => i.SServicesCustomerType)
                .OrderBy(x => x.DateAdd);

            int totalCount = result.Count();

            var filteredResult = searchPredicate is null ?
                result :
                result.Where(searchPredicate);

            int filteredCount = filteredResult.Count();

            var dataPage = filteredResult
                .Skip(start)
                .Take(length)
                .Select(x => new ServiceCustomerDto()
                {
                    Id = x.Id,
                    SServicesCustomerTypeId = x.SServicesCustomerTypeId,
                    SServicesId = serviceId,
                    TypeName = x.SServicesCustomerType.TypeName
                }).ToList();

            return (dataPage, totalCount, filteredCount);
        }

        /// <summary>
        /// Поучить список получателей услуги
        /// </summary>
        /// <param name="serviceId">Id услуги</param>
        /// <param name="start">Брать начиная с</param>
        /// <param name="length">Кол-во элементов</param>
        public (List<ServiceCustomerDto>, int, int) GetServiceCustomers(Guid serviceId, int start, int length)
        {
            var result = _context.SServicesCustomers
                .AsNoTracking()
                .Where(x => !x.IsRemove && x.SServices.Id == serviceId)
                .Include(i => i.SServicesCustomerType)
                .OrderBy(x => x.DateAdd);

            int totalCount = result.Count();

            var dataPage = result
                .Skip(start)
                .Take(length)
                .Select(x => new ServiceCustomerDto()
                {
                    Id = x.Id,
                    SServicesCustomerTypeId = x.SServicesCustomerTypeId,
                    SServicesId = serviceId,
                    TypeName = x.SServicesCustomerType.TypeName
                }).ToList();

            return (dataPage, totalCount, totalCount);
        }

        /// <summary>
        /// Поучить список всех получателей услуги
        /// </summary>
        /// <param name="serviceId">Id услуги</param>
        public async Task<List<ServiceCustomerDto>> GetAllServiceCustomersAsync(Guid serviceId)
        {
            var result = _context.SServicesCustomers
                .AsNoTracking()
                .Where(x => !x.IsRemove && x.SServices.Id == serviceId)
                .Include(i => i.SServicesCustomerType)
                .OrderBy(x => x.DateAdd);

            return await result
                .Select(x => new ServiceCustomerDto()
                {
                    Id = x.Id,
                    SServicesCustomerTypeId = x.SServicesCustomerTypeId,
                    SServicesId = serviceId,
                    TypeName = x.SServicesCustomerType.TypeName
                }).ToListAsync();
        }

        /// <summary>
        /// Модель для добавления / редактирования получателя услуги
        /// </summary>
        public async Task<ServiceCustomerModelDto> GetServiceCustomerDtoAsync(Guid? Id)
        {
            if (Id is null)
                throw new ArgumentNullException(nameof(Id));

            var result = await _context.SServicesCustomers.FindAsync(Id);
            if (result == null)
                throw new Exception("Данные не найдены!");

            return _mapper.Map<ServiceCustomerModelDto>(result);
        }

        /// <summary>
        /// Добавить получателя услуги
        /// </summary>
        public async Task AddServiceCustomerAsync(ServiceCustomerModelDto model)
        {
            var entity = _mapper.Map<SServicesCustomer>(model);

            await _context.SServicesCustomers.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Обновить основные данные поставщика услуги
        /// </summary>
        public async Task UpdateServiceCustomerAsync(ServiceCustomerModelDto model)
        {
            var entity = await _context.SServicesCustomers.FindAsync(model.Id);
            if (entity == null)
                throw new Exception("Данные не найдены!");

            _mapper.Map<ServiceCustomerModelDto, SServicesCustomer>(model, entity);

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Пометить на удаление поставщика услуги
        /// </summary>
        /// <param name="Id">Id записи о поставщике услуги</param>
        /// <param name="comment">Причина удаления</param>
        public async Task RemoveServiceCustomerAsync(Guid Id, string comment)
        {
            var entity = await _context.SServicesCustomers.FindAsync(Id);
            if (entity == null)
                throw new Exception("Запись не найдена!");

            entity.IsRemove = true;

            await _context.SaveChangesAsync();
        }

        public List<ServiceCustomerTypeDto> GetServiceCustomerTypes(Func<SServicesCustomerType, bool> searchPredicate)
        {
            var result = _context.SServicesCustomerTypes
                .AsNoTracking()
                .Where(searchPredicate)
                .OrderBy(x => x.Id);

            return result.Select(x => new ServiceCustomerTypeDto()
            {
                Id = x.Id,
                IdParent = x.IdParent,
                TypeName = x.TypeName
            }).ToList();
        }

        public async Task<List<ServiceCustomerTypeDto>> GetServiceCustomerTypes()
        {
            var result = await _context.SServicesCustomerTypes
                .AsNoTracking()
                .OrderBy(x => x.Id)
                .Select(x => new ServiceCustomerTypeDto()
                {
                    Id = x.Id,
                    IdParent = x.IdParent,
                    TypeName = x.TypeName
                }).ToListAsync();

            return result;
        }

        public async Task<List<ServiceCustomerTypeDto>> GetServiceCustomerMainTypes()
        {
            var result = await _context.SServicesCustomerTypes
                .AsNoTracking()
                .Where(w => w.IdParent == 0)
                .OrderBy(x => x.Id)
                .Select(x => new ServiceCustomerTypeDto()
                {
                    Id = x.Id,
                    IdParent = x.IdParent,
                    TypeName = x.TypeName
                }).ToListAsync();

            return result;
        }
    }
}
