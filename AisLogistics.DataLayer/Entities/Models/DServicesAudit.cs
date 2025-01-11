using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Изменения
    /// </summary>
    public partial class DServicesAudit
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Обращение
        /// </summary>
        public string DCasesId { get; set; }
        /// <summary>
        /// Услуга
        /// </summary>
        public Guid? DServicesId { get; set; }
        /// <summary>
        /// дата и время
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// сотрудник
        /// </summary>
        public Guid SEmployeesId { get; set; }
        /// <summary>
        /// организация
        /// </summary>
        public Guid SOfficesId { get; set; }
        /// <summary>
        /// должность
        /// </summary>
        public int SEmployeesJobPositionId { get; set; }
        /// <summary>
        /// изменение
        /// </summary>
        public string Changed { get; set; }

        public virtual DCase DCases { get; set; }
        public virtual DService DServices { get; set; }
        public virtual SEmployee SEmployees { get; set; }
        public virtual SEmployeesJobPosition SEmployeesJobPosition { get; set; }
        public virtual SOffice SOffices { get; set; }
    }
}
