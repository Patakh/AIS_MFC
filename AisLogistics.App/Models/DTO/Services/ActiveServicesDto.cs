namespace AisLogistics.App.Models.DTO.Services
{
    public class ActiveServicesDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string NameSmall { get; set; }
        public string ProviderName { get; set; }
        public bool isFavorite { get; set; }    
    }
}
