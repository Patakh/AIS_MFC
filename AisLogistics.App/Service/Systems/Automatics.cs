using AisLogistics.App.Models.DTO.Automatics;
using AisLogistics.App.ViewModels.Systems.Automatics;
using DataTables.AspNet.Core;
using Microsoft.EntityFrameworkCore;

namespace AisLogistics.App.Service.Systems
{
    public partial class SystemsService
    {
        public async Task<(List<AutomaticsDto>, int, int)> GetAutomaticsOperations(IDataTablesRequest request)
        {
            try
            {
                var allData = _context.SAutomaticOperations;
                var allDataCount = await allData.CountAsync();

                var dataPage = await allData.Skip(request.Start).Take(request.Length)
                     .Select(s => new AutomaticsDto
                     {
                         Id = s.Id,
                         OperationName = s.OperationName,
                         DateStart = s.DAutomaticLogs.OrderByDescending(o => o.DateStart).ThenByDescending(t => t.TimeStart).Select(s => s.DateStart.Add(s.TimeStart).ToShortDateString()).FirstOrDefault(),
                     }).OrderBy(o => o.Id).ToListAsync();

                return (dataPage, allDataCount, allDataCount);
            }
            catch
            {
                return (new List<AutomaticsDto>(), 0, 0);
            }
        }

        public async Task<(List<AutomaticsLogsDto>, int, int)> GetAutomaticsOperationLogs(IDataTablesRequest request, SearchAutomaticLogsRequestData requestData)
        {
            try
            {
                var allData = _context.DAutomaticLogs.Where(w => w.SAutomaticOperationId == requestData.AutomaticId);
                var allDataCount = await allData.CountAsync();

                var dataPage = await allData
                    .OrderByDescending(o => o.DateStart)
                    .ThenByDescending(t => t.TimeStart)
                    .Select(s => new AutomaticsLogsDto { Id = s.Id, DateStart = s.DateStart.Add(s.TimeStart).ToString() })
                    .Skip(request.Start).Take(request.Length)
                    .ToListAsync();

                return (dataPage, allDataCount, allDataCount);
            }
            catch
            {
                return (new List<AutomaticsLogsDto>(), 0, 0);
            }
        }
    }
}
