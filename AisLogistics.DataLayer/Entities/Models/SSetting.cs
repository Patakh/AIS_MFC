using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник настроек системы
    /// </summary>
    public partial class SSetting
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public short Id { get; set; }
        /// <summary>
        /// Наименование параметра
        /// </summary>
        public string ParamName { get; set; }
        /// <summary>
        /// Значение параметра
        /// </summary>
        public string ParamValue { get; set; }
        /// <summary>
        /// Комментраий
        /// </summary>
        public string Commentt { get; set; }
    }
}
