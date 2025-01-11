using AisLogistics.App.Models;
using AisLogistics.App.ViewModels.ModelBuilder;

namespace AisLogistics.App.Controllers.Cases
{
    public partial class CasesController
    {
        public async Task<IActionResult> DetailsAudit(string id)
        {
            ViewBag.Id = id;
            var audits = await _caseService.GetServiceAuditByCaseIdAsync(id);

            var modelBuilder = new ModalViewModelBuilder()
             .AddModalType(ModalType.EXTRA)
             .AddModalViewPath("Details/Modals/_ModalAudit")
             .AddModel(audits)
             .HideSubmitButton()
             .AddModalTitle("Действия");

            return ModalLayoutView(modelBuilder);
        }
    }
}
