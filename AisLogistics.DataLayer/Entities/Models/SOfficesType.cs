using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник типов филиалов/организаций
    /// </summary>
    public partial class SOfficesType
    {
        public SOfficesType()
        {
            SOffices = new HashSet<SOffice>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string TypeName { get; set; }

        public virtual ICollection<SOffice> SOffices { get; set; }
    }
}
