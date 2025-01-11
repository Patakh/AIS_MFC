using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Таблица для популярных услуг
    /// </summary>
    public partial class DActualService
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Отдел
        /// </summary>
        public Guid SOfficesId { get; set; }
        /// <summary>
        /// Услуга
        /// </summary>
        public Guid SServicesId { get; set; }
        /// <summary>
        /// Дата услуги
        /// </summary>
        public DateTime PeriodDate { get; set; }
        /// <summary>
        /// Количество услуг
        /// </summary>
        public int CountServices { get; set; }

        public virtual SOffice SOffices { get; set; }
        public virtual SService SServices { get; set; }
    }
}
