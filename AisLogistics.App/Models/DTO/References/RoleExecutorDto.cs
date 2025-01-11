namespace AisLogistics.App.Models.DTO.References
{
    public class RoleExecutorDto
    {
        public Guid Id { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public string EmployeesFioAdd { get; set; }
        public bool IsRemove { get; set; }
        public string DateAdd { get; set; }
    }
}
