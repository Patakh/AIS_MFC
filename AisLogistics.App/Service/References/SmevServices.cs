using AisLogistics.App.Models.DTO.References;
using AisLogistics.App.Models.DTO.Template;
using AisLogistics.DataLayer.Common.Dto.Reference;
using AisLogistics.DataLayer.Entities.Models;
using DataTables.AspNet.Core;
using Microsoft.EntityFrameworkCore;
using NinjaNye.SearchExtensions;

namespace AisLogistics.App.Service
{
    // Справочники - СМЭВ Сервисы

    public partial class ReferencesService : IReferencesService
    {
        /// <summary>
        /// Поучить список сервисов СМЭВ
        /// </summary>
        /// <param name="request">Запрос</param>
        public async Task<(List<SmevServiceDto>, int, int)> GetSmevServices(IDataTablesRequest request)
        {
            var results = _context.SSmevs
                .AsNoTracking()
                .Where(x => !x.IsRemove);

            int totalCount = await results.CountAsync();

            var filterResult = string.IsNullOrWhiteSpace(request.Search.Value) ?
                results :
                results.Search(x => x.SmevName.ToLower()).Containing(request.Search.Value.ToLower().Trim());

            var filterCount = string.IsNullOrWhiteSpace(request.Search.Value) ? totalCount : await filterResult.CountAsync();

            var dataPage = await filterResult
                .OrderBy(x => x.SmevName)
                .Skip(request.Start)
                .Take(request.Length)
                .Select(x => new SmevServiceDto()
                {
                    Id = x.Id,
                    SmevName = x.SmevName,
                    SmevMnemo = x.SmevMnemo,
                    SmevProvider = x.SmevProvider,
                    ProviderCode = x.ProviderCode,
                    ProviderName = x.ProviderName,
                    SmevDescription = x.SmevDescription,
                    ProviderUrl = x.ProviderUrl,
                    IsSmev3 = x.IsSmev3
                }).ToListAsync();

            return (dataPage, totalCount, filterCount);
        }

        /// <summary>
        /// Поучить список всех сервисов СМЭВ
        /// </summary>
        public async Task<List<SmevServiceDto>> GetAllSmevServicesAsync()
        {
            var results = await _context.SSmevs
                .AsNoTracking()
                .Where(w => !w.IsRemove)
                .OrderBy(x => x.SmevName)
                .Select(x => new SmevServiceDto()
                {
                    Id = x.Id,
                    SmevName = x.SmevName,
                }).ToListAsync();

            return results;
        }

        /// <summary>
        /// Поучить список всех сервисов СМЭВ
        /// </summary>
        public async Task<List<SmevServiceDto>> GetAllSmevServicesAsync(List<Guid> id)
        {
            var results = await _context.SSmevs
                .AsNoTracking()
                .Where(w => !w.IsRemove && id.Any(a => a == w.Id))
                .OrderBy(x => x.SmevName)
                .Select(x => new SmevServiceDto()
                {
                    Id = x.Id,
                    SmevName = x.SmevName,
                }).ToListAsync();

            return results;
        }

        public async Task<List<SelectListDto<string>>> GetAllSmevProvidersAsync()
        {
            var results = await _context.SSmevs
                .AsNoTracking()
                .OrderBy(x => x.SmevName)
                .GroupBy(x => x.SmevProvider)
                .Select(x => new SelectListDto<string>(x.Key, x.Key)
               ).ToListAsync();

            return results;
        }

        public async Task<List<SmevRequestDto>> GetSmevRequestBySmevService(List<Guid> id)
        {
            var results = await _context.SSmevRequests
                .AsNoTracking()
                .Where(w => id.Contains(w.SSmevId))
                .OrderBy(x => x.RequestName)
                .Select(x => new SmevRequestDto
                {
                    Id = x.Id,
                    RequestName = x.RequestName
                }
               ).ToListAsync();

            return results;
        }


        /// <summary>
        /// Модель для добавления / редактирования сервиса СМЭВ
        /// </summary>
        public async Task<SmevServiceModelDto> GetSmevServiceModelDtoAsync(Guid? Id)
        {
            if (Id is null)
                throw new ArgumentNullException(nameof(Id));

            var result = await _context.SSmevs.FindAsync(Id);
            if (result == null)
                throw new Exception("Данные не найдены!");

            return _mapper.Map<SmevServiceModelDto>(result);
        }

        /// <summary>
        /// Пометить на удаление (удалить?) сервис СМЭВ
        /// </summary>
        /// <param name="Id">ID записи</param>
        /// <param name="comment">Причина удаления</param>
        public async Task RemoveSmevServiceAsync(Guid Id, string comment)
        {
            var entity = await _context.SSmevs.FindAsync(Id);
            if (entity == null)
                throw new Exception("Запись не найдена!");

            entity.IsRemove = true;

            await _context.SaveChangesAsync();
        }

        public async Task AddSmevServiceAsync(SmevServiceModelDto model)
        {
            var entity = _mapper.Map<SSmev>(model);

            await _context.SSmevs.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSmevServiceAsync(SmevServiceModelDto model)
        {
            var entity = await _context.SSmevs.FindAsync(model.Id);
            if (entity == null)
                throw new Exception("Данные не найдены!");

            _mapper.Map<SmevServiceModelDto, SSmev>(model, entity);

            await _context.SaveChangesAsync();
        }
    }
}
