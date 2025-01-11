namespace AisLogistics.App.Models.DTO.Identity
{
    public class IdentityUserDto : UserDto<Guid>
    {
        public bool IsLockedout { get => (DateTime.UtcNow < LockoutEnd.GetValueOrDefault().DateTime); }
    }
}
