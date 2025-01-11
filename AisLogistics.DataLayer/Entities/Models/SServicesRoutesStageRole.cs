using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Роли исполнителей к услугам
    /// </summary>
    public partial class SServicesRoutesStageRole
    {
        /// <summary>
        /// Этап с услугой
        /// </summary>
        public Guid SServicesRoutesStageId { get; set; }
        /// <summary>
        /// Дата и время добавления записи
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Сотрудник добавивший запись
        /// </summary>
        public string EmployeesFioAdd { get; set; }
        /// <summary>
        /// Признак удаления
        /// </summary>
        public bool IsRemove { get; set; }
        /// <summary>
        /// Роль исполнителя
        /// </summary>
        public Guid SRolesExecutorId { get; set; }
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }

        public virtual SRolesExecutor SRolesExecutor { get; set; }
        public virtual SServicesRoutesStage SServicesRoutesStage { get; set; }
    }
}
