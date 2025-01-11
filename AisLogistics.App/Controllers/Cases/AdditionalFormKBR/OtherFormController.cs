using AisLogistics.App.Models;
namespace AisLogistics.App.Controllers.Cases;

public partial class CasesController
{
    public async Task<IActionResult> _1_DepartureSpecialistsForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Other/_1_DepartureSpecialists", !id.HasValue ? new _1_DepartureSpecialistsModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_1_DepartureSpecialistsModel>(id.Value) ?? new _1_DepartureSpecialistsModel());
    
    public async Task<IActionResult> _33_TechnicalDocumentationForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Other/_33_TechnicalDocumentation", !id.HasValue ? new _33_TechnicalDocumentationModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_33_TechnicalDocumentationModel>(id.Value) ?? new _33_TechnicalDocumentationModel());

    public async Task<IActionResult> _34_ComprehensiveServiceForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Other/_34_ComprehensiveService", !id.HasValue ? new _34_ComprehensiveServiceModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_34_ComprehensiveServiceModel>(id.Value) ?? new _34_ComprehensiveServiceModel());
}