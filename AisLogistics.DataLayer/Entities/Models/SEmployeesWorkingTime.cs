using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник статусов для табеля
    /// </summary>
    public partial class SEmployeesWorkingTime
    {
        public SEmployeesWorkingTime()
        {
            SEmployeesWorkingTimeJoins = new HashSet<SEmployeesWorkingTimeJoin>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование статуса
        /// </summary>
        public string StatusName { get; set; }
        /// <summary>
        /// Мнемоника статуса
        /// </summary>
        public string StatusMnemo { get; set; }

        public virtual ICollection<SEmployeesWorkingTimeJoin> SEmployeesWorkingTimeJoins { get; set; }
    }
}
