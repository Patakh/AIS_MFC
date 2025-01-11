namespace AisLogistics.App.Models.AdditionalForms.Regional
{
    public sealed class AllowanceBirthUpbringingChildrenDeliveryMethodModel : AbstractAdditionalFormModel
    {
        public PaymentType Payment { get; set; }
        public class PaymentType
        {
            public string Type { get; set; }
            public string BankName { get; set; }
            public string BankBik { get; set; }
            public string BankInn { get; set; }
            public string BankScore { get; set; }
            public string BankNumber { get; set; }
            public Address Address { get; set; }
            public string BankAddressMatches { get; set; }
        }

        public class Address
        {
            public string FiasHouseCode { get; set; }
            public string Town { get; set; }
            public string Street { get; set; }
            public string House { get; set; }
            public string Building { get; set; }
            public string Apartmen { get; set; }
            public string PostalCode { get; set; }
            public string FullAddress { get; set; }
        }
    }
}
