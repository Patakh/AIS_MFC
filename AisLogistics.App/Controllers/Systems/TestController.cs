using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.References;
using AisLogistics.App.ViewModels.ModelBuilder;
using AisLogistics.App.ViewModels.Systems.Test;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmartBreadcrumbs.Attributes;

namespace AisLogistics.App.Controllers.Systems
{
    public partial class SystemsController
    {
        [Breadcrumb("Тесты", FromAction = nameof(Index), FromController = typeof(SystemsController))]
        public IActionResult Test()
        {
            var modelBuilder = new ViewModelBuilder()
                .AddViewTitle("Тесты").SetInvisibleViewTitle()
                .AddViewDescription("Тесты")
                .AddTableMethodAction(Url.Action(nameof(GetTestDataJson)));

            return View("Test/Index", modelBuilder);
        }

        public async Task<IActionResult> GetTestDataJson(IDataTablesRequest request)
        {
            (var responseData, int totalCount, int filteredCount) = await _systemsService.GetTest(request);

            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult> TestChangeModalAdd()
        {
            var jobs = await _referencesService.GetAllJobsAsync();
            var direction = await _referencesService.GetAllDirectionsAsync();
            var offices = await _referencesService.GetAllOfficesTypeMfcAndTospAsync();

            ViewBag.Jobs = new SelectList(jobs, nameof(EmployeesJobDto.Id), nameof(EmployeesJobDto.JobPositionName));
            ViewBag.Directions = new SelectList(direction, nameof(TestDirectionDto.Id), nameof(TestDirectionDto.Name));
            ViewBag.Offices = new SelectList(offices, nameof(OfficeDto.Id), nameof(OfficeDto.OfficeName));


            var model = new ModalViewModelBuilder()
                .AddModalTitle("Добавление теста")
                .AddModalViewPath("~/Views/Systems/Test/_ModalAddTest.cshtml")
                .AddModalType(ModalType.FULL);

            return ModalLayoutView(model);
        }

        public async Task<IActionResult> TestChangeSidebarView(Guid id)
        {
            var responseData = await _systemsService.GetTestEmployees(id);

            return PartialView("Test/_TableViewTestEmployees", responseData);
        }

        public async Task<ActionResult<string>> TestEmployeesPrint(Guid id)
        {
            try
            {
                var employeeName = await _employeeManager.GetNameAsync();
                var file = await _referencesService.SystemFiles(8);
                if (file is null) return NotFound();

                var connection = _configuration.GetConnectionString("DefaultConnection");
                var content = await _systemsService.GetTestEmployeesPrint(file, id, connection);

                if (content is null) return NotFound();

                return Convert.ToBase64String(content);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
                return NotFound();
            }
        }

        public async Task<IActionResult> TestEmployeesChangeModalView(Guid id)
        {
            var responseData = await _systemsService.GetTestEmployeesQuestionAndAnswer(id);

            var model = new ModalViewModelBuilder()
                .AddModalTitle("Вопросы")
                .AddModalViewPath("~/Views/Systems/Test/_ModalViewTestEmployeesQuestions.cshtml")
                .AddModalType(ModalType.EXTRA)
                .HideSubmitButton()
                .AddModel(responseData);

            return ModalLayoutView(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetJobsDirections(List<int> jobsId)
        {
            var data = await _referencesService.GetAllDirectionsAsync(jobsId);
            data.Add(new TestDirectionDto { Id = Guid.Empty, Name = "Все" });

            return Json(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeesForOffice(List<int> jobsId, Guid officeId)
        {
            var data = await _referencesService.GetEmployeesForMfc(officeId, jobsId);
            data.Add(new OfficeDto { Id = Guid.Empty, OfficeName = "Все" });
            return Json(data);
        }

        [HttpPost]
        public async Task<IActionResult> GetEmployeesQuestions(EmployeesQuestionRequestModel requestModel)
        {
            if (requestModel == null) throw new ArgumentNullException(nameof(requestModel));
            if (requestModel.TestDirectionId.Count == 0) throw new ArgumentException("Направления не выбраны");
            if (requestModel.TestEmployeesId.Count == 0) throw new ArgumentException("Сотрудники не выбраны");
            if (requestModel.TestEmployeeJobsId.Count == 0) throw new ArgumentException("Должности не выбраны");
            return Json(await _systemsService.GetEmployeesQuestionList(requestModel));
        }

        [HttpPost]
        public async Task<IActionResult> GetEmployeesRefreshQuestions(EmployeesQuestioRefreshRequestModel requestModel)
        {
            if (requestModel == null) throw new ArgumentNullException(nameof(requestModel));
            if (requestModel.TestDirectionId.Count == 0) throw new ArgumentException("Направления не выбраны");
            if (requestModel.TestEmployeeJobsId.Count == 0) throw new ArgumentException("Должности не выбраны");
            return Json(await _systemsService.GetRefreshEmployeesQuestion(requestModel));
        }

        [HttpPost]
        public async Task<IActionResult> EmployeesTestSave(EmployeesTestSaveRequestModel requestModel)
        {
            var isSave = await _systemsService.EmployeesTestSave(requestModel);
            if (isSave) { ShowSuccess(MessageDescription.AddSuccess); return Ok(); }
            else { ShowError(MessageDescription.Error); return Problem(); }
        }
    }
}
