using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Таблица адресатов комментариев
    /// </summary>
    public partial class DServicesCommenttEmployee
    {
        /// <summary>
        /// первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Связь с комментарием
        /// </summary>
        public Guid DServicesCommenttId { get; set; }
        /// <summary>
        /// Сотрудник, которому адресован комментарий 
        /// </summary>
        public Guid SEmployeesId { get; set; }

        public virtual DServicesCommentt DServicesCommentt { get; set; }
        public virtual SEmployee SEmployees { get; set; }
    }
}
