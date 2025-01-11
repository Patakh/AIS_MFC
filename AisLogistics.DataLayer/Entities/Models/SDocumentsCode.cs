using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Коды подразделений выдавших документы
    /// </summary>
    public partial class SDocumentsCode
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Код документа
        /// </summary>
        public string DocumentCode { get; set; }
        /// <summary>
        /// Кто выдал документ
        /// </summary>
        public string DocumentIssueBody { get; set; }
        /// <summary>
        /// Дата окончания названия документа
        /// </summary>
        public DateTime? DateStop { get; set; }
        public Guid? IdUuid { get; set; }
    }
}
