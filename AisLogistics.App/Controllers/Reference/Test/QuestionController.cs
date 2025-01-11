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
        public IActionResult Questions()
        {
            var modelBuilder = new ViewModelBuilder()
                .AddViewTitle("Тестирование").SetInvisibleViewTitle()
                .AddViewDescription("Вопросы")
                .AddTableMethodAction(Url.Action(nameof(GetQuestionsDataJson)))
                .AddEditMethodAction(Url.Action(nameof(QuestionsChangeModal)))
                .AddRemoveMethodAction(Url.Action(nameof(QuestionsSaveAsync)));
            return View("Test/Questions", modelBuilder);
        }

        public async Task<IActionResult> GetQuestionsDataJson(IDataTablesRequest request)
        {
            (var responseData, int totalCount, int filteredCount) = await _referencesService.GetQuestions(request);

            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult> QuestionsChangeModal(Guid? id, ActionType actionType)
        {

            ViewBag.Directions = new SelectList(await _referencesService.GetAllDirectionsAsync(), nameof(TestDirectionDto.Id), nameof(TestDirectionDto.Name));

            var model = new ModalViewModelBuilder()
                .AddModel(actionType == ActionType.Add ? new TestQuestionsModelDto() : await _referencesService.GetQuestionsDtoAsync(id))
                .AddModalTitle((actionType == ActionType.Add ? "Добавление" : "Изменение") + " Вопроса")
                .AddModalViewPath("~/Views/Reference/Test/_ModalChangeQuestions.cshtml")
                .AddActionType(actionType)
                .AddModalType(ModalType.LARGE);
            return ModalLayoutView(model);
        }

        [HttpPost]
        public async Task QuestionsRemove(Guid id, string comment)
        {
            try
            {
                await _referencesService.RemoveQuestionsAsync(id, comment);
                ShowSuccess(MessageDescription.RemoveSuccess);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task QuestionsSaveAsync(TestQuestionsModelDto input, ActionType actionType)
        {
            var employeeName = await _employeeManager.GetNameAsync();
            input.EmployeesFioAdd = employeeName;
            input.DateAdd = DateTime.Now;
            if (actionType == ActionType.Add)
            {
                try
                {
                    await _referencesService.AddQuestionsAsync(input);
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
                    await _referencesService.UpdateQuestionsAsync(input);
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
