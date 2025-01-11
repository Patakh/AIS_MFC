using AisLogistics.App.Models;
using AisLogistics.App.ViewModels.ModelBuilder;
using AisLogistics.DataLayer.Common.Dto.Reference;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;

namespace AisLogistics.App.Controllers.Reference
{
    public partial class ReferenceController
    {
        public async Task<IActionResult> EmployeeActivities(Guid id)
        {
            var emlpoyee = await _referencesService.GetEmployeeAnyAsync(id);
            if (emlpoyee is false) return NotFound();
            ViewData["Id"] = id;

            var modelBuilder = new ViewModelBuilder()
                .AddViewDescription("Активность")
                .SetElementName(nameof(EmployeeActivities))
                .AddTableMethodAction(Url.Action(nameof(GetEmployeeActivitiesDataJson), new { id = id }))
                .AddEditMethodAction(Url.Action(nameof(EmployeeActivityChangeModal)))
                .AddRemoveMethodAction(Url.Action(nameof(EmployeeActivityRemove)));
            return PartialView("Employees/Details/Activities", modelBuilder);
        }

        public async Task<IActionResult> GetEmployeeActivitiesDataJson(IDataTablesRequest request, Guid id)
        {
            (var responseData, int totalCount, int filteredCount) = await _referencesService.GetEmployeeActivities(request, id);

            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult> EmployeeActivityChangeModal(Guid id, Guid employeeId, ActionType actionType)
        {
            var model = new ModalViewModelBuilder()
                .AddModel(actionType == ActionType.Add ? new EmployeeActivityModelDto() { SEmployeesId = employeeId } : await _referencesService.GetEmployeeActivityDtoAsync(id))
                .AddModalTitle((actionType == ActionType.Add ? "Добавление" : "Изменение") + " активности сотрудника")
                .AddModalViewPath("~/Views/Reference/Employees/Details/Modals/_ModalChangeEmployeeActivity.cshtml")
                .AddActionType(actionType)
                .AddModalType(ModalType.LARGE);
            return ModalLayoutView(model);

        }

        [HttpPost]
        public async Task EmployeeActivityRemove(Guid id, bool isRemove, string comment)
        {
            try
            {
                await _referencesService.RemoveEmployeeActivityAsync(id, isRemove, comment);

                ShowSuccess(isRemove ? MessageDescription.RemoveSuccess : MessageDescription.CloseSuccess);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task EmployeeActivitySaveAsync(EmployeeActivityModelDto input, ActionType actionType)
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
                    await _referencesService.AddEmployeeActivityAsync(input);

                    ShowSuccess(MessageDescription.AddSuccess);
                }
                catch (Exception ex)
                {
                    ShowError(ex.Message);
                }
            }
            //else
            //{

            //}
        }
    }
}
