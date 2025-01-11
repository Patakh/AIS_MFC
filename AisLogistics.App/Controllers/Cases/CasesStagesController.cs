using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.Cases;
using AisLogistics.App.Models.DTO.Services;
using AisLogistics.App.ViewModels.ModelBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Controllers.Cases
{
    public partial class CasesController
    {
        public async Task<IActionResult> ServiceStages(Guid id)
        {
            ViewBag.Id = id;
            var stages = await _caseService.GetStagesByServiceIdAsync(id);
            var modelBuilder = new ViewModelBuilder()
                .AddViewTitle("Этапы")
                .AddModel(stages);
            return PartialView("Details/Sidebar/_SidebarStages", modelBuilder);
        }

        public async Task<IActionResult> ServiceStageAddModal(Guid id)
        {
            var officeId = await _employeeManager.GetOfficeAsync();
            var employeeId = await _employeeManager.GetIdAsync();
            var stageModelAdd = new StageAddDto
            {
                ServiceId = new List<Guid>() { id },
                OfficeId = officeId.Value,
                EmployeeId = employeeId.Value
            };

            stageModelAdd.Stages.AddRange(User.HasClaim(AccessKeyNames.DataCaseServiceAllStage, AccessKeyValues.View)
                ? await _caseService.GetStagesNextAllAsync(new List<Guid>() { id })
                : await _caseService.GetStagesNextByServiceIdAsync(new List<Guid>() { id }));

            ViewBag.Offices = new SelectList(await _referencesService.GetAllOfficesTypeMfcAndTospAsync(), "Id", "OfficeName", officeId);

            var modelBuilder = new ModalViewModelBuilder()
                .AddModalType(ModalType.SMALL)
                .AddModalViewPath("Details/Modals/_ModalStageAdd")
                .AddModalTitle("Добавление этапа")
                .AddModel(stageModelAdd);

            if (stageModelAdd.Stages.Any() == false) modelBuilder.HideSubmitButton();

            return ModalLayoutView(modelBuilder);
        }

        public async Task<IActionResult> ServicesStageAddModal(List<Guid> id)
        {
            var officeId = await _employeeManager.GetOfficeAsync();
            var employeeId = await _employeeManager.GetIdAsync();
            var stageModelAdd = new StageAddDto
            {
                ServiceId = id,
                OfficeId = officeId.Value,
                EmployeeId = employeeId.Value
            };

            stageModelAdd.Stages.AddRange(User.HasClaim(AccessKeyNames.DataCaseServiceAllStage, AccessKeyValues.Add)
                ? await _caseService.GetStagesNextAllAsync(id)
                : await _caseService.GetStagesNextByServiceIdAsync(id));

            ViewBag.Offices = new SelectList(await _referencesService.GetAllOfficesTypeMfcAndTospAsync(), "Id", "OfficeName", officeId);

            var modelBuilder = new ModalViewModelBuilder()
                .AddModalType(ModalType.SMALL)
                .AddModalViewPath("Details/Modals/_ModalStageAdd")
                .AddModalTitle("Добавление этапа")
                .AddModel(stageModelAdd);

            if (stageModelAdd.Stages.Any() == false) modelBuilder.HideSubmitButton();

            return ModalLayoutView(modelBuilder);
        }

        public async Task<IActionResult> ServiceStageNextEmployess(ServiceStageNextEmployessDto request)
        {
            var employeeId = await _employeeManager.GetIdAsync();
            var employee = await _caseService.GetStagesNextEmployessByServiceIdAsync(request);
            if (employee == null) 
            {
                ShowError("Сотрудник не найден"); 
                return Problem(); 
            }

            //if (!employee.Any(a => a.Id == employeeId))
            //{
            //    var name = await _employeeManager.GetNameAsync();
            //    employee.Add(new EmployeesDtO { Id = (Guid)employeeId, Name = name ?? string.Empty });
            //}

            return Json(employee);
        }

        [HttpPost]
        public async Task ServiceStageSave(ServiceStageSaveDto request)
        {
            var responce = await _caseService.AddServiceStageAsync(request);
            if (responce) ShowSuccess("Этап добавлен");
            else ShowError("Добавления этапа невозможно");
        }
        [HttpPost]
        public async Task<IActionResult> ServiceStageSaveResult(ServiceStageSaveDto request)
        {
            var responce = await _caseService.AddServiceStageAsync(request);
            if (responce) { ShowSuccess("Этап добавлен"); return Ok(); }
            else { ShowError("Добавления этапа невозможно"); return Problem(); }
        }
        [HttpPost]
        public async Task<IActionResult> ServiceStageIncomingSaveResult(List<ServiceStageIncomingSaveDto> data)
        {
            try
            {
                var employee = await _employeeManager.GetFullInfoAsync();
                foreach (var item in data)
                {
                    var request = new ServiceStageSaveDto()
                    {
                        serviceId = new List<Guid>() { item.ServiceId },
                        stageId = item.StageId,
                        employeeId = employee.Id,
                        officeId = employee.Office.Id
                    };

                    var responce = await _caseService.AddServiceStageAsync(request);
                    if (responce is false) throw new InvalidOperationException();
                }
                ShowSuccess("Этап добавлен"); return Ok();
            }
            catch (Exception e) {
                ShowError("Добавления этапа невозможно");
                return Problem();  
            }

        }
    }
}
