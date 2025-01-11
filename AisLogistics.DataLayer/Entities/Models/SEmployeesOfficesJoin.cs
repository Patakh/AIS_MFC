using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник отношений сотрудника к офису
    /// </summary>
    public partial class SEmployeesOfficesJoin
    {
        public SEmployeesOfficesJoin()
        {
            SEmployeesWorkingTimeJoins = new HashSet<SEmployeesWorkingTimeJoin>();
        }

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
        /// Связь с должностью
        /// </summary>
        public int SEmployeesJobPositionId { get; set; }
        /// <summary>
        /// Интенсивность
        /// </summary>
        public decimal EmployeeIntensity { get; set; }
        /// <summary>
        /// Ставка
        /// </summary>
        public decimal EmployeeRate { get; set; }
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
        public virtual SEmployeesJobPosition SEmployeesJobPosition { get; set; }
        public virtual SOffice SOffices { get; set; }
        public virtual ICollection<SEmployeesWorkingTimeJoin> SEmployeesWorkingTimeJoins { get; set; }
    }
}
