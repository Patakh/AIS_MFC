using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник авторзаций сотрудников
    /// </summary>
    public partial class SEmployeesAuthorizationLog
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Связь с сотрудником
        /// </summary>
        public Guid SEmployeesId { get; set; }
        /// <summary>
        /// Связь с офисом
        /// </summary>
        public Guid SOfficesId { get; set; }
        /// <summary>
        /// Дата авторизации
        /// </summary>
        public DateTime LogInDate { get; set; }
        /// <summary>
        /// Наименование браузера
        /// </summary>
        public string LogInBrowserName { get; set; }
        /// <summary>
        /// Версия браузера
        /// </summary>
        public string LogInBrowserVersion { get; set; }
        /// <summary>
        /// IP адрес с которого совершена авторизация
        /// </summary>
        public string LogInIp { get; set; }
        /// <summary>
        /// Провайдер
        /// </summary>
        public string LogInProvider { get; set; }

        public virtual SEmployee SEmployees { get; set; }
        public virtual SOffice SOffices { get; set; }
    }
}
