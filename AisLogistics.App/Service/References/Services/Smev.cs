using AisLogistics.App.Models.DTO.References;
using AisLogistics.DataLayer.Common.Dto.Reference;
using AisLogistics.DataLayer.Entities.Models;
using DataTables.AspNet.Core;
using Microsoft.EntityFrameworkCore;
using NinjaNye.SearchExtensions;

namespace AisLogistics.App.Service
{
    // Справочники - Услуги - СМЭВ

    public partial class ReferencesService : IReferencesService
    {
        /// <summary>
        /// Поучить список запросов СМЭВ услуги
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="serviceId">Id услуги</param>
        public async Task<(List<ServiceSmevDto>, int, int)> GetServiceSmevRequests(IDataTablesRequest request, Guid serviceId)
        {
            var results = _context.SServicesSmevRequestJoins
                .AsNoTracking()
                .Where(x => !x.IsRemove && x.SServices.Id == serviceId);

            int totalCount = await results.CountAsync();

            var filteredResult = string.IsNullOrEmpty(request.Search.Value)
               ? results
               : results.Search(x => x.SSmevRequest.RequestName.ToLower()).Containing(request.Search.Value.ToLower().Trim());

            int filteredCount = string.IsNullOrEmpty(request.Search.Value) ? totalCount : await filteredResult.CountAsync();

            var dataPage = await filteredResult
                .OrderBy(x => x.DateAdd)
                .Skip(request.Start)
                .Take(request.Length)
                .Select(x => new ServiceSmevDto()
                {
                    Id = x.Id,
                    SmevName = x.SSmevRequest.SSmev.SmevName,
                    SmevProvider = x.SSmevRequest.SSmev.SmevProvider,
                    RequestName = x.SSmevRequest.RequestName,
                    CountDayExecution = x.SSmevRequest.CountDayExecution
                }).ToListAsync();

            return (dataPage, totalCount, filteredCount);
        }

        /// <summary>
        /// Поучить список запросов СМЭВ услуги
        /// </summary>
        /// <param name="searchPredicate">Условие поиска</param>
        /// <param name="serviceId">Id услуги</param>
        /// <param name="start">Брать начиная с</param>
        /// <param name="length">Кол-во элементов</param>
        public (List<ServiceSmevDto>, int, int) GetServiceSmevRequests(Func<SServicesSmevRequestJoin, bool> searchPredicate, Guid serviceId, int start, int length)
        {
            var result = _context.SServicesSmevRequestJoins
                .AsNoTracking()
                .Where(x => !x.IsRemove && x.SServices.Id == serviceId)
                .Include(i => i.SSmevRequest)
                .ThenInclude(i => i.SSmev)
                .OrderBy(x => x.DateAdd);

            int totalCount = result.Count();
            //x => x.SSmevRequest.SSmev.SmevName.Contains(request.Search.Value, StringComparison.OrdinalIgnoreCase)

            var filteredResult = searchPredicate is null ?
                result :
                result.Where(searchPredicate);

            int filteredCount = filteredResult.Count();

            var dataPage = filteredResult
                .Skip(start)
                .Take(length)
                .Select(x => new ServiceSmevDto()
                {
                    Id = x.Id,
                    SmevName = x.SSmevRequest.SSmev.SmevName,
                    SmevProvider = x.SSmevRequest.SSmev.SmevProvider,
                    RequestName = x.SSmevRequest.RequestName,
                    CountDayExecution = x.SSmevRequest.CountDayExecution
                }).ToList();

            return (dataPage, totalCount, filteredCount);
        }

        /// <summary>
        /// Поучить список запросов СМЭВ услуги
        /// </summary>
        /// <param name="serviceId">Id услуги</param>
        /// <param name="start">Брать начиная с</param>
        /// <param name="length">Кол-во элементов</param>
        public (List<ServiceSmevDto>, int, int) GetServiceSmevRequests(Guid serviceId, int start, int length)
        {
            var result = _context.SServicesSmevRequestJoins
                .AsNoTracking()
                .Where(x => !x.IsRemove && x.SServices.Id == serviceId)
                .Include(i => i.SSmevRequest)
                .ThenInclude(i => i.SSmev)
                .OrderBy(x => x.DateAdd);

            int totalCount = result.Count();

            var dataPage = result
                .Skip(start)
                .Take(length)
                .Select(x => new ServiceSmevDto()
                {
                    Id = x.Id,
                    SmevName = x.SSmevRequest.SSmev.SmevName,
                    SmevProvider = x.SSmevRequest.SSmev.SmevProvider,
                    RequestName = x.SSmevRequest.RequestName,
                    CountDayExecution = x.SSmevRequest.CountDayExecution
                }).ToList();

            return (dataPage, totalCount, totalCount);
        }

        /// <summary>
        /// Поучить список всех запросов СМЭВ услуги
        /// </summary>
        /// <param name="serviceId">Id услуги</param>
        public List<ServiceSmevDto> GetAllServiceSmevRequests(Guid serviceId)
        {
            var result = _context.SServicesSmevRequestJoins
                .AsNoTracking()
                .Where(x => !x.IsRemove && x.SServices.Id == serviceId);

            return result.Select(x => new ServiceSmevDto()
            {
                Id = x.Id,
                SServicesId = x.SServicesId,
                SSmevRequestId = x.SSmevRequestId,
                RequestName = x.SSmevRequest.RequestName,
            }).ToList();
        }

        /// <summary>
        /// Модель для добавления / редактирования запроса СМЭВ услуги
        /// </summary>
        public async Task<ServiceSmevRequestModelDto> GetServiceSmevRequestAsync(Guid? Id)
        {
            if (Id is null)
                throw new ArgumentNullException(nameof(Id));

            var result = await _context.SServicesSmevRequestJoins
                .FirstOrDefaultAsync(x => x.Id == Id);
            if (result == null)
                throw new Exception("Данные не найдены!");

            return _mapper.Map<ServiceSmevRequestModelDto>(result);
        }

        /// <summary>
        /// Пометить на удаление запрос СМЭВ услуги
        /// </summary>
        /// <param name="Id">Id записи</param>
        /// <param name="comment">Причина удаления</param>
        public async Task RemoveServiceSmevRequestAsync(Guid Id, string comment)
        {
            var entity = await _context.SServicesSmevRequestJoins.FindAsync(Id);
            if (entity == null)
                throw new Exception("Запись не найдена!");

            entity.IsRemove = true;

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Добавить запрос СМЭВ услуги
        /// </summary>
        public async Task AddServiceSmevRequestAsync(ServiceSmevRequestModelDto model)
        {
            var entity = _mapper.Map<SServicesSmevRequestJoin>(model);

            await _context.SServicesSmevRequestJoins.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Обновить запрос СМЭВ услуги
        /// </summary>
        public async Task UpdateServiceSmevRequestAsync(ServiceSmevRequestModelDto model)
        {
            var entity = await _context.SServicesSmevRequestJoins.FindAsync(model.Id);
            if (entity == null)
                throw new Exception("Данные не найдены!");

            _mapper.Map<ServiceSmevRequestModelDto, SServicesSmevRequestJoin>(model, entity);

            await _context.SaveChangesAsync();
        }
    }
}
