namespace AisLogistics.App.Models.DTO.Cases
{
    public class ServiceStageNextEmployessDto
    {
        public List<Guid> serviceId { get; set; }
        public Guid officeId { get; set; }
        public int stageId { get; set; }
    }
}
