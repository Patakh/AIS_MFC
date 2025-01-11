namespace AisLogistics.App.Models.DTO.Cases
{
    public class CasesServiceCopyDto
    {
        public Guid Id { get; set; }    
        public Guid ServiceId { get; set; }
        public int CustomerType { get; set; }
        public Guid ProcedureId { get; set; }
        public string ServiceName { get; set; }
        public string ProviderName { get; set; }
        public string CustomerName { get; set; }
    }
}
