using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Изменения
    /// </summary>
    public partial class AServicesAudit
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
        /// Дата и время
        /// </summary>
        public DateTime DateAdd { get; set; }
        public Guid? SEmployeesId { get; set; }
        public Guid? SOfficesId { get; set; }
        public int? SEmployeesJobPositionId { get; set; }
        public string Changed { get; set; }

        public virtual ACase ACases { get; set; }
        public virtual AService AServices { get; set; }
        public virtual SEmployee SEmployees { get; set; }
        public virtual SEmployeesJobPosition SEmployeesJobPosition { get; set; }
        public virtual SOffice SOffices { get; set; }
    }
}
