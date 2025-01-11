using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Способы оповещения заявителей по услуге
    /// </summary>
    public partial class SAlertCustomer
    {
        public SAlertCustomer()
        {
            AServicesCustomers = new HashSet<AServicesCustomer>();
            DServicesCustomers = new HashSet<DServicesCustomer>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование способа оповещения
        /// </summary>
        public string AlertName { get; set; }
        /// <summary>
        /// Признак удаления
        /// </summary>
        public bool IsRemove { get; set; }

        public virtual ICollection<AServicesCustomer> AServicesCustomers { get; set; }
        public virtual ICollection<DServicesCustomer> DServicesCustomers { get; set; }
    }
}
