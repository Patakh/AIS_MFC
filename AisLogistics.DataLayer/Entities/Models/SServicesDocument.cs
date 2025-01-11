using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник документов заявителей
    /// </summary>
    public partial class SServicesDocument
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Связь с документами
        /// </summary>
        public Guid SDocumentsId { get; set; }
        /// <summary>
        /// Связь с подуслугой
        /// </summary>
        public Guid SServicesId { get; set; }
        /// <summary>
        /// Необходимость документа. Обязательный - 0, Не обязательный документ - 1, При наличии - 2.
        /// </summary>
        public int DocumentNeeds { get; set; }
        /// <summary>
        /// Тип документа. Оригинал - 0, Копия - 1
        /// </summary>
        public int DocumentType { get; set; }
        /// <summary>
        /// Количество копий документа
        /// </summary>
        public int DocumentCount { get; set; }

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
        /// Процедура
        /// </summary>
        public Guid? SServicesProcedureId { get; set; }
        /// <summary>
        /// Выгрузка для сайта
        /// </summary>
        public bool IsUploadingSite { get; set; }

        public virtual SDocument SDocuments { get; set; }
        public virtual SService SServices { get; set; }
        public virtual SServicesProcedure SServicesProcedures { get; set; }
    }
}
