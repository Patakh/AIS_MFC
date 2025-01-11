using AisLogistics.App.Models.AdditionalForms;
namespace AisLogistics.App.Models;

public sealed class _45_ApplicationsDisabledPersonVehicleModel : AbstractAdditionalFormModel
{
    public string RegisterNumberTransport { get; set; }
    public string BrandAndModelTransport { get; set; }
    public DateTime? DateStart { get; set; }
    public DateTime? DateEnd { get; set; }
    public string NotificationEmail { get; set; }
}
