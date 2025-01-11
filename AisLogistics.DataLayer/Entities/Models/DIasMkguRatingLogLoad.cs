using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Логи оценок, загруженных из ИАС МКГУ
    /// </summary>
    public partial class DIasMkguRatingLogLoad
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// ID органа власти из ФРГУ
        /// </summary>
        public string FrguProviderId { get; set; }
        /// <summary>
        /// Дата начала периода оценок
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Дата конца периода оценок
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// Идентификатор запроса СМЭВ 3
        /// </summary>
        public string MessageId { get; set; }
        /// <summary>
        /// Запрос XML
        /// </summary>
        public byte[] RequestXml { get; set; }
        /// <summary>
        /// Ответ XML
        /// </summary>
        public byte[] ResponseXml { get; set; }
    }
}
