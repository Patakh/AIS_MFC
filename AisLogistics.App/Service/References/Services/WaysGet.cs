using AisLogistics.App.Models.DTO.References;
using AisLogistics.DataLayer.Common.Dto.Reference;
using AisLogistics.DataLayer.Entities.Models;
using DataTables.AspNet.Core;
using Microsoft.EntityFrameworkCore;

namespace AisLogistics.App.Service
{
    // Справочники - Услуги - Способы обращений

    public partial class ReferencesService : IReferencesService
    {
        /// <summary>
        /// Поучить список способов обращений услуги
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="serviceId">Id услуги</param>
        /// <param name="wt">Тип обращения</param>
        public async Task<(List<ServiceWayGetDto>, int, int)> GetServiceWaysGet(IDataTablesRequest request, Guid serviceId, int wt)
        {
            var results = _context.SServicesWayGetJoins
                .AsNoTracking()
                .Where(x => !x.IsRemove && x.SServices.Id == serviceId && x.WayType == wt);

            int totalCount = await results.CountAsync();

            var dataPage = await results
                .OrderBy(x => x.DateAdd)
                .Skip(request.Start)
                .Take(request.Length)
                .Select(x => new ServiceWayGetDto()
                {
                    Id = x.Id,
                    SServicesId = serviceId,
                    SServicesWayGetId = x.SServicesWayGetId,
                    WayType = x.WayType,
                    NameWay = x.SServicesWayGet.NameWay
                }).ToListAsync();

            return (dataPage, totalCount, totalCount);
        }

        /// <summary>
        /// Поучить список всех способов обращений услуги
        /// </summary>
        public async Task<List<ServiceWayGetDto>> GetAllServiceWaysGet(Guid serviceId, int wayType)
        {
          return await _context.SServicesWayGetJoins
                .AsNoTracking()
                .Where(x => !x.IsRemove && x.SServices.Id == serviceId && x.WayType == wayType)
                .OrderBy(x => x.DateAdd)
                .Select(x => new ServiceWayGetDto()
                {
                    Id = x.Id,
                    SServicesId = serviceId,
                    SServicesWayGetId = x.SServicesWayGetId,
                    WayType = x.WayType,
                    NameWay = x.SServicesWayGet.NameWay
                }).ToListAsync();
        }

        /// <summary>
        /// Модель для добавления / редактирования способа получения услуги
        /// </summary>
        public async Task<ServiceWayGetModelDto> GetServiceWayGetAsync(Guid? Id)
        {
            if (Id is null)
                throw new ArgumentNullException(nameof(Id));

            var result = await _context.SServicesWayGetJoins
                .FirstOrDefaultAsync(x => x.Id == Id);
            if (result == null)
                throw new ArgumentException("Данные не найдены!");

            return _mapper.Map<ServiceWayGetModelDto>(result);
        }

        /// <summary>
        /// Пометить на удаление способ получения услуги
        /// </summary>
        /// <param name="Id">Id записи</param>
        /// <param name="comment">Причина удаления</param>
        public async Task RemoveServiceWayGetAsync(Guid Id, string comment)
        {
            var entity = await _context.SServicesWayGetJoins.FindAsync(Id);
            if (entity == null)
                throw new ArgumentException("Запись не найдена!");

            entity.IsRemove = true;

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Добавить способ получения услуги
        /// </summary>
        public async Task AddServiceWayGetAsync(ServiceWayGetModelDto model)
        {
            var entity = _mapper.Map<SServicesWayGetJoin>(model);

            await _context.SServicesWayGetJoins.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Обновить способ получения услуги
        /// </summary>
        public async Task UpdateServiceWayGetAsync(ServiceWayGetModelDto model)
        {
            var entity = await _context.SServicesWayGetJoins.FindAsync(model.Id);
            if (entity == null)
                throw new ArgumentException("Данные не найдены!");

            _mapper.Map<ServiceWayGetModelDto, SServicesWayGetJoin>(model, entity);

            await _context.SaveChangesAsync();
        }
    }
}
