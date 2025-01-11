using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Этапы к услугам
    /// </summary>
    public partial class SRoutesStage
    {
        public SRoutesStage()
        {
            APremiumFines = new HashSet<APremiumFine>();
            AServicesRoutesStages = new HashSet<AServicesRoutesStage>();
            DPremiumFines = new HashSet<DPremiumFine>();
            DServicesRoutesStages = new HashSet<DServicesRoutesStage>();
            SServicesRoutesStages = new HashSet<SServicesRoutesStage>();
            DServicesRoutesStagesCurrent = new HashSet<DService>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование этапа
        /// </summary>
        public string StageName { get; set; }
        /// <summary>
        /// Количество дней на исполнение по умолчанию
        /// </summary>
        public int DayExcution { get; set; }
        /// <summary>
        /// Комментарий к записи
        /// </summary>
        public string Commentt { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public int? SServicesStatusId { get; set; }

        public virtual SServicesStatus SServicesStatus { get; set; }
        public virtual ICollection<APremiumFine> APremiumFines { get; set; }
        public virtual ICollection<AServicesRoutesStage> AServicesRoutesStages { get; set; }
        public virtual ICollection<DPremiumFine> DPremiumFines { get; set; }
        public virtual ICollection<DServicesRoutesStage> DServicesRoutesStages { get; set; }
        public virtual ICollection<SServicesRoutesStage> SServicesRoutesStages { get; set; }
        public virtual ICollection<DService> DServicesRoutesStagesCurrent { get; set; }
    }
}
