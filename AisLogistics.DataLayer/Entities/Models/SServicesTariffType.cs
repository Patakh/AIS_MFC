using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник типов тарифов
    /// </summary>
    public partial class SServicesTariffType
    {
        public SServicesTariffType()
        {
            AServices = new HashSet<AService>();
            DServices = new HashSet<DService>();
            SServicesCustomerTariffs = new HashSet<SServicesCustomerTariff>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование типа трифа
        /// </summary>
        public string TariffTypeName { get; set; }

        public virtual ICollection<AService> AServices { get; set; }
        public virtual ICollection<DService> DServices { get; set; }
        public virtual ICollection<SServicesCustomerTariff> SServicesCustomerTariffs { get; set; }
    }
}
