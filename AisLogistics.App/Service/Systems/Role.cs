using AisLogistics.App.Models.DTO.Systems;
using DataTables.AspNet.Core;
using Microsoft.EntityFrameworkCore;

namespace AisLogistics.App.Service.Systems
{
    public partial class SystemsService
    {
        public async Task<(List<RoleDto>, int, int)> GetRoles(IDataTablesRequest request)
        {
            try
            {
                var allData = _context.AspNetRoles;
                var allDataCount = await _context.AspNetRoles.CountAsync();

                var filteredData = String.IsNullOrWhiteSpace(request.Search.Value)
                    ? allData
                    : allData.Where(w =>
                        w.Name.Contains(request.Search.Value) && w.Description.Contains(request.Search.Value));

                var filteredDataCount = String.IsNullOrWhiteSpace(request.Search.Value) ? allDataCount : await filteredData.CountAsync();

                var dataPage = await filteredData.OrderBy(o => o.Name).Skip(request.Start).Take(request.Length)
                    .Select(s => new RoleDto
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Employees = s.Users.Count
                    }).ToListAsync();

                return (dataPage, allDataCount, allDataCount);
            }
            catch
            {
                return (new List<RoleDto>(), 0, 0);
            }
        }
    }
}
