using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Файлы к информации
    /// </summary>
    public partial class DInformationFile
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Информация
        /// </summary>
        public Guid DInformationId { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Расширение
        /// </summary>
        public string FileExtention { get; set; }
        /// <summary>
        /// Размер
        /// </summary>
        public int FileSize { get; set; }
        /// <summary>
        /// Дата и время добавления
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Кто добавил 
        /// </summary>
        public string EmployeesFioAdd { get; set; }

        /// <summary>
        /// Файл
        /// </summary>
        public byte[] File { get; set; }

        public virtual DInformation DInformation { get; set; }
    }
}
