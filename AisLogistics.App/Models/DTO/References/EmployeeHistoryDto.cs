namespace AisLogistics.App.Models.DTO.References
{
    public class EmployeeHistoryDto
    {
        public Guid Id { get; set; }
        public Guid SEmployeesId { get; set; }
        public Guid SOfficeId { get; set; }
        public string EmployeeName { get; set; }
        public string OfficeName { get; set; }
        public string LogInDate { get; set; }
        public string LogInIp { get; set; }
    }
}
