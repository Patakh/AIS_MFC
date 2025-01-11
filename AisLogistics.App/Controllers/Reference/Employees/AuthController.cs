using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.Identity;
using AisLogistics.App.Models.DTO.References;
using AisLogistics.App.ViewModels.ModelBuilder;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;

namespace AisLogistics.App.Controllers.Reference
{
    public partial class ReferenceController
    {
        public async Task<IActionResult> EmployeeAuthDetails(Guid id)
        {
            var emlpoyee = await _referencesService.GetEmployeeDtoAsync(id);
            if (emlpoyee is null) return NotFound();
            ViewData["Id"] = emlpoyee.Id;

            var modelBuilder = new ViewModelBuilder()
                .AddViewDescription("Роли")
                .SetElementName(nameof(EmployeeAuthDetails))
                .AddTableMethodAction(Url.Action(nameof(GetEmployeeRolesDataJson), new { id = emlpoyee.AspNetUserId }))
                .AddEditMethodAction(Url.Action(nameof(EmployeeChangeRole)))
                .AddModel(emlpoyee.AspNetUserId);
            return PartialView("Employees/Details/AuthDetails", modelBuilder);
        }

        public async Task<IActionResult> GetEmployeeRolesDataJson(IDataTablesRequest request, Guid id)
        {
            var userRoles = await _identityService.GetUserRolesAsync(id);

            var responseData = (await _identityService.GetRolesAsync())
                .Select(x => new UserRoleItem(x.Id, x.Name, userRoles.Any(r => r.Id == x.Id)))
                .OrderBy(x => x.RoleName)
                .ToList();

            int totalCount = responseData.Count;

            var response = DataTablesResponse.Create(request, totalCount, totalCount, responseData);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult> EmployeePasswordChangeModal(Guid id)
        {
            var model = new ModalViewModelBuilder()
                .AddModel(new EmployeePasswordChangeDto()
                {
                    EmployeeId = id
                })
                .AddModalTitle("Изменить пароль сотрудника")
                .AddModalViewPath("~/Views/Reference/Employees/Details/Modals/_ModalChangeEmployeePassword.cshtml")
                //.AddActionType(actionType)
                .AddModalType(ModalType.LARGE);

            return ModalLayoutView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task EmployeePasswordSaveAsync(EmployeePasswordChangeDto input)
        {
            var editedEmployee = await _referencesService.GetEmployeeDtoAsync(input.EmployeeId);

            try
            {
                await _identityService.UserChangePasswordAsync(new UserPasswordChangeDto<Guid>()
                {
                    UserId = (Guid)editedEmployee.AspNetUserId,
                    NewPassword = input.NewPassword,
                    ConfirmPassword = input.ConfirmPassword
                });

                ShowSuccess(MessageDescription.EditSuccess);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        [HttpPost]
        public async Task EmployeeChangeRole(UserRoleChangeDto input)
        {
            try
            {
                if (input.Selected)
                {
                    await _identityService.CreateUserRoleAsync(input.UserId, input.RoleId);
                }
                else
                {
                    await _identityService.DeleteUserRoleAsync(input.UserId, input.RoleId);
                }

                ShowSuccess(MessageDescription.EditSuccess);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }
    }
}
