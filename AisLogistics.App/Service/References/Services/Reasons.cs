using AisLogistics.App.Models.DTO.References;
using AisLogistics.DataLayer.Common.Dto.Reference;
using AisLogistics.DataLayer.Entities.Models;
using DataTables.AspNet.Core;
using Microsoft.EntityFrameworkCore;

namespace AisLogistics.App.Service
{
    // Справочники - Услуги - Основания

    public partial class ReferencesService : IReferencesService
    {
        /// <summary>
        /// Поучить список оснований услуги
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="serviceId">Id услуги</param>
        /// <param name="rt">Тип основания</param>
        public async Task<(List<ServiceReasonDto>, int, int)> GetServiceReasons(IDataTablesRequest request, Guid serviceId, int rt)
        {
            var results = _context.SServicesReasons
                .AsNoTracking()
                .Where(x => !x.IsRemove && x.SServices.Id == serviceId && x.ReasonType == rt);

            int totalCount = await results.CountAsync();

            var dataPage = await results
                .OrderBy(x => x.DateAdd)
                .Skip(request.Start)
                .Take(request.Length)
                .Select(x => new ServiceReasonDto()
                {
                    Id = x.Id,
                    SServicesId = serviceId,
                    ReasonText = x.ReasonText,
                    ReasonType = x.ReasonType,
                    LegalAct = x.LegalAct,
                    Commentt = x.Commentt,
                    CountDay = x.CountDay,
                    TypeName = x.SServicesWeek == null ? null : x.SServicesWeek.TypeName
                }).ToListAsync();

            return (dataPage, totalCount, totalCount);
        }

        /// <summary>
        /// Модель для добавления / редактирования способа получения услуги
        /// </summary>
        public async Task<ServiceReasonModelDto> GetServiceReasonAsync(Guid? Id)
        {
            if (Id is null)
                throw new ArgumentNullException(nameof(Id));

            var result = await _context.SServicesReasons
                .FirstOrDefaultAsync(x => x.Id == Id);
            if (result == null)
                throw new Exception("Данные не найдены!");

            return _mapper.Map<ServiceReasonModelDto>(result);
        }

        /// <summary>
        /// Пометить на удаление основания услуги
        /// </summary>
        /// <param name="Id">Id записи</param>
        /// <param name="comment">Причина удаления</param>
        public async Task RemoveServiceReasonAsync(Guid Id, string comment)
        {
            var entity = await _context.SServicesReasons.FindAsync(Id);
            if (entity == null)
                throw new Exception("Запись не найдена!");

            entity.IsRemove = true;

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Добавить способ получения услуги
        /// </summary>
        public async Task AddServiceReasonAsync(ServiceReasonModelDto model)
        {
            var entity = _mapper.Map<SServicesReason>(model);

            await _context.SServicesReasons.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Обновить способ получения услуги
        /// </summary>
        public async Task UpdateServiceReasonAsync(ServiceReasonModelDto model)
        {
            var entity = await _context.SServicesReasons.FindAsync(model.Id);
            if (entity == null)
                throw new Exception("Данные не найдены!");

            _mapper.Map<ServiceReasonModelDto, SServicesReason>(model, entity);

            await _context.SaveChangesAsync();
        }
    }
}
