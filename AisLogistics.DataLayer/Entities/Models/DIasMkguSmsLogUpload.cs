using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Лог отправки данных по СМС оценкам ИАС МКГУ
    /// </summary>
    public partial class DIasMkguSmsLogUpload
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// дата отправки
        /// </summary>
        public DateTime? DateSend { get; set; }
        /// <summary>
        /// id пакета
        /// </summary>
        public string PackedId { get; set; }
        /// <summary>
        /// запрос XML
        /// </summary>
        public byte[] RequestXml { get; set; }
        /// <summary>
        /// ответ XML
        /// </summary>
        public byte[] ResponseXml { get; set; }
        /// <summary>
        /// Идентификатор запроса СМЭВ 3
        /// </summary>
        public string MessageId { get; set; }
    }
}
