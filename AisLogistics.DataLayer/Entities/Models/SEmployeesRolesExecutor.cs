using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Роли исполнителя у сотрудника
    /// </summary>
    public partial class SEmployeesRolesExecutor
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Сотрудник
        /// </summary>
        public Guid SEmployeesId { get; set; }
        /// <summary>
        /// Роль исполнителя
        /// </summary>
        public Guid SRolesExecutorId { get; set; }
        /// <summary>
        /// Дата и время добавлния записи
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Кто добавил
        /// </summary>
        public string EmployeesFioAdd { get; set; }
        /// <summary>
        /// Признак удаления записи
        /// </summary>
        public bool IsRemove { get; set; }

        public virtual SEmployee SEmployees { get; set; }
        public virtual SRolesExecutor SRolesExecutor { get; set; }
    }
}
