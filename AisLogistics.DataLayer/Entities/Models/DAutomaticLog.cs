using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Лог запуска автоматических операций
    /// </summary>
    public partial class DAutomaticLog
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Дата начала
        /// </summary>
        public DateTime DateStart { get; set; }
        /// <summary>
        /// Время запуска
        /// </summary>
        public TimeSpan TimeStart { get; set; }
        /// <summary>
        /// Дата окончания
        /// </summary>
        //public DateTime DateStop { get; set; }
        /// <summary>
        /// Операция
        /// </summary>
        public int SAutomaticOperationId { get; set; }

        public virtual SAutomaticOperation SAutomaticOperation { get; set; }
    }
}
