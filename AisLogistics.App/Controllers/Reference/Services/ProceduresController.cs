using AisLogistics.App.Models;
using AisLogistics.App.ViewModels.ModelBuilder;
using AisLogistics.DataLayer.Common.Dto.Reference;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;

namespace AisLogistics.App.Controllers.Reference
{
    // Процедуры
    public partial class ReferenceController
    {
        public async Task<IActionResult> ServiceProcedures(Guid id)
        {
            var serviceNameSmall = await _referencesService.GetServiceAnyAsync(id);
            if (serviceNameSmall is false) return NotFound();
            ViewData["Id"] = id;

            var modelBuilder = new ViewModelBuilder()
                .AddViewDescription("Процедуры")
                .SetElementName(nameof(ServiceProcedures))
                .AddTableMethodAction(Url.Action(nameof(GetServiceProceduresDataJson), new { id = id }))
                .AddEditMethodAction(Url.Action(nameof(ServiceProcedureChangeModal)))
                .AddRemoveMethodAction(Url.Action(nameof(ServiceProcedureRemove)));

            return PartialView("Services/Details/Procedures", modelBuilder);
        }

        public async Task<IActionResult> GetServiceProceduresDataJson(IDataTablesRequest request, Guid id)
        {

            (var responseData, int totalCount, int filteredCount) = await _referencesService.GetServiceProceduresAsync(request, id);
            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult> ServiceProcedureChangeModal(Guid? id, Guid serviceId, ActionType actionType)
        {
            var model = new ModalViewModelBuilder()
                .AddModel(actionType == ActionType.Add ? new ServiceProcedureModelDto() { SServicesId = serviceId } : await _referencesService.GetServiceProcedureDtoAsync(id))
                .AddModalTitle((actionType == ActionType.Add ? "Добавление" : "Изменение") + " процедуры")
                .AddModalViewPath("~/Views/Reference/Services/Details/Modals/_ModalChangeServiceProcedure.cshtml")
                .AddActionType(actionType)
                .AddModalType(ModalType.LARGE);
            return ModalLayoutView(model);
        }

        [HttpPost]
        public async Task ServiceProcedureRemove(Guid id, string comment)
        {
            try
            {
                await _referencesService.RemoveServiceProcedureAsync(id, comment);

                ShowSuccess(MessageDescription.RemoveSuccess);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task ServiceProcedureSaveAsync(ServiceProcedureModelDto input, ActionType actionType)
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
                input.EmployeesFioAdd = employeeName;

                try
                {
                    await _referencesService.AddServiceProcedureAsync(input);

                    ShowSuccess(MessageDescription.AddSuccess);
                }
                catch (Exception ex)
                {
                    ShowError(ex.Message);
                }
            }
            else
            {
                try
                {
                    await _referencesService.UpdateServiceProcedureAsync(input);
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
