using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.References;
using AisLogistics.App.ViewModels.ModelBuilder;
using AisLogistics.DataLayer.Common.Dto.Reference;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Controllers.Reference
{
    // Этапы
    public partial class ReferenceController
    {
        public async Task<IActionResult> ServiceStages(Guid id)
        {
            var serviceNameSmall = await _referencesService.GetServiceAnyAsync(id);
            if (serviceNameSmall is false) return NotFound();
            ViewData["Id"] = id;

            var modelBuilder = new ViewModelBuilder()
                .AddViewDescription("Этапы")
                .SetElementName(nameof(ServiceStages))
                .AddTableMethodAction(Url.Action(nameof(GetServiceStagesDataJson), new { id = id }))
                .AddEditMethodAction(Url.Action(nameof(ServiceStageChangeModal)))
                .AddRemoveMethodAction(Url.Action(nameof(ServiceStageRemove)));

            return PartialView("Services/Details/Stages", modelBuilder);
        }

        public async Task<IActionResult> GetServiceStagesDataJson(IDataTablesRequest request, Guid id, Guid parentId = default(Guid))
        {
            (var responseData, int totalCount, int filteredCount) = await _referencesService.GetServiceStages(request, id, parentId);

            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult> GetServiceStageRolesDataJson(IDataTablesRequest request, Guid id)
        {
            (var responseData, int totalCount, int filteredCount) = await _referencesService.GetServiceStageRoles(request, id);

            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }


        public async Task<IActionResult> ServiceStageChangeModal(Guid? id, Guid serviceId, Guid parentId)
        {
            var stages = await _referencesService.GetRoutesStageAllAsync();
            var added = await _referencesService.GetServiceStagesAsync(serviceId, parentId);

            stages.RemoveAll(x => added.Where(w => w.SServicesId == serviceId && w.ParentId == parentId)
                .Select(a => a.SRoutesStageId).ToArray().Contains(x.Id));

            ViewBag.Stages = new SelectList(stages, nameof(RoutesStageModelDto.Id), nameof(RoutesStageModelDto.StageName));

            var model = new ModalViewModelBuilder()
                .AddModel(new ServiceStageModelDto() { Id = default(Guid), PrevParentId = id ?? default(Guid), SServicesId = serviceId, ParentId = parentId })
                .AddModalTitle("Добавление этапа")
                .AddModalViewPath("~/Views/Reference/Services/Details/Modals/_ModalChangeServiceStage.cshtml")
                .AddActionType(ActionType.Add)
                .AddModalType(ModalType.LARGE);
            return ModalLayoutView(model);
        }

        public async Task<IActionResult> ServiceStageAddRoleAsync(Guid id)
        {
            var added = await _referencesService.GetServiceStageRolesAsync(id);
            var roles = await _referencesService.GetAllRolesExecutorAsync();
            roles.RemoveAll(x => added.Select(a => a.Id).ToArray().Contains(x.Id));

            ViewBag.Roles = new SelectList(roles, nameof(RoleExecutorDto.Id), nameof(RoleExecutorDto.RoleName));

            var modelBuilder = new ModalViewModelBuilder()
                .AddModel(new ServicesStageRoleModelDto() { SServicesRoutesStageId = id})
                .AddModalType(ModalType.SMALL)
                .AddModalViewPath("~/Views/Reference/Services/Details/Modals/_ModalAddServiceStageRole.cshtml")
                .AddModalTitle("Добавить роль исполнителя");
            return ModalLayoutView(modelBuilder);
        }

        [HttpPost]
        public async Task ServiceStageRemove(Guid id, string comment)
        {
            try
            {
                await _referencesService.RemoveServiceStageAsync(id, comment);

                ShowSuccess(MessageDescription.RemoveSuccess);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task ServiceStageSaveAsync(ServiceStageModelDto input, ActionType actionType)
        {
            if (actionType == ActionType.Add)
            {
                var employeeId = await _employeeManager.GetIdAsync();

                if (employeeId is null)
                {
                    ShowError(MessageDescription.Error);
                    return;
                }

                input.SEmployeesIdAdd = (Guid)employeeId;

                var employeeName = await _employeeManager.GetNameAsync();
                input.EmployeesFioAdd = employeeName;

                try
                {
                    await _referencesService.AddServiceStageAsync(input);

                    ShowSuccess(MessageDescription.AddSuccess);
                }
                catch (Exception ex)
                {
                    ShowError(ex.Message);
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task StageRoleAddSave(ServicesStageRoleModelDto input, ActionType actionType)
        {
            var employeeId = await _employeeManager.GetIdAsync();

            if (employeeId is null)
            {
                ShowError(MessageDescription.Error);
                return;
            }

            var employeeName = await _employeeManager.GetNameAsync();
            input.EmployeesFioAdd = employeeName;

            try
            {
                await _referencesService.AddServiceStageRoleAsync(input);

                ShowSuccess(MessageDescription.AddSuccess);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        [HttpPost]
        public async Task ServiceStageRoleRemove(Guid id, string comment)
        {
            try
            {
                await _referencesService.RemoveServiceStageRoleAsync(id, comment);

                ShowSuccess(MessageDescription.RemoveSuccess);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }
    }
}
