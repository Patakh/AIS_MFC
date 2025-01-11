using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.ViewModels.ReestrTransferDocuments
{
    public class SearchTransferDocumentsRequestData
    {
        public Guid ServiceId { get; internal set; }
        public Guid ProvidersId { get; internal set; }
        public Guid? DepartamentId { get; internal set; }
    }
    public class SearchTransferDocumentsResponceData
    {
        public SelectList OfficesList { get; internal set; }
        public SelectList ServicesList { get; internal set; }
    }
}
