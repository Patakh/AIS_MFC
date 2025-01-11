using AisLogistics.App.Models;
using AisLogistics.App.ViewModels.ModelBuilder;
using AisLogistics.DataLayer.Common.Dto.Reference;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using SmartBreadcrumbs.Attributes;

namespace AisLogistics.App.Controllers.Reference
{
    public partial class ReferenceController
    {
        [Breadcrumb("Жизненные ситуации", FromAction = nameof(Index), FromController = typeof(ReferenceController))]
        public IActionResult LivingSituation()
        {
            var modelBuilder = new ViewModelBuilder()
                .AddViewTitle("Жизненные ситуации").SetInvisibleViewTitle()
                .AddViewDescription("Справочник Жизненные ситуации")
                .AddTableMethodAction(Url.Action(nameof(GetLivingSituationDataJson)))
                .AddEditMethodAction(Url.Action(nameof(LivingSituationChangeModal)))
                .AddRemoveMethodAction(Url.Action(nameof(LivingSituationRemove)));
            return View("LivingSituation/Index", modelBuilder);
        }

        public async Task<IActionResult> GetLivingSituationDataJson(IDataTablesRequest request)
        {
            (var responseData, int totalCount, int filteredCount) = await _referencesService.GetLivingSituation(request);

            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult> LivingSituationChangeModal(Guid? id, ActionType actionType)
        {
            var model = new ModalViewModelBuilder()
                .AddModel(actionType == ActionType.Add ? new LivingSituationModelDto() : await _referencesService.GetLivingSituationDtoAsync(id))
                .AddModalTitle((actionType == ActionType.Add ? "Добавление" : "Изменение") + " Жизненные ситуации")
                .AddModalViewPath("~/Views/Reference/LivingSituation/_ModalChangeLivingSituation.cshtml")
                .AddActionType(actionType)
                .AddModalType(ModalType.LARGE);

            return ModalLayoutView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task LivingSituationSaveAsync(LivingSituationModelDto input, ActionType actionType)
        {
            if (actionType == ActionType.Add)
            {
                try
                {
                    var employeeName = await _employeeManager.GetNameAsync();
                    input.EmployeesFioAdd = employeeName;
                    input.DateAdd = DateTime.Today;

                    await _referencesService.AddLivingSituationAsync(input);

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
                    await _referencesService.UpdateLivingSituationAsync(input);
                    ShowSuccess(MessageDescription.EditSuccess);
                }
                catch (Exception ex)
                {
                    ShowError(ex.Message);
                }
            }
        }


        [HttpPost]
        public async Task LivingSituationRemove(Guid id, string comment)
        {
            try
            {
                await _referencesService.RemoveLivingSituationAsync(id, comment);

                ShowSuccess(MessageDescription.RemoveSuccess);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

    }
}
