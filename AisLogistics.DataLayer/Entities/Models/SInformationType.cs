using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Типы информации
    /// </summary>
    public partial class SInformationType
    {
        public SInformationType()
        {
            DInformations = new HashSet<DInformation>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование 
        /// </summary>
        public string TypeName { get; set; }

        public virtual ICollection<DInformation> DInformations { get; set; }
    }
}
