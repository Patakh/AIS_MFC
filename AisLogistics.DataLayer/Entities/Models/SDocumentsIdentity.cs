using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Cписок документов удостоверяющих личность
    /// </summary>
    public partial class SDocumentsIdentity
    {
        public SDocumentsIdentity()
        {
            AServicesCustomers = new HashSet<AServicesCustomer>();
            DServicesCustomers = new HashSet<DServicesCustomer>();
            DCustomers = new HashSet<DCustomer>();
        }

        /// <summary>
        /// ID\Код документа
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование документа
        /// </summary>
        public string DocumentName { get; set; }
        /// <summary>
        /// Краткое наименование документа
        /// </summary>
        public string DocumentNameSmall { get; set; }
        /// <summary>
        /// Комментарий
        /// </summary>
        public string Commentt { get; set; }

        public virtual ICollection<AServicesCustomer> AServicesCustomers { get; set; }
        public virtual ICollection<DServicesCustomer> DServicesCustomers { get; set; }
        public virtual ICollection<DCustomer> DCustomers { get; set; }
    }
}
