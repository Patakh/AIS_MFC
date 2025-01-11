using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Показатели для отчетов
    /// </summary>
    public partial class SIndicator
    {
        public SIndicator()
        {
            DIndicatorsValues = new HashSet<DIndicatorsValue>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование показателя
        /// </summary>
        public string IndicatorName { get; set; }

        public virtual ICollection<DIndicatorsValue> DIndicatorsValues { get; set; }
    }
}
