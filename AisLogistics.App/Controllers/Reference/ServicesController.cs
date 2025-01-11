using AisLogistics.App.Models;
using AisLogistics.App.ViewModels.ModelBuilder;
using AisLogistics.DataLayer.Common.Dto.Reference;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmartBreadcrumbs.Attributes;

namespace AisLogistics.App.Controllers.Reference
{
    public partial class ReferenceController
    {
        [Breadcrumb("Услуги", FromAction = nameof(Index), FromController = typeof(ReferenceController))]
        public async Task<IActionResult> Services()
        {
            var providers = await _filterManager.GetProvidersDataJson();
            ViewBag.OfficesProviders = string.Join("", providers.Select(x => $"<option value=\"{x.Id}\">{x.OfficeName}</option>"));

            var modelBuilder = new ViewModelBuilder()
                .AddViewTitle("Услуги").SetInvisibleViewTitle()
                .AddViewDescription("Справочник услуг")
                .AddTableMethodAction(Url.Action(nameof(GetServicesDataJson)))
                .AddEditMethodAction(Url.Action(nameof(ServiceChangeModal)))
                .AddRemoveMethodAction(Url.Action(nameof(ServiceRemove)));
            return View("Services/Index", modelBuilder);
        }

        public async Task<IActionResult> GetServicesDataJson(IDataTablesRequest request, Guid officeId, string search)
        {
            (var responseData, int totalCount, int filteredCount) = await _referencesService.GetServices(request, officeId, search);

            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult> ServiceChangeModal(Guid? id, ActionType actionType)
        {
            var type = await _referencesService.GetServiceTypesAll();
            var interaction = await _referencesService.GetServiceInteractionsAll();
            var catalog = await _referencesService.GetServiceLivingSituationAll();
            var hasgtag = await _referencesService.GetServiceHashtagAll();
            var offices = await _filterManager.GetProvidersDataJson();

            ViewBag.ServiceType = new SelectList(type, "Id", "Name");
            ViewBag.ServicesInteraction = new SelectList(interaction, "Id", "Name");
            ViewBag.Catalog = new SelectList(catalog, "Id", "Name");
            ViewBag.Hashtag = new SelectList(hasgtag, "Name", "Name");
            ViewBag.Offices = new SelectList(offices, "Id", "OfficeName");

            var model = new ModalViewModelBuilder()
                .AddModel(actionType == ActionType.Add ? new ServiceModelDto() : await _referencesService.GetServiceDtoAsync(id))
                .AddModalTitle((actionType == ActionType.Add ? "Добавление" : "Изменение") + " услуги")
                .AddModalViewPath("~/Views/Reference/Services/_ModalChangeService.cshtml")
                .AddActionType(actionType)
                .AddModalType(ModalType.LARGE);
            return ModalLayoutView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task ServiceSaveAsync(ServiceModelDto input, ActionType actionType)
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

                try
                {
                    await _referencesService.AddServiceAsync(input);

                    ShowSuccess(MessageDescription.AddSuccess);
                }
                catch (Exception ex)
                {
                    ShowError(MessageDescription.Error);
                }
            }
            else
            {
                try
                {
                    await _referencesService.UpdateServiceAsync(input);
                    ShowSuccess(MessageDescription.EditSuccess);
                }
                catch (Exception ex)
                {
                    ShowError(MessageDescription.Error);
                }
            }
        }

        [HttpPost]
        public async Task ServiceRemove(Guid id, string comment)
        {
            try
            {
                await _referencesService.RemoveServiceAsync(id, comment);

                ShowSuccess(MessageDescription.RemoveSuccess);
            }
            catch (Exception ex)
            {
                ShowError(MessageDescription.Error);
            }
        }

        [HttpPost]
        public async Task ServiceСopy(Guid id)
        {
            try
            {
                var employee = await _employeeManager.GetNameAsync();
                await _referencesService.CopyServiceAsync(id, employee);

                ShowSuccess(MessageDescription.CopySuccess);
            }
            catch (Exception ex)
            {
                ShowError(MessageDescription.Error);
            }
        }

        public async Task<IActionResult> ServiceDetails(Guid id)
        {
            var service = await _referencesService.GetServiceDtoAsync(id);
            if (service is null) return NotFound();
            //ViewData["Title"] = service.ServiceNameSmall.Length > 330 ? service.ServiceNameSmall[..330] + "..." : service.ServiceNameSmall;

            var modelBuilder = new ViewModelBuilder()
                .AddViewTitle(service.ServiceNameSmall).SetInvisibleViewTitle()
                .AddViewDescription("Общая информация")
                .AddEditMethodAction(Url.Action(nameof(ServiceChangeModal)))
                .AddModel(service);

            return PartialView("Services/Details/Index", modelBuilder);
        }

        [HttpGet]
        public async Task<IActionResult> GetOfficeTypeDataJson(int? type)
        {
            var offices = await _referencesService.GetAllOfficesTypeAsync(type);
            return Json(offices);
        }
    }
}
