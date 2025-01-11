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
        [Breadcrumb("Роли исполнителя", FromAction = nameof(Index), FromController = typeof(ReferenceController))]
        public IActionResult RolesExecutor()
        {
            var modelBuilder = new ViewModelBuilder()
                .AddViewTitle("Роли исполнителя").SetInvisibleViewTitle()
                .AddViewDescription("Справочник ролей исполнителей")
                .AddTableMethodAction(Url.Action(nameof(GetRolesExecutorDataJson)))
                .AddEditMethodAction(Url.Action(nameof(RolesExecutorChangeModal)))
                .AddRemoveMethodAction(Url.Action(nameof(RoleExecutorRemove)));
            return View("RolesExecutor/Index", modelBuilder);
        }

        public async Task<IActionResult> GetRolesExecutorDataJson(IDataTablesRequest request)
        {
            (var responseData, int totalCount, int filteredCount) = await _referencesService.GetRolesExecutor(request);

            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult> RolesExecutorChangeModal(Guid? id, ActionType actionType)
        {
            var model = new ModalViewModelBuilder()
                .AddModel(actionType == ActionType.Add ? new RoleExecutorModelDto() : await _referencesService.GetRolesExecutorModelDtoAsync(id))
                .AddModalTitle((actionType == ActionType.Add ? "Добавление" : "Изменение") + " роли исполнителя")
                .AddModalViewPath("~/Views/Reference/RolesExecutor/_ModalChangeRoleExecutor.cshtml")
                .AddActionType(actionType)
                .AddModalType(ModalType.LARGE);
            return ModalLayoutView(model);
        }

        [HttpPost]
        public async Task RoleExecutorRemove(Guid id, string comment)
        {
            try
            {
                await _referencesService.RemoveRolesExecutorAsync(id, comment);

                ShowSuccess(MessageDescription.RemoveSuccess);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task RoleExecutorSaveAsync(RoleExecutorModelDto input, ActionType actionType)
        {
            var employeeId = await _employeeManager.GetIdAsync();

            if (employeeId is null)
            {
                ShowError(MessageDescription.Error);
                return;
            }

            var employeeName = await _employeeManager.GetNameAsync();

            if (actionType == ActionType.Add)
            {
                input.EmployeesFioAdd = employeeName;
                input.DateAdd = DateTime.Now;

                try
                {
                    await _referencesService.AddRoleExecutorAsync(input);

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
                    //role.EmployeesFioAdd = employeeName;
                    //role.DateAdd = DateTime.Now;

                    await _referencesService.UpdateRoleExecutorAsync(input);
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
