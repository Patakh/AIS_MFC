using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Перечень юридических лиц к услуге
    /// </summary>
    public partial class AServicesCustomersLegal
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Номер дела
        /// </summary>
        public string ACasesId { get; set; }
        /// <summary>
        /// Связь с типами юридических лиц
        /// </summary>
        public int SServicesCustomerTypeId { get; set; }
        /// <summary>
        /// ИНН организации
        /// </summary>
        public string CustomerInn { get; set; }
        /// <summary>
        /// ОКАТО
        /// </summary>
        public string CustomerOkato { get; set; }
        /// <summary>
        /// ОКТМО
        /// </summary>
        public string CustomerOktmo { get; set; }
        /// <summary>
        /// КОД региона
        /// </summary>
        public string CustomerCodeRegion { get; set; }
        /// <summary>
        /// КПП юридического лица
        /// </summary>
        public string CustomerKpp { get; set; }
        /// <summary>
        /// ОГРН юридического лица
        /// </summary>
        public string CustomerOgrn { get; set; }
        /// <summary>
        /// Связь с сотрудником добавившим запись
        /// </summary>
        public Guid SEmployeesId { get; set; }
        /// <summary>
        /// Связь с филиалом
        /// </summary>
        public Guid SOfficesId { get; set; }
        /// <summary>
        /// Связь с должностью сотрудника, добавившего запись
        /// </summary>
        public int SEmployeesJobPositionId { get; set; }
        /// <summary>
        /// Дата и время добавления записи
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Адрес
        /// </summary>
        public string CustomerAddress { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Адрес детальный
        /// </summary>
        public string CustomerAddressDetail { get; set; }
        /// <summary>
        /// Должность руководителя
        /// </summary>
        public string HeadPosition { get; set; }
        /// <summary>
        /// ФИО руководителя
        /// </summary>
        public string HeadName { get; set; }
        /// <summary>
        /// Номер телефона 1
        /// </summary>
        public string CustomerPhone1 { get; set; }
        /// <summary>
        /// Номер телефона 2
        /// </summary>
        public string CustomerPhone2 { get; set; }
        /// <summary>
        /// Электронная почта заявителя
        /// </summary>
        public string CustomerEmail { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string HeadFirstName { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string HeadLastName { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string HeadSecondName { get; set; }

        public virtual ACase ACases { get; set; }
        public virtual SEmployee SEmployees { get; set; }
        public virtual SEmployeesJobPosition SEmployeesJobPosition { get; set; }
        public virtual SOffice SOffices { get; set; }
        public virtual SServicesCustomerType SServicesCustomerType { get; set; }
    }
}
