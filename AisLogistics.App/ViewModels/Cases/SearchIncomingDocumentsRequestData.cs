using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.ViewModels.Cases
{
    public class SearchIncomingDocumentsRequestData
    {
        public Guid ServiceId { get; internal set; }
        public Guid ProvidersId { get; internal set; }
        public Guid? DepartamentId { get; internal set; }
    }
    public class SearchIncomingDocumentsResponceData
    {
        public SelectList OfficesList { get; internal set; }
        public SelectList ServicesList { get; internal set; }
    }
}
