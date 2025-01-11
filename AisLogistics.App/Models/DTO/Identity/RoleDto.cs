namespace AisLogistics.App.Models.DTO.Identity
{
    public class RoleDto<TKey> : IRoleDto<TKey>
    {
        public TKey Id { get; set; }
        public string Name { get; set; }
    }
}
