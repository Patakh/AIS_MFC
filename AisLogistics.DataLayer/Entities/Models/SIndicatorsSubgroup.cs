using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Подгруппы показателей
    /// </summary>
    public partial class SIndicatorsSubgroup
    {
        public SIndicatorsSubgroup()
        {
            InverseSIndicatorGroup = new HashSet<SIndicatorsSubgroup>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string SubgroupName { get; set; }
        /// <summary>
        /// Группа
        /// </summary>
        public int SIndicatorGroupId { get; set; }

        public virtual SIndicatorsSubgroup SIndicatorGroup { get; set; }
        public virtual ICollection<SIndicatorsSubgroup> InverseSIndicatorGroup { get; set; }
    }
}
