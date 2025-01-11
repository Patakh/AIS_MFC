using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Список документов к услуге
    /// </summary>
    public partial class AServicesDocument
    {
        public AServicesDocument()
        {
            AServicesFiles = new HashSet<AServicesFile>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Связь с обращением
        /// </summary>
        public string ACasesId { get; set; }
        /// <summary>
        /// Связь с услугой
        /// </summary>
        public Guid AServicesId { get; set; }
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
        public virtual ICollection<AServicesFile> AServicesFiles { get; set; }
    }
}
