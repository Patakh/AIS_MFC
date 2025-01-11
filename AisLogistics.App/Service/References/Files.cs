using AisLogistics.App.Models.DTO.References;
using AisLogistics.DataLayer.Common.Dto.Reference;
using AisLogistics.DataLayer.Entities.Models;
using DataTables.AspNet.Core;
using Microsoft.EntityFrameworkCore;
using NinjaNye.SearchExtensions;

namespace AisLogistics.App.Service
{
    // Справочники - Файлы

    public partial class ReferencesService : IReferencesService
    {
        /// <summary>
        /// Поучить список файлов
        /// </summary>
        /// <param name="request">Запрос</param>
        public async Task<(List<ReferencesServicesFileDto>, int, int)> GetReferencesServicesFiles(IDataTablesRequest request)
        {
            var results = _context.SServicesFiles
                .AsNoTracking()
                .Where(x => !x.IsRemove);

            int totalCount = await results.CountAsync();

            var filteredResult = string.IsNullOrEmpty(request.Search.Value)
               ? results
               : results.Search(s => s.FileName.ToLower()).Containing(request.Search.Value.ToLower());

            int filteredCount = string.IsNullOrEmpty(request.Search.Value) ? totalCount : await filteredResult.CountAsync();

            var dataPage = await filteredResult
                .OrderBy(x => x.FileName)
                .Skip(request.Start)
                .Take(request.Length)
                .Select(x => new ReferencesServicesFileDto()
                {
                    Id = x.Id,
                    FileName = x.FileName,
                    FileExpansion = x.FileExpansion,
                    FileSize = x.FileSize,
                    Commentt = x.Commentt,
                    EmployeesFioAdd = x.EmployeesFioAdd
                }).ToListAsync();

            return (dataPage, totalCount, filteredCount);
        }

        /// <summary>
        /// Поучить список всех файлов
        /// </summary>
        /// <param name="start">Брать начиная с</param>
        /// <param name="length">Кол-во элементов</param>
        public async Task<List<ReferencesServicesFileDto>> GetAllReferencesServicesFilesAsync()
        {
            var files = _context.SServicesFiles
                .AsNoTracking()
                .Where(x => !x.IsRemove)
                .OrderBy(x => x.FileName);

            int totalCount = files.Count();

            return await files
                .Select(x => new ReferencesServicesFileDto()
                {
                    Id = x.Id,
                    FileName = x.FileName,
                    FileExpansion = x.FileExpansion,
                    FileSize = x.FileSize,
                    Commentt = x.Commentt,
                    EmployeesFioAdd = x.EmployeesFioAdd
                }).ToListAsync();
        }

        /// <summary>
        /// Модель для редактирования файла
        /// </summary>
        public async Task<ReferencesServicesFileModelDto> GetReferencesServicesFileDtoAsync(Guid? Id)
        {
            if (Id is null)
                throw new ArgumentNullException(nameof(Id));

            var result = await _context.SServicesFiles.FindAsync(Id);
            if (result == null)
                throw new InvalidOperationException("Данные не найдены!");

            return _mapper.Map<ReferencesServicesFileModelDto>(result);
        }

        /// <summary>
        /// Добавить файл
        /// </summary>
        public async Task AddReferencesServicesFileAsync(ReferencesServicesFileModelDto model)
        {
            var entity = _mapper.Map<SServicesFile>(model);

            if (model.AddedFile is not null)
            {
                // записать byte[]
                using (var ms = new MemoryStream())
                {
                    await model.AddedFile.CopyToAsync(ms);
                    entity.File = ms.ToArray();
                }
            }

            await _context.SServicesFiles.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Обновить файл
        /// </summary>
        public async Task UpdateReferencesServicesFileAsync(ReferencesServicesFileModelDto model)
        {
            var entity = await _context.SServicesFiles.FindAsync(model.Id);
            if (entity == null)
                throw new InvalidOperationException("Данные не найдены!");

            if (model.AddedFile is not null)
            {
                // перезаписать существующий файл
                using (var ms = new MemoryStream())
                {
                    await model.AddedFile.CopyToAsync(ms);
                    entity.File = ms.ToArray();
                }
            }

            _mapper.Map<ReferencesServicesFileModelDto, SServicesFile>(model, entity);

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Пометить на удаление файл
        /// </summary>
        /// <param name="Id">Id файла</param>
        /// <param name="comment">Причина удаления</param>
        public async Task RemoveReferencesServicesFileAsync(Guid Id, string comment)
        {
            var entity = await _context.SServicesFiles.FindAsync(Id);
            if (entity == null)
                throw new Exception("Запись не найдена!");

            entity.IsRemove = true;
            entity.Commentt = comment;

            await _context.SaveChangesAsync();
        }
    }
}
