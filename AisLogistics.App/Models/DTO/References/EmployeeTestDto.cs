namespace AisLogistics.App.Models.DTO.References
{
    public class EmployeeTestDto
    {
        public Guid Id { get; set; }
        public Guid SEmployeesId { get; set; }
        public int TestNumber { get; set; }
        public string TestName { get; set; }
        public string DateStartActiveTest { get; set; }
        public bool IsDateStartActiveTest { get; set; }
        public short CountQuestion { get; set; }    
        public short CountMinute { get; set; }
        public string? DateStartEmployee{ get; set; }
        public string? DateStopEmployee { get; set; }
        public short? Percent { get; set; }
        public string Commentt { get; set; }
        public string DateAdd { get; set; }
        public string EmployeesFioAdd { get; set; }
    }
}
