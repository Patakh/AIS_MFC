using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Оценки с сайта ИАС МКГУ
    /// </summary>
    public partial class DEmployeesIasMkguOfficesWebsite
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
        /// Оценка с сайта
        /// </summary>
        public decimal IasMkguRating { get; set; }
        /// <summary>
        /// Дата выставления оценки
        /// </summary>
        public DateTime DateRating { get; set; }
        /// <summary>
        /// Дата и время занесения записи
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// ФИО сотрудника добавившего запись
        /// </summary>
        public string EmployeesFioAdd { get; set; }

        public virtual SOffice SOffices { get; set; }
    }
}
