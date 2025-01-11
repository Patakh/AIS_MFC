using AisLogistics.App.Models.DTO.References;
using AisLogistics.DataLayer.Common.Dto.Reference;
using AisLogistics.DataLayer.Entities.Models;
using DataTables.AspNet.Core;
using Microsoft.EntityFrameworkCore;

namespace AisLogistics.App.Service
{
    /// <summary>
    /// Справочники - Сотрудники - История
    /// </summary>
    public partial class ReferencesService : IReferencesService
    {
        /// <summary>
        /// Получить должности и офисы сотрудника
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="id">Id сотрудника</param>
        public async Task<(List<EmployeeHistoryDto>, int, int)> GetEmployeeHistory(IDataTablesRequest request, Guid id)
        {
            var results = _context.SEmployeesAuthorizationLogs
                .AsNoTracking()
                .Where(x => x.SEmployeesId == id);

            int totalCount = await results.CountAsync();

            var dataPage = await results
                .OrderByDescending(x => x.LogInDate)
                .Skip(request.Start)
                .Take(request.Length)
                .Select(x => new EmployeeHistoryDto()
                {
                    Id = x.Id,
                    SEmployeesId = x.SEmployeesId,
                    SOfficeId = x.SOfficesId,
                    OfficeName = x.SOffices.OfficeNameSmall,
                    LogInDate = x.LogInDate.ToString("dd.MM.yyyy"),
                    LogInIp = x.LogInIp,
                }).ToListAsync();

            return (dataPage, totalCount, totalCount);
        }
    }
}
