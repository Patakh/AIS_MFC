using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Таблица запросов результата для асинхронных сервисев 
    /// </summary>
    public partial class AServicesSmevRequestStatus
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Связь с запросом СМЭВ
        /// </summary>
        public Guid AServicesSmevRequestId { get; set; }
        /// <summary>
        /// ID сообщения
        /// </summary>
        public string MessageId { get; set; }
        /// <summary>
        /// ID запроса для повторного запроса сведений
        /// </summary>
        public string RequestIdRef { get; set; }
        /// <summary>
        /// Дата запроса
        /// </summary>
        public DateTime DateRequest { get; set; }
        /// <summary>
        /// Время запроса
        /// </summary>
        public TimeOnly TimeRequest { get; set; }

        public virtual AServicesSmevRequest AServicesSmevRequest { get; set; }
    }
}
