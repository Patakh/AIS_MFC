namespace AisLogistics.App.Models.DTO.Identity
{
    public interface IRoleDto<TKey>
    {
        TKey Id { get; set; }
        string Name { get; set; }
    }
}
