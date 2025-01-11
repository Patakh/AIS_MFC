namespace AisLogistics.App.Models.DTO.References
{
    public class ServiceFileDto
    {
        public Guid Id { get; set; }
        public Guid? SServicesId { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public string FileExpansion { get; set; }
        public string Commentt { get; set; }
        public string? ProcedureName { get; set; }
        public string EmployeesFioAdd { get; set; }  
    }
}
