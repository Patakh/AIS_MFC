namespace AisLogistics.App.Models.DTO.Identity
{
    public class UserRoleChangeDto
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public bool Selected { get; set; }
    }
}
