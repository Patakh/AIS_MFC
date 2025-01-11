namespace AisLogistics.App.Models.DTO.References
{
    public class SmevServiceDto
    {
        public Guid Id { get; set; }
        public string SmevName { get; set; }
        public string SmevMnemo { get; set; }
        public string SmevProvider { get; set; }
        public string ProviderCode { get; set; }
        public string ProviderName { get; set; }
        public string SmevDescription { get; set; }
        public string ProviderUrl { get; set; }
        public bool IsSmev3 { get; set; }
    }
}
