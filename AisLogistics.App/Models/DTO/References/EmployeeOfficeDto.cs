namespace AisLogistics.App.Models.DTO.References
{
    public class EmployeeOfficeDto
    {
        public Guid Id { get; set; }
        public Guid SEmployeesId { get; set; }
        public Guid SOfficeId { get; set; }
        public bool IsOfficesActive {get;set;}
        public string EmployeeName { get; set; }
        public string OfficeName { get; set; }
        public string DateStart { get; set; }
        public string? DateStop { get; set; }
        public string EmployeesFioAdd { get; set; }
        public string DateAdd { get; set; }
        public bool IsRemoveActive { get; set; }
    }
}
