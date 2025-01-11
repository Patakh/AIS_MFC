using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Лог сервиса СМЭВ
    /// </summary>
    public partial class DServicesSmevLog
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Связь с запросом
        /// </summary>
        public Guid? DServicesSmevRequestId { get; set; }
        /// <summary>
        /// Дата и время лога
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// текст лога
        /// </summary>
        public string LogText { get; set; }
        /// <summary>
        /// тип лога
        /// </summary>
        public short? LogType { get; set; }
        public int? SprSmevRequestId { get; set; }
    }
}
