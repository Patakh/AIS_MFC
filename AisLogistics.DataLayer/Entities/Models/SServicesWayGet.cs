using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник способов получения услуг
    /// </summary>
    public partial class SServicesWayGet
    {
        public SServicesWayGet()
        {
            SServicesWayGetJoins = new HashSet<SServicesWayGetJoin>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование способа
        /// </summary>
        public string NameWay { get; set; }

        public virtual ICollection<SServicesWayGetJoin> SServicesWayGetJoins { get; set; }
    }
}
