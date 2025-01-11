using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник продолжительности действий сотрудников в минутах
    /// </summary>
    public partial class SPremiumService
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Связь с действием
        /// </summary>
        public int SPremiumStepId { get; set; }
        /// <summary>
        /// Связь с услугой
        /// </summary>
        public Guid SServicesId { get; set; }
        /// <summary>
        /// Продолжительность действия в секундах
        /// </summary>
        public int StepDuration { get; set; }
        /// <summary>
        /// Дата начала действия
        /// </summary>
        public DateTime StepDateStart { get; set; }
        /// <summary>
        /// Дата окончания дейсвия 
        /// </summary>
        public DateTime? StepDateStop { get; set; }
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

        public virtual SPremiumStep SPremiumStep { get; set; }
    }
}
