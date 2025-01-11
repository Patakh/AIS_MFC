using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Список должностей учавствующих в рейтинге 
    /// </summary>
    public partial class SRatingJobPosition
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Должность
        /// </summary>
        public int SEmployeesJobPositionId { get; set; }
        public string Commentt { get; set; }

        public virtual SEmployeesJobPosition SEmployeesJobPosition { get; set; }
    }
}
