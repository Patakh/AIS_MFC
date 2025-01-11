using AisLogistics.App.Models;
using AisLogistics.App.ViewModels.ModelBuilder;
using AisLogistics.DataLayer.Common.Dto.Reference;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using SmartBreadcrumbs.Attributes;

namespace AisLogistics.App.Controllers.Reference
{
    // СМЭВ - Сервисы
    public partial class ReferenceController
    {
        [Breadcrumb("СМЭВ", FromAction = nameof(Index), FromController = typeof(ReferenceController))]
        public IActionResult SmevServices()
        {
            var modelBuilder = new ViewModelBuilder()
                .AddViewTitle("СМЭВ").SetInvisibleViewTitle()
                .AddViewDescription("СМЭВ Сервисы")
                .AddTableMethodAction(Url.Action(nameof(GetSmevServicesDataJson)))
                .AddEditMethodAction(Url.Action(nameof(SmevServiceChangeModal)))
                .AddRemoveMethodAction(Url.Action(nameof(SmevServiceRemove)));
            return View("Smev/Services", modelBuilder);
        }

        public async Task<IActionResult> GetSmevServicesDataJson(IDataTablesRequest request)
        {
            (var responseData, int totalCount, int filteredCount) = await _referencesService.GetSmevServices(request);
            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult> SmevServiceChangeModal(Guid? id, ActionType actionType)
        {
            var model = new ModalViewModelBuilder()
                .AddModel(actionType == ActionType.Add ? new SmevServiceModelDto() : await _referencesService.GetSmevServiceModelDtoAsync(id))
                .AddModalTitle((actionType == ActionType.Add ? "Добавление" : "Изменение") + " сервиса СМЭВ")
                .AddModalViewPath("~/Views/Reference/Smev/_ModalChangeSmevService.cshtml")
                .AddActionType(actionType)
                .AddModalType(ModalType.LARGE);
            return ModalLayoutView(model);
        }

        [HttpPost]
        public async Task SmevServiceRemove(Guid id, string comment)
        {
            try
            {
                await _referencesService.RemoveSmevServiceAsync(id, comment);

                ShowSuccess(MessageDescription.RemoveSuccess);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task SmevServiceSaveAsync(SmevServiceModelDto input, ActionType actionType)
        {
            if (actionType == ActionType.Add)
            {
                try
                {
                    await _referencesService.AddSmevServiceAsync(input);

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
                    await _referencesService.UpdateSmevServiceAsync(input);
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
