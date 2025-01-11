using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник файлов и бланков
    /// </summary>
    public partial class SServicesFile
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Наименование файла
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Расширение
        /// </summary>
        public string FileExpansion { get; set; }
        /// <summary>
        /// Размер
        /// </summary>
        public int FileSize { get; set; }
        /// <summary>
        /// Дата и время добавления записи
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
        /// <summary>
        /// Услуга
        /// </summary>
        public Guid? SServicesId { get; set; }
        /// <summary>
        /// Процедура
        /// </summary>
        public Guid? SServicesProcedureId { get; set; }
        /// <summary>
        /// Файл
        /// </summary>
        public byte[] File { get; set; }
        /// <summary>
        /// не выгружать
        /// </summary>
        public bool IsDownload { get; set; }

        public virtual SService SServices { get; set; }
        public virtual SServicesProcedure SServicesProcedure { get; set; }
    }
}
