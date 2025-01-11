using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Ссылки на электронные образы документов к услугам
    /// </summary>
    public partial class AServicesFile
    {
        /// <summary>
        /// первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Cвязь документом
        /// </summary>
        public Guid AServicesDocumentsId { get; set; }
        /// <summary>
        /// Связь с номером дела
        /// </summary>
        public string ACasesId { get; set; }
        /// <summary>
        /// Имя файла
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Расширение файла
        /// </summary>
        public string FileExtention { get; set; }
        /// <summary>
        /// Размер файла
        /// </summary>
        public int FileSize { get; set; }
        /// <summary>
        /// 0 - Файл присутствует на FTP, 1 - Файл отсутствует на FTP
        /// </summary>
        public int? FileFlag { get; set; }
        /// <summary>
        /// Тип получения файла. 1 - Сканирование, 2 - С рабочего стола, 3 - С архива
        /// </summary>
        public int TypeAddFile { get; set; }
        /// <summary>
        /// Признак оплачиваемости файла
        /// </summary>
        public bool? IsPaid { get; set; }
        /// <summary>
        /// Дата добавления
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Cвязь с сотрудником добавившим файл
        /// </summary>
        public Guid SEmployeesId { get; set; }
        /// <summary>
        /// Связь с филиалов в котором добавлен файл
        /// </summary>
        public Guid SOfficesId { get; set; }
        /// <summary>
        /// Связь с должностью сотрудника добавившего файл
        /// </summary>
        public int SEmployeesJobPositionId { get; set; }
        /// <summary>
        /// ФИО сотрудник добавившего запись
        /// </summary>
        public string EmployeesFioAdd { get; set; }
        /// <summary>
        /// Cвязь с FTP сервером где храняться файлы
        /// </summary>
        public Guid SFtpId { get; set; }

        public virtual ACase ACases { get; set; }
        public virtual AServicesDocument AServicesDocuments { get; set; }
        public virtual SEmployee SEmployees { get; set; }
        public virtual SEmployeesJobPosition SEmployeesJobPosition { get; set; }
        public virtual SFtp SFtp { get; set; }
        public virtual SOffice SOffices { get; set; }
    }
}
