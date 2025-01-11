using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Архив совершенных действий сотрудников
    /// </summary>
    public partial class APremiumStep
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
        /// Связь с сотрудником
        /// </summary>
        public Guid SEmployeesId { get; set; }
        /// <summary>
        /// Связь с должностью
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
        /// Связь с действием
        /// </summary>
        public int SPremiumStepId { get; set; }
        /// <summary>
        /// Дата и время действия совершенного сотрудником
        /// </summary>
        public DateTime StepDate { get; set; }
        /// <summary>
        /// Сумма за совершенное действие
        /// </summary>
        public decimal StepPremium { get; set; }
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
        public virtual SPremiumStep SPremiumStep { get; set; }
        public virtual SService SServices { get; set; }
    }
}
