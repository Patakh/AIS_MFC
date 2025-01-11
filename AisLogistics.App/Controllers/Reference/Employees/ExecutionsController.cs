using AisLogistics.App.Models;
using AisLogistics.App.ViewModels.ModelBuilder;
using AisLogistics.DataLayer.Common.Dto.Reference;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;

namespace AisLogistics.App.Controllers.Reference
{
    public partial class ReferenceController
    {
        public async Task<IActionResult> EmployeeExecutions(Guid id)
        {
            var emlpoyee = await _referencesService.GetEmployeeAnyAsync(id);
            if (emlpoyee is false) return NotFound();
            ViewData["Id"] = id;

            var modelBuilder = new ViewModelBuilder()
                .AddViewDescription("Исполнение")
                .SetElementName(nameof(EmployeeExecutions))
                .AddTableMethodAction(Url.Action(nameof(GetEmployeeExecutionsDataJson), new { id = id }))
                .AddEditMethodAction(Url.Action(nameof(EmployeeExecutionChangeModal)))
                .AddRemoveMethodAction(Url.Action(nameof(EmployeeExecutionRemove)));
            return PartialView("Employees/Details/Executions", modelBuilder);
        }

        public async Task<IActionResult> GetEmployeeExecutionsDataJson(IDataTablesRequest request, Guid id)
        {
            (var responseData, int totalCount, int filteredCount) = await _referencesService.GetEmployeeExecutions(request, id);

            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult> EmployeeExecutionChangeModal(Guid id, Guid employeeId, ActionType actionType)
        {
            var model = new ModalViewModelBuilder()
                .AddModel(actionType == ActionType.Add ? new EmployeeExecutionModelDto() { SEmployeesId = employeeId } : await _referencesService.GetEmployeeExectionDtoAsync(id))
                .AddModalTitle((actionType == ActionType.Add ? "Добавление" : "Изменение") + " исполнения сотрудника")
                .AddModalViewPath("~/Views/Reference/Employees/Details/Modals/_ModalChangeEmployeeExecution.cshtml")
                .AddActionType(actionType)
                .AddModalType(ModalType.LARGE);
            return ModalLayoutView(model);
        }

        [HttpPost]
        public async Task EmployeeExecutionRemove(Guid id, bool isRemove, string comment)
        {
            try
            {
                await _referencesService.RemoveEmployeeExecutionAsync(id, isRemove, comment);

                ShowSuccess(isRemove ? MessageDescription.RemoveSuccess : MessageDescription.CloseSuccess);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task EmployeeExecutionSaveAsync(EmployeeExecutionModelDto input, ActionType actionType)
        {
            // всегда добавить
            if (actionType == ActionType.Add)
            {
                var employeeId = await _employeeManager.GetIdAsync();

                if (employeeId is null)
                {
                    ShowError(MessageDescription.Error);
                    return;
                }

                var employeeName = await _employeeManager.GetNameAsync();
                input.EmployeesFioAdd = employeeName;

                try
                {
                    await _referencesService.AddEmployeeExecutionAsync(input);

                    ShowSuccess(MessageDescription.AddSuccess);
                }
                catch (Exception ex)
                {
                    ShowError(ex.Message);
                }
            }
        }
    }
}
