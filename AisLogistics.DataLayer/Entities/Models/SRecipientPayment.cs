using System;

namespace AisLogistics.DataLayer.Entities.Models
{
    public class SRecipientPayment
    {
        public Guid Id { get; set; }
        public Guid SOfficesId { get; set; }
        public Guid SOfficesIdMfc { get; set; }
        public string OfficeInn { get; set; }
        public string OfficeKpp { get; set; }
        public string OfficeOktmo { get; set; }
        public string OfficeBik { get; set; }
        public string OfficeRs { get; set; }
        public string OfficeBankName { get; set; }
        public string OfficeKs { get; set; }
        public string Purpose { get; set; }
        public string OfficeBeneficiaryName { get; set; }
    }
}
