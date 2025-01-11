using AisLogistics.App.Models.DTO.References;
using AisLogistics.DataLayer.Common.Dto.Reference;
using AisLogistics.DataLayer.Entities.Models;
using DataTables.AspNet.Core;
using Microsoft.EntityFrameworkCore;

namespace AisLogistics.App.Service
{
    /// <summary>
    /// Справочники - Сотрудники - Роли исполнителя
    /// </summary>
    public partial class ReferencesService : IReferencesService
    {

        /// <summary>
        /// Получить роли исполнения сотрудника
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="id">Id сотрудника</param>
        public async Task<(List<EmployeeExecutorRoleDto>, int, int)> GetEmployeeExecutorRoles(IDataTablesRequest request, Guid id)
        {
            var results = _context.SEmployeesRolesExecutors
                .AsNoTracking()
                .Where(x => !x.IsRemove && x.SEmployeesId == id);

            int totalCount = await results.CountAsync();

            var dataPage = await results
                .Skip(request.Start)
                .Take(request.Length)
                .Select(x => new EmployeeExecutorRoleDto()
                {
                    Id = x.Id,
                    SEmployeesId = x.SEmployeesId,
                    SRolesExecutorId = x.SRolesExecutorId,
                    RoleName = x.SRolesExecutor.RoleName,
                    EmployeesFioAdd = x.EmployeesFioAdd,
                    DateAdd = x.DateAdd.ToString("dd.MM.yyyy")
                }).ToListAsync();

            return (dataPage, totalCount, totalCount);
        }

        /// <summary>
        /// Получить все роли исполнения сотрудника
        /// </summary>
        /// <param name="id">Id сотрудника</param>
        public async Task<List<EmployeeExecutorRoleDto>> GetAllEmployeeExecutorRolesAsync(Guid id)
        {
            var results = _context.SEmployeesRolesExecutors
                .AsNoTracking()
                .Where(x => !x.IsRemove && x.SEmployeesId == id);

            return await results
                .Select(x => new EmployeeExecutorRoleDto()
                {
                    Id = x.Id,
                    SEmployeesId = x.SEmployeesId,
                    SRolesExecutorId = x.SRolesExecutorId,
                    RoleName = x.SRolesExecutor.RoleName
                }).ToListAsync();
        }

        /// <summary>
        /// Пометить на удаление роль исполнителя сотрудника
        /// </summary>
        /// <param name="Id">ID роли</param>
        /// <param name="comment">Причина удаления</param>
        public async Task RemoveEmployeeExecutorRoleAsync(Guid Id, string comment)
        {
            var entity = await _context.SEmployeesRolesExecutors.FindAsync(Id);
            if (entity == null)
                throw new Exception("Запись не найдена!");

            entity.IsRemove = true;

            await _context.SaveChangesAsync();
        }

        public async Task AddEmployeeExecutorRoleAsync(EmployeeRoleExecutorModelDto model)
        {
            var entity = _mapper.Map<SEmployeesRolesExecutor>(model);

            await _context.SEmployeesRolesExecutors.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}
