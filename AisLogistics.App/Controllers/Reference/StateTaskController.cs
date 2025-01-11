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
        [Breadcrumb("Гос задание", FromAction = nameof(Index), FromController = typeof(ReferenceController))]
        public IActionResult StateTask()
        {
            var modelBuilder = new ViewModelBuilder()
                .AddViewTitle("Гос задание").SetInvisibleViewTitle()
                .AddViewDescription("Гос задание")
                .AddTableMethodAction(Url.Action(nameof(GetStateTaskDataJson)))
                .AddEditMethodAction(Url.Action(nameof(StateTaskChangeModal)))
                .AddRemoveMethodAction(Url.Action(nameof(StateTaskRemove)));
            return View("StateTask/Index", modelBuilder);
        }

        public async Task<IActionResult> GetStateTaskDataJson(IDataTablesRequest request)
        {
            (var responseData, int totalCount, int filteredCount) = await _referencesService.GetStateTask(request);

            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult> StateTaskChangeModal(Guid? id, ActionType actionType)
        {
            var model = new ModalViewModelBuilder()
                .AddModel(actionType == ActionType.Add ? new StateTaskDto() : await _referencesService.GetStateTaskDtoAsync(id))
                .AddModalTitle((actionType == ActionType.Add ? "Добавление" : "Изменение") + "Гос задание")
                .AddModalViewPath("~/Views/Reference/StateTask/_ModalChangeStateTask.cshtml")
                .AddActionType(actionType)
                .AddModalType(ModalType.LARGE);

            return ModalLayoutView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task StateTaskSaveAsync(StateTaskDto input, ActionType actionType)
        {
            if (actionType == ActionType.Add)
            {
                try
                {
                    var employeeName = await _employeeManager.GetNameAsync();
                    await _referencesService.AddStateTaskAsync(input, employeeName);

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
                    await _referencesService.UpdateStateTaskAsync(input);
                    ShowSuccess(MessageDescription.EditSuccess);
                }
                catch (Exception ex)
                {
                    ShowError(ex.Message);
                }
            }
        }


        [HttpPost]
        public async Task StateTaskRemove(Guid id, string comment)
        {
            try
            {
                await _referencesService.RemoveStateTaskAsync(id, comment);

                ShowSuccess(MessageDescription.RemoveSuccess);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }


    }
}
