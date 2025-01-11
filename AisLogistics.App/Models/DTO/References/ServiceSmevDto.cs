namespace AisLogistics.App.Models.DTO.References
{
    public class ServiceSmevDto
    {
        public Guid Id { get; set; }
        public Guid SServicesId { get; set; }
        public int SSmevRequestId { get; set; }
        public string SmevName { get; set; }
        public string SmevProvider { get; set; }
        public string RequestName { get; set; }
        public int CountDayExecution { get; set; }
    }
}
