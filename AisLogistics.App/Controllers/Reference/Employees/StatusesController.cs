using AisLogistics.App.Models;
using AisLogistics.App.ViewModels.ModelBuilder;
using AisLogistics.DataLayer.Common.Dto.Reference;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Controllers.Reference
{
    public partial class ReferenceController
    {
        public async Task<IActionResult> EmployeeStatuses(Guid id)
        {
            var emlpoyee = await _referencesService.GetEmployeeAnyAsync(id);
            if (emlpoyee is false) return NotFound();
            ViewData["Id"] = id;

            var modelBuilder = new ViewModelBuilder()
                .AddViewDescription("Статус")
                .SetElementName(nameof(EmployeeStatuses))
                .AddTableMethodAction(Url.Action(nameof(GetEmployeeStatusesDataJson), new { id = id }))
                .AddEditMethodAction(Url.Action(nameof(EmployeeStatusChangeModal)))
                .AddRemoveMethodAction(Url.Action(nameof(EmployeeStatusRemove)));
            return PartialView("Employees/Details/Statuses", modelBuilder);
        }

        public async Task<IActionResult> GetEmployeeStatusesDataJson(IDataTablesRequest request, Guid id)
        {
            (var responseData, int totalCount, int filteredCount) = await _referencesService.GetEmployeeStatuses(request, id);

            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult> EmployeeStatusChangeModal(Guid? id, Guid employeeId, ActionType actionType)
        {
            var lastModified = await _referencesService.GetLastEmployeeStatusDtoAsync(employeeId);

            ViewBag.Statuses = new SelectList(await _referencesService.GetAllEmployeeStatusesAsync(), "Key", "Value", lastModified.SEmployeesStatusId);
            ViewBag.MaxDate = lastModified.DateStart;

            var model = new ModalViewModelBuilder()
                .AddModel(lastModified)
                .AddModalTitle("Добавление статуса сотрудника")
                .AddModalViewPath("~/Views/Reference/Employees/Details/Modals/_ModalChangeEmployeeStatus.cshtml")
                .AddActionType(actionType)
                .AddModalType(ModalType.LARGE);
            return ModalLayoutView(model);
        }

        [HttpPost]
        public async Task EmployeeStatusRemove(Guid id, bool isRemove, string comment)
        {
            try
            {
                await _referencesService.RemoveEmployeeStatusAsync(id, isRemove, comment);

                ShowSuccess(isRemove ? MessageDescription.RemoveSuccess : MessageDescription.CloseSuccess);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task EmployeeStatusSaveAsync(EmployeeStatusModelDto input, ActionType actionType)
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
                    await _referencesService.AddEmployeeStatusAsync(input);

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
