using AisLogistics.App.Models.DTO.Services;

namespace AisLogistics.App.Models.DTO.ReestrTransferDocuments
{

    public class ReestrCasesTransferDocumentsDTO
    {
        public Guid Id { get; set; }    
        public Guid DReestrId { get; set; }
        public Guid ServiceId { get; set; }
        public string CasesNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone1 { get; set; }
        public string CustomerPhone2 { get; set; }
    }

    public class CasesTransferDocumentDto
    {
        public Guid ServiceId { get; set; }
        public string CasesNumber { get; set; }
        public ApplicantDto? Applicant { get; set; }
        public string ServiceRourteStage { get; set; }
        public string CurrentEmployee { get; set; }
    }

}
