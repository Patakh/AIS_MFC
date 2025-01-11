using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник действий для расчета заработной платы
    /// </summary>
    public partial class SPremiumStep
    {
        public SPremiumStep()
        {
            APremiumSteps = new HashSet<APremiumStep>();
            DPremiumSteps = new HashSet<DPremiumStep>();
            SPremiumServices = new HashSet<SPremiumService>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование активности
        /// </summary>
        public string StepName { get; set; }

        public virtual ICollection<APremiumStep> APremiumSteps { get; set; }
        public virtual ICollection<DPremiumStep> DPremiumSteps { get; set; }
        public virtual ICollection<SPremiumService> SPremiumServices { get; set; }
    }
}
