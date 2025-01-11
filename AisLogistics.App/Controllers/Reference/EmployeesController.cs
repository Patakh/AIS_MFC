using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.Identity;
using AisLogistics.App.Models.DTO.References;
using AisLogistics.App.ViewModels.Filter;
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
        [Breadcrumb("Сотрудники", FromAction = nameof(Index), FromController = typeof(ReferenceController))]
        public async Task<IActionResult> Employees()
        {
            var providers = await _filterManager.GetOfficesReceptionAllCustomerDataJson(true, false);
            ViewBag.Offices = string.Join("", providers.Select(x => $"<option value=\"{x.Id}\">{x.OfficeName}</option>"));

            var modelBuilder = new ViewModelBuilder()
                .AddViewTitle("Сотрудники").SetInvisibleViewTitle()
                .AddViewDescription("Справочник сотрудников")
                .AddTableMethodAction(Url.Action(nameof(GetEmployeesDataJson)))
                .AddEditMethodAction(Url.Action(nameof(EmployeeAddModal)));
            //.AddRemoveMethodAction(Url.Action(nameof(EmployeeRemove)));
            return View("Employees/Index", modelBuilder);
        }

        public async Task<IActionResult> GetEmployeesDataJson(IDataTablesRequest request, Guid officeId, string search)
        {
            (var responseData, int totalCount, int filteredCount) = await _referencesService.GetReferencesEmployees(request, officeId, search);

            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult> EmployeeAddModal(Guid? id, ActionType actionType)
        {
            ViewBag.Offices = new SelectList(await _filterManager.GetOfficesReceptionAllCustomerDataJson(false,false), nameof(FilterOfficeModel.Id), nameof(FilterOfficeModel.OfficeName));
            ViewBag.Jobs = new SelectList(await _referencesService.GetAllJobsAsync(), nameof(EmployeesJobDto.Id), nameof(EmployeesJobDto.JobPositionName));
            ViewBag.RolesExecutor = new SelectList(await _referencesService.GetAllRolesExecutorAsync(), nameof(RoleExecutorDto.Id), nameof(RoleExecutorDto.RoleName));
            ViewBag.Roles = new SelectList(await _identityService.GetRolesAsync(), nameof(IdentityRoleDto.Id), nameof(IdentityRoleDto.Name));
            ViewBag.Statuses = new SelectList(await _referencesService.GetAllEmployeeStatusesAsync(), "Key", "Value");

            var model = new ModalViewModelBuilder()
                .AddModel(new EmployeeAddModelDto())
                .AddModalTitle("Добавление сотрудника")
                .AddModalViewPath("~/Views/Reference/Employees/_ModalAddEmployee.cshtml")
                .AddActionType(actionType)
                .AddModalType(ModalType.LARGE);
            return ModalLayoutView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task EmployeeAddSaveAsync(EmployeeAddModelDto input, ActionType actionType)
        {
            if (!ModelState.IsValid)
            {
                ShowError($"Произошла ошибка: {string.Join("<br />", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))}");
                return;
            }

            var employeeIdAdd = await _employeeManager.GetIdAsync();

            if (employeeIdAdd is null)
            {
                ShowError(MessageDescription.Error);
                return;
            }

            var employeesFioAdd = await _employeeManager.GetNameAsync();

            var newUser = new IdentityUserDto()
            {
                UserName = input.Login,
                Email = input.EmployeeEmail,
                EmailConfirmed = true,
                PhoneNumber = input.EmployeePhone,
                PhoneNumberConfirmed = false,
                LockoutEnabled = true,
            };

            try
            {
                // добавить Asp.net User
                var result = await _identityService.CreateUserAsync(newUser);
                if (result.identityResult.Succeeded)
                {
                    var newUserId = result.userId;
                    await _identityService.UserChangePasswordAsync(new UserPasswordChangeDto<Guid>()
                    {
                        NewPassword = input.Password,
                        UserId = newUserId
                    });

                    // привязать к выбранной роли
                    var identityRoleAddResult = await _identityService.CreateUserRoleAsync(newUserId, input.RoleId);
                    if (identityRoleAddResult.Succeeded)
                    {
                        Guid newEmployeeId = default(Guid);

                        // добавить Employee
                        try
                        {
                            input.SEmployeesIdAdd = (Guid)employeeIdAdd;
                            input.EmployeesFioAdd = employeesFioAdd;
                            input.AspNetUserId = newUserId;

                            newEmployeeId = await _referencesService.AddEmployeeWithLinkedDataAsync(input);

                            ShowSuccess(MessageDescription.AddSuccess);
                        }
                        catch (Exception ex)
                        {
                            //if (newUserId != Guid.Empty)
                            //{
                            //    // удалить внесенные данные
                            //    //_referencesService.RemoveEmployeeOfficeAsync(newUserId);
                            //}
                            await _identityService.DeleteUserAsync(newUserId);

                            ShowError(ex.Message);
                        }

                        return;
                    }

                    await _identityService.DeleteUserAsync(newUserId);

                    ShowError($"Ошибка при добавлении роли пользователя: {string.Join("<br />", identityRoleAddResult.Errors.Select(x => x.Description))}");
                    return;
                }

                ShowError($"Ошибка при добавлении пользователя: {string.Join("<br />", result.identityResult.Errors.Select(x => x.Description))}");
                return;
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        [HttpPost]
        public async Task EmployeeRemove(Guid id, string comment)
        {
            try
            {
                //await _referencesService.RemoveOfficeAsync(id, comment);

                ShowSuccess(MessageDescription.RemoveSuccess);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }




        // [Breadcrumb("ViewData.Title", FromAction = nameof(Employees), FromController = typeof(ReferenceController))]
        // public async Task<IActionResult> EmployeeDetails(Guid id)
        // {
        //     var emlpoyee = await _referencesService.GetEmployeeDtoAsync(id);
        //     ViewData["Title"] = emlpoyee.EmployeeName;

        //     var modelBuilder = new ViewModelBuilder()
        //         .AddViewTitle(emlpoyee.EmployeeName).SetInvisibleViewTitle()
        //         .AddViewDescription("Общая информация")
        //         .AddEditMethodAction(Url.Action(nameof(EmployeeChangeModal)))
        //         .AddModel(emlpoyee);

        //     return View("Employees/Details/Index", modelBuilder);
        // }

        // public async Task<IActionResult> EmployeeChangeModal(Guid? id, ActionType actionType)
        // {
        //     ViewBag.Roles = new SelectList(await _identityService.GetRolesAsync(), nameof(IdentityRoleDto.Id), nameof(IdentityRoleDto.Name));

        //     var model = new ModalViewModelBuilder()
        //         .AddModel(actionType == ActionType.Add ? new EmployeeModelDto() : await _referencesService.GetEmployeeDtoAsync(id))
        //         .AddModalTitle((actionType == ActionType.Add ? "Добавление" : "Изменение") + " сотрудника")
        //         .AddModalViewPath("~/Views/Reference/Employees/_ModalChangeEmployee.cshtml")
        //         .AddActionType(actionType)
        //         .AddModalType(ModalType.LARGE);
        //     return ModalLayoutView(model);
        // }

        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task EmployeeSaveAsync(EmployeeModelDto input, ActionType actionType)
        // {
        //     if (actionType == ActionType.Add)
        //     {
        //         var employeeId = await _employeeManager.GetIdAsync();

        //         if (employeeId is null)
        //         {
        //             ShowError(MessageDescription.Error);
        //             return;
        //         }

        //         var employeeName = await _employeeManager.GetNameAsync();

        //         input.SEmployeesIdAdd = (Guid)employeeId;
        //         input.EmployeesFioAdd = employeeName;



        //         ShowSuccess(MessageDescription.AddSuccess);
        //     }
        //     else
        //     {
        //         try
        //         {
        //             await _referencesService.UpdateEmployeeAsync(input);
        //             ShowSuccess(MessageDescription.EditSuccess);
        //         }
        //         catch (Exception ex)
        //         {
        //             ShowError(ex.Message);
        //         }
        //     }

        // }
    }
}
