using AisLogistics.App.Models.DTO.Services;

namespace AisLogistics.App.Models.DTO.Cases
{
    public class CasesIncomingDocumentDto
    {
        public Guid ServiceId { get; set; }
        public string CasesNumber { get; set; }
        public ApplicantDto? Applicant { get; set; }
        public List<StageNext> StagesNext { get; set; } = new List<StageNext>();

    }


    public class StageNext
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
