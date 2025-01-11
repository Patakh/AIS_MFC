using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.References;
using AisLogistics.App.ViewModels.ModelBuilder;
using AisLogistics.DataLayer.Common.Dto.Reference;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sentry;
using SmartBreadcrumbs.Attributes;

namespace AisLogistics.App.Controllers.Reference
{
    // СМЭВ - Запросы
    public partial class ReferenceController
    {
        [Breadcrumb("СМЭВ", FromAction = nameof(Index), FromController = typeof(ReferenceController))]
        public async Task<IActionResult> SmevRequests()
        {
            var providers = await _referencesService.GetAllSmevServicesAsync();
            string providersOptions = providers == null ? "" : string.Join("", providers.Take(190).Select(x => $"<option value=\"{x.Id}\">{x.SmevName}</option>"));

            var modelBuilder = new ViewModelBuilder()
                .AddViewTitle("СМЭВ").SetInvisibleViewTitle()
                .AddModel(providersOptions)
                .AddViewDescription("СМЭВ Зпаросы")
                .AddTableMethodAction(Url.Action(nameof(GetSmevRequestsDataJson)))
                .AddEditMethodAction(Url.Action(nameof(SmevRequestChangeModal)))
                .AddRemoveMethodAction(Url.Action(nameof(SmevRequestRemove)));
            return View("Smev/Requests", modelBuilder);
        }

        public async Task<IActionResult> GetSmevRequestsDataJson(IDataTablesRequest request)
        {
            (var responseData, int totalCount, int filteredCount) = await _referencesService.GetSmevRequests(request);

            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult> SmevRequestChangeModal(int? id, ActionType actionType)
        {
            ViewBag.DayTypes = new SelectList(await _referencesService.GetAllServiceWeekTypesAsync(), "Key", "Value");
            ViewBag.Services = new SelectList(await _referencesService.GetAllSmevServicesAsync(), nameof(SmevServiceDto.Id), nameof(SmevServiceDto.SmevName));

            var model = new ModalViewModelBuilder()
                .AddModel(actionType == ActionType.Add ? new SmevRequestModelDto() : await _referencesService.GetSmevRequestModelDtoAsync(id))
                .AddModalTitle((actionType == ActionType.Add ? "Добавление" : "Изменение") + " запроса СМЭВ")
                .AddModalViewPath("~/Views/Reference/Smev/_ModalChangeSmevRequest.cshtml")
                .AddActionType(actionType)
                .AddModalType(ModalType.LARGE);
            return ModalLayoutView(model);
        }

        [HttpPost]
        public async Task SmevRequestRemove(int id, string comment)
        {
            try
            {
                await _referencesService.RemoveSmevRequestAsync(id, comment);

                ShowSuccess(MessageDescription.RemoveSuccess);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task SmevRequestSaveAsync(SmevRequestModelDto input, ActionType actionType)
        {
            if (actionType == ActionType.Add)
            {
                try
                {
                    await _referencesService.AddSmevRequestAsync(input);

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
                    await _referencesService.UpdateSmevRequestAsync(input);
                    ShowSuccess(MessageDescription.EditSuccess);
                }
                catch (Exception ex)
                {
                    ShowError(ex.Message);
                }
            }
        }

        public async Task<IActionResult> SmevRequestServiceChangeModal(int id)
        {
            ViewBag.Id = id;

            var model = new ModalViewModelBuilder()
                .AddModel(await _referencesService.GetServicesForSmevAsync(id))
                .AddModalTitle("Услуги запроса СМЭВ")
                .AddModalViewPath("~/Views/Reference/Smev/_ModalChangeSmevRequestServices.cshtml")
                .AddModalType(ModalType.LARGE);
            return ModalLayoutView(model);
        }

        public async Task<IActionResult> SmevRequestServiceAddModal(int id)
        {

            var services = await _referencesService.GetServicesAll();
            var smevServices = await _referencesService.GetServicesForSmevAsync(id);

            services.RemoveAll(r => smevServices.Exists(e => e.ServiceId == r.Id));

            var isActive = services.Any();

            ViewBag.Services = new SelectList(services, nameof(ServicesDto.Id), nameof(ServicesDto.ServiceName));
            ViewBag.isActive = isActive;

            var model = new ModalViewModelBuilder()
                .AddModel(new AddSmevReferenceServiceDto { SmevId = id })
                .AddModalTitle("Добавление Услуг запроса СМЭВ")
                .AddModalViewPath("~/Views/Reference/Smev/_ModalChangeSmevRequestServicesAdd.cshtml")
                .AddModalType(ModalType.LARGE);

            if (!isActive) model.HideSubmitButton();

            return ModalLayoutView(model);
        }

        public async Task SmevRequestServiceSave(AddSmevReferenceServiceDto request)
        {
            request.EmployeesFioAdd = await _employeeManager.GetNameAsync(); ;
            var responce = await _referencesService.AddServicesForSmevAsync(request);
            if (responce) ShowSuccess("Услуги добавлены");
            else ShowError("Добавления услуг невозможно");
        }

        public async Task SmevRequestServiceDelete(Guid id)
        {
            var responce = await _referencesService.DeleteServicesForSmevAsync(id);
            if (responce) ShowSuccess("Услуга удалена");
            else ShowError("Удаление услуг невозможно");
        }
    }
}
