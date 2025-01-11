using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Избранные обращения по сотрудникам
    /// </summary>
    public partial class DCasesFavorite
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Cвязь с делом
        /// </summary>
        public string DCasesId { get; set; }
        /// <summary>
        /// Cвязь с сотрудником
        /// </summary>
        public Guid SEmployeesId { get; set; }
        /// <summary>
        /// Дата добавления в избранное
        /// </summary>
        public DateTime DateAdd { get; set; }

        public virtual DCase DCases { get; set; }
        public virtual SEmployee SEmployees { get; set; }
    }
}
