using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Таблица отмененных действий сотрудников
    /// 
    /// Используется для перерасчета
    /// </summary>
    public partial class DStepCancel
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// ID отмененного действия 
        /// </summary>
        public Guid StepId { get; set; }
        /// <summary>
        /// Номер обращения
        /// </summary>
        public string DCasesId { get; set; }
        /// <summary>
        /// Связь с сотрудником отменившим действие
        /// </summary>
        public Guid SEmployeesId { get; set; }
        /// <summary>
        /// Дата отмены действия
        /// </summary>
        public DateTime DateCanсel { get; set; }
        /// <summary>
        /// Тип таблицы, в которой отменено действие
        /// </summary>
        public int TableType { get; set; }
        /// <summary>
        /// Комментарий при отмене
        /// </summary>
        public string CommentCancel { get; set; }

        public virtual DCase DCases { get; set; }
        public virtual SEmployee SEmployees { get; set; }
    }
}
