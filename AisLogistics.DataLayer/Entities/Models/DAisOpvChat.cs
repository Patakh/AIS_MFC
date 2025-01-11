using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Таблица для хранения чата с АИС ОПВ
    /// </summary>
    public partial class DAisOpvChat
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Идентификатор запроса, посредством которого отправлена анкета в СМЭВ
        /// </summary>
        public Guid DServicesSmevRequestId { get; set; }
        /// <summary>
        /// Направление сообщения:
        /// 1 - входящее
        /// 2 - исходящее
        /// </summary>
        public int ChatDirection { get; set; }
        /// <summary>
        /// Сообщение в чате
        /// </summary>
        public string ChatMessage { get; set; }
        /// <summary>
        /// Дата и время получения или отправки сообщения
        /// </summary>
        public DateTime? ReceivedOrSentTime { get; set; }
        /// <summary>
        /// Признак, что исходящее сообщение не валидно
        /// </summary>
        public bool? OutcomingMessageInvalid { get; set; }
        /// <summary>
        /// Отправитель
        /// </summary>
        public string Sender { get; set; }

        public virtual DServicesSmevRequest DServicesSmevRequest { get; set; }
    }
}
