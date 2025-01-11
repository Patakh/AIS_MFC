using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Таблица уведомлений сотрудников
    /// </summary>
    public partial class DAlertEmployee
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Связь с номером дела
        /// </summary>
        public string DCasesId { get; set; }
        /// <summary>
        /// Связь с услугой , data_services id
        /// </summary>
        public Guid? DServicesId { get; set; }
        /// <summary>
        /// Связь с комментарием
        /// </summary>
        public Guid? DServicesCommenttId { get; set; }
        /// <summary>
        /// Связь с запросом СМЭВ
        /// </summary>
        public Guid? DServicesSmevRequestId { get; set; }
        /// <summary>
        /// Тип уведомления
        /// </summary>
        public int SAlertEmployeeId { get; set; }
        /// <summary>
        /// Сотрудник
        /// </summary>
        public Guid SEmployeesId { get; set; }
        /// <summary>
        /// Дата и время добавления записи
        /// </summary>
        public DateTime DateAdd { get; set; }
        public bool IsRead { get; set; }

        public virtual DCase DCases { get; set; }
        public virtual DService DServices { get; set; }
        public virtual DServicesCommentt DServicesCommentt { get; set; }
        public virtual DServicesSmevRequest DServicesSmevRequest { get; set; }
        public virtual SAlertEmployee SAlertEmployee { get; set; }
        public virtual SEmployee SEmployees { get; set; }
    }
}
