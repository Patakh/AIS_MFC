using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Данные СМС опроса МФЦ
    /// </summary>
    public partial class DSmsPollRegion
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
        /// название услуги
        /// </summary>
        public string ServiceSubName { get; set; }
        /// <summary>
        /// Номер телефона
        /// </summary>
        public string CustomerPhone { get; set; }
        /// <summary>
        /// Фамилия заявителя
        /// </summary>
        public string CustomerLastName { get; set; }
        /// <summary>
        /// Имя заявителя
        /// </summary>
        public string CustomerFirstName { get; set; }
        /// <summary>
        /// Отчество заявителя
        /// </summary>
        public string CustomerMiddleName { get; set; }
        /// <summary>
        /// Текст отправленного СМС
        /// </summary>
        public string SmsTextSend { get; set; }
        /// <summary>
        /// Текст полученного  СМС ответа
        /// </summary>
        public string SmsTextAnswer { get; set; }
        /// <summary>
        /// Статус отправки СМС
        /// 
        /// 1 Ожидание отправки
        /// 
        /// 2 Отправленно
        /// 
        /// 3 Принят ответ
        /// 
        /// 4 Ошибка
        /// </summary>
        public short SmsStatus { get; set; }
        /// <summary>
        /// Оценка из СМС
        /// </summary>
        public short? SmsRating { get; set; }
        /// <summary>
        /// Дата отправки СМС
        /// </summary>
        public DateTime? DateSend { get; set; }
        /// <summary>
        /// Дата получения СМС ответа
        /// </summary>
        public DateTime? DateAnswer { get; set; }
        /// <summary>
        /// дата и время добавления записи
        /// </summary>
        public DateTime? DateAddRecord { get; set; }
        /// <summary>
        /// Связь с филиалом
        /// </summary>
        public Guid SOfficesId { get; set; }
        /// <summary>
        /// Связь с сотрудником
        /// </summary>
        public Guid SEmployeesId { get; set; }
        /// <summary>
        /// ФИО сотрудника
        /// </summary>
        public string EmployeeFio { get; set; }

        public virtual DCase DCases { get; set; }
        public virtual SEmployee SEmployees { get; set; }
        public virtual SOffice SOffices { get; set; }
    }
}
