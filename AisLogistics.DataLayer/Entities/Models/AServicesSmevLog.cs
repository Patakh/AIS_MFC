using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Лог сервиса СМЭВ
    /// </summary>
    public partial class AServicesSmevLog
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Связь с запросом
        /// </summary>
        public Guid AServicesSmevRequestId { get; set; }
        /// <summary>
        /// Дата и время лога
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Текст лога
        /// </summary>
        public string LogText { get; set; }
        /// <summary>
        /// Тип лога
        /// </summary>
        public short? LogType { get; set; }

        public virtual AServicesSmevRequest AServicesSmevRequest { get; set; }
    }
}
