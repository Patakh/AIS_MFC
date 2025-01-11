using System;

namespace AisLogistics.DataLayer.Entities.Models
{
    public class SOfficesAuthorization
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
        /// Связь с офисом
        /// </summary>
        public Guid SOfficesId { get; set; }
        /// <summary>
        /// Дата начала действия
        /// </summary>
        public DateTime DateStart { get; set; }
        /// <summary>
        /// Дата окончания действия
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
        public virtual SEmployee SEmployees { get; set; }
        public virtual SOffice SOffices { get; set; }
    }
}
