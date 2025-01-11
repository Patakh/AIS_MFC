using AisLogistics.App.Data;
using AisLogistics.App.Models;
using AisLogistics.App.ViewModels.ModelBuilder;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using SmartBreadcrumbs.Attributes;
using System.Security.Claims;

namespace AisLogistics.App.Controllers.Systems
{
    public partial class SystemsController
    {
        [Breadcrumb("Роли", FromAction = nameof(Index), FromController = typeof(SystemsController))]
        public IActionResult Roles()
        {
            var modelBuilder = new ViewModelBuilder()
                .AddViewTitle("Роли").SetInvisibleViewTitle()
                .AddViewDescription("Справочник ролей сотрудников")
                .AddTableMethodAction(Url.Action(nameof(GetRolesDataJson)))
                .AddEditMethodAction(Url.Action(nameof(RoleChangeModal)))
                .AddRemoveMethodAction(Url.Action(nameof(RoleRemove)));
            return View("Roles/Index", modelBuilder);
        }

        public async Task<IActionResult> GetRolesDataJson(IDataTablesRequest request)
        {
            (var responseData, int totalCount, int filteredCount) = await _systemsService.GetRoles(request);

            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult> RoleChangeModal(string id, ActionType actionType)
        {

            //TODO переделать визуал - https://pixinvent.com/demo/vuexy-html-bootstrap-admin-template/html/ltr/vertical-menu-template-bordered/app-access-roles.html

            ViewBag.Role = actionType == ActionType.Add ? new ApplicationRole() : await _roleManager.FindByIdAsync(id);

            try
            {
                var a = AccessKeysRepository.AccessKeys;
            }
            catch (Exception ex)
            {
                var a = ex;
            }

            var model = new ModalViewModelBuilder()
                .AddModel(AccessKeysRepository.AccessKeys)
                .AddModalTitle((actionType == ActionType.Add ? "Добавление" : "Изменение") + " роли")
                .AddModalViewPath("~/Views/Systems/Roles/_ModalChangeRole.cshtml")
                .AddActionType(actionType)
                .AddModalType(ModalType.LARGE);
            return ModalLayoutView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task RoleSaveAsync(ApplicationRole applicationRole,
            Dictionary<string, bool> viewName,
            Dictionary<string, bool> addName,
            Dictionary<string, bool> editName,
            Dictionary<string, bool> removeName,
            ActionType actionType)
        {
            try
            {
                ApplicationRole? role;
                if (actionType == ActionType.Add)
                {
                    await _roleManager.CreateAsync(applicationRole);
                    ShowSuccess(MessageDescription.AddSuccess);
                }
                else
                {
                    role = _roleManager.FindByIdAsync(applicationRole.Id.ToString()).Result;
                    role.Name = applicationRole.Name;
                    await _roleManager.UpdateAsync(role);
                    ShowSuccess(MessageDescription.EditSuccess);
                }

                if (!ModelState.IsValid) throw new Exception("Ошибка валидации!");

                role = _roleManager.FindByNameAsync(applicationRole.Name).Result;
                var claims = _roleManager.GetClaimsAsync(role).Result;
                foreach (var itemViewName in viewName)
                {
                    var anyClaim = claims.Any(a => a.Type == itemViewName.Key && a.Value == AccessKeyValues.View);
                    var claim = new Claim(itemViewName.Key, AccessKeyValues.View);
                    if (itemViewName.Value && !anyClaim)
                        await _roleManager.AddClaimAsync(role, claim);
                    else if (!itemViewName.Value && anyClaim)
                        await _roleManager.RemoveClaimAsync(role, claim);
                }
                foreach (var itemAddName in addName)
                {
                    var anyClaim = claims.Any(a => a.Type == itemAddName.Key && a.Value == AccessKeyValues.Add);
                    var claim = new Claim(itemAddName.Key, AccessKeyValues.Add);
                    if (itemAddName.Value && !anyClaim)
                        await _roleManager.AddClaimAsync(role, claim);
                    else if (!itemAddName.Value && anyClaim)
                        await _roleManager.RemoveClaimAsync(role, claim);
                }
                foreach (var itemEditName in editName)
                {
                    var anyClaim = claims.Any(a => a.Type == itemEditName.Key && a.Value == AccessKeyValues.Edit);
                    var claim = new Claim(itemEditName.Key, AccessKeyValues.Edit);
                    if (itemEditName.Value && !anyClaim)
                        await _roleManager.AddClaimAsync(role, claim);
                    else if (!itemEditName.Value && anyClaim)
                        await _roleManager.RemoveClaimAsync(role, claim);
                }
                foreach (var itemRemoveName in removeName)
                {
                    var anyClaim = claims.Any(a => a.Type == itemRemoveName.Key && a.Value == AccessKeyValues.Remove);
                    var claim = new Claim(itemRemoveName.Key, AccessKeyValues.Remove);
                    if (itemRemoveName.Value && !anyClaim)
                        await _roleManager.AddClaimAsync(role, claim);
                    else if (!itemRemoveName.Value && anyClaim)
                        await _roleManager.RemoveClaimAsync(role, claim);
                }
            }
            catch (Exception e)
            {
                ShowError(MessageDescription.Error);
            }

        }

        [HttpPost]
        public async Task RoleRemove(Guid id, string comment)
        {
            var update = await _roleManager.FindByIdAsync(id.ToString());
            if (update is null)
            {
                ShowError(MessageDescription.Error);
                return;
            }

            await _roleManager.DeleteAsync(update);
            ShowSuccess(MessageDescription.RemoveSuccess);
        }
    }
}
