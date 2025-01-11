namespace AisLogistics.API.Models.Responce
{
    public class ServicesTariffsInfoResponse
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public string Name { get; set; }
        public decimal Tariff { get; set; }
        public decimal TariffMfc { get; set; }
    }
}
