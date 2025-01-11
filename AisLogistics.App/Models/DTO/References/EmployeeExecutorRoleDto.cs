namespace AisLogistics.App.Models.DTO.References
{
    public class EmployeeExecutorRoleDto
    {
        public Guid Id { get; set; }
        public Guid SEmployeesId { get; set; }
        public Guid SRolesExecutorId { get; set; }
        public string RoleName { get; set; }
        public string EmployeesFioAdd { get; set; }
        public string DateAdd { get; set; }
    }
}
