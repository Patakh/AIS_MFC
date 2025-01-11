using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Список полей для подгрупп, для группировки данныйх и фильтрации
    /// </summary>
    public partial class SIndicatorsSubgroupField
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Подгруппа
        /// </summary>
        public int SIndicatorsSubgroupId { get; set; }
        /// <summary>
        /// Показатель
        /// </summary>
        public int SIndicatorsFieldId { get; set; }

        public virtual SIndicatorsField SIndicatorsField { get; set; }
        public virtual SIndicatorsSubgroup SIndicatorsSubgroup { get; set; }
    }
}
