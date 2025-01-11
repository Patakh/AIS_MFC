using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Звонки заявителям
    /// </summary>
    public partial class DServicesCustomersCall
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
        /// Заявитель
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Дата и время звонка
        /// </summary>
        public DateTime DateCall { get; set; }
        /// <summary>
        /// Номер телефона
        /// </summary>
        public string CustomerPhone { get; set; }
        /// <summary>
        /// Формат звонка
        /// </summary>
        public string AudioFormat { get; set; }
        /// <summary>
        /// Время разговора
        /// </summary>
        public string TimeTalk { get; set; }
        /// <summary>
        /// признак сохранения на FTP
        /// </summary>
        public bool SaveFtp { get; set; }
        /// <summary>
        /// Связь с сотрудником
        /// </summary>
        public Guid SEmployeesId { get; set; }
        /// <summary>
        /// Связь с филиалом
        /// </summary>
        public Guid SOfficesId { get; set; }
        /// <summary>
        /// Связь с должностью сотрудника
        /// </summary>
        public int SEmployeesJobPositionId { get; set; }
        /// <summary>
        /// Cвязь с FTP сервером
        /// </summary>
        public Guid? SFtpId { get; set; }

        public virtual DCase DCases { get; set; }
        public virtual SEmployee SEmployees { get; set; }
        public virtual SEmployeesJobPosition SEmployeesJobPosition { get; set; }
        public virtual SFtp SFtp { get; set; }
        public virtual SOffice SOffices { get; set; }
    }
}
