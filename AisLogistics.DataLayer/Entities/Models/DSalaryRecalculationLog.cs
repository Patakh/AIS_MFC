using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Таблица хранения времени запуска перерасчета зарплат
    /// </summary>
    public partial class DSalaryRecalculationLog
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
        /// Связь с сотрудником
        /// </summary>
        public Guid SEmployeesId { get; set; }
        /// <summary>
        /// Дата начала
        /// </summary>
        public DateTime DateStart { get; set; }
        /// <summary>
        /// Дата окончания
        /// </summary>
        public DateTime DateStop { get; set; }
        /// <summary>
        /// Дата добавления
        /// </summary>
        public DateTime DateAdd { get; set; }

        public virtual SEmployee SEmployees { get; set; }
        public virtual SOffice SOffices { get; set; }
    }
}
