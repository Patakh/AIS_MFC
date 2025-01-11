using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Список документов результатов к услуге
    /// </summary>
    public partial class AServicesDocumentsResult
    {
        public AServicesDocumentsResult()
        {
            AServicesFileResults = new HashSet<AServicesFileResult>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Связь с услугой
        /// </summary>
        public Guid AServicesId { get; set; }
        /// <summary>
        /// Связь с обращением
        /// </summary>
        public string ACasesId { get; set; }
        /// <summary>
        /// Связь со справочником документов
        /// </summary>
        public Guid SDocumentsId { get; set; }
        /// <summary>
        /// Результат положительный или отрицательный
        /// </summary>
        public bool? DocumentResult { get; set; }
        /// <summary>
        /// Способы получения документа
        /// </summary>
        public string DocumentMethod { get; set; }
        /// <summary>
        /// Срок хранения в органе власти
        /// </summary>
        public string DocumentPeriodProvider { get; set; }
        /// <summary>
        /// Срок хранения в МФЦ
        /// </summary>
        public string DocumentPeriodMfc { get; set; }
        /// <summary>
        /// Кол-во оригиналов
        /// </summary>
        public int? CountOriginal { get; set; }
        /// <summary>
        /// Кол-во копий
        /// </summary>
        public int? CountCopy { get; set; }

        public virtual ACase ACases { get; set; }
        public virtual AService AServices { get; set; }
        public virtual SDocument SDocuments { get; set; }
        public virtual ICollection<AServicesFileResult> AServicesFileResults { get; set; }
    }
}
