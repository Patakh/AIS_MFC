using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник должностей совмещаемых сотрудником
    /// </summary>
    public partial class SEmployeesCombinationJob
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
        /// Дата начала действия должности
        /// </summary>
        public DateTime DateStart { get; set; }
        /// <summary>
        /// Дата окончания действия должности
        /// </summary>
        public DateTime? DateStop { get; set; }
        /// <summary>
        /// Дата и время добавления записи
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// ФИО сотрудника добавившего запись
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
        public virtual SEmployeesJobPosition SEmployeesJobPosition { get; set; }
    }
}
