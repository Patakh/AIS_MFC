using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Роли исполнителей 
    /// </summary>
    public partial class SRolesExecutor
    {
        public SRolesExecutor()
        {
            SEmployeesRolesExecutors = new HashSet<SEmployeesRolesExecutor>();
            SServicesRoutesStageRoles = new HashSet<SServicesRoutesStageRole>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Наименование роли
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Дата и время добавления
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Кто добавил запись
        /// </summary>
        public string EmployeesFioAdd { get; set; }
        /// <summary>
        /// Признак удаления
        /// </summary>
        public bool IsRemove { get; set; }

        public virtual ICollection<SEmployeesRolesExecutor> SEmployeesRolesExecutors { get; set; }
        public virtual ICollection<SServicesRoutesStageRole> SServicesRoutesStageRoles { get; set; }
    }
}
