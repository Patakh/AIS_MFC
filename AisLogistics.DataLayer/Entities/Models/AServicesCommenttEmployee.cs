using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Таблица адресатов комментариев
    /// </summary>
    public partial class AServicesCommenttEmployee
    {
        /// <summary>
        /// первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Связь с комментарием
        /// </summary>
        public Guid AServicesCommenttId { get; set; }
        /// <summary>
        /// Сотрудник, которому адресован комментарий 
        /// </summary>
        public Guid SEmployeesId { get; set; }

        public virtual AServicesCommentt AServicesCommentt { get; set; }
        public virtual SEmployee SEmployees { get; set; }
    }
}
