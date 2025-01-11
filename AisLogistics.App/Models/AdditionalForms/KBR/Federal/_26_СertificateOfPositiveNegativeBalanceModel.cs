using AisLogistics.App.Models.AdditionalForms;
namespace AisLogistics.App.Models;

public sealed class _26_СertificateOfPositiveNegativeBalanceModel : AbstractAdditionalFormModel
{
    public string Code { get; set; }
    public int ApplicantAttribute { get; set; }
    public int PleaseProvideCertificate { get; set; }
    public DateTime? DateStart { get; set; }
    public DateTime? DateEnd { get; set; }
    public int MethodOfIssuingCertificate { get; set; }
}
