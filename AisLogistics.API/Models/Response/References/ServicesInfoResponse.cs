using AisLogistics.API.Models.Responce.References;

namespace AisLogistics.API.Models.Responce
{
    public class Services
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string NameSmall { get; set; }
        public string NameSite { get; set; }
        public string Description { get; set; }
        public string TypeName { get; set; }
        public string ProviderName { get; set; }
        public string LegalAct { get; set; }
        public int TypeId { get; set; }
        public Guid ProviderId { get; set; }
    }

    public class ServicesInfoResponse : Services
    {
        public List<LivingSituationInfoResponse>? LivingSituationInfoResponses { get; set; }
        public List<ServicesRecipientsInfoResponse>? ServicesRecipientsInfoResponses { get; set; }
        public List<ServicesDocumentsInfoResponse>? ServicesDocumentsInfoResponses { get; set; } 
        public List<ServicesDocumentResultsInfoResponse>? ServicesDocumentResultsInfoResponses { get; set; } 
        public List<ServicesTariffsInfoResponse>? ServicesTariffsInfoResponses { get; set; }
        public List<ServicesWaysGetsInfoResponse>? ServicesWaysGetsInfoResponses { get; set; }
        public List<ServicesReasonsInfoResponse>? ServicesReasonsInfoResponses { get; set; } 
        public List<ServicesFilesInfoResponse>? servicesFilesInfoResponses { get; set; } 
    }

    public class ServicesListInfoResponse : Services
    {

    }

    public class ServicesPopularInfoResponse : ServicesListInfoResponse
    {
        public int CountServices { get; set; }
    }
}
