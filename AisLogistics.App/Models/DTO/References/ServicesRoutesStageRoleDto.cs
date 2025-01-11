namespace AisLogistics.App.Models.DTO.References
{
    public class ServicesRoutesStageRoleDto
    {
        public Guid Id { get; set; }
        public Guid SServicesRoutesStageId { get; set; }
        public Guid SRolesExecutorId { get; set; }
        public string RoleName { get; set; }
    }
}
