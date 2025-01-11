using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Сопроводительные письма сотрудника. Шаблоны
    /// </summary>
    public partial class SEmployeesCoverLetter
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Связь со справочником сотрудников
        /// </summary>
        public Guid SEmployeesId { get; set; }
        /// <summary>
        /// ФИО сотрудника
        /// </summary>
        public string EmployeesFioAdd { get; set; }
        /// <summary>
        /// Шаблон письма
        /// </summary>
        public string TemplateName { get; set; }
        /// <summary>
        /// Время добавления записи
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Информация для письма
        /// </summary>
        public string JsonData { get; set; }

        public virtual SEmployee SEmployees { get; set; }
    }
}
