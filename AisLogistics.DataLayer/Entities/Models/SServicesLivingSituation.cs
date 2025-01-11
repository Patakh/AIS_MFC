using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник услуг по жизненным ситуациям
    /// </summary>
    public partial class SServicesLivingSituation
    {
        public SServicesLivingSituation()
        {
            SServicesLivingSituationJoins = new HashSet<SServicesLivingSituationJoin>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Наименование ситуации
        /// </summary>
        public string SituationName { get; set; }
        /// <summary>
        /// Дата и время добавления записи
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Сотрудник добавивший запись
        /// </summary>
        public string EmployeesFioAdd { get; set; }
        /// <summary>
        /// Признак удаления записи
        /// </summary>
        public bool IsRemove { get; set; }
        /// <summary>
        /// Комментарий к записи
        /// </summary>
        public string Commentt { get; set; }

        public virtual ICollection<SServicesLivingSituationJoin> SServicesLivingSituationJoins { get; set; }
    }
}
