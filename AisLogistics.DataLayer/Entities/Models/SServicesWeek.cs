using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Таблица типов расчета дней
    /// </summary>
    public partial class SServicesWeek
    {
        public SServicesWeek()
        {
            AServices = new HashSet<AService>();
            AServicesSmevRequests = new HashSet<AServicesSmevRequest>();
            DServices = new HashSet<DService>();
            DServicesSmevRequests = new HashSet<DServicesSmevRequest>();
            SServicesCustomerTariffs = new HashSet<SServicesCustomerTariff>();
            SServicesReasons = new HashSet<SServicesReason>();
            SSmevRequests = new HashSet<SSmevRequest>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование типа
        /// </summary>
        public string TypeName { get; set; }

        public virtual ICollection<AService> AServices { get; set; }
        public virtual ICollection<AServicesSmevRequest> AServicesSmevRequests { get; set; }
        public virtual ICollection<DService> DServices { get; set; }
        public virtual ICollection<DServicesSmevRequest> DServicesSmevRequests { get; set; }
        public virtual ICollection<SServicesCustomerTariff> SServicesCustomerTariffs { get; set; }
        public virtual ICollection<SServicesReason> SServicesReasons { get; set; }
        public virtual ICollection<SSmevRequest> SSmevRequests { get; set; }
    }
}
