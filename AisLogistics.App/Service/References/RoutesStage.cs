using AisLogistics.App.Models.DTO.References;
using AisLogistics.App.Models.DTO.Services;
using AisLogistics.DataLayer.Common.Dto.Reference;
using AisLogistics.DataLayer.Entities.Models;
using DataTables.AspNet.Core;
using Microsoft.EntityFrameworkCore;
using NinjaNye.SearchExtensions;
using System.Globalization;

namespace AisLogistics.App.Service
{
    public partial class ReferencesService : IReferencesService
    {
        /// <summary>
        /// Получить список "Этапов"
        /// </summary>
        public async Task<(List<RoutesStageDto>, int, int)> GetRoutesStage(IDataTablesRequest request)
        {
            try
            {
                var results = _context.SRoutesStages
                    .AsNoTracking();

                int totalCount = await results.CountAsync();

                var filteredData = String.IsNullOrWhiteSpace(request.Search.Value)
                    ? results
                    : results.Search(s =>s.StageName.ToLower()).Containing(request.Search.Value.ToLower());

                var filteredDataCount = String.IsNullOrWhiteSpace(request.Search.Value) ? totalCount : await filteredData.CountAsync();

                var dataPage = await filteredData
                    .Skip(request.Start)
                    .Take(request.Length)
                    .Select(x => new RoutesStageDto()
                    {
                        Id = x.Id,
                        Name = x.StageName,
                        StatusId = x.SServicesStatusId,
                        StatusName = x.SServicesStatusId.HasValue ? x.SServicesStatus.StatusName : null,
                        Days = x.DayExcution,
                        Commentt = x.Commentt,
                    }).ToListAsync();

                return (dataPage, totalCount, filteredDataCount);
            }
            catch
            {
                return (new List<RoutesStageDto>(), 0, 0);
            }
        }
        /// <summary>
        /// Получить список "Этапов"
        /// </summary>
        public async Task<List<RoutesStageModelDto>> GetRoutesStageAllAsync()
        {
            return await _context.SRoutesStages
                .AsNoTracking()
                .Select(s => new RoutesStageModelDto
                {
                    Id = s.Id,
                    StageName = s.StageName,
                    DayExcution = s.DayExcution,
                    Commentt = s.Commentt,
                    SServicesStatusId = s.SServicesStatusId
                }).ToListAsync();
        }

        /// <summary>
        /// Модель для редактирования Этапов
        /// </summary>
        public async Task<RoutesStageModelDto?> GetRoutesStageDtoAsync(int? Id)
        {
            if (Id is null)
                throw new ArgumentNullException(nameof(Id));

            var result = await _context.SRoutesStages.FindAsync(Id) ?? throw new InvalidOperationException("Данные не найдены!");

            return _mapper.Map<RoutesStageModelDto>(result);
        }

        public async Task AddRoutesStageAsync(RoutesStageModelDto model)
        {
            var entity = _mapper.Map<SRoutesStage>(model);

            var Id = await _context.SRoutesStages.Select(s => s.Id).OrderByDescending(o => o).FirstOrDefaultAsync();

            entity.Id = ++Id;

            await _context.SRoutesStages.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRoutesStageAsync(RoutesStageModelDto model)
        {
            var entity = await _context.SRoutesStages.FindAsync(model.Id) ?? throw new InvalidOperationException("Данные не найдены!");
            _mapper.Map<RoutesStageModelDto, SRoutesStage>(model, entity);

            await _context.SaveChangesAsync();
        }


        public async Task<List<ServicesStatusDto>> GetStatusesAllAsync()
        {
            return await _context.SServicesStatuses
              .AsNoTracking()
              .OrderBy(x => x.Id)
              .Select(x => new ServicesStatusDto
              {
                  Id = x.Id,
                  StatusName = x.StatusName,
                  IsDatefact = x.IsDatefact
              })
              .ToListAsync();
        }
    }
}
