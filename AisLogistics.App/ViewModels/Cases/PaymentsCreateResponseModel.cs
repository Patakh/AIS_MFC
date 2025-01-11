using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.ViewModels.Cases
{
    public class PaymentsCreateResponseModel : ServicePaymentsInfo
    {
        public SelectList CustomerPayments { get; set; }
        public SelectList PaymentBeneficiaries { get; set; }
        public SelectList DAcquirings { get; set; }
    }

    public class ServicePaymentsInfo {
        public string DCaseId { get; set; }
        public Guid DServicesId { get; set; }
        public Guid SOfficesIdProvider { get; set; }
        public string ServiceName { get; set; }
        public decimal? TariffState { get; set; }
        public decimal? TariffMfc { get; set; }
    }

    public class CustomerPayments
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
    }
}
