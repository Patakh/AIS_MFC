using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Способы оценки качества предоставления услуг
    /// </summary>
    public partial class SServicesTypeQuality
    {
        public SServicesTypeQuality()
        {
            SServicesTypeQualityJoins = new HashSet<SServicesTypeQualityJoin>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Тип оценки качества услуг
        /// </summary>
        public string TypeName { get; set; }

        public virtual ICollection<SServicesTypeQualityJoin> SServicesTypeQualityJoins { get; set; }
    }
}
