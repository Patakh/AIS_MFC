namespace AisLogistics.App.Models.DTO.References
{
    /// Справочники - Услуги 
    public class ServicesDto
    {
        public Guid Id { get; set; }
        public string ServiceName { get; set; }
        public string OfficeName { get; set; }
        public string Mnemo {  get; set; }
        public string SServicesTypeName { get; set; }
        public string SServicesInteractionName { get; set; }
    }
}
