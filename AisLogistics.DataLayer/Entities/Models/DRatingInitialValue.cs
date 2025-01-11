using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Данные по принятым, исполненным , и выполненным этапам по сотрудникам для рейтинга
    /// </summary>
    public partial class DRatingInitialValue
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Должность сотрудника
        /// </summary>
        public int SEmployeesJobPositionId { get; set; }
        /// <summary>
        /// Сотрудник
        /// </summary>
        public Guid SEmployeesId { get; set; }
        /// <summary>
        /// Кол-во принятых услуг
        /// </summary>
        public int CountReceived { get; set; }
        /// <summary>
        /// Кол-во исполненых услуг
        /// </summary>
        public int CountExecution { get; set; }
        /// <summary>
        /// Кол-во выполненых этапов
        /// </summary>
        public int CountRoutesStage { get; set; }
        /// <summary>
        /// Кол-во выполненых этапов с просрочкой
        /// </summary>
        public int CountRoutesStageOverdue { get; set; }
        /// <summary>
        /// Процент просроченных этапов
        /// </summary>
        public decimal PercentRoutesStageOverdue { get; set; }
        /// <summary>
        /// Офис
        /// </summary>
        public Guid SOfficesId { get; set; }
        /// <summary>
        /// Дата значения
        /// </summary>
        public DateTime ValueDate { get; set; }
        /// <summary>
        /// Месяц
        /// </summary>
        public int Month { get; set; }
        /// <summary>
        /// Год
        /// </summary>
        public int Year { get; set; }

        public virtual SEmployeesJobPosition SEmployeesJobPosition { get; set; }
    }
}
