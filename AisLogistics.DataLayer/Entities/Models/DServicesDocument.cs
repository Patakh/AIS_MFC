using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Список документов к услуге
    /// </summary>
    public partial class DServicesDocument
    {
        public DServicesDocument()
        {
            DServicesFiles = new HashSet<DServicesFile>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Связь с обращением
        /// </summary>
        public string DCasesId { get; set; }
        /// <summary>
        /// Связь с услугой
        /// </summary>
        public Guid DServicesId { get; set; }
        /// <summary>
        /// Связь с документом
        /// </summary>
        public Guid SDocumentsId { get; set; }
        /// <summary>
        /// Количество копий
        /// </summary>
        public int DocumentCount { get; set; }
        /// <summary>
        /// Тип документа (0 - оригинал, 1 - копия)
        /// </summary>
        public int DocumentType { get; set; }
        /// <summary>
        /// Обязательный - 0, Не обязательный документ - 1,  При наличии - 2
        /// </summary>
        public int DocumentNeeds { get; set; }
        /// <summary>
        /// Отметка о предоставлении документа заявителем
        /// </summary>
        public bool IsCheck { get; set; }
        /// <summary>
        /// Отметка о выдаче документа
        /// </summary>
        public bool IsIssued { get; set; }
        /// <summary>
        /// Кол-во оригиналов
        /// </summary>
        public int? CountOriginal { get; set; }
        /// <summary>
        /// Кол-во копий
        /// </summary>
        public int? CountCopy { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public string Commentt { get; set; }
        /// <summary>
        /// Кто добавил
        /// </summary>
        public string? EmployeesFioAdd {  get; set; }
        /// <summary>
        /// Дата и время добавления
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Cвязь с сотрудником добавившим файл
        /// </summary>
        public Guid? SEmployeesId { get; set; }

        public virtual DCase DCases { get; set; }
        public virtual DService DServices { get; set; }
        public virtual SDocument SDocuments { get; set; }
        public virtual SEmployee SEmployees { get; set; }
        public virtual ICollection<DServicesFile> DServicesFiles { get; set; }
    }
}
