using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.References;
using AisLogistics.App.ViewModels.Filter;
using AisLogistics.App.ViewModels.ModelBuilder;
using AisLogistics.DataLayer.Common.Dto.Reference;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Controllers.Reference
{
    public partial class ReferenceController
    {
        public async Task<IActionResult> EmployeeJobs(Guid id)
        {
            var emlpoyee = await _referencesService.GetEmployeeAnyAsync(id);
            if (emlpoyee is false) return NotFound();
            ViewData["Id"] = id;

            var modelBuilder = new ViewModelBuilder()
                .AddViewDescription("Должность")
                .SetElementName(nameof(EmployeeJobs))
                .AddTableMethodAction(Url.Action(nameof(GetEmployeeJobsDataJson), new { id = id }))
                .AddEditMethodAction(Url.Action(nameof(EmployeeJobChangeModal)))
                .AddRemoveMethodAction(Url.Action(nameof(EmployeeJobRemove)));
            return PartialView("Employees/Details/Jobs", modelBuilder);
        }

        public async Task<IActionResult> GetEmployeeJobsDataJson(IDataTablesRequest request, Guid id)
        {
            (var responseData, int totalCount, int filteredCount) = await _referencesService.GetEmployeeJobs(request, id);

            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult> EmployeeJobChangeModal(Guid? id, Guid employeeId, ActionType actionType)
        {

            if (id is null)
            {
                // добавление
            }
            else
            {
                // измениние                
            }

            var lastModified = await _referencesService.GetLastEmployeesJobDtoAsync(employeeId);

            //var offices = await _referencesService.GetAllOfficesAsync();
            var jobs = await _referencesService.GetAllJobsAsync();

            ViewBag.Offices = new SelectList(await _filterManager.GetOfficesReceptionAllCustomerDataJson(false, false), nameof(FilterOfficeModel.Id), nameof(FilterOfficeModel.OfficeName), lastModified.SOfficesId);
            ViewBag.Jobs = new SelectList(jobs, nameof(EmployeesJobDto.Id), nameof(EmployeesJobDto.JobPositionName), lastModified.SEmployeesJobPositionId);
            ViewBag.MaxDate = lastModified.DateStart;

            var model = new ModalViewModelBuilder()
                .AddModel(lastModified)
                .AddModalTitle("Добавление должности и офиса сотрудника")
                .AddModalViewPath("~/Views/Reference/Employees/Details/Modals/_ModalChangeEmployeeJob.cshtml")
                .AddActionType(actionType)
                .AddModalType(ModalType.LARGE);
            return ModalLayoutView(model);
        }

        [HttpPost]
        public async Task EmployeeJobRemove(Guid id, bool isRemove, string comment)
        {
            try
            {
                await _referencesService.RemoveEmployeeJobAsync(id, isRemove, comment);

                ShowSuccess(isRemove ? MessageDescription.RemoveSuccess : MessageDescription.CloseSuccess);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task EmployeeJobSaveAsync(EmployeeJobModelDto input, ActionType actionType)
        {
            if (actionType == ActionType.Add)
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
                    await _referencesService.AddEmployeeJobAsync(input);

                    ShowSuccess(MessageDescription.AddSuccess);
                }
                catch (Exception ex)
                {
                    ShowError(ex.Message);
                }
            }
        }
    }
}
