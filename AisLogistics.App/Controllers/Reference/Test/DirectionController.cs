using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.References;
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
        [Breadcrumb("Тестирование", FromAction = nameof(Index), FromController = typeof(ReferenceController))]
        public IActionResult Directions()
        {
            var modelBuilder = new ViewModelBuilder()
                .AddViewTitle("Тестирование").SetInvisibleViewTitle()
                .AddViewDescription("Направления")
                .AddTableMethodAction(Url.Action(nameof(GetDirectionsDataJson)))
                .AddEditMethodAction(Url.Action(nameof(DirectionsChangeModal)))
                .AddRemoveMethodAction(Url.Action(nameof(DirectionsRemove)));
            return View("Test/Directions", modelBuilder);
        }

        public async Task<IActionResult> GetDirectionsDataJson(IDataTablesRequest request)
        {
            (var responseData, int totalCount, int filteredCount) = await _referencesService.GetDirections(request);

            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult> DirectionsChangeModal(Guid? id, ActionType actionType)
        {
            ViewBag.Jobs = new SelectList(await _referencesService.GetAllJobsAsync(), nameof(EmployeesJobDto.Id), nameof(EmployeesJobDto.JobPositionName));

            var model = new ModalViewModelBuilder()
                .AddModel(actionType == ActionType.Add ? new TestDirectionModelDto() : await _referencesService.GetDirectionsDtoAsync(id))
                .AddModalTitle((actionType == ActionType.Add ? "Добавление" : "Изменение") + " Направления")
                .AddModalViewPath("~/Views/Reference/Test/_ModalChangeDirection.cshtml")
                .AddActionType(actionType)
                .AddModalType(ModalType.LARGE);
            return ModalLayoutView(model);
        }

        [HttpPost]
        public async Task DirectionsRemove(Guid id, string comment)
        {
            try
            {
                await _referencesService.RemoveDirectionsAsync(id, comment);

                ShowSuccess(MessageDescription.RemoveSuccess);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task DirectionsSaveAsync(TestDirectionModelDto input, ActionType actionType)
        {
            var employeeName = await _employeeManager.GetNameAsync();
            input.EmployeesFioAdd = employeeName;
            input.DateAdd = DateTime.Now;

            if (actionType == ActionType.Add)
            {
                try
                {
                    await _referencesService.AddDirectionsAsync(input);
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
                    await _referencesService.UpdateDirectionsAsync(input);
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

