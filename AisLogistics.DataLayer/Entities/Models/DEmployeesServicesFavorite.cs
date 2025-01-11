using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Таблица для хранения избранных услуг для сотрудника, которые он сам для себя определил , для удобства при добавлении нового обращения
    /// </summary>
    public partial class DEmployeesServicesFavorite
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
        /// Подуслуга
        /// </summary>
        public Guid SServicesId { get; set; }

        public virtual SEmployee SEmployees { get; set; }
        public virtual SService SServices { get; set; }
    }
}
