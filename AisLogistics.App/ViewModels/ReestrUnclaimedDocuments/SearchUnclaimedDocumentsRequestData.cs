using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.ViewModels.ReestrUnclaimedDocuments
{
    public class SearchUnclaimedDocumentsRequestData
    {
        public Guid ServiceId { get; internal set; }
        public Guid ProvidersId { get; internal set; }
        public Guid? DepartamentId { get; internal set; }
    }
    public class SearchUnclaimedDocumentsResponceData
    {
        public SelectList OfficesList { get; internal set; }
        public SelectList ServicesList { get; internal set; }
    }
}
