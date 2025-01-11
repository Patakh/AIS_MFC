using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Входящие звонки
    /// </summary>
    public partial class DIncomingCall
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Номер телефона
        /// </summary>
        public string CustomerPhone { get; set; }
        /// <summary>
        /// Заявитель
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Дата и время звонка
        /// </summary>
        public DateTime DateCall { get; set; }
        /// <summary>
        /// Формат звонка
        /// </summary>
        public string AudioFormat { get; set; }
        /// <summary>
        /// Время разговора
        /// </summary>
        public string TimeTalk { get; set; }
        /// <summary>
        /// Признак сохранения на FTP
        /// </summary>
        public bool IsSavedFtp { get; set; }
        /// <summary>
        /// Сотрудник, добавивший заявителя
        /// </summary>
        public Guid? SEmployeesId { get; set; }
        /// <summary>
        /// Филиал сотрудника, добавившего заявителя
        /// </summary>
        public Guid? SOfficesId { get; set; }
        /// <summary>
        /// Должность сотрудника добавившего заявителя
        /// </summary>
        public int? SEmployeesJobPositionId { get; set; }
        /// <summary>
        /// Cвязь с FTP сервером
        /// </summary>
        public Guid? SFtpId { get; set; }

        public virtual SEmployee SEmployees { get; set; }
        public virtual SEmployeesJobPosition SEmployeesJobPosition { get; set; }
        public virtual SFtp SFtp { get; set; }
        public virtual SOffice SOffices { get; set; }
    }
}
