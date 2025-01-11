using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник оснований для отказа и приостановки по услуге
    /// </summary>
    public partial class SServicesReason
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Связь со спрвочником подуслуг
        /// </summary>
        public Guid SServicesId { get; set; }
        /// <summary>
        /// Текст
        /// </summary>
        public string ReasonText { get; set; }
        /// <summary>
        /// 1 - Отказ в приеме документа. 2 - Отказ в предоставлении подуслуги 
        /// 3- Приостановка 
        /// </summary>
        public int ReasonType { get; set; }
        /// <summary>
        /// Нормативно правовой акт
        /// </summary>
        public string LegalAct { get; set; }
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
        /// <summary>
        /// Количество дней приостановки
        /// </summary>
        public int? CountDay { get; set; }
        /// <summary>
        /// Тип расчета дней
        /// </summary>
        public int? SServicesWeekId { get; set; }

        public virtual SService SServices { get; set; }
        public virtual SServicesWeek SServicesWeek { get; set; }
    }
}
