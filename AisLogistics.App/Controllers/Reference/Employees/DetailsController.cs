using AisLogistics.App.Models;
using AisLogistics.App.ViewModels.ModelBuilder;
using AisLogistics.DataLayer.Common.Dto.Reference;

namespace AisLogistics.App.Controllers.Reference
{
    public partial class ReferenceController
    {
        public async Task<IActionResult> EmployeeDetails(Guid id)
        {

            var emlpoyee = await _referencesService.GetEmployeeDtoAsync(id);
            if (emlpoyee is null) return NotFound();
            var employeeId = await _employeeManager.GetIdAsync();
            ViewData["isThisEmployees"] = employeeId == emlpoyee.Id;

            var modelBuilder = new ViewModelBuilder()
                .AddViewTitle(emlpoyee.EmployeeName).SetInvisibleViewTitle()
                .AddViewDescription("Общая информация")
                .AddEditMethodAction(Url.Action(nameof(EmployeeChangeModal)))
                .AddModel(emlpoyee);

            return PartialView("Employees/Details/Index", modelBuilder);
        }

        public async Task<IActionResult> EmployeeChangeModal(Guid? id, ActionType actionType)
        {
            var model = new ModalViewModelBuilder()
                .AddModel(actionType == ActionType.Add ? new EmployeeModelDto() : await _referencesService.GetEmployeeDtoAsync(id))
                .AddModalTitle((actionType == ActionType.Add ? "Добавление" : "Изменение") + " сотрудника")
                .AddModalViewPath("~/Views/Reference/Employees/_ModalChangeEmployee.cshtml")
                .AddActionType(actionType)
                .AddModalType(ModalType.LARGE);
            return ModalLayoutView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task EmployeeSaveAsync(EmployeeModelDto input, ActionType actionType)
        {
            if (actionType == ActionType.Add)
            {
                var employeeId = await _employeeManager.GetIdAsync();

                if (employeeId is null)
                {
                    ShowError(MessageDescription.Error);
                    return;
                }

                var employeeName = await _employeeManager.GetNameAsync();

                input.SEmployeesIdAdd = (Guid)employeeId;
                input.EmployeesFioAdd = employeeName;

                ShowSuccess(MessageDescription.AddSuccess);
            }
            else
            {
                try
                {
                    await _referencesService.UpdateEmployeeAsync(input);
                    ShowSuccess(MessageDescription.EditSuccess);
                }
                catch (Exception ex)
                {
                    ShowError(ex.Message);
                }
            }

        }
    }
}
