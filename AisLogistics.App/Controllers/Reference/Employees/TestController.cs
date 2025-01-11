using AisLogistics.App.Models.DTO.References;
using AisLogistics.App.ViewModels.ModelBuilder;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;

namespace AisLogistics.App.Controllers.Reference
{
    public partial class ReferenceController
    {
        public async Task<IActionResult> EmployeeTest(Guid id)
        {
           
            var emlpoyee = await _referencesService.GetEmployeeAnyAsync(id);
            if (emlpoyee is false) return NotFound();
            var employeeId = await _employeeManager.GetIdAsync();
            ViewData["Id"] = id;
            ViewData["isThisEmployees"] = employeeId == id;

            var modelBuilder = new ViewModelBuilder()
                .AddViewTitle("Тестирование").SetInvisibleViewTitle()
                .AddViewDescription("Тестирование")
                .SetElementName(nameof(EmployeeTest))
                .AddTableMethodAction(Url.Action(nameof(GetEmployeeTestDataJson), new { id = id }));
            return PartialView("Employees/Details/Test", modelBuilder);
        }

        public async Task<IActionResult> GetEmployeeTestDataJson(IDataTablesRequest request, Guid id)
        {
            (var responseData, int totalCount, int filteredCount) = await _referencesService.GetEmployeeTest(request, id);

            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult> EmployeeTestStartView(Guid id)
        {
            var model = await _referencesService.GetEmployeeTestStart(id);
            return View("Employees/Details/Partials/_StartTest", model);
        }

        public async Task<IActionResult> EmployeeTestQuestionView(Guid id)
        {
            var model = await _referencesService.GetEmployeeTestQuestion(id);
            return PartialView("Employees/Details/Partials/_QuestionTest", model);
        }

        public async Task<IActionResult> EmployeeTestAnswersSave(EmployeesTestAnswerDto request)
        {
            try
            {
                await _referencesService.EmployeeTestAnswersSave(request);
                return await EmployeeTestQuestionView(request.EmployeeTestId);
            }
            catch (Exception ex)
            {
                return Problem();
            }

        }
    }
}
