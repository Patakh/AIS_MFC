using AisLogistics.App.Models.AdditionalForms;

namespace AisLogistics.App.Models;

public sealed class _39_ProvisionInformationEnforcementProceedingsModel : AbstractAdditionalFormModel
{
    public int TypeApplicant { get; set; }
    public string EnforcementProceeding { get; set; }
    public int WhoIs { get; set; }
    public int WayGetResult { get; set; }
    public string MailAddress { get; set; }
    public bool ConsentToQualityAssessment { get; set; }
    public string PhoneNumber { get; set; }
}