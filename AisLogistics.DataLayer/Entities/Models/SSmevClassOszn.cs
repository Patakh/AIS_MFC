using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник осзн для минтруда
    /// </summary>
    public partial class SSmevClassOszn
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Код осзн
        /// </summary>
        public int OsznCode { get; set; }
        /// <summary>
        /// Наименование ОСЗН
        /// </summary>
        public string OsznName { get; set; }
        /// <summary>
        /// Адрес ОСЗН
        /// </summary>
        public string OsznAddress { get; set; }
        /// <summary>
        /// Идентификатор цели услуги
        /// </summary>
        public string ServiceCode { get; set; }
    }
}
