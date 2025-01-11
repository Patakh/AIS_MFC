using AisLogistics.App.Models.DTO.References;
using AisLogistics.DataLayer.Common.Dto.Reference;
using AisLogistics.DataLayer.Entities.Models;
using DataTables.AspNet.Core;
using Microsoft.EntityFrameworkCore;
using NinjaNye.SearchExtensions;

namespace AisLogistics.App.Service
{
    // Справочники - Роли исполнителя

    public partial class ReferencesService : IReferencesService
    {
        /// <summary>
        /// Поучить список ролей исполнителя
        /// </summary>
        /// <param name="request">Запрос</param>
        public async Task<(List<RoleExecutorDto>, int, int)> GetRolesExecutor(IDataTablesRequest request)
        {
            var results = _context.SRolesExecutors
                .AsNoTracking()
                .Where(w => !w.IsRemove);


            int totalCount = await results.CountAsync();

            var filteredResult = string.IsNullOrEmpty(request.Search.Value)
               ? results
               : results.Search(s => s.RoleName.ToLower()).Containing(request.Search.Value.ToLower());

            int filteredCount = string.IsNullOrEmpty(request.Search.Value) ? totalCount : await filteredResult.CountAsync();

            var dataPage = await filteredResult
                .OrderBy(x => x.RoleName)
                .Skip(request.Start)
                .Take(request.Length)
                .Select(x => new RoleExecutorDto()
                {
                    Id = x.Id,
                    RoleName = x.RoleName,
                    Description = x.Description,
                    EmployeesFioAdd = x.EmployeesFioAdd,
                    DateAdd = x.DateAdd.ToString("dd.MM.yyyy HH:mm:ss"),
                    IsRemove = x.IsRemove
                }).ToListAsync();


            return (dataPage, totalCount, filteredCount);
        }

        /// <summary>
        /// Модель для добавления / редактирования роли исполнителя
        /// </summary>
        public async Task<RoleExecutorModelDto> GetRolesExecutorModelDtoAsync(Guid? Id)
        {
            if (Id is null)
                throw new ArgumentNullException(nameof(Id));

            var result = await _context.SRolesExecutors.FindAsync(Id);
            if (result == null)
                throw new Exception("Данные не найдены!");

            return _mapper.Map<RoleExecutorModelDto>(result);
        }

        /// <summary>
        /// Пометить на удаление роль исполнителя
        /// </summary>
        /// <param name="Id">ID роли</param>
        /// <param name="comment">Причина удаления</param>
        public async Task RemoveRolesExecutorAsync(Guid Id, string comment)
        {
            var entity = await _context.SRolesExecutors.FindAsync(Id);
            if (entity == null)
                throw new Exception("Запись не найдена!");

            entity.IsRemove = true;
            //roleExecutor.Description = comment;

            await _context.SaveChangesAsync();
        }

        public async Task AddRoleExecutorAsync(RoleExecutorModelDto model)
        {
            var entity = _mapper.Map<SRolesExecutor>(model);

            await _context.SRolesExecutors.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRoleExecutorAsync(RoleExecutorModelDto model)
        {
            var entity = await _context.SRolesExecutors.FindAsync(model.Id);
            if (entity == null)
                throw new Exception("Данные не найдены!");

            // т.к. эти поля добавляются только при добавлении
            model.EmployeesFioAdd = entity.EmployeesFioAdd;
            model.DateAdd = entity.DateAdd;

            _mapper.Map<RoleExecutorModelDto, SRolesExecutor>(model, entity);

            await _context.SaveChangesAsync();
        }
    }
}
