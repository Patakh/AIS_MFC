using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Среднее время ожидание в очереди 
    /// </summary>
    public partial class DQueueAvgTime
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Связь с филиалом
        /// </summary>
        public Guid SOfficesId { get; set; }
        /// <summary>
        /// Среднее время очереди
        /// </summary>
        public decimal AvgTime { get; set; }
        /// <summary>
        /// Дата регистрации значения
        /// </summary>
        public DateTime DateRegistration { get; set; }
        /// <summary>
        /// Дата и время добавления записи
        /// </summary>
        public DateTime DateAdd { get; set; }

        public virtual SOffice SOffices { get; set; }
    }
}
