namespace AisLogistics.App.Models.DTO.References
{
    public class EmployeeJobDto
    {
        public Guid Id { get; set; }
        public Guid SEmployeesId { get;set; }
        public Guid SOfficeId { get; set; }
        public int SJobPositionId { get; set; }
        public string EmployeeName { get; set; }    
        public string OfficeName { get; set; }
        public string JobPositionName { get; set; }
        public decimal EmployeeIntensity { get; set; }
        public decimal EmployeeRate { get; set; }
        public string DateStart { get; set; }
        public string? DateStop { get; set; }
        public string EmployeesFioAdd { get; set; }
        public string DateAdd { get; set; }
        public bool IsRemoveActive { get; set; }
        public bool IsJobActive { get; set; }
    }
}
