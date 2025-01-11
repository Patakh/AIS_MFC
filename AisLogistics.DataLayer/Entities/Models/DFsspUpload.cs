using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Выгрузка для ФССП
    /// </summary>
    public partial class DFsspUpload
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
        /// Фамилия заявителя
        /// </summary>
        public string CustomerLastName { get; set; }
        /// <summary>
        /// Имя заявителя
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Отчество заявителя
        /// </summary>
        public string CustomerMiddleName { get; set; }
        /// <summary>
        /// Дата рождения заявителя
        /// </summary>
        public DateTime? DocumentBirthDate { get; set; }
        /// <summary>
        /// Телефон 1
        /// </summary>
        public string CustomerPhone1 { get; set; }
        /// <summary>
        /// Телефон 2
        /// </summary>
        public string CustomerPhone2 { get; set; }
        /// <summary>
        /// Адрес заявителя
        /// </summary>
        public string CustomerAddress { get; set; }
        /// <summary>
        /// Электронная почта заявителя
        /// </summary>
        public string CustomerEmail { get; set; }
        /// <summary>
        /// Наименование филиала
        /// </summary>
        public string OfficeName { get; set; }
        /// <summary>
        /// Дата и время отправки
        /// </summary>
        public DateTime? DateSend { get; set; }
        /// <summary>
        /// КПП
        /// </summary>
        public string CustomerKpp { get; set; }
        /// <summary>
        /// ИНН
        /// </summary>
        public string CustomerInn { get; set; }
        /// <summary>
        /// Наименовние фирмы/организации
        /// </summary>
        public string CustomerContragentName { get; set; }
        /// <summary>
        /// Номера исполнительных производств
        /// </summary>
        public string IpNumbers { get; set; }
        /// <summary>
        /// Дата и время добавления записи
        /// </summary>
        public DateTime? DateAddRecord { get; set; }

        public virtual DCase DCases { get; set; }
    }
}
