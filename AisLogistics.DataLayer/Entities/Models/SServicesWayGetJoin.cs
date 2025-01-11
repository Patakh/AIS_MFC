using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник получения  к услугам
    /// </summary>
    public partial class SServicesWayGetJoin
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Связь со справочником подуслуг
        /// </summary>
        public Guid SServicesId { get; set; }
        /// <summary>
        /// Связь со способом получения услуги
        /// </summary>
        public int SServicesWayGetId { get; set; }
        /// <summary>
        /// Тип способа. 1 - Способ обращения для получения услуги.
        /// 2 - Способ получения результата. 
        /// </summary>
        public int WayType { get; set; }
        /// <summary>
        /// Признак удаления
        /// </summary>
        public bool IsRemove { get; set; }
        /// <summary>
        /// Дата и время добавления записи
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Сотрудник добавивший запись
        /// </summary>
        public string EmployeesFioAdd { get; set; }

        public virtual SService SServices { get; set; }
        public virtual SServicesWayGet SServicesWayGet { get; set; }
    }
}
