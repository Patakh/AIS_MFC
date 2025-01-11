using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник активности подуслуг
    /// </summary>
    public partial class SServicesActive
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Cвязь  с подуслугой
        /// </summary>
        public Guid SServicesId { get; set; }
        /// <summary>
        /// МФЦ
        /// </summary>
        public Guid SOfficesId { get; set; }
        /// <summary>
        /// Сотрудник
        /// </summary>
        public string EmployeesFioAdd { get; set; }
        /// <summary>
        /// Дата и время добавления
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Признак удаления записи
        /// </summary>
        public bool IsRemove { get; set; }
        /// <summary>
        /// Комментарий к записи
        /// </summary>
        public string Commentt { get; set; }
        /// <summary>
        /// Дата начала
        /// </summary>
        public DateTime DateStart { get; set; }
        /// <summary>
        /// Дата завершения
        /// </summary>
        public DateTime? DateStop { get; set; }

        public virtual SService SServices { get; set; }
        public virtual SOffice SOffices { get; set; }
    }
}
