using AisLogistics.App.Models; 
namespace AisLogistics.App.Controllers.Cases;

public partial class CasesController
{
    public async Task<IActionResult> _1_ArchiveInformationAppealForm(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/KBR/Regional/_1_ArchiveInformationAppeal", new _1_ArchiveInformationAppealModel());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_1_ArchiveInformationAppealModel>(id.Value);
        return PartialView("AdditionalForms/KBR/Regional/_1_ArchiveInformationAppeal", model ?? new _1_ArchiveInformationAppealModel());
    }
    
    public async Task<IActionResult> _1_SubsidiesForm(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/KBR/Regional/_1_Subsidies", new _1_SubsidiesModel());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_1_SubsidiesModel>(id.Value);
        return PartialView("AdditionalForms/KBR/Regional/_1_Subsidies", model ?? new _1_SubsidiesModel());
    }

    public async Task<IActionResult> _2_ArchivalDocumentsForm(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/KBR/Regional/_2_ArchivalDocuments", new _2_ArchivalDocumentsModel());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_2_ArchivalDocumentsModel>(id.Value);
        return PartialView("AdditionalForms/KBR/Regional/_2_ArchivalDocuments", model ?? new _2_ArchivalDocumentsModel());
    }
     
    public async Task<IActionResult> _5_FamilyMembersForm(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/KBR/Regional/_5_FamilyMembers", new _5_FamilyMembersModel());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_5_FamilyMembersModel>(id.Value);
        return PartialView("AdditionalForms/KBR/Regional/_5_FamilyMembers", model ?? new _5_FamilyMembersModel());
    }

    public async Task<IActionResult> _6_BurialForm(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/KBR/Regional/_6_Burial", new _6_BurialModel());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_6_BurialModel>(id.Value);
        return PartialView("AdditionalForms/KBR/Regional/_6_Burial", model ?? new _6_BurialModel());
    }

    public async Task<IActionResult> _7_SuperannuationPensionForm(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/KBR/Regional/_7_SuperannuationPension", new _7_SuperannuationPensionModel());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_7_SuperannuationPensionModel>(id.Value);
        return PartialView("AdditionalForms/KBR/Regional/_7_SuperannuationPension", model ?? new _7_SuperannuationPensionModel());
    }

    public async Task<IActionResult> _9_HuntingTicketForm(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/KBR/Regional/_9_HuntingTicket", new _9_HuntingTicketModel());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_9_HuntingTicketModel>(id.Value);
        return PartialView("AdditionalForms/KBR/Regional/_9_HuntingTicket", model ?? new _9_HuntingTicketModel());
    }
    public async Task<IActionResult> _9_HuntingTicketCancelForm(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/KBR/Regional/_9_HuntingTicketCancel", new _9_HuntingTicketCancelModel());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_9_HuntingTicketCancelModel>(id.Value);
        return PartialView("AdditionalForms/KBR/Regional/_9_HuntingTicketCancel", model ?? new _9_HuntingTicketCancelModel());
    }

    public async Task<IActionResult> _10_UrbanPlanningPlanForm(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/KBR/Regional/_10_UrbanPlanningPlan", new _10_UrbanPlanningPlanModel());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_10_UrbanPlanningPlanModel>(id.Value);
        return PartialView("AdditionalForms/KBR/Regional/_10_UrbanPlanningPlan", model ?? new _10_UrbanPlanningPlanModel());
    }

    public async Task<IActionResult> _12_ArchivalDocumentsForm(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/KBR/Regional/_12_ArchivalDocuments", new _12_ArchivalDocumentsModel());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_12_ArchivalDocumentsModel>(id.Value);
        return PartialView("AdditionalForms/KBR/Regional/_12_ArchivalDocuments", model ?? new _12_ArchivalDocumentsModel());
    }

    public async Task<IActionResult> _13_AddressesForm(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/KBR/Regional/_13_Addresses", new _13_AddressesModel());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_13_AddressesModel>(id.Value);
        return PartialView("AdditionalForms/KBR/Regional/_13_Addresses", model ?? new _13_AddressesModel());
    }

    public async Task<IActionResult> _17_PostVaccinationComplicationsForm(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/KBR/Regional/_17_PostVaccinationComplications", new _17_PostVaccinationComplicationsModel());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_17_PostVaccinationComplicationsModel>(id.Value);
        return PartialView("AdditionalForms/KBR/Regional/_17_PostVaccinationComplications", model ?? new _17_PostVaccinationComplicationsModel());
    }

