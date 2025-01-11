using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник документов необходимых для оказания услуги
    /// </summary>
    public partial class SDocument
    {
        public SDocument()
        {
            AServicesDocuments = new HashSet<AServicesDocument>();
            AServicesDocumentsResults = new HashSet<AServicesDocumentsResult>();
            DServicesDocuments = new HashSet<DServicesDocument>();
            DServicesDocumentsResults = new HashSet<DServicesDocumentsResult>();
            SDocumentsSmevRequestJoins = new HashSet<SDocumentsSmevRequestJoin>();
            SServicesDocuments = new HashSet<SServicesDocument>();
            SServicesDocumentsResults = new HashSet<SServicesDocumentsResult>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Наименование документа
        /// </summary>
        public string DocumentName { get; set; }
        /// <summary>
        /// Описание документа
        /// </summary>
        public string DocumentDescription { get; set; }
        /// <summary>
        /// Требование к документу
        /// </summary>
        public string DocumentSpecification { get; set; }
        /// <summary>
        /// Дата и время добавления документа
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// ФИО сотрудник добавившего запись
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

        public virtual ICollection<AServicesDocument> AServicesDocuments { get; set; }
        public virtual ICollection<AServicesDocumentsResult> AServicesDocumentsResults { get; set; }
        public virtual ICollection<DServicesDocument> DServicesDocuments { get; set; }
        public virtual ICollection<DServicesDocumentsResult> DServicesDocumentsResults { get; set; }
        public virtual ICollection<SDocumentsSmevRequestJoin> SDocumentsSmevRequestJoins { get; set; }
        public virtual ICollection<SServicesDocument> SServicesDocuments { get; set; }
        public virtual ICollection<SServicesDocumentsResult> SServicesDocumentsResults { get; set; }
    }
}
