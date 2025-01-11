using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Поля для фильтрации и группировки в отчетах
    /// </summary>
    public partial class SIndicatorsField
    {
        /// <summary>
        /// Первияный ключ
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование поля
        /// </summary>
        public string FieldName { get; set; }
    }
}
