using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Таблица хранения сопроводительных писем прикрепленных к услуге
    /// </summary>
    public partial class DServicesCoverLetter
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
        /// Код письма
        /// </summary>
        public string NumberCoverLetter { get; set; }
        /// <summary>
        /// Время добавление записи
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Содержание сопроводительного письма
        /// </summary>
        public string JsonData { get; set; }
        /// <summary>
        /// Связь с обращением
        /// </summary>
        public string DCasesId { get; set; }

        public virtual DCase DCases { get; set; }
        public virtual SEmployee SEmployees { get; set; }
    }
}
