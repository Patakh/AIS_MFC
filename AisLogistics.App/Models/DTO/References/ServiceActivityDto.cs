namespace AisLogistics.App.Models.DTO.References
{
    public class ServiceActivityDto
    {
        public Guid Id { get; set; }
        public Guid SServicesId { get; set; }
        public bool IsServicesActive { get; set; }
        public bool IsRemoveActive { get; set; }
        public string OfficeName { get; set; }
        public string EmployeesFioAdd { get; set; }
        public string DateAdd { get; set; }
        public string Commentt { get; set; }
        public string DateStart { get; set; }
        public string? DateStop { get; set; }
        public Guid SEmployeesIdAdd { get; set; }
    }
}
