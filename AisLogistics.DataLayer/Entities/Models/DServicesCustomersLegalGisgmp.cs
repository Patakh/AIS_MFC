using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Информация по задолженности с сервиса ГИС ГМП 
    /// </summary>
    public partial class DServicesCustomersLegalGisgmp
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Связь с сотрудником добавившим запись
        /// </summary>
        public Guid SEmployeesId { get; set; }
        /// <summary>
        /// Задолженность с сервиса ГИС ГМП
        /// </summary>
        public decimal GisgmpDebt { get; set; }
        /// <summary>
        /// Дата добавления
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Связь с заявителем юр лицо
        /// </summary>
        public Guid DServicesCustomersLegalId { get; set; }

        public virtual DServicesCustomersLegal DServicesCustomersLegal { get; set; }
        public virtual SEmployee SEmployees { get; set; }
    }
}
