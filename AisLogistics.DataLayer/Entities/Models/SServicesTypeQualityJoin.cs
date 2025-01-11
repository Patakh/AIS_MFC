using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник отношений способов оценки качества услуг к услугам
    /// </summary>
    public partial class SServicesTypeQualityJoin
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
        /// Связь с типом оценки качества
        /// </summary>
        public int SServicesTypeQualityId { get; set; }
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

        public virtual SService SServices { get; set; }
        public virtual SServicesTypeQuality SServicesTypeQuality { get; set; }
    }
}
