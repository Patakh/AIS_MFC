namespace AisLogistics.App.Models.DTO.References
{
    public class ServiceCustomerDto
    {
        public Guid Id { get; set; }
        public Guid SServicesId { get; set; }
        public int SServicesCustomerTypeId { get; set; }
        public string TypeName { get; set; }
    }
}
