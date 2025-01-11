namespace AisLogistics.App.Models.DTO.Cases
{
    public class ServiceDocumentsDto
    {
        public Guid ServiceId { get; set; }
        public string CasesId { get; set; }
        public Guid DocumentId { get; set; }
        public int DocumentNeeds { get; set; }
        public int DocumentType { get; set; }
        public int DocumentCount { get; set; }
        public string Commentt { get; set; }
        public string? EmployeesFioAdd { get; set; }
        public DateTime DateAdd { get; set; }
        public Guid? SEmployeesId { get; set; }
    }
}
