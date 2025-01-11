using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Список файлов с результатами услуги
    /// </summary>
    public partial class DServicesFileResult
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
        /// Тип добавления файла (1 - Сканирование, 2 - C рабочего стола, 3 - с архива)
        /// </summary>
        public int TypeAddFile { get; set; }
        /// <summary>
        /// Признак оплачиваемости файла
        /// </summary>
        public bool? IsPaid { get; set; }
        /// <summary>
        /// Сохранность на FTP
        /// </summary>
        public bool? IsSavedFtp { get; set; }
        /// <summary>
        /// Связь с сотрудником добавившим запись
        /// </summary>
        public Guid SEmployeesId { get; set; }
        /// <summary>
        /// Связь с филиалом сотрудника, добавившего запись
        /// </summary>
        public Guid SOfficesId { get; set; }
        /// <summary>
        /// Связь с должностью сотрудника, добавившего запись
        /// </summary>
        public int SEmployeesJobPositionId { get; set; }
        /// <summary>
        /// Документ результата к услуге
        /// </summary>
        public Guid DServicesDocumentResultId { get; set; }
        /// <summary>
        /// Дата внесения услуги
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// ФИО сотрудник добавившего запись
        /// </summary>
        public string EmployeesFioAdd { get; set; }
        /// <summary>
        /// Cвязь с FTP сервером где храняться файлы
        /// </summary>
        public Guid SFtpId { get; set; }

        public virtual DCase DCases { get; set; }
        public virtual DServicesDocumentsResult DServicesDocumentResult { get; set; }
        public virtual SEmployee SEmployees { get; set; }
        public virtual SEmployeesJobPosition SEmployeesJobPosition { get; set; }
        public virtual SFtp SFtp { get; set; }
        public virtual SOffice SOffices { get; set; }
    }
}
