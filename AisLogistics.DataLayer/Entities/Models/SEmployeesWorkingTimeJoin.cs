using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник статусов для табеля сотрудников
    /// </summary>
    public partial class SEmployeesWorkingTimeJoin
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Связь со статусом рабочего времени
        /// </summary>
        public int SEmployeesWorkingTimeId { get; set; }
        /// <summary>
        /// Связь с сотрудником
        /// </summary>
        public Guid SEmployeesId { get; set; }
        /// <summary>
        /// Связь с отношением филиала к сотруднику
        /// </summary>
        public Guid SEmployeesOfficesJoinId { get; set; }
        /// <summary>
        /// Дата статуса
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Дата и время добавления записи
        /// </summary>
        public DateTime? DateAdd { get; set; }
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

        public virtual SEmployee SEmployees { get; set; }
        public virtual SEmployeesOfficesJoin SEmployeesOfficesJoin { get; set; }
        public virtual SEmployeesWorkingTime SEmployeesWorkingTime { get; set; }
    }
}
