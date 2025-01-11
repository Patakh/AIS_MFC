using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Этапы к услуге
    /// </summary>
    public partial class SServicesRoutesStage
    {
        public SServicesRoutesStage()
        {
            AServicesRoutesStages = new HashSet<AServicesRoutesStage>();
            SServicesRoutesStageRoles = new HashSet<SServicesRoutesStageRole>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Услуга
        /// </summary>
        public Guid SServicesId { get; set; }
        /// <summary>
        /// Этап
        /// </summary>
        public int SRoutesStageId { get; set; }
        /// <summary>
        /// Дата и время добавления записи
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Сотрудник добавивший запись
        /// </summary>
        public string EmployeesFioAdd { get; set; }
        /// <summary>
        /// Комментарий к записи
        /// </summary>
        public string Commentt { get; set; }
        /// <summary>
        /// ID родительской записи
        /// </summary>
        public Guid ParentId { get; set; }
        /// <summary>
        /// Признак удаления
        /// </summary>
        public bool IsRemove { get; set; }
        public virtual SRoutesStage SRoutesStage { get; set; }
        public virtual SService SServices { get; set; }
        public virtual ICollection<AServicesRoutesStage> AServicesRoutesStages { get; set; }
        public virtual ICollection<SServicesRoutesStageRole> SServicesRoutesStageRoles { get; set; }
    }
}
