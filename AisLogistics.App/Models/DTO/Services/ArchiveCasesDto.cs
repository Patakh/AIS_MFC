namespace AisLogistics.App.Models.DTO.Services
{
    public sealed class ArchiveCaseDetailsDto
    {
        public string CaseId { get; set; }
        public ArchiveCaseServiceInfoDto Info { get; set; }
        public IEnumerable<ArchiveCaseServiceDocumentsDto> Documents { get; set; }
        public IEnumerable<ArchiveCaseServiceDocumentsDto> Results { get; set; }
        public IEnumerable<CaseServiceSmevСompletedDto> Smev { get; set; }
        public IEnumerable<CaseCommentsDto> Comments { get; set; }
        public IEnumerable<CaseServiceStageDto> Stages { get; set; }
        public IEnumerable<CaseAuditDto> Audits { get; set; }
        public IEnumerable<ApplicantAdditionalDto> Customers { get; set; }
    }

    public sealed class ArchiveCaseServiceInfoDto
    {
        public string Name { get; set; }
        public string Office { get; set; }
        public DateTime DateAdd { get; set; }
        public bool IsRoot { get; set; }
        public StatusDto Status { get; set; }
    }

    public class ArchiveCaseServiceDocumentsDto : FileDto
    {
        public Guid DocumentId { get; set; }
        public string DocumentName { get; set; }
    }
}