    public async Task<IActionResult> _18_ForCareForm(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/KBR/Regional/_18_ForCare", new _18_ForCareModel());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_18_ForCareModel>(id.Value);
        return PartialView("AdditionalForms/KBR/Regional/_18_ForCare", model ?? new _18_ForCareModel());
    }
    public async Task<IActionResult> _19_ForCarerForm(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/KBR/Regional/_19_ForCare", new _19_ForCareModel());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_19_ForCareModel>(id.Value);
        return PartialView("AdditionalForms/KBR/Regional/_19_ForCare", model ?? new _19_ForCareModel());
    }
    public async Task<IActionResult> _20_ForCareDisabledChildForm(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/KBR/Regional/_20_ForCareDisabledChild", new _20_ForCareDisabledChildModel());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_20_ForCareDisabledChildModel>(id.Value);
        return PartialView("AdditionalForms/KBR/Regional/_20_ForCareDisabledChild", model ?? new _20_ForCareDisabledChildModel());
    }

    public async Task<IActionResult> _21_VeteranLaborForm(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/KBR/Regional/_21_VeteranLabor", new _21_VeteranLaborModel());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_21_VeteranLaborModel>(id.Value);
        return PartialView("AdditionalForms/KBR/Regional/_21_VeteranLabor", model ?? new _21_VeteranLaborModel());
    }
    
    public async Task<IActionResult> _21_VeteranLabor2Form(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/KBR/Regional/_21_VeteranLabor2", new _21_VeteranLabor2Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_21_VeteranLabor2Model>(id.Value);
        return PartialView("AdditionalForms/KBR/Regional/_21_VeteranLabor2", model ?? new _21_VeteranLabor2Model());
    }

    public async Task<IActionResult> _27_ForCarePreSchoolForm(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/KBR/Regional/_27_ForCarePreSchool", new _27_ForCarePreSchoolModel());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_27_ForCarePreSchoolModel>(id.Value);
        return PartialView("AdditionalForms/KBR/Regional/_27_ForCarePreSchool", model ?? new _27_ForCarePreSchoolModel());
    }

    public async Task<IActionResult> _28_IndividualCategoriesСompensationForm(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/KBR/Regional/_28_IndividualCategoriesСompensation", new _28_IndividualCategoriesCompensationModel());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_28_IndividualCategoriesCompensationModel>(id.Value);
        return PartialView("AdditionalForms/KBR/Regional/_28_IndividualCategoriesСompensation", model ?? new _28_IndividualCategoriesCompensationModel());
    }

    public async Task<IActionResult> _29_IndividualCategoriesForm(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/KBR/Regional/_29_IndividualCategories", new _29_IndividualCategoriesModel());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_29_IndividualCategoriesModel>(id.Value);
        return PartialView("AdditionalForms/KBR/Regional/_29_IndividualCategories", model ?? new _29_IndividualCategoriesModel());
    }

    public async Task<IActionResult> _28_1_EnrollmentEducationalInstitutionForm(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/KBR/Regional/_28_1_EnrollmentEducationalInstitution", new _28_1_EnrollmentEducationalInstitutionModel());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_28_1_EnrollmentEducationalInstitutionModel>(id.Value);
        return PartialView("AdditionalForms/KBR/Regional/_28_1_EnrollmentEducationalInstitution", model ?? new _28_1_EnrollmentEducationalInstitutionModel());
    }

    public async Task<IActionResult> _28_2_EnrollmentEducationalInstitutionForm(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/KBR/Regional/_28_2_EnrollmentEducationalInstitution", new _28_2_EnrollmentEducationalInstitutionModel());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_28_2_EnrollmentEducationalInstitutionModel>(id.Value);
        return PartialView("AdditionalForms/KBR/Regional/_28_2_EnrollmentEducationalInstitution", model ?? new _28_2_EnrollmentEducationalInstitutionModel());
    }

    public async Task<IActionResult> _33_ForestDevelopmentForm(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/KBR/Regional/_33_ForestDevelopment", new _33_ForestDevelopmentModel());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_33_ForestDevelopmentModel>(id.Value);
        return PartialView("AdditionalForms/KBR/Regional/_33_ForestDevelopment", model ?? new _33_ForestDevelopmentModel());
    }

    public async Task<IActionResult> _46_KindergartensForm(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/KBR/Regional/_46_Kindergartens", new _46_KindergartensModel());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_46_KindergartensModel>(id.Value);
        return PartialView("AdditionalForms/KBR/Regional/_46_Kindergartens", model ?? new _46_KindergartensModel());
    }

    public async Task<IActionResult> _69_ForCareapartmentBuildingForm(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/KBR/Regional/_69_ForCareapartmentBuilding", new _69_ForCareapartmentBuildingModel());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_69_ForCareapartmentBuildingModel>(id.Value);
        return PartialView("AdditionalForms/KBR/Regional/_69_ForCareapartmentBuilding", model ?? new _69_ForCareapartmentBuildingModel());
    }
    
    public async Task<IActionResult> _69_ForCareForm(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/KBR/Regional/_69_ForCare", new _69_ForCareModel());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_69_ForCareModel>(id.Value);
        return PartialView("AdditionalForms/KBR/Regional/_69_ForCare", model ?? new _69_ForCareModel());
    }

