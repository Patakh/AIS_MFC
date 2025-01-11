using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Информация по задолженности с сервиса ГИС ГМП 
    /// </summary>
    public partial class DServicesCustomersGisgmp
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Связь с заявителем
        /// </summary>
        public Guid DServicesCustomersId { get; set; }
        /// <summary>
        /// Связь с сотрудником добавившим запись
        /// </summary>
        public Guid SEmployeesId { get; set; }
        /// <summary>
        /// задолженность с сервиса ГИС ГМП
        /// </summary>
        public decimal GisgmpDebt { get; set; }
        /// <summary>
        /// Дата добавления
        /// </summary>
        public DateTime DateAdd { get; set; }

        public virtual DServicesCustomer DServicesCustomers { get; set; }
        public virtual SEmployee SEmployees { get; set; }
    }
}
