using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// План по  услугам для филиалов
    /// </summary>
    public partial class SOfficesPlan
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// План на месяц
        /// </summary>
        public int PlanMonth { get; set; }
        /// <summary>
        /// План на год
        /// </summary>
        public int PlanYear { get; set; }
        /// <summary>
        /// Кто добавил запись
        /// </summary>
        public string EmployeesFioAdd { get; set; }
        /// <summary>
        /// Дата и время добавления
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Год
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// Филиал
        /// </summary>
        public Guid SOfficesId { get; set; }
        /// <summary>
        /// Признак удаления
        /// </summary>
        public bool IsRemove { get; set; }

        public virtual SOffice SOffices { get; set; }
    }
}
