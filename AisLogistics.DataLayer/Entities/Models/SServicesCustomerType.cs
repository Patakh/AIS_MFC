using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Cправочник типов заявителей
    /// </summary>
    public partial class SServicesCustomerType
    {
        public SServicesCustomerType()
        {
            AServices = new HashSet<AService>();
            AServicesCustomersLegals = new HashSet<AServicesCustomersLegal>();
            DServices = new HashSet<DService>();
            DServicesCustomersLegals = new HashSet<DServicesCustomersLegal>();
            SServicesCustomers = new HashSet<SServicesCustomer>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Cвязь с ролительским id
        /// </summary>
        public int IdParent { get; set; }
        /// <summary>
        /// наименование получателя
        /// </summary>
        public string TypeName { get; set; }

        public virtual ICollection<AService> AServices { get; set; }
        public virtual ICollection<AServicesCustomersLegal> AServicesCustomersLegals { get; set; }
        public virtual ICollection<DService> DServices { get; set; }
        public virtual ICollection<DServicesCustomersLegal> DServicesCustomersLegals { get; set; }
        public virtual ICollection<SServicesCustomer> SServicesCustomers { get; set; }
    }
}
