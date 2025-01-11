using AisLogistics.App.Models.DTO.References;
using AisLogistics.DataLayer.Common.Dto.Reference;
using AisLogistics.DataLayer.Entities.Models;
using DataTables.AspNet.Core;
using Microsoft.EntityFrameworkCore;

namespace AisLogistics.App.Service
{
    // Справочники - Услуги - Бланки

    public partial class ReferencesService : IReferencesService
    {
        /// <summary>
        /// Поучить список бланков услуги
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="serviceId">Id услуги</param>
        public async Task<(List<ServiceBlankDto>, int, int)> GetServiceBlancs(IDataTablesRequest request, Guid serviceId)
        {
            var results = _context.SServicesForms
                .AsNoTracking()
                .Where(x => !x.IsRemove && (x.SServices.Id == serviceId));

            int totalCount = await results.CountAsync();

            var dataPage = await results
                .OrderBy(x => x.DateAdd)
                .Skip(request.Start)
                .Take(request.Length)
                .Select(x => new ServiceBlankDto
                {
                    Id = x.Id,
                    SServicesId = x.SServicesId,
                    FileName = x.FileName,
                    FileExpansion = x.FileExpansion,
                    FileSize = (long)Math.Round((decimal)(x.FileSize / 1000)),
                    Commentt = x.Commentt,
                    EmployeesFioAdd = x.EmployeesFioAdd,
                    ProcedureName = x.SServicesProcedureId.HasValue ? x.SServicesProcedure.ProcedureName : null,
                }).ToListAsync();

            return (dataPage, totalCount, totalCount);
        }


        /// <summary>
        /// Поучить список всех бланков услуги
        /// </summary>
        /// <param name="serviceId">Id услуги</param>
        public async Task<List<ServiceBlankDto>> GetAllServiceBlancs(Guid serviceId)
        {
            var result = await _context.SServicesForms
                .AsNoTracking()
                .Where(x => !x.IsRemove && x.SServices.Id == serviceId)
                .OrderBy(x => x.DateAdd)
                .Select(x => new ServiceBlankDto()
                {
                    Id = x.Id,
                    SServicesId = serviceId,
                    FileExpansion = x.FileExpansion,
                    FileSize = x.FileSize,
                    FileName = x.FileName
                })
                .ToListAsync(); ;

            return result;

        }

        /// <summary>
        /// Модель для добавления / редактирования бланков услуги
        /// </summary>
        public async Task<ServiceBlancModelDto> GetServiceBlancsAsync(Guid? Id)
        {
            if (Id is null)
                throw new ArgumentNullException(nameof(Id));

            var result = await _context.SServicesForms
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == Id);

            if (result == null)
                throw new Exception("Данные не найдены!");

            return _mapper.Map<ServiceBlancModelDto>(result);
        }

        /// <summary>
        /// Пометить на удаление файл бланков
        /// </summary>
        /// <param name="Id">Id записи</param>
        /// <param name="comment">Причина удаления</param>
        public async Task RemoveServiceBlancsAsync(Guid Id, string comment)
        {
            var entity = await _context.SServicesForms.FindAsync(Id);
            if (entity == null)
                throw new Exception("Запись не найдена!");

            entity.IsRemove = true;

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Добавить бланко услуги
        /// </summary>
        public async Task AddServiceBlancsAsync(ServiceBlancModelDto model)
        {
            var entity = _mapper.Map<SServicesForm>(model);

            if (model.AddedFile is not null)
            {
                // записать byte[]
                using (var ms = new MemoryStream())
                {
                    await model.AddedFile.CopyToAsync(ms);
                    entity.File = ms.ToArray();
                }
            }

            await _context.SServicesForms.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Обновить бланк услуги
        /// </summary>
        public async Task UpdateServiceBlancsAsync(ServiceBlancModelDto model)
        {
            var entity = await _context.SServicesForms.FindAsync(model.Id);
            if (entity == null)
                throw new InvalidOperationException("Данные не найдены!");

            if (model.AddedFile is not null)
            {
                // перезаписать существующий файл
                using var ms = new MemoryStream();
                await model.AddedFile.CopyToAsync(ms);
                model.File = ms.ToArray();
                await ms.DisposeAsync();
            }

            _mapper.Map(model, entity);

            await _context.SaveChangesAsync();
        }

    }
}
