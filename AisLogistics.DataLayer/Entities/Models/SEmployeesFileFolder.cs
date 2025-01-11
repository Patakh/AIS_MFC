using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник папок сотрудников для файлов
    /// </summary>
    public partial class SEmployeesFileFolder
    {
        public SEmployeesFileFolder()
        {
            SEmployeesFiles = new HashSet<SEmployeesFile>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Связь с сотрудником
        /// </summary>
        public Guid SEmployeesId { get; set; }
        /// <summary>
        /// Наименование папки
        /// </summary>
        public string FolderName { get; set; }
        /// <summary>
        /// Дата и время добавления папки
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Сотрудник добавивший запись
        /// </summary>
        public string EmployeesFioAdd { get; set; }
        /// <summary>
        /// Признак удаления записи
        /// </summary>
        public bool IsRemove { get; set; }
        /// <summary>
        /// Комментарий к записи
        /// </summary>
        public string Commentt { get; set; }

        public virtual SEmployee SEmployees { get; set; }
        public virtual ICollection<SEmployeesFile> SEmployeesFiles { get; set; }
    }
}
