using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Включение\Выключение учетной записи сотрудника
    /// </summary>
    public partial class SEmployeesActive
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Связь с сотрудником
        /// </summary>
        public Guid SEmployeesId { get; set; }
        /// <summary>
        /// Дата начала действия статуса
        /// </summary>
        public DateTime DateStart { get; set; }
        /// <summary>
        /// Дата окончания действия статуса
        /// </summary>
        public DateTime? DateStop { get; set; }
        /// <summary>
        /// Дата и время добавления статуса
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Сотрудник добавивший запись
        /// </summary>
        public string EmployeesFioAdd { get; set; }
        /// <summary>
        /// Признак удаления записи
        /// </summary>
        public bool IsRemove { get; set; }
        /// <summary>
        /// Комментарий к записи
        /// </summary>
        public string Commentt { get; set; }

        public virtual SEmployee SEmployees { get; set; }
    }
}
