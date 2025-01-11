using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Сообщения заявителям
    /// </summary>
    public partial class AServicesCustomersMessage
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Cвязь сномером дела
        /// </summary>
        public string ACasesId { get; set; }
        /// <summary>
        /// Заявитель
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// номер телефона
        /// </summary>
        public string CustomerPhone { get; set; }
        /// <summary>
        /// Идентефикатор СМС соответствующий идентефкатору из базы СМС сервиса
        /// </summary>
        public int? SmsId { get; set; }
        /// <summary>
        /// Статус СМС так же из базы СМС сервиса
        /// </summary>
        public int? Status { get; set; }
        /// <summary>
        /// Дата и время сообщения
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string TextMessage { get; set; }
        /// <summary>
        /// Cвязь с сотрудником
        /// </summary>
        public Guid SEmployeesId { get; set; }
        /// <summary>
        /// Связь с филиалом сотрудника
        /// </summary>
        public Guid SOfficesId { get; set; }
        /// <summary>
        /// Связь с должностью сотрудника
        /// </summary>
        public int SEmployeesJobPositionId { get; set; }
        /// <summary>
        /// Дата и время помещения в очередь для отправки
        /// </summary>
        public DateTime? EnqueueDate { get; set; }

        public virtual ACase ACases { get; set; }
        public virtual SEmployee SEmployees { get; set; }
        public virtual SEmployeesJobPosition SEmployeesJobPosition { get; set; }
        public virtual SOffice SOffices { get; set; }
    }
}
