using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочники для ЗАГС
    /// </summary>
    public partial class SSmevClassZag
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование органа ЗАГС
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Адрес фактического расположения
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Контактный телефон справочной службы
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Код органа ЗАГС
        /// </summary>
        public string Code { get; set; }
    }
}
