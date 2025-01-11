using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Единица измерения
    /// </summary>
    public partial class SUnitMeasure
    {
        public SUnitMeasure()
        {
            SIndicators = new HashSet<SIndicator>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string UnitName { get; set; }

        public virtual ICollection<SIndicator> SIndicators { get; set; }
    }
}
