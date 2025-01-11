namespace AisLogistics.App.Models.DTO.References
{
    public class ServiceWayGetDto
    {
        public Guid Id { get; set; }
        public Guid SServicesId { get; set; }
        public int SServicesWayGetId { get; set; }
        public int WayType { get; set; }
        public string NameWay { get; set; }
    }
}
