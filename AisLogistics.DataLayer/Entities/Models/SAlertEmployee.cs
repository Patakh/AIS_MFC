using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Уведомления сотрудникам
    /// </summary>
    public partial class SAlertEmployee
    {
        public SAlertEmployee()
        {
            DAlertEmployees = new HashSet<DAlertEmployee>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Уведомление
        /// </summary>
        public string AlertName { get; set; }

        public virtual ICollection<DAlertEmployee> DAlertEmployees { get; set; }
    }
}
