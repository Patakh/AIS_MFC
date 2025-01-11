using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.References;
using AisLogistics.App.ViewModels.ModelBuilder;
using AisLogistics.DataLayer.Common.Dto.Reference;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Controllers.Reference
{
    //Активность
    public partial class ReferenceController
    {
        public async Task<IActionResult> ServiceActivities(Guid id)
        {
            var serviceNameSmall = await _referencesService.GetServiceAnyAsync(id);
            if (serviceNameSmall is false) return NotFound();
            ViewData["Id"] = id;

            var modelBuilder = new ViewModelBuilder()
                .AddViewDescription("Активность")
                .SetElementName(nameof(ServiceActivities))
                .AddTableMethodAction(Url.Action(nameof(GetServiceAcyivitiesOfficesDataJson), new { id = id }))
                .AddEditMethodAction(Url.Action(nameof(ServiceActivityChangeModal)))
                .AddRemoveMethodAction(Url.Action(nameof(ServiceActivityRemove)));

            return PartialView("Services/Details/Activities", modelBuilder);
        }

        public async Task<IActionResult> GetServiceAcyivitiesOfficesDataJson(IDataTablesRequest request, Guid id)
        {
            (var responseData, int totalCount, int filteredCount) = await _referencesService.GetServiceActivitiesOfficesAsync(request, id);

            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult> GetServiceAcyivitiesDataJson(IDataTablesRequest request, Guid id, Guid officeId)
        {
            (var responseData, int totalCount, int filteredCount) = await _referencesService.GetServiceActivitiesAsync(request, id, officeId);

            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult> ServiceActivityChangeModal(Guid serviceId, ActionType actionType)
        {
            var offices = await _filterManager.GetOfficesReceptionAllCustomerDataJson(true, true);

            ViewBag.Offices = new SelectList(offices, nameof(OfficeDto.Id), nameof(OfficeDto.OfficeName));

            var model = new ModalViewModelBuilder()
                .AddModel(new ServiceActivityModelDto { SServicesId = serviceId })
                .AddModalTitle("Добавление активности услуги")
                .AddModalViewPath("~/Views/Reference/Services/Details/Modals/_ModalChangeServiceActivity.cshtml")
                .AddActionType(actionType)
                .AddModalType(ModalType.LARGE);
            return ModalLayoutView(model);
        }

        [HttpPost]
        public async Task ServiceActivityRemove(Guid id, bool isRemove, string comment)
        {
            try
            {
                await _referencesService.RemoveServiceActivityAsync(id, isRemove, comment);

                ShowSuccess(isRemove ? MessageDescription.RemoveSuccess : MessageDescription.CloseSuccess);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }


        [HttpPost]
        public async Task ServiceActivityOfficesRemove(Guid serviceId, List<Guid> officesId, string comment)
        {
            try
            {
                await _referencesService.RemoveServiceActivityAsync(serviceId, officesId, comment);

                ShowSuccess(MessageDescription.RemoveSuccess);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task ServiceActivitySaveAsync(ServiceActivityModelDto input, ActionType actionType)
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

                input.SEmployeesIdAdd = (Guid)employeeId;
                input.EmployeesFioAdd = employeeName;

                try
                {
                    await _referencesService.AddServiceActivityAsync(input);

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
