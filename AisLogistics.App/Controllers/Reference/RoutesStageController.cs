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
        [Breadcrumb("Этапы", FromAction = nameof(Index), FromController = typeof(ReferenceController))]
        public IActionResult RoutesStage()
        {
            var modelBuilder = new ViewModelBuilder()
                .AddViewTitle("Этапы").SetInvisibleViewTitle()
                .AddViewDescription("Справочник Этапов")
                .AddTableMethodAction(Url.Action(nameof(GetRoutesStageDataJson)))
                .AddEditMethodAction(Url.Action(nameof(RoutesStageChangeModal)));
            return View("RoutesStage/Index", modelBuilder);
        }

        public async Task<IActionResult> GetRoutesStageDataJson(IDataTablesRequest request)
        {
            (var responseData, int totalCount, int filteredCount) = await _referencesService.GetRoutesStage(request);

            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult> RoutesStageChangeModal(int? id, ActionType actionType)
        {
            var status = await _referencesService.GetStatusesAllAsync();
            ViewBag.Status = new SelectList(status, "Id", "StatusName");

            var model = new ModalViewModelBuilder()
                .AddModel(actionType == ActionType.Add ? new RoutesStageModelDto() : await _referencesService.GetRoutesStageDtoAsync(id))
                .AddModalTitle((actionType == ActionType.Add ? "Добавление" : "Изменение") + " Этапа")
                .AddModalViewPath("~/Views/Reference/RoutesStage/_ModalChangeRoutesStage.cshtml")
                .AddActionType(actionType)
                .AddModalType(ModalType.LARGE);

            return ModalLayoutView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task RoutesStageSaveAsync(RoutesStageModelDto input, ActionType actionType)
        {
            if (actionType == ActionType.Add)
            {
                try
                {
                    await _referencesService.AddRoutesStageAsync(input);

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
                    await _referencesService.UpdateRoutesStageAsync(input);
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
