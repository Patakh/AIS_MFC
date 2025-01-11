using AisLogistics.App.ViewModels.ModelBuilder;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;

namespace AisLogistics.App.Controllers.Reference
{
    public partial class ReferenceController
    {
        public async Task<IActionResult> EmployeeHistory(Guid id)
        {
            var emlpoyee = await _referencesService.GetEmployeeAnyAsync(id);
            if (emlpoyee is false) return NotFound();
            ViewData["Id"] = id;

            var modelBuilder = new ViewModelBuilder()
                .AddViewDescription("История")
                .SetElementName(nameof(EmployeeHistory))
                .AddTableMethodAction(Url.Action(nameof(GetEmployeeHistoryDataJson), new { id = id }));
            return PartialView("Employees/Details/History", modelBuilder);
        }

        public async Task<IActionResult> GetEmployeeHistoryDataJson(IDataTablesRequest request, Guid id)
        {
            (var responseData, int totalCount, int filteredCount) = await _referencesService.GetEmployeeHistory(request, id);

            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }
    }
}
