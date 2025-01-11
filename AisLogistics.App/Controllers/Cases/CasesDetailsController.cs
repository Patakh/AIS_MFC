using AisLogistics.App.Models.DTO.Services;
using AisLogistics.App.ViewModels.Cases;
using AisLogistics.App.ViewModels.ModelBuilder;
using SmartBreadcrumbs.Attributes;

namespace AisLogistics.App.Controllers.Cases
{
    public partial class CasesController
    {
        [Breadcrumb("ViewData.Title", FromAction = nameof(Index), FromController = typeof(CasesController))]
        public async Task<IActionResult> Details(string id)
        {
            var services = await _caseService.GetServicesByCaseIdAsync(id);
            if (services is null) return NotFound();
            await _caseService.ViewCaseAsync(id);
            var modelBuilder = new ViewModelBuilder()
                .AddViewTitle(id)
                .AddModel(new CaseDetailsResponseModel<CasesDto>(services));
            return View("Details/Index", modelBuilder);
        }
    }
}
