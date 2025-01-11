namespace AisLogistics.App.Models.DTO.Identity
{
    public interface IUserDto<TKey>
    {
        TKey Id { get; set; }
        string UserName { get; set; }
        string Email { get; set; }
        bool EmailConfirmed { get; set; }
        bool LockoutEnabled { get; set; }
        bool TwoFactorEnabled { get; set; }
        int AccessFailedCount { get; set; }
        DateTimeOffset? LockoutEnd { get; set; }
    }
}
