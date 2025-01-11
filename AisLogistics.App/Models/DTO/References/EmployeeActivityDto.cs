namespace AisLogistics.App.Models.DTO.References
{
    public class EmployeeActivityDto
    {
        public Guid Id { get; set; }
        public Guid SEmployeesId { get; set; }
        public bool IsActive { get; set; }
        public string DateStart { get; set; }
        public string? DateStop { get; set; }
        public string Commentt { get; set; }
        public string EmployeesFioAdd { get; set; }
        public string DateAdd { get; set; }
        public bool IsRemoveActive { get; set; }
    }
}
