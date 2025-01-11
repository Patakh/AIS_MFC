using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник отношений статусов к сотрудникам
    /// </summary>
    public partial class SEmployeesStatusJoin
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Связь с cотрудником
        /// </summary>
        public Guid SEmployeesId { get; set; }
        /// <summary>
        /// Cвязь со статусом
        /// </summary>
        public int SEmployeesStatusId { get; set; }
        /// <summary>
        /// Дата начала работы статуса
        /// </summary>
        public DateTime DateStart { get; set; }
        /// <summary>
        /// Дата окончания работы статуса
        /// </summary>
        public DateTime? DateStop { get; set; }
        /// <summary>
        /// Дата и время добавления записи
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
        public virtual SEmployeesStatus SEmployeesStatus { get; set; }
    }
}
