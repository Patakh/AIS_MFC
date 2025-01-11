using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник результатов подуслуги
    /// </summary>
    public partial class SServicesDocumentsResult
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Связь со справочником документов
        /// </summary>
        public Guid SDocumentsId { get; set; }
        /// <summary>
        /// Связь со справочником подуслуг
        /// </summary>
        public Guid SServicesId { get; set; }
        /// <summary>
        /// Результат положительный или отрицательный
        /// </summary>
        public bool DocumentResult { get; set; }
        /// <summary>
        /// Способы получения документа
        /// </summary>
        public string DocumentMethod { get; set; }
        /// <summary>
        /// Срок хранения в органе власти
        /// </summary>
        public string DocumentPeriodProvider { get; set; }
        /// <summary>
        /// Срок хранения в мфц
        /// </summary>
        public string DocumentPeriodMfc { get; set; }
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

        public virtual SDocument SDocuments { get; set; }
        public virtual SService SServices { get; set; }
        public virtual SServicesProcedure SServicesProcedures { get; set; }

    }
}
