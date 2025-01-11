using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник типов услуг
    /// </summary>
    public partial class SServicesType
    {
        public SServicesType()
        {
            SServices = new HashSet<SService>();
            DServices = new HashSet<DService>();
        }
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование типа услуги
        /// </summary>
        public string TypeName { get; set; }

        public virtual ICollection<SService> SServices { get; set; }
        public virtual ICollection<DService> DServices { get; set; }
    }
}
