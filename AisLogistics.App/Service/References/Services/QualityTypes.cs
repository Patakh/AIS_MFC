using AisLogistics.App.Models.DTO.References;
using AisLogistics.DataLayer.Common.Dto.Reference;
using AisLogistics.DataLayer.Entities.Models;
using DataTables.AspNet.Core;
using Microsoft.EntityFrameworkCore;

namespace AisLogistics.App.Service
{
    /// <summary>
    /// Справочники - Услуги - Способы оценки
    /// </summary>
    public partial class ReferencesService : IReferencesService
    {
        /// <summary>
        /// Поучить список способов оценки услуги
        /// </summary>
        /// <param name="serviceId">Id услуги</param>
        /// <param name="start">Брать начиная с</param>
        /// <param name="length">Кол-во элементов</param>
        public async Task<(List<ServiceQualityTypeDto>, int, int)> GetServiceQualityTypes(IDataTablesRequest request, Guid serviceId)
        {
            var result = _context.SServicesTypeQualityJoins
                .AsNoTracking()
                .Where(x => !x.IsRemove && x.SServices.Id == serviceId);

            int totalCount = await result.CountAsync();

            var dataPage = await result
                .OrderBy(x => x.DateAdd)
                .Skip(request.Start)
                .Take(request.Length)
                .Select(x => new ServiceQualityTypeDto()
                {
                    Id = x.Id,
                    SServicesId = serviceId,
                    SServicesTypeQualityId = x.SServicesTypeQualityId,
                    TypeName = x.SServicesTypeQuality.TypeName
                }).ToListAsync();

            return (dataPage, totalCount, totalCount);
        }

        /// <summary>
        /// Поучить все способы оценки услуги
        /// </summary>
        /// <param name="serviceId">Id услуги</param>
        /// <param name="start">Брать начиная с</param>
        /// <param name="length">Кол-во элементов</param>
        public List<ServiceQualityTypeDto> GetAllServiceQualityTypes(Guid serviceId)
        {
            var result = _context.SServicesTypeQualityJoins
                .AsNoTracking()
                .Where(x => !x.IsRemove && x.SServices.Id == serviceId)
                .Include(i => i.SServicesTypeQuality)
                .OrderBy(x => x.DateAdd);

            int totalCount = result.Count();

            return result
                .Select(x => new ServiceQualityTypeDto()
                {
                    Id = x.Id,
                    SServicesId = serviceId,
                    SServicesTypeQualityId = x.SServicesTypeQualityId,
                }).ToList();
        }

        /// <summary>
        /// Модель для добавления / редактирования способа оценки услуги
        /// </summary>
        public async Task<ServiceQualityTypeModelDto> GetServiceQualityTypeDtoAsync(Guid? Id)
        {
            if (Id is null)
                throw new ArgumentNullException(nameof(Id));

            var result = await _context.SServicesTypeQualityJoins.FindAsync(Id);
            if (result == null)
                throw new ArgumentException("Данные не найдены!");

            return _mapper.Map<ServiceQualityTypeModelDto>(result);
        }

        /// <summary>
        /// Пометить на удаление способа оценки услуги
        /// </summary>
        /// <param name="Id">Id записи</param>
        /// <param name="comment">Причина удаления</param>
        public async Task RemoveServiceQualityTypeAsync(Guid Id, string comment)
        {
            var entity = await _context.SServicesTypeQualityJoins.FindAsync(Id);
            if (entity == null)
                throw new ArgumentException("Запись не найдена!");

            entity.IsRemove = true;

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Добавить способ оценки услуги
        /// </summary>
        public async Task AddServiceQualityTypeAsync(ServiceQualityTypeModelDto model)
        {
            var entity = _mapper.Map<SServicesTypeQualityJoin>(model);

            await _context.SServicesTypeQualityJoins.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Обновить способ оценки услуги
        /// </summary>
        public async Task UpdateServiceQualityTypeAsync(ServiceQualityTypeModelDto model)
        {
            var entity = await _context.SServicesTypeQualityJoins.FindAsync(model.Id);
            if (entity == null)
                throw new ArgumentException("Данные не найдены!");

            _mapper.Map<ServiceQualityTypeModelDto, SServicesTypeQualityJoin>(model, entity);

            await _context.SaveChangesAsync();
        }
    }
}
