using AisLogistics.App.Models;
using AisLogistics.App.ViewModels.ModelBuilder;

namespace AisLogistics.App.Controllers.Cases
{
    public partial class CasesController
    {
        [Route("[controller]/Details/{id}/Comments")]
        public async Task<IActionResult> DetailsComments(string id)
        {
            ViewBag.Id = id;
            var comments = await _caseService.GetCommentsByCaseIdAsync(id);
            var modelBuilder = new ModalViewModelBuilder()
                .AddModalType(ModalType.LARGE)
                .AddModalViewPath("Details/Comments")
                .AddModel(comments)
                .HideSubmitButton()
                .AddModalTitle("Комментарии");

            return ModalLayoutView(modelBuilder);
        }

        public async Task<IActionResult> CommentEmployeesPick(string? id)
        {
            var employees = await _referencesService.GetReferencesAllEmployees();
            var modelBuilder = new ModalViewModelBuilder()
                .AddModalType(ModalType.SMALL)
                .AddModalViewPath("Details/Modals/_ModalCommentEmployeesPick")
                .AddModalTitle("Выбор сотрудников")
                .AddModel(employees);
            return ModalLayoutView(modelBuilder);
        }

        public async Task<IActionResult> CommentAdd(string id, string comment, Guid[] employeesId)
        {
            await _caseService.AddCommentAsync(id, comment, employeesId);
            return RedirectToAction(nameof(DetailsComments), new { id });
        }
    }
}
