using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.References;
using AisLogistics.App.ViewModels.ModelBuilder;
using AisLogistics.DataLayer.Common.Dto.Reference;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Controllers.Reference
{
    public partial class ReferenceController
    {
        public async Task<IActionResult> EmployeeOffices(Guid id)
        {
            var emlpoyee = await _referencesService.GetEmployeeAnyAsync(id);
            if (emlpoyee is false) return NotFound();
            ViewData["Id"] = id;

            var modelBuilder = new ViewModelBuilder()
                .AddViewDescription("Офисы")
                .SetElementName(nameof(EmployeeOffices))
                .AddTableMethodAction(Url.Action(nameof(GetEmployeeOfficesDataJson), new { id = id }))
                .AddEditMethodAction(Url.Action(nameof(EmployeeOfficeChangeModal)))
                .AddRemoveMethodAction(Url.Action(nameof(EmployeeOfficeRemove)));
            return PartialView("Employees/Details/Offices", modelBuilder);
        }

        public async Task<IActionResult> GetEmployeeOfficesDataJson(IDataTablesRequest request, Guid id)
        {
            (var responseData, int totalCount, int filteredCount) = await _referencesService.GetEmployeeOffices(request, id);

            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult> EmployeeOfficeChangeModal(Guid employeeId, ActionType actionType)
        {
            var offices = await _filterManager.GetOfficesReceptionAllCustomerDataJson(true, true);

            ViewBag.Offices = new SelectList(offices, nameof(OfficeDto.Id), nameof(OfficeDto.OfficeName));

            var model = new ModalViewModelBuilder()
                .AddModel(new EmployeeOfficeModelDto() { SEmployeesId = employeeId })
                .AddModalTitle((actionType == ActionType.Add ? "Добавление" : "Изменение") + " Офисов Авторизации")
                .AddModalViewPath("~/Views/Reference/Employees/Details/Modals/_ModalChangeEmployeeOffices.cshtml")
                .AddActionType(actionType)
                .AddModalType(ModalType.LARGE);
            return await Task.Run(() => ModalLayoutView(model));
        }

        [HttpPost]
        public async Task EmployeeOfficeRemove(Guid id, bool isRemove, string comment)
        {
            try
            {
                await _referencesService.RemoveEmployeeOfficeAsync(id, isRemove, comment);

                ShowSuccess(isRemove ? MessageDescription.RemoveSuccess : MessageDescription.CloseSuccess);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task EmployeeOfficeSaveAsync(EmployeeOfficeModelDto input, ActionType actionType)
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
                    await _referencesService.AddEmployeeOfficesAsync(input);

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
