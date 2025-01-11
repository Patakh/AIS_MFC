using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Штрафы сотрудников
    /// </summary>
    public partial class APremiumFine
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Связь с филиалом
        /// </summary>
        public Guid SOfficesId { get; set; }
        /// <summary>
        /// Cвязь с сотрудником
        /// </summary>
        public Guid SEmployeesId { get; set; }
        /// <summary>
        /// Cвязь с должностью
        /// </summary>
        public int SEmployeesJobPositionId { get; set; }
        /// <summary>
        /// Связь с услугой
        /// </summary>
        public Guid SServicesId { get; set; }
        /// <summary>
        /// Связь с текущим делом
        /// </summary>
        public Guid? DServicesId { get; set; }
        /// <summary>
        /// Номер дела
        /// </summary>
        public string DCasesId { get; set; }
        /// <summary>
        /// Связь с этапом
        /// </summary>
        public int SRoutesStageId { get; set; }
        /// <summary>
        /// Связь с зарплатой сотрудника
        /// </summary>
        public Guid APremiumId { get; set; }
        /// <summary>
        /// Дата штрафа
        /// </summary>
        public DateTime? FineDate { get; set; }
        /// <summary>
        /// Количество просроченных дней
        /// </summary>
        public int? CountDayFine { get; set; }
        /// <summary>
        /// Сумма штрафа
        /// </summary>
        public decimal FineSum { get; set; }
        /// <summary>
        /// Процент штрафа
        /// </summary>
        public decimal FinePercent { get; set; }

        public virtual APremium APremium { get; set; }
        public virtual DCase DCases { get; set; }
        public virtual DService DServices { get; set; }
        public virtual SEmployee SEmployees { get; set; }
        public virtual SEmployeesJobPosition SEmployeesJobPosition { get; set; }
        public virtual SOffice SOffices { get; set; }
        public virtual SRoutesStage SRoutesStage { get; set; }
        public virtual SService SServices { get; set; }
    }
}
