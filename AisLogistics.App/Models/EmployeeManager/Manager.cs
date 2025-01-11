namespace AisLogistics.App.Models
{
    public class EmployeeInfo
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public EmployeeJobInfo Job { get; set; }
        public EmployeeOfficeInfo Office { get; set; }
    }
    public class EmployeeJobInfo
    {
        public EmployeeJobInfo(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class EmployeeOfficeInfo
    {
        public EmployeeOfficeInfo() { }

        public EmployeeOfficeInfo(Guid id, string name, string mnemo)
        {
            Id = id;
            Name = name;
            Mnemo = mnemo;
        }
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Mnemo { get; set; }
    }
    public class EmployeesAuthorizationLog
    {
        public EmployeesAuthorizationLog(Guid sEmployeesId, Guid sOfficesId)
        {
            SEmployeesId = sEmployeesId;
            SOfficesId = sOfficesId;
        }

        public Guid SEmployeesId { get; set; }
        public Guid SOfficesId { get; set; }
        public DateTime LogInDate { get; set; }
        public string? LogInBrowserName { get; set; }
        public string? LogInBrowserVersion { get; set; }
        public string? LogInIp { get; set; }
        public string? LogInProvider { get; set; }
    }
}
