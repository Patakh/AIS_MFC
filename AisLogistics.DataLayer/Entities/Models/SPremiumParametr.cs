using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Таблица параметров к зарплате
    /// </summary>
    public partial class SPremiumParametr
    {
        public SPremiumParametr()
        {
            SPremiumParametrsJobPositionJoins = new HashSet<SPremiumParametrsJobPositionJoin>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование параметра
        /// </summary>
        public string ParametrName { get; set; }

        public virtual ICollection<SPremiumParametrsJobPositionJoin> SPremiumParametrsJobPositionJoins { get; set; }
    }
}
