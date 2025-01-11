using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Источники оценок ИАС МКГУ
    /// </summary>
    public partial class SIasMkguCategory
    {
        public SIasMkguCategory()
        {
            DIasMkguRatingLoads = new HashSet<DIasMkguRatingLoad>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование категории
        /// </summary>
        public string CategoryName { get; set; }

        public virtual ICollection<DIasMkguRatingLoad> DIasMkguRatingLoads { get; set; }
    }
}
