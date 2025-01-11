using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Таблица для хранения логов отправки данных в МДМ
    /// </summary>
    public partial class DMdmObjectsLogUpload
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Идентификатор сообщения СМЭВ 3
        /// </summary>
        public string MessageId { get; set; }
        /// <summary>
        /// XML запроса
        /// </summary>
        public byte[] RequestXml { get; set; }
        /// <summary>
        /// XML ответа
        /// </summary>
        public byte[] ResponseXml { get; set; }
    }
}
