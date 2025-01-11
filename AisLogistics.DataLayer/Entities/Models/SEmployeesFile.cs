using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник файлов сотрудника
    /// </summary>
    public partial class SEmployeesFile
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Связь с папкой
        /// </summary>
        public Guid SEmployeesFileFolderId { get; set; }
        /// <summary>
        /// Наименование файла
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Расширение файла
        /// </summary>
        public string FileExtension { get; set; }
        /// <summary>
        /// Размер файла
        /// </summary>
        public int FileSize { get; set; }
        /// <summary>
        /// Дата и время добавления записи
        /// </summary>
        public DateTime? DateAdd { get; set; }
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

        public virtual SEmployeesFileFolder SEmployeesFileFolder { get; set; }
    }
}
