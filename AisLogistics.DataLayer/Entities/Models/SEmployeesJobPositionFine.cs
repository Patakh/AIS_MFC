using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник штрафов в отношении должностей
    /// </summary>
    public partial class SEmployeesJobPositionFine
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Связь с должностью
        /// </summary>
        public int SEmployeesJobPositionId { get; set; }
        /// <summary>
        /// Сумма штрафа
        /// </summary>
        public decimal FineSum { get; set; }
        /// <summary>
        /// Дата начала действия штрафа
        /// </summary>
        public DateTime DateStart { get; set; }
        /// <summary>
        /// Дата окончания действия штрафа
        /// </summary>
        public DateTime DateStop { get; set; }
        /// <summary>
        /// Дата и время добавления записи
        /// </summary>
        public DateTime? DateAdd { get; set; }
        /// <summary>
        /// Сотрудник добавивший запись
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

        public virtual SEmployeesJobPosition SEmployeesJobPosition { get; set; }
    }
}
