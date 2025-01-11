using AisLogistics.App.Models;
using AisLogistics.App.ViewModels.ModelBuilder;
using AisLogistics.DataLayer.Common.Dto.Reference;
using SmartBreadcrumbs.Attributes;

namespace AisLogistics.App.Controllers.Reference
{
    public partial class ReferenceController
    {
        [Breadcrumb("Календарь", FromAction = nameof(Index), FromController = typeof(ReferenceController))]
        public IActionResult Calendar()
        {
            var modelBuilder = new ViewModelBuilder()
                .AddViewTitle("Календарь")
                .SetInvisibleViewTitle()
                .SetInvisibleViewDescription()
                .SetElementName("calendar")
                .AddTableMethodAction(Url.Action(nameof(GetCalendarDataJson)))
                .AddEditMethodAction(Url.Action(nameof(CalendarChangeModal)))
                .AddRemoveMethodAction(Url.Action(nameof(CalendarRemove)));
            return View("Calendar/Index", modelBuilder);
        }

        public async Task<IActionResult> GetCalendarDataJson(DateTime startDate, DateTime endDate)
        {
            var output = await _referencesService.GetCalendarDatesAsync(startDate, endDate);
            return Ok(output);
        }

        public async Task<IActionResult> CalendarChangeModal(DateTime date)
        {
            var calendarDate = await _referencesService.GetCalendarDateAsync(date);
            var model = new ModalViewModelBuilder()
                .AddModel(calendarDate)
                .AddModalTitle("Изменить тип даты")
                .AddActionType(ActionType.Edit)
                .AddModalViewPath("~/Views/Reference/Calendar/_ModalChangeDateType.cshtml");

            return ModalLayoutView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task CalendarSaveAsync(CalendarDateModelDto input)
        {
            try
            {
                var employeeName = await _employeeManager.GetNameAsync();
                input.EmployeesFioAdd = employeeName;
                await _referencesService.UpdateCalendarDateAsync(input);

                ShowSuccess(MessageDescription.EditSuccess);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        [HttpPost]
        public async Task CalendarRemove(int id, string comment)
        {
            try
            {
                await _referencesService.RemoveCalendarDateAsync(id, comment);

                ShowSuccess(MessageDescription.RemoveSuccess);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }
    }
}
