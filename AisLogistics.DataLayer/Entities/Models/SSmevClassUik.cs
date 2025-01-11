using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник избирательных участков для СМЭВ (Система межведомственного электронного взаимодействия)
    /// </summary>
    public partial class SSmevClassUik
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Код региона избирательного участка
        /// </summary>
        public string RegionCode { get; set; }
        /// <summary>
        /// Наименование региона избирательного участка
        /// </summary>
        public string RegionName { get; set; }
        /// <summary>
        /// Код страны избирательного участка
        /// </summary>
        public string CountryCode { get; set; }
        /// <summary>
        /// Телефон избирательного участка
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Адрес избирательного участка
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Код избирательного участка
        /// </summary>
        public string UikNumber { get; set; }
    }
}
