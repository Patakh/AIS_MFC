using AisLogistics.App.Models;
using AisLogistics.App.Models.AdditionalForms;
using AisLogistics.App.Models.AdditionalForms.KBR.Federal;
using AisLogistics.App.Models.AdditionalForms.Regional;
namespace AisLogistics.App.Controllers.Cases;

public partial class CasesController
{
    public async Task<IActionResult> _7_UFNS_R16001Form(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_7_UFNS_R16001", !id.HasValue ? new _7_UFNS_R16001Model()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_7_UFNS_R16001Model>(id.Value) ?? new _7_UFNS_R16001Model());
    
    public async Task<IActionResult> _7_UFNS_P26001Form(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_7_UFNS_P26001", !id.HasValue ? new _7_UFNS_P26001Model()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_7_UFNS_P26001Model>(id.Value) ?? new _7_UFNS_P26001Model());
    
    public async Task<IActionResult> _7_UFNS_P26002Form(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_7_UFNS_P26002", !id.HasValue ? new _7_UFNS_P26002Model()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_7_UFNS_P26002Model>(id.Value) ?? new _7_UFNS_P26002Model());
    
    public async Task<IActionResult> _7_UFNS_P12003Form(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_7_UFNS_P12003", !id.HasValue ? new _7_UFNS_P12003Model()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_7_UFNS_P12003Model>(id.Value) ?? new _7_UFNS_P12003Model());
    
    public async Task<IActionResult> _7_UFNS_R21001Form(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_7_UFNS_R21001", !id.HasValue ? new _7_UFNS_R21001Model()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_7_UFNS_R21001Model>(id.Value) ?? new _7_UFNS_R21001Model());
    
    public async Task<IActionResult> _7_UFNS_R24001Form(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_7_UFNS_R24001", !id.HasValue ? new _7_UFNS_R24001Model()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_7_UFNS_R24001Model>(id.Value) ?? new _7_UFNS_R24001Model());
    
    public async Task<IActionResult> _7_UFNS_R24002Form(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_7_UFNS_R24002", !id.HasValue ? new _7_UFNS_R24002Model()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_7_UFNS_R24002Model>(id.Value) ?? new _7_UFNS_R24002Model());

    public async Task<IActionResult> _9_FNSExtractsForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_9_FNSExtracts", !id.HasValue ? new _9_FNSExtractsModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_9_FNSExtractsModel>(id.Value) ?? new _9_FNSExtractsModel());
    
    public async Task<IActionResult> _10_3_LegalDigitalInfoForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_10_3_LegalDigitalInfo", !id.HasValue ? new _10_3_LegalDigitalInfoModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_10_3_LegalDigitalInfoModel>(id.Value) ?? new _10_3_LegalDigitalInfoModel());
    
    public async Task<IActionResult> _11_1_FNSIndividualInformationForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_11_1_FNSIndividualInformation", !id.HasValue ? new _11_1_FNSIndividualInformationModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_11_1_FNSIndividualInformationModel>(id.Value) ?? new _11_1_FNSIndividualInformationModel());

    public async Task<IActionResult> _11_2_PresenceArrearsForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_11_2_PresenceArrears", !id.HasValue ? new _11_2_PresenceArrearsModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_11_2_PresenceArrearsModel>(id.Value) ?? new _11_2_PresenceArrearsModel());
    
    public async Task<IActionResult> _12_FnsKnd1150063Form(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_12_FnsKnd1150063", !id.HasValue ? new _12_FnsKnd1150063Model()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_12_FnsKnd1150063Model>(id.Value) ?? new _12_FnsKnd1150063Model());

    public async Task<IActionResult> _13_FnsKnd1150040Form(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_13_FnsKnd1150040", !id.HasValue ? new _13_FnsKnd1150040Model()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_13_FnsKnd1150040Model>(id.Value) ?? new _13_FnsKnd1150040Model());
    
    public async Task<IActionResult> _14_FnsKnd1150038Form(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_14_FnsKnd1150038", !id.HasValue ? new _14_FnsKnd1150038Model()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_14_FnsKnd1150038Model>(id.Value) ?? new _14_FnsKnd1150038Model());

    public async Task<IActionResult> _15_FnsKnd1150084Form(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_15_FnsKnd1150084", !id.HasValue ? new _15_FnsKnd1150084Model()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_15_FnsKnd1150084Model>(id.Value) ?? new _15_FnsKnd1150084Model());
    
    public async Task<IActionResult> GetDriverLicenseKBRForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_GetDriverLicenseKBR", !id.HasValue ? new GetDriverLicenseKBRModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<GetDriverLicenseKBRModel>(id.Value) ?? new GetDriverLicenseKBRModel());

    public async Task<IActionResult> _21_FnsKnd1150076Form(Guid? id) =>
    PartialView("AdditionalForms/KBR/Federal/_21_FnsKnd1150076", !id.HasValue ? new _21_FnsKnd1150076Model()
         : await _caseService.GetAdditionalDataByServiceIdAsync<_21_FnsKnd1150076Model>(id.Value) ?? new _21_FnsKnd1150076Model());
    
    public async Task<IActionResult> _24_FnsKnd1150122Form(Guid? id) =>
    PartialView("AdditionalForms/KBR/Federal/_24_FnsKnd1150122", !id.HasValue ? new _24_FnsKnd1150122Model()
         : await _caseService.GetAdditionalDataByServiceIdAsync<_24_FnsKnd1150122Model>(id.Value) ?? new _24_FnsKnd1150122Model());

    public async Task<IActionResult> _25_1_ApplicationPatentIndividualForm(Guid? id) =>
      PartialView("AdditionalForms/KBR/Federal/_25_1_ApplicationPatentIndividual", !id.HasValue ? new _25_1_ApplicationPatentIndividualModel()
         : await _caseService.GetAdditionalDataByServiceIdAsync<_25_1_ApplicationPatentIndividualModel>(id.Value) ?? new _25_1_ApplicationPatentIndividualModel());
    
    public async Task<IActionResult> _25_2_ApplicationDeregistrationPatentForm(Guid? id) =>
   PartialView("AdditionalForms/KBR/Federal/_25_2_ApplicationDeregistrationPatent", !id.HasValue ? new _25_2_ApplicationDeregistrationPatentModel()
      : await _caseService.GetAdditionalDataByServiceIdAsync<_25_2_ApplicationDeregistrationPatentModel>(id.Value) ?? new _25_2_ApplicationDeregistrationPatentModel());

    public async Task<IActionResult> _26_СertificateOfPositiveNegativeBalanceForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_26_СertificateOfPositiveNegativeBalance", !id.HasValue ? new _26_СertificateOfPositiveNegativeBalanceModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_26_СertificateOfPositiveNegativeBalanceModel>(id.Value) ?? new _26_СertificateOfPositiveNegativeBalanceModel());

    public async Task<IActionResult> _28_ReconciliationAccessoriesForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_28_ReconciliationAccessories", !id.HasValue ? new _28_ReconciliationAccessoriesModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_28_ReconciliationAccessoriesModel>(id.Value) ?? new _28_ReconciliationAccessoriesModel());

    public async Task<IActionResult> _29_TaxpayerConsentForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_29_TaxpayerConsent", !id.HasValue ? new _29_TaxpayerConsentModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_29_TaxpayerConsentModel>(id.Value) ?? new _29_TaxpayerConsentModel());

    public async Task<IActionResult> _30_TransitionSimplifiedTaxSystemForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_30_TransitionSimplifiedTaxSystem", !id.HasValue ? new _30_TransitionSimplifiedTaxSystemModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_30_TransitionSimplifiedTaxSystemModel>(id.Value) ?? new _30_TransitionSimplifiedTaxSystemModel());

    public async Task<IActionResult> _39_ProvisionInformationEnforcementProceedingsForm(Guid? id) =>
   PartialView("AdditionalForms/KBR/Federal/_39_ProvisionInformationEnforcementProceedings", !id.HasValue ? new _39_ProvisionInformationEnforcementProceedingsModel()
      : await _caseService.GetAdditionalDataByServiceIdAsync<_39_ProvisionInformationEnforcementProceedingsModel>(id.Value) ?? new _39_ProvisionInformationEnforcementProceedingsModel());

    public async Task<IActionResult> _41_4_OrderMonthlyPaymentForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_41_4_OrderMonthlyPayment", !id.HasValue ? new _41_4_OrderMonthlyPaymentModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_41_4_OrderMonthlyPaymentModel>(id.Value) ?? new _41_4_OrderMonthlyPaymentModel());

    public async Task<IActionResult> _41_1_PfrAppointMonthlyCashPaymentsForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_41_1_PfrAppointMonthlyCashPayments", !id.HasValue ? new _41_1_PfrAppointMonthlyCashPaymentsModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_41_1_PfrAppointMonthlyCashPaymentsModel>(id.Value) ?? new _41_1_PfrAppointMonthlyCashPaymentsModel());

    public async Task<IActionResult> _41_2_PfrAppointMonthlyCashPaymentsForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_41_2_PfrAppointMonthlyCashPayments", !id.HasValue ? new _41_2_PfrAppointMonthlyCashPaymentsModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_41_2_PfrAppointMonthlyCashPaymentsModel>(id.Value) ?? new _41_2_PfrAppointMonthlyCashPaymentsModel());

    public async Task<IActionResult> _41_3_PfrAppointMonthlyCashPaymentsForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_41_3_PfrAppointMonthlyCashPayments", !id.HasValue ? new _41_2_PfrAppointMonthlyCashPaymentsModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_41_2_PfrAppointMonthlyCashPaymentsModel>(id.Value) ?? new _41_2_PfrAppointMonthlyCashPaymentsModel());

    public async Task<IActionResult> _41_4_PfrAppointMonthlyCashPaymentsForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_41_4_PfrAppointMonthlyCashPayments", !id.HasValue ? new _41_4_PfrAppointMonthlyCashPaymentsModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_41_4_PfrAppointMonthlyCashPaymentsModel>(id.Value) ?? new _41_4_PfrAppointMonthlyCashPaymentsModel());

    public async Task<IActionResult> _41_5_PfrAppointMonthlyCashPaymentsForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_41_5_PfrAppointMonthlyCashPayments", !id.HasValue ? new _41_2_PfrAppointMonthlyCashPaymentsModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_41_2_PfrAppointMonthlyCashPaymentsModel>(id.Value) ?? new _41_2_PfrAppointMonthlyCashPaymentsModel());

    public async Task<IActionResult> _41_6_PfrAppointMonthlyCashPaymentsForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_41_6_PfrAppointMonthlyCashPayments", !id.HasValue ? new _41_6_PfrAppointMonthlyCashPaymentsModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_41_6_PfrAppointMonthlyCashPaymentsModel>(id.Value) ?? new _41_6_PfrAppointMonthlyCashPaymentsModel());

    public async Task<IActionResult> _41_7_PfrAppointMonthlyCashPaymentsForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_41_7_PfrAppointMonthlyCashPayments", !id.HasValue ? new _41_7_PfrAppointMonthlyCashPaymentsModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_41_7_PfrAppointMonthlyCashPaymentsModel>(id.Value) ?? new _41_7_PfrAppointMonthlyCashPaymentsModel());

    public async Task<IActionResult> _44_1_PfrAdv1Form(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_44_1_PfrAdv1", !id.HasValue ? new _44_1_PfrAdv1Model()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_44_1_PfrAdv1Model>(id.Value) ?? new _44_1_PfrAdv1Model());

    public async Task<IActionResult> _44_2_PfrAdv2Form(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_44_2_PfrAdv2", !id.HasValue ? new _44_2_PfrAdv2Model()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_44_2_PfrAdv2Model>(id.Value) ?? new _44_2_PfrAdv2Model());

    public async Task<IActionResult> _44_3_PfrAdv3Form(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_44_1_PfrAdv1", !id.HasValue ? new _44_1_PfrAdv1Model()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_44_1_PfrAdv1Model>(id.Value) ?? new _44_1_PfrAdv1Model());

    public async Task<IActionResult> _45_ApplicationsDisabledPersonVehicleForm(Guid? id) =>
   PartialView("AdditionalForms/KBR/Federal/_45_ApplicationsDisabledPersonVehicle", !id.HasValue ? new _45_ApplicationsDisabledPersonVehicleModel()
      : await _caseService.GetAdditionalDataByServiceIdAsync<_45_ApplicationsDisabledPersonVehicleModel>(id.Value) ?? new _45_ApplicationsDisabledPersonVehicleModel());

    public async Task<IActionResult> _46_ProvisionTechnicalFacilitiesDisabledForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_46_ProvisionTechnicalFacilitiesDisabled", !id.HasValue ? new _46_ProvisionTechnicalFacilitiesDisabledModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_46_ProvisionTechnicalFacilitiesDisabledModel>(id.Value) ?? new _46_ProvisionTechnicalFacilitiesDisabledModel());

    public async Task<IActionResult> _47_1_PensionAssignmentForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_47_1_PensionAssignment", !id.HasValue ? new _47_1_PensionAssignmentModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_47_1_PensionAssignmentModel>(id.Value) ?? new _47_1_PensionAssignmentModel());

    public async Task<IActionResult> _47_2_RecalculationPensionAmountForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_47_2_RecalculationPensionAmount", !id.HasValue ? new _47_2_RecalculationPensionAmountModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_47_2_RecalculationPensionAmountModel>(id.Value) ?? new _47_2_RecalculationPensionAmountModel());

    public async Task<IActionResult> _49_1_ResumptionPensionPaymentsForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_49_1_ResumptionPensionPayments", !id.HasValue ? new _49_1_ResumptionPensionPaymentsModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_49_1_ResumptionPensionPaymentsModel>(id.Value) ?? new _49_1_ResumptionPensionPaymentsModel());

    public async Task<IActionResult> _49_3_PaymentPensionNotReceivedWithDeathForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_49_3_PaymentPensionNotReceivedWithDeath", !id.HasValue ? new _49_3_PaymentPensionNotReceivedWithDeathModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_49_3_PaymentPensionNotReceivedWithDeathModel>(id.Value) ?? new _49_3_PaymentPensionNotReceivedWithDeathModel());
    public async Task<IActionResult> _49_4_ReimbursementReceivedAmountsPensionsForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_49_4_ReimbursementReceivedAmountsPensions", !id.HasValue ? new _49_4_ReimbursementReceivedAmountsPensionsModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_49_4_ReimbursementReceivedAmountsPensionsModel>(id.Value) ?? new _49_4_ReimbursementReceivedAmountsPensionsModel());

    public async Task<IActionResult> _49_5_StatementDeliveryPensionForm(Guid? id) =>
      PartialView("AdditionalForms/KBR/Federal/_49_5_StatementDeliveryPension", !id.HasValue ? new _49_5_StatementDeliveryPensionModel()
         : await _caseService.GetAdditionalDataByServiceIdAsync<_49_5_StatementDeliveryPensionModel>(id.Value) ?? new _49_5_StatementDeliveryPensionModel());

    public async Task<IActionResult> _49_6_PensionChangingPersonalDataForm(Guid? id) =>
      PartialView("AdditionalForms/KBR/Federal/_49_6_PensionChangingPersonalData", !id.HasValue ? new _49_6_PensionChangingPersonalDataModel()
         : await _caseService.GetAdditionalDataByServiceIdAsync<_49_6_PensionChangingPersonalDataModel>(id.Value) ?? new _49_6_PensionChangingPersonalDataModel());

    public async Task<IActionResult> _49_7_RefusalReceiveAssignedPensionForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_49_7_RefusalReceiveAssignedPension", !id.HasValue ? new _49_7_RefusalReceiveAssignedPensionModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_49_7_RefusalReceiveAssignedPensionModel>(id.Value) ?? new _49_7_RefusalReceiveAssignedPensionModel());

    public async Task<IActionResult> _49_8_TerminationPensionPaymentForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_49_8_TerminationPensionPayment", !id.HasValue ? new _49_8_TerminationPensionPaymentModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_49_8_TerminationPensionPaymentModel>(id.Value) ?? new _49_8_TerminationPensionPaymentModel());

    public async Task<IActionResult> _49_10_PaymentPensionSavingsForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_49_10_PaymentPensionSavings", !id.HasValue ? new _49_10_PaymentPensionSavingsModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_49_10_PaymentPensionSavingsModel>(id.Value) ?? new _49_10_PaymentPensionSavingsModel());

    public async Task<IActionResult> _61_ProvisionMonthlyPaymentBirthBornOrAdoptionChildForm(Guid? id) =>
        PartialView("AdditionalForms/KBR/Federal/_61_ProvisionMonthlyPaymentBirthBornOrAdoptionChild", !id.HasValue ? new _61_ProvisionMonthlyPaymentBirthBornOrAdoptionChildModel()
         : await _caseService.GetAdditionalDataByServiceIdAsync<_61_ProvisionMonthlyPaymentBirthBornOrAdoptionChildModel>(id.Value) ?? new _61_ProvisionMonthlyPaymentBirthBornOrAdoptionChildModel());

    public async Task<IActionResult> _63_1_PaymentsCaringChildrenDisabilitiesForm(Guid? id) =>
        PartialView("AdditionalForms/KBR/Federal/_63_1_PaymentsCaringChildrenDisabilities", !id.HasValue ? new _63_1_PaymentsCaringChildrenDisabilitiesModel()
            : await _caseService.GetAdditionalDataByServiceIdAsync<_63_1_PaymentsCaringChildrenDisabilitiesModel>(id.Value) ?? new _63_1_PaymentsCaringChildrenDisabilitiesModel());

    public async Task<IActionResult> _63_2_RenewalCaringChildrenDisabilitiesForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_63_2_RenewalCaringChildrenDisabilities", !id.HasValue ? new _63_2_RenewalCaringChildrenDisabilitiesModel()
           : await _caseService.GetAdditionalDataByServiceIdAsync<_63_2_RenewalCaringChildrenDisabilitiesModel>(id.Value) ?? new _63_2_RenewalCaringChildrenDisabilitiesModel());

    public async Task<IActionResult> _63_3_ConsentCaringChildrenDisabilitiesForm(Guid? id) =>
      PartialView("AdditionalForms/KBR/Federal/_63_3_ConsentCaringChildrenDisabilities", !id.HasValue ? new _63_3_ConsentCaringChildrenDisabilitiesModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_63_3_ConsentCaringChildrenDisabilitiesModel>(id.Value) ?? new _63_3_ConsentCaringChildrenDisabilitiesModel());

    public async Task<IActionResult> _63_4_TerminationCaringChildrenDisabilitiesForm(Guid? id) =>
     PartialView("AdditionalForms/KBR/Federal/_63_4_TerminationCaringChildrenDisabilities", !id.HasValue ? new _63_4_TerminationCaringChildrenDisabilitiesModel()
        : await _caseService.GetAdditionalDataByServiceIdAsync<_63_4_TerminationCaringChildrenDisabilitiesModel>(id.Value) ?? new _63_4_TerminationCaringChildrenDisabilitiesModel());

    public async Task<IActionResult> _63_5_RecalculationCaringChildrenDisabilitiesForm(Guid? id) =>
     PartialView("AdditionalForms/KBR/Federal/_63_5_RecalculationCaringChildrenDisabilities", !id.HasValue ? new _63_5_RecalculationCaringChildrenDisabilitiesModel()
        : await _caseService.GetAdditionalDataByServiceIdAsync<_63_5_RecalculationCaringChildrenDisabilitiesModel>(id.Value) ?? new _63_5_RecalculationCaringChildrenDisabilitiesModel());

    public async Task<IActionResult> _63_6_NotificationCaringChildrenDisabilitiesForm(Guid? id) =>
     PartialView("AdditionalForms/KBR/Federal/_63_6_NotificationCaringChildrenDisabilities", !id.HasValue ? new _63_6_NotificationCaringChildrenDisabilitiesModel()
        : await _caseService.GetAdditionalDataByServiceIdAsync<_63_6_NotificationCaringChildrenDisabilitiesModel>(id.Value) ?? new _63_6_NotificationCaringChildrenDisabilitiesModel());

    public async Task<IActionResult> _63_7_CertificateCaringChildrenDisabilitiesForm(Guid? id) =>
     PartialView("AdditionalForms/KBR/Federal/_63_7_CertificateCaringChildrenDisabilities", !id.HasValue ? new _63_7_CertificateCaringChildrenDisabilitiesModel()
        : await _caseService.GetAdditionalDataByServiceIdAsync<_63_7_CertificateCaringChildrenDisabilitiesModel>(id.Value) ?? new _63_7_CertificateCaringChildrenDisabilitiesModel());

    public async Task<IActionResult> _63_8_PaymentDeathCaringChildrenDisabilitiesForm(Guid? id) =>
     PartialView("AdditionalForms/KBR/Federal/_63_8_PaymentDeathCaringChildrenDisabilities", !id.HasValue ? new _63_8_PaymentDeathCaringChildrenDisabilitiesModel()
        : await _caseService.GetAdditionalDataByServiceIdAsync<_63_8_PaymentDeathCaringChildrenDisabilitiesModel>(id.Value) ?? new _63_8_PaymentDeathCaringChildrenDisabilitiesModel());

    public async Task<IActionResult> _63_9_PaymentRemainsCaringChildrenDisabilitiesForm(Guid? id) =>
     PartialView("AdditionalForms/KBR/Federal/_63_9_PaymentRemainsCaringChildrenDisabilities", !id.HasValue ? new _63_9_PaymentRemainsCaringChildrenDisabilitiesModel()
        : await _caseService.GetAdditionalDataByServiceIdAsync<_63_9_PaymentRemainsCaringChildrenDisabilitiesModel>(id.Value) ?? new _63_9_PaymentRemainsCaringChildrenDisabilitiesModel());

    public async Task<IActionResult> _64_1_PaymentCareDisabledCitizensForm(Guid? id) =>
    PartialView("AdditionalForms/KBR/Federal/_64_1_PaymentCareDisabledCitizens", !id.HasValue ? new _64_1_PaymentCareDisabledCitizensModel()
       : await _caseService.GetAdditionalDataByServiceIdAsync<_64_1_PaymentCareDisabledCitizensModel>(id.Value) ?? new _64_1_PaymentCareDisabledCitizensModel());

    public async Task<IActionResult> _64_2_ConsentCareDisabledCitizensForm(Guid? id) =>
      PartialView("AdditionalForms/KBR/Federal/_64_2_ConsentCareDisabledCitizens", !id.HasValue ? new _64_2_ConsentCareDisabledCitizensModel()
         : await _caseService.GetAdditionalDataByServiceIdAsync<_64_2_ConsentCareDisabledCitizensModel>(id.Value) ?? new _64_2_ConsentCareDisabledCitizensModel());

    public async Task<IActionResult> _64_3_RenewalCareDisabledCitizensForm(Guid? id) =>
      PartialView("AdditionalForms/KBR/Federal/_64_3_RenewalCareDisabledCitizens", !id.HasValue ? new _64_3_RenewalCareDisabledCitizensModel()
         : await _caseService.GetAdditionalDataByServiceIdAsync<_64_3_RenewalCareDisabledCitizensModel>(id.Value) ?? new _64_3_RenewalCareDisabledCitizensModel());

    public async Task<IActionResult> _64_4_CertificateCareDisabledCitizensForm(Guid? id) =>
      PartialView("AdditionalForms/KBR/Federal/_64_4_CertificateCareDisabledCitizens", !id.HasValue ? new _64_4_CertificateCareDisabledCitizensModel()
         : await _caseService.GetAdditionalDataByServiceIdAsync<_64_4_CertificateCareDisabledCitizensModel>(id.Value) ?? new _64_4_CertificateCareDisabledCitizensModel());

    public async Task<IActionResult> _64_5_TerminationCareDisabledCitizensForm(Guid? id) =>
     PartialView("AdditionalForms/KBR/Federal/_64_5_TerminationCareDisabledCitizens", !id.HasValue ? new _64_5_TerminationCareDisabledCitizensModel()
        : await _caseService.GetAdditionalDataByServiceIdAsync<_64_5_TerminationCareDisabledCitizensModel>(id.Value) ?? new _64_5_TerminationCareDisabledCitizensModel());

    public async Task<IActionResult> _64_6_NotificationCareDisabledCitizensForm(Guid? id) =>
     PartialView("AdditionalForms/KBR/Federal/_64_6_NotificationCareDisabledCitizens", !id.HasValue ? new _64_6_NotificationCareDisabledCitizensModel()
        : await _caseService.GetAdditionalDataByServiceIdAsync<_64_6_NotificationCareDisabledCitizensModel>(id.Value) ?? new _64_6_NotificationCareDisabledCitizensModel());

    public async Task<IActionResult> _64_7_PaymentDeathCareDisabledCitizensForm(Guid? id) =>
     PartialView("AdditionalForms/KBR/Federal/_64_7_PaymentDeathCareDisabledCitizens", !id.HasValue ? new _64_7_PaymentDeathCareDisabledCitizensModel()
        : await _caseService.GetAdditionalDataByServiceIdAsync<_64_7_PaymentDeathCareDisabledCitizensModel>(id.Value) ?? new _64_7_PaymentDeathCareDisabledCitizensModel());

    public async Task<IActionResult> _64_8_PaymentRemainsCareDisabledCitizensForm(Guid? id) =>
     PartialView("AdditionalForms/KBR/Federal/_64_8_PaymentRemainsCareDisabledCitizens", !id.HasValue ? new _64_8_PaymentRemainsCareDisabledCitizensModel()
        : await _caseService.GetAdditionalDataByServiceIdAsync<_64_8_PaymentRemainsCareDisabledCitizensModel>(id.Value) ?? new _64_8_PaymentRemainsCareDisabledCitizensModel());

    public async Task<IActionResult> _69_1_AmountPensionsForm(Guid? id) =>
      PartialView("AdditionalForms/KBR/Federal/_69_1_AmountPensions", !id.HasValue ? new _69_1_AmountPensionsModel()
         : await _caseService.GetAdditionalDataByServiceIdAsync<_69_1_AmountPensionsModel>(id.Value) ?? new _69_1_AmountPensionsModel());

    public async Task<IActionResult> _52_ProvisionCompensationForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_52_ProvisionCompensation", !id.HasValue ? new _52_ProvisionCompensationModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_52_ProvisionCompensationModel>(id.Value) ?? new _52_ProvisionCompensationModel());

    public async Task<IActionResult> _69_2_AmountPensionsForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_69_2_AmountPensions", !id.HasValue ? new _69_2_AmountPensionsModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_69_2_AmountPensionsModel>(id.Value) ?? new _69_2_AmountPensionsModel());

    public async Task<IActionResult> _70_ApplicationEstablishmentSecretCodeForm(Guid? id) =>
      PartialView("AdditionalForms/KBR/Federal/_70_ApplicationEstablishmentSecretCode", !id.HasValue ? new _70_ApplicationEstablishmentSecretCodeModel()
         : await _caseService.GetAdditionalDataByServiceIdAsync<_70_ApplicationEstablishmentSecretCodeModel>(id.Value) ?? new _70_ApplicationEstablishmentSecretCodeModel());
    
    public async Task<IActionResult> _73_RefusalBiometricsForm(Guid? id) =>
      PartialView("AdditionalForms/KBR/Federal/_73_RefusalBiometrics", !id.HasValue ? new _73_RefusalBiometricsModel()
         : await _caseService.GetAdditionalDataByServiceIdAsync<_73_RefusalBiometricsModel>(id.Value) ?? new _73_RefusalBiometricsModel());

    public async Task<IActionResult> _InformingClassificationPreRetirementAgeForm(Guid? id) =>
      PartialView("AdditionalForms/KBR/Federal/_InformingClassificationPreRetirementAge", !id.HasValue ? new _InformingClassificationPreRetirementAgeModel()
         : await _caseService.GetAdditionalDataByServiceIdAsync<_InformingClassificationPreRetirementAgeModel>(id.Value) ?? new _InformingClassificationPreRetirementAgeModel());

    public async Task<IActionResult> _IndividualPersonalAccountsForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_IndividualPersonalAccounts", !id.HasValue ? new _IndividualPersonalAccountsModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_IndividualPersonalAccountsModel>(id.Value) ?? new _IndividualPersonalAccountsModel());

    public async Task<IActionResult> _78_1_MvdRegistrationForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_78_1_MvdRegistration", !id.HasValue ? new _78_1_MvdRegistrationModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_78_1_MvdRegistrationModel>(id.Value) ?? new _78_1_MvdRegistrationModel());

    public async Task<IActionResult> _78_2_MvdRegistrationPlaceStayForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_78_2_MvdRegistrationPlaceStay", !id.HasValue ? new _78_2_MvdRegistrationPlaceStayModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_78_2_MvdRegistrationPlaceStayModel>(id.Value) ?? new _78_2_MvdRegistrationPlaceStayModel());

    public async Task<IActionResult> _78_3_MvdDe_RegistrationForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_78_3_MvdDe_Registration", !id.HasValue ? new _78_3_MvdDe_RegistrationModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_78_3_MvdDe_RegistrationModel>(id.Value) ?? new _78_3_MvdDe_RegistrationModel());

    public async Task<IActionResult> _78_4_MvdDe_RegistrationStayForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_78_4_MvdDe_RegistrationStay", !id.HasValue ? new _78_4_MvdDe_RegistrationStayModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_78_4_MvdDe_RegistrationStayModel>(id.Value) ?? new _78_4_MvdDe_RegistrationStayModel());

    public async Task<IActionResult> _79_1_InternationalPassportTenYearForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_79_1_InternationalPassportTenYear", !id.HasValue ? new _79_1_InternationalPassportTenYearModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_79_1_InternationalPassportTenYearModel>(id.Value) ?? new _79_1_InternationalPassportTenYearModel());

    public async Task<IActionResult> _80_AdministrativeOffensesForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_80_AdministrativeOffenses", !id.HasValue ? new _80_AdministrativeOffensesModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_80_AdministrativeOffensesModel>(id.Value) ?? new _80_AdministrativeOffensesModel());

    public async Task<IActionResult> _92_1_ImplementationMigrationRegistrationForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_92_1_ImplementationMigrationRegistration", !id.HasValue ? new _92_1_ImplementationMigrationRegistrationModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_92_1_ImplementationMigrationRegistrationModel>(id.Value) ?? new _92_1_ImplementationMigrationRegistrationModel());

    public async Task<IActionResult> _92_2_DepartureForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_92_2_Departure", !id.HasValue ? new _92_2_DepartureModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_92_2_DepartureModel>(id.Value) ?? new _92_2_DepartureModel());

    public async Task<IActionResult> _92_3_WithdrawalForeignResidenceForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_92_3_WithdrawalForeignResidence", !id.HasValue ? new _92_3_WithdrawalForeignResidenceModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_92_3_WithdrawalForeignResidenceModel>(id.Value) ?? new _92_3_WithdrawalForeignResidenceModel());

    public async Task<IActionResult> _92_4_RemovalForeignResidenceForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_92_4_RemovalForeignResidence", !id.HasValue ? new _92_4_RemovalForeignResidenceModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_92_4_RemovalForeignResidenceModel>(id.Value) ?? new _92_4_RemovalForeignResidenceModel());

    public async Task<IActionResult> _98_1_PassportIssuancForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_98_1_PassportIssuanc", !id.HasValue ? new _98_1_PassportIssuancModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_98_1_PassportIssuancModel>(id.Value) ?? new _98_1_PassportIssuancModel());

    public async Task<IActionResult> _99_1_InternationalPassportFiveYearForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_99_1_InternationalPassportFiveYear",
          !id.HasValue
          ? new _99_1_InternationalPassportFiveYearModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_99_1_InternationalPassportFiveYearModel>(id.Value) ?? new _99_1_InternationalPassportFiveYearModel());

    public async Task<IActionResult> _99_2_InternationalPassportFiveYearForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_99_2_InternationalPassportFiveYear",
          !id.HasValue
          ? new _99_2_InternationalPassportFiveYearModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_99_2_InternationalPassportFiveYearModel>(id.Value) ?? new _99_2_InternationalPassportFiveYearModel());

    public async Task<IActionResult> _105_ApostilleAffixingForm(Guid? id) =>
       PartialView("AdditionalForms/KBR/Federal/_105_ApostilleAffixing",
          !id.HasValue
          ? new _105_ApostilleAffixingModel()
          : await _caseService.GetAdditionalDataByServiceIdAsync<_105_ApostilleAffixingModel>(id.Value) ?? new _105_ApostilleAffixingModel());

    public async Task<IActionResult> _47_ProvisionTechnicalFacilitiesDisabledForm() =>
       PartialView("AdditionalForms/KBR/Federal/_47_ProvisionTechnicalFacilitiesDisabled",
          new _46_ProvisionTechnicalFacilitiesDisabledModel());

    public async Task<IActionResult> PfrChildBenefitsKbrForm(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/KBR/Federal/_PfrChildBenefits", new PfrChildBenefitsKbrModel());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<PfrChildBenefitsKbrModel>(id.Value);
        return PartialView("AdditionalForms/KBR/Federal/_PfrChildBenefits", model ?? new PfrChildBenefitsKbrModel());
    }

    public async Task<IActionResult> FnsAccountingKbrForm(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/KBR/Federal/_FnsAccounting", new FnsAccountingKbrModel());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<FnsAccountingKbrModel>(id.Value);
        return PartialView("AdditionalForms/KBR/Federal/_FnsAccounting", model ?? new FnsAccountingKbrModel());
    }

    public async Task<IActionResult> DisqualifiedPersonsKbrForm(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/KBR/Federal/DisqualifiedPersons", new DisqualifiedPersonsKbrModel());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<DisqualifiedPersonsKbrModel>(id.Value);
        return PartialView("AdditionalForms/KBR/Federal/DisqualifiedPersons", model ?? new DisqualifiedPersonsKbrModel());
    }

    public async Task<IActionResult> AllowanceBirthUpbringingChildrenKbrForm(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/KBR/Federal/_AllowanceBirthUpbringingChildren", new AllowanceBirthUpbringingChildrenModel());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<AllowanceBirthUpbringingChildrenModel>(id.Value);
        return PartialView("AdditionalForms/KBR/Federal/_AllowanceBirthUpbringingChildren", model ?? new AllowanceBirthUpbringingChildrenModel());
    }

    public async Task<IActionResult> AllowanceBirthUpbringingChildrenDeliveryMethodKbrForm(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/KBR/Federal/_AllowanceBirthUpbringingChildrenDeliveryMethod", new AllowanceBirthUpbringingChildrenDeliveryMethodModel());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<AllowanceBirthUpbringingChildrenDeliveryMethodModel>(id.Value);
        return PartialView("AdditionalForms/KBR/Federal/_AllowanceBirthUpbringingChildrenDeliveryMethod", model ?? new AllowanceBirthUpbringingChildrenDeliveryMethodModel());
    }

    public async Task<IActionResult> UnregisterDeadForm(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/KBR/Federal/UnregisterDead", new UnregisterDeadModel());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<UnregisterDeadModel>(id.Value);
        return PartialView("AdditionalForms/KBR/Federal/UnregisterDead", model ?? new UnregisterDeadModel());
    }
}