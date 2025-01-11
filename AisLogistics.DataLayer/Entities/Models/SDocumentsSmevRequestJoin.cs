using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник отношений запросов СМЭВ к документам
    /// </summary>
    public partial class SDocumentsSmevRequestJoin
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Связь с документом
        /// </summary>
        public Guid SDocumentsId { get; set; }
        /// <summary>
        /// Связь с запросом СМЭВ
        /// </summary>
        public int SSmevRequestId { get; set; }
        /// <summary>
        /// Дата добавления
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Кто добавил
        /// </summary>
        public string EmployeesFioAdd { get; set; }
        /// <summary>
        /// Комментарий
        /// </summary>
        public string Commentt { get; set; }
        /// <summary>
        /// Признак удаления записи
        /// </summary>
        public bool IsRemove { get; set; }

        public virtual SDocument SDocuments { get; set; }
        public virtual SSmevRequest SSmevRequest { get; set; }
    }
}
