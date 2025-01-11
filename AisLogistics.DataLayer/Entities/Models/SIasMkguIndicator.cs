using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Идентификатор оцениваемого критерия (показателя) ИАС МКГУ
    /// </summary>
    public partial class SIasMkguIndicator
    {
        public SIasMkguIndicator()
        {
            DIasMkguRatingLoads = new HashSet<DIasMkguRatingLoad>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование индикатора
        /// </summary>
        public string IndicatorName { get; set; }

        public virtual ICollection<DIasMkguRatingLoad> DIasMkguRatingLoads { get; set; }
    }
}
