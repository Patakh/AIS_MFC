using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Лог отправки данных по Инфомат оценкам ИАС МКГУ
    /// </summary>
    public partial class DIasMkguInfomatLogUpload
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Дата отправки
        /// </summary>
        public DateTime? DateSend { get; set; }
        /// <summary>
        /// ID пакета
        /// </summary>
        public string PackedId { get; set; }
        /// <summary>
        /// Запрос XML
        /// </summary>
        public byte[] RequestXml { get; set; }
        /// <summary>
        /// Ответ XML
        /// </summary>
        public byte[] ResponseXml { get; set; }
        /// <summary>
        /// Идентификатор запроса СМЭВ 3
        /// </summary>
        public string MessageId { get; set; }
    }
}
