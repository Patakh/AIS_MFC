using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Заметки сотрудников
    /// </summary>
    public partial class DNote
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Номер обращения
        /// </summary>
        public string DCasesId { get; set; }
        /// <summary>
        /// Текст заметки
        /// </summary>
        public string NoteText { get; set; }
        /// <summary>
        /// Сотрудник
        /// </summary>
        public Guid SEmployeesId { get; set; }
        /// <summary>
        /// Дата для напоминания
        /// </summary>
        public DateTime? DateReminder { get; set; }
        /// <summary>
        /// Дата и время добавления записи
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Статус просмотра
        /// </summary>
        public bool? IsViewed { get; set; }

        public virtual SEmployee SEmployees { get; set; }
    }
}
