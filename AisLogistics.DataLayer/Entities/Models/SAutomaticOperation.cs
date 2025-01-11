using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Автоматические операции
    /// </summary>
    public partial class SAutomaticOperation
    {
        public SAutomaticOperation()
        {
            DAutomaticLogs = new HashSet<DAutomaticLog>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование операции
        /// </summary>
        public string OperationName { get; set; }
        /// <summary>
        /// Показатель
        /// </summary>
        //public int? SIndicatorsId { get; set; }
        /// <summary>
        /// Функция
        /// </summary>
        //public string FunctionName { get; set; }

        public virtual ICollection<DAutomaticLog> DAutomaticLogs { get; set; }
    }
}
