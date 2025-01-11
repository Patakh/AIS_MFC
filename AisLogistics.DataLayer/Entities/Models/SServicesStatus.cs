using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Таблица статусов к услуге
    /// </summary>
    public partial class SServicesStatus
    {
        public SServicesStatus()
        {
            AServices = new HashSet<AService>();
            DServices = new HashSet<DService>();
            SRoutesStages = new HashSet<SRoutesStage>();
        }

        /// <summary>
        ///  Первичный ключ
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование статуса
        /// </summary>
        public string StatusName { get; set; }
        /// <summary>
        /// Завершение услуги
        /// </summary>
        public bool IsDatefact { get; set; }

        public virtual ICollection<AService> AServices { get; set; }
        public virtual ICollection<DService> DServices { get; set; }
        public virtual ICollection<SRoutesStage> SRoutesStages { get; set; }
    }
}
