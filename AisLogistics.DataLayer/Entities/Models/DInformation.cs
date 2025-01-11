using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Информация для сотрудников, пользователей системы
    /// </summary>
    public partial class DInformation
    {
        public DInformation()
        {
            DInformationFiles = new HashSet<DInformationFile>();
            DInformationRecipients = new HashSet<DInformationRecipient>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Тип информации
        /// </summary>
        public int SInformationTypeId { get; set; }
        /// <summary>
        /// Текст
        /// </summary>
        public string InformationText { get; set; }
        /// <summary>
        /// Информационная тема
        /// </summary>
        public string InformationTopic { get; set; }
        /// <summary>
        /// Сотрудник
        /// </summary>
        public string EmployeesFioAdd { get; set; }
        /// <summary>
        /// Должность сотрудника
        /// </summary>
        public string EmployeesJobPositionAdd { get; set; }
        /// <summary>
        /// Дата и время добавления записи
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Признак удаления
        /// </summary>
        public bool IsRemove { get; set; }
        /// <summary>
        /// Дата начала отображения
        /// </summary>
        public DateTime DateStart { get; set; }
        /// <summary>
        /// Дата окончания
        /// </summary>
        public DateTime? DateStop { get; set; }

        public virtual SInformationType SInformationType { get; set; }
        public virtual ICollection<DInformationFile> DInformationFiles { get; set; }
        public virtual ICollection<DInformationRecipient> DInformationRecipients { get; set; }
    }
}
