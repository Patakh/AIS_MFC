using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Штрафы сотрудников
    /// </summary>
    public partial class DPremiumFine
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
        /// Номер дела
        /// </summary>
        public string DCasesId { get; set; }
        /// <summary>
        /// Связь с этапом
        /// </summary>
        public int SRoutesStageId { get; set; }
        /// <summary>
        /// Дата штрафа
        /// </summary>
        public DateTime FineDate { get; set; }
        /// <summary>
        /// Количество просроченных дней
        /// </summary>
        public int? CountDayFine { get; set; }
        /// <summary>
        /// Процент штрафа
        /// </summary>
        public decimal FinePercent { get; set; }
        /// <summary>
        /// Cумма штрафа
        /// </summary>
        public decimal FineSum { get; set; }
        /// <summary>
        /// Дата и время добавления записи
        /// </summary>
        public DateTime? DateAdd { get; set; }
        /// <summary>
        /// Сотрудник добавивший запись
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

        public virtual DCase DCases { get; set; }
        public virtual SEmployee SEmployees { get; set; }
        public virtual SEmployeesJobPosition SEmployeesJobPosition { get; set; }
        public virtual SOffice SOffices { get; set; }
        public virtual SRoutesStage SRoutesStage { get; set; }
        public virtual SService SServices { get; set; }
    }
}
