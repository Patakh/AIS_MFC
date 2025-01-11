using AisLogistics.App.Models.DTO.References;
using AisLogistics.DataLayer.Common.Dto.Reference;
using AisLogistics.DataLayer.Entities.Models;
using DataTables.AspNet.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AisLogistics.App.Service
{
    // Справочники - Услуги - Стадии
    public partial class ReferencesService : IReferencesService
    {
        /// <summary>
        /// Получить список этапов услуги
        /// </summary>
        /// <param name="request">Параметры запроса</param>
        /// <param name="serviceId">ID услуги</param>
        /// <param name="parentId">ID родителя</param>
        public async Task<(List<ServicesRoutesStageDto>, int, int)> GetServiceStages(IDataTablesRequest request, Guid serviceId, Guid parentId)
        {
            try
            {
                var results = _context.SServicesRoutesStages
                    .AsNoTracking()
                    .AsSplitQuery()//A command is already in progress
                    .Where(x => !x.IsRemove && x.SServices.Id == serviceId && x.ParentId == parentId)
                    ;

                int totalCount = await results.CountAsync();

                var filteredResult = string.IsNullOrEmpty(request?.Search.Value)
                    ? results
                    : results.Where(x => x.SRoutesStage.StageName.Contains(request.Search.Value, StringComparison.OrdinalIgnoreCase));

                int filteredCount = string.IsNullOrEmpty(request?.Search.Value) ? totalCount : await filteredResult.CountAsync();

                //int start = request?.Start > 0 ? request.Start : 0;
                //int take = request?.Length > 0 ? request.Length : filteredCount;

                var dataPage = await filteredResult
                    .OrderBy(x => x.DateAdd)
                    //.Skip(request.Start)
                    //.Take(request.Length)
                    .Select(x => new ServicesRoutesStageDto()
                    {
                        Id = x.Id,
                        SServicesId = x.SServicesId,
                        ParentId = x.ParentId,
                        Commentt = x.Commentt,
                        StageName = x.SRoutesStage.StageName,
                        //RoutesStageRoles = x.SServicesRoutesStageRoles.Where(r => !r.IsRemove).Select(r => new ServicesRoutesStageRoleDto()
                        //{
                        //    Id = r.Id,
                        //    RoleName = r.SRolesExecutor.RoleName,
                        //    SServicesRoutesStageId = r.SServicesRoutesStageId
                        //})
                        //.OrderBy(o => o.RoleName)
                        //.ToList(),
                        //HasChildren = _context.SServicesRoutesStages.Any(a => !a.IsRemove && a.ParentId == x.Id)
                    }).ToListAsync();

                return (dataPage, totalCount, filteredCount);
            }
            catch(Exception e)
            {
                return (new List<ServicesRoutesStageDto>(),0,0);
            } 
        }

        public async Task<(List<ServicesRoutesStageRoleDto>, int, int)> GetServiceStageRoles(IDataTablesRequest request, Guid id)
        {
            try
            {
                var results = _context.SServicesRoutesStageRoles
                    .AsNoTracking()
                    .AsSplitQuery()
                    .Where(x => !x.IsRemove && x.SServicesRoutesStageId == id);

                int totalCount = await results.CountAsync();

                var filteredResult = string.IsNullOrEmpty(request?.Search.Value)
                    ? results
                    : results.Where(x => x.SRolesExecutor.RoleName.Contains(request.Search.Value, StringComparison.OrdinalIgnoreCase));

                int filteredCount = string.IsNullOrEmpty(request?.Search.Value) ? totalCount : await filteredResult.CountAsync();

                var dataPage = await filteredResult
                    .Select(x => new ServicesRoutesStageRoleDto()
                    {
                        Id = x.Id,
                        RoleName = x.SRolesExecutor.RoleName,
                        SServicesRoutesStageId = x.SServicesRoutesStageId
                    }).OrderBy(o=>o.RoleName).ToListAsync();

                return (dataPage, totalCount, filteredCount);
            }
            catch (Exception e)
            {
                return (new List<ServicesRoutesStageRoleDto>(), 0, 0);
            }
        }

        /// <summary>
        /// Получить список этапов услуги
        /// </summary>
        /// <param name="serviceId">ID услуги</param>
        /// <param name="parentId">ID родителя</param>
        public async Task<List<ServicesRoutesStageDto>> GetServiceStagesAsync(Guid serviceId, Guid parentId)
        {
            //TODO ID родителя не нужно
            return await _context.SServicesRoutesStages
                .AsNoTracking()
                .Where(x => !x.IsRemove && x.SServices.Id == serviceId && x.ParentId == parentId)
                .Select(x => new ServicesRoutesStageDto()
                {
                    Id = x.Id,
                    SServicesId = serviceId,
                    ParentId = parentId,
                    SRoutesStageId = x.SRoutesStageId
                })
                .ToListAsync(); ;
        }

        /// <summary>
        /// Модель для добавления / редактирования этапа услуги
        /// </summary>
        public async Task<ServiceStageModelDto> GetServiceStageDtoAsync(Guid? Id)
        {
            if (Id is null)
                throw new ArgumentNullException(nameof(Id));

            var result = await _context.SServicesRoutesStages.FindAsync(Id);
            if (result == null)
                throw new InvalidOperationException("Данные не найдены!");

            return _mapper.Map<ServiceStageModelDto>(result);
        }

        /// <summary>
        /// Добавить этап услуги
        /// </summary>
        public async Task AddServiceStageAsync(ServiceStageModelDto model)
        {
            var entity = _mapper.Map<SServicesRoutesStage>(model);

            if (model.ParentId != Guid.Empty)
            {
                var isParent = await _context.SServicesRoutesStages.AnyAsync(a => a.SServicesId == model.SServicesId && a.SRoutesStageId == model.SRoutesStageId && a.ParentId == Guid.Empty && !a.IsRemove);
                if (!isParent)
                {
                    var entityParent = _mapper.Map<SServicesRoutesStage>(model);
                    entityParent.ParentId = Guid.Empty;
                    await _context.SServicesRoutesStages.AddAsync(entityParent);

                }
            }
            await _context.SServicesRoutesStages.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Обновить этап услуги
        /// </summary>
        public async Task UpdateServiceStageAsync(ServiceStageModelDto model)
        {
            var entity = await _context.SServicesRoutesStages.FindAsync(model.Id);
            if (entity == null)
                throw new InvalidOperationException("Данные не найдены!");

            _mapper.Map<ServiceStageModelDto, SServicesRoutesStage>(model, entity);

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Пометить на удаление этап услуги
        /// </summary>
        /// <param name="Id">Id записи об этапе услуги</param>
        /// <param name="comment">Причина удаления</param>
        public async Task RemoveServiceStageAsync(Guid Id, string comment)
        {
            var entity = await _context.SServicesRoutesStages.FindAsync(Id);
            if (entity == null)
                throw new InvalidOperationException("Запись не найдена!");
            if (entity.SRoutesStageId == 1)
                throw new InvalidOperationException("Этап Принято нельзя удалить");

            entity.IsRemove = true;

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Получить все роли исполнителя этапа
        /// </summary>
        /// <param name="Id">ID этапа</param>
        public async Task<List<RoleExecutorDto>> GetServiceStageRolesAsync(Guid Id)
        {
            return await _context.SServicesRoutesStageRoles
                .AsNoTracking()
                .Where(x => !x.IsRemove && x.SServicesRoutesStageId == Id)
                .Select(x => new RoleExecutorDto()
                {
                    Id = x.SRolesExecutorId,
                    RoleName = x.SRolesExecutor.RoleName
                })
                .ToListAsync();
        }

        /// <summary>
        /// Добавить роль исполнителя к этапу услуги
        /// </summary>
        public async Task AddServiceStageRoleAsync(ServicesStageRoleModelDto model)
        {
            var entity = _mapper.Map<SServicesRoutesStageRole>(model);

            await _context.SServicesRoutesStageRoles.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Пометить на удаление роль исполнителя этапа услуги
        /// </summary>
        /// <param name="Id">Id роли</param>
        /// <param name="comment">Причина удаления</param>
        public async Task RemoveServiceStageRoleAsync(Guid Id, string comment)
        {
            var entity = await _context.SServicesRoutesStageRoles.FindAsync(Id);
            if (entity == null)
                throw new InvalidOperationException("Запись не найдена!");

            entity.IsRemove = true;

            await _context.SaveChangesAsync();
        }
    }
}