    public async Task<IActionResult> _71_StateAwardsForm(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/KBR/Regional/_71_StateAwards", new _71_StateAwardsModel());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_71_StateAwardsModel>(id.Value);
        return PartialView("AdditionalForms/KBR/Regional/_71_StateAwards", model ?? new _71_StateAwardsModel());
    }

    public async Task<IActionResult> _82_EnrollmentEducationalInstitutionForm(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/KBR/Regional/_82_EnrollmentEducationalInstitution", new _82_EnrollmentEducationalInstitutionModel());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_82_EnrollmentEducationalInstitutionModel>(id.Value);
        return PartialView("AdditionalForms/KBR/Regional/_82_EnrollmentEducationalInstitution", model ?? new _82_EnrollmentEducationalInstitutionModel());
    }
    
    public async Task<IActionResult> _94_OUForm(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/KBR/Regional/_94_OU", new _94_OUModel());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_94_OUModel>(id.Value);
        return PartialView("AdditionalForms/KBR/Regional/_94_OU", model ?? new _94_OUModel());
    }

    public async Task<IActionResult> _101_RuralSettlementsSubsidiesForm(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/KBR/Regional/_101_RuralSettlementsSubsidies", new _101_RuralSettlementsSubsidiesModel());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_101_RuralSettlementsSubsidiesModel>(id.Value);
        return PartialView("AdditionalForms/KBR/Regional/_101_RuralSettlementsSubsidies", model ?? new _101_RuralSettlementsSubsidiesModel());
    }

    public async Task<IActionResult> _103_ConfirmationEducationForm(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/KBR/Regional/_103_ConfirmationEducation", new _103_ConfirmationEducationModel());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_103_ConfirmationEducationModel>(id.Value);
        return PartialView("AdditionalForms/KBR/Regional/_103_ConfirmationEducation", model ?? new _103_ConfirmationEducationModel());
    }

    public async Task<IActionResult> _121_MigrantForm(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/KBR/Regional/_121_Migrant", new _121_MigrantModel());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_121_MigrantModel>(id.Value);
        return PartialView("AdditionalForms/KBR/Regional/_121_Migrant", model ?? new _121_MigrantModel());
    }

    public async Task<IActionResult> _132_LocationLandPlotForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Regional/_132_LocationLandPlot", !id.HasValue ? new _132_LocationLandPlotModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_132_LocationLandPlotModel>(id.Value) ?? new _132_LocationLandPlotModel());
    
    public async Task<IActionResult> _57_ChildrenCenterRadugaForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Regional/_57_ChildrenCenterRaduga", !id.HasValue ? new _57_ChildrenCenterRadugaModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_57_ChildrenCenterRadugaModel>(id.Value) ?? new _57_ChildrenCenterRadugaModel());
    
    public async Task<IActionResult> _233_CreatingFosterFamilyForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Regional/_233_CreatingFosterFamily", !id.HasValue ? new _233_CreatingFosterFamilyModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_233_CreatingFosterFamilyModel>(id.Value) ?? new _233_CreatingFosterFamilyModel());

    public async Task<IActionResult> _198_ReinstatementSeniorityFairForm(Guid? id) => 
         PartialView("AdditionalForms/KBR/Regional/_198_ReinstatementSeniority", !id.HasValue ? new _198_ReinstatementSeniorityModel() 
            : await _caseService.GetAdditionalDataByServiceIdAsync<_198_ReinstatementSeniorityModel>(id.Value) ?? new _198_ReinstatementSeniorityModel());
    
    public async Task<IActionResult> _200_ThirdChildForm(Guid? id) => 
         PartialView("AdditionalForms/KBR/Regional/_200_ThirdChild", !id.HasValue ? new _200_ThirdChildModel() 
            : await _caseService.GetAdditionalDataByServiceIdAsync<_200_ThirdChildModel>(id.Value) ?? new _200_ThirdChildModel());

    public async Task<IActionResult> _210_ArchivalDocumentsWorkExperienceForm(Guid? id) => 
         PartialView("AdditionalForms/KBR/Regional/_210_ArchivalDocumentsWorkExperience", !id.HasValue ? new _210_ArchivalDocumentsWorkExperienceModel() 
            : await _caseService.GetAdditionalDataByServiceIdAsync<_210_ArchivalDocumentsWorkExperienceModel>(id.Value) ?? new _210_ArchivalDocumentsWorkExperienceModel());
    public async Task<IActionResult> _213_FairForm(Guid? id) => 
         PartialView("AdditionalForms/KBR/Regional/_213_Fair", !id.HasValue ? new _213_FairModel() 
            : await _caseService.GetAdditionalDataByServiceIdAsync<_213_FairModel>(id.Value) ?? new _213_FairModel());
}