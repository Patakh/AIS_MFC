using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.References;
using AisLogistics.App.ViewModels.ModelBuilder;
using AisLogistics.DataLayer.Common.Dto.Reference;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Controllers.Reference
{
    // Получатели услуг
    public partial class ReferenceController
    {
        public async Task<IActionResult> ServiceCustomers(Guid id)
        {
            var serviceNameSmall = await _referencesService.GetServiceAnyAsync(id);
            if (serviceNameSmall is false) return NotFound();
            ViewData["Id"] = id;

            var modelBuilder = new ViewModelBuilder()
                .AddViewDescription("Получатели")
                .SetElementName(nameof(ServiceCustomers))
                .AddTableMethodAction(Url.Action(nameof(GetServiceCustomersDataJson), new { id = id }))
                .AddEditMethodAction(Url.Action(nameof(ServiceCustomerChangeModal)))
                .AddRemoveMethodAction(Url.Action(nameof(ServiceCustomerRemove)));

            return PartialView("Services/Details/Customers", modelBuilder);
        }

        public async Task<IActionResult> GetServiceCustomersDataJson(IDataTablesRequest request, Guid id)
        {
            (var responseData, int totalCount, int filteredCount) = await _referencesService.GetServiceCustomers(request, id);

            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult> ServiceCustomerChangeModal(Guid? id, Guid serviceId, ActionType actionType)
        {
            var customerTypes = _referencesService.GetServiceCustomerTypes(x => x.IdParent == 0);
            //исключить уже добавленных
            var added = await _referencesService.GetAllServiceCustomersAsync(serviceId);
            if (id is null)
            {
                // добавление
                customerTypes.RemoveAll(x => added.Where(x => x.SServicesId == serviceId).Select(o => o.SServicesCustomerTypeId).ToArray().Contains(x.Id));
            }
            else
            {
                // измениние
                customerTypes.RemoveAll(x => added.Where(x => x.Id != id && x.SServicesId == serviceId).Select(o => o.SServicesCustomerTypeId).ToArray().Contains(x.Id));
            }
            // ***************************************************
            ViewBag.СustomerTypes = new SelectList(customerTypes, nameof(ServiceCustomerTypeDto.Id), nameof(ServiceCustomerTypeDto.TypeName));

            var model = new ModalViewModelBuilder()
                .AddModel(actionType == ActionType.Add ? new ServiceCustomerModelDto() { SServicesId = serviceId } : await _referencesService.GetServiceCustomerDtoAsync(id))
                .AddModalTitle((actionType == ActionType.Add ? "Добавление" : "Изменение") + " получателя")
                .AddModalViewPath("~/Views/Reference/Services/Details/Modals/_ModalChangeServiceCustomer.cshtml")
                .AddActionType(actionType)
                .AddModalType(ModalType.LARGE);
            return ModalLayoutView(model);
        }

        [HttpPost]
        public async Task ServiceCustomerRemove(Guid id, string comment)
        {
            try
            {
                await _referencesService.RemoveServiceCustomerAsync(id, comment);

                ShowSuccess(MessageDescription.RemoveSuccess);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task ServiceCustomerSaveAsync(ServiceCustomerModelDto input, ActionType actionType)
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
                    await _referencesService.AddServiceCustomerAsync(input);

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
                    await _referencesService.UpdateServiceCustomerAsync(input);
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
