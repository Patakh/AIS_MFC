namespace AisLogistics.App.Models.DTO.References
{
    public class ServiceQualityTypeDto
    {
        public Guid Id { get; set; }
        public Guid SServicesId { get; set; }
        public int SServicesTypeQualityId { get; set; }
        public string TypeName { get; set; }
    }
}
