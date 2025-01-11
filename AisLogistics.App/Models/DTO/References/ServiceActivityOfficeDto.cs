namespace AisLogistics.App.Models.DTO.References
{
    public class ServiceActivityOfficeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int OfficeTypeId { get; set; }
    }
}
