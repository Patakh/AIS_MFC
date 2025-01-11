using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Получатели информации, Филиалы
    /// </summary>
    public partial class DInformationRecipient
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// связь с инфо
        /// </summary>
        public Guid DInformationId { get; set; }
        /// <summary>
        /// дата и время добавления записи
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// кто добавил запись
        /// </summary>
        public string EmployeesFioAdd { get; set; }
        /// <summary>
        /// Сотрудник
        /// </summary>
        public Guid SEmployeesId { get; set; }
        /// <summary>
        /// Дата ознакомления
        /// </summary>
        public DateTime? DateFamiliarization { get; set; }
        /// <summary>
        /// ФИО сотрудника получателя
        /// </summary>
        public string EmployeesFio { get; set; }
        /// <summary>
        /// Филиал
        /// </summary>
        public string OfficeName { get; set; }
        /// <summary>
        /// Должность
        /// </summary>
        public string JobPositionName { get; set; }

        public virtual DInformation DInformation { get; set; }
        public virtual SEmployee SEmployees { get; set; }
    }
}
