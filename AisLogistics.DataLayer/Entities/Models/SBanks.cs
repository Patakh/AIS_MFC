using System;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник банков.
    /// </summary>
    public class SBanks
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование банка
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// БИК
        /// </summary>
        public string Bik { get; set; }

        /// <summary>
        /// ИНН
        /// </summary>
        public string Inn { get; set; }
    }
}
