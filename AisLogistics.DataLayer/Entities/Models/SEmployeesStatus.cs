using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник статусов сотрудников
    /// </summary>
    public partial class SEmployeesStatus
    {
        public SEmployeesStatus()
        {
            SEmployeesStatusJoins = new HashSet<SEmployeesStatusJoin>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование статуса
        /// </summary>
        public string StatusName { get; set; }

        public virtual ICollection<SEmployeesStatusJoin> SEmployeesStatusJoins { get; set; }
    }
}
