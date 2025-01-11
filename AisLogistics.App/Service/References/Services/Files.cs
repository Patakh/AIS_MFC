using AisLogistics.App.Models.DTO.References;
using AisLogistics.DataLayer.Common.Dto.Reference;
using AisLogistics.DataLayer.Entities.Models;
using DataTables.AspNet.Core;
using Microsoft.EntityFrameworkCore;

namespace AisLogistics.App.Service
{
    // Справочники - Услуги - Файлы

    public partial class ReferencesService : IReferencesService
    {
        /// <summary>
        /// Поучить список файлов услуги
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="serviceId">Id услуги</param>
        public async Task<(List<ServiceFileDto>, int, int)> GetServiceFiles(IDataTablesRequest request, Guid serviceId)
        {
            var results = _context.SServicesFiles
                .AsNoTracking()
                .Where(x => !x.IsRemove && (x.SServices.Id == serviceId));

            int totalCount = await results.CountAsync();

            var dataPage = await results
                .OrderBy(x => x.DateAdd)
                .Skip(request.Start)
                .Take(request.Length)
                .Select(x => new ServiceFileDto
                {
                    Id = x.Id,
                    SServicesId = x.SServicesId,
                    FileName = x.FileName,
                    FileExpansion = x.FileExpansion,
                    FileSize = (long)Math.Round((decimal)(x.FileSize / 1000)),
                    Commentt = x.Commentt,
                    EmployeesFioAdd = x.EmployeesFioAdd,
                    ProcedureName = x.SServicesProcedureId.HasValue ? x.SServicesProcedure.ProcedureName : null
                }).ToListAsync();

            return (dataPage, totalCount, totalCount);
        }


        /// <summary>
        /// Поучить список всех файлов услуги
        /// </summary>
        /// <param name="serviceId">Id услуги</param>
        public async Task<List<ServiceFileDto>> GetAllServiceFiles(Guid serviceId)
        {
            var result = await _context.SServicesFiles
                .AsNoTracking()
                .Where(x => !x.IsRemove && x.SServices.Id == serviceId)
                .OrderBy(x => x.DateAdd)
                .Select(x => new ServiceFileDto()
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
        /// Модель для добавления / редактирования тарифа получателя услуги
        /// </summary>
        public async Task<ServiceFileModelDto> GetServiceFileAsync(Guid? Id)
        {
            if (Id is null)
                throw new ArgumentNullException(nameof(Id));

            var result = await _context.SServicesFiles
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == Id);

            if (result == null)
                throw new ArgumentException("Данные не найдены!");

            return _mapper.Map<ServiceFileModelDto>(result);
        }

        /// <summary>
        /// Пометить на удаление файл услуги
        /// </summary>
        /// <param name="Id">Id записи</param>
        /// <param name="comment">Причина удаления</param>
        public async Task RemoveServiceFileAsync(Guid Id, string comment)
        {
            var entity = await _context.SServicesFiles.FindAsync(Id);
            if (entity == null)
                throw new ArgumentException("Запись не найдена!");

            entity.IsRemove = true;

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Добавить файл услуги
        /// </summary>
        public async Task AddServiceFileAsync(ServiceFileModelDto model)
        {
            var entity = _mapper.Map<SServicesFile>(model);

            if (model.AddedFile is not null)
            {
                // записать byte[]
                using var ms = new MemoryStream();
                await model.AddedFile.CopyToAsync(ms);
                entity.File = ms.ToArray();
                ms.Dispose();
            }

            await _context.SServicesFiles.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Обновить файл услуги
        /// </summary>
        public async Task UpdateServiceFileAsync(ServiceFileModelDto model)
        {
            var entity = await _context.SServicesFiles.FindAsync(model.Id);
            if (entity == null)
                throw new ArgumentException("Данные не найдены!");

            if (model.AddedFile is not null)
            {
                // перезаписать существующий файл
                using var ms = new MemoryStream();
                await model.AddedFile.CopyToAsync(ms);
                model.File = ms.ToArray();
                ms.Dispose();
            }

            _mapper.Map(model, entity);

            await _context.SaveChangesAsync();
        }
    }
}
