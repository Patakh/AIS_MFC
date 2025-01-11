using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// История просмотров обращений
    /// </summary>
    public partial class DCasesView
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Обращение
        /// </summary>
        public string DCasesId { get; set; }
        /// <summary>
        /// Сотрудник
        /// </summary>
        public string EmployeesName { get; set; }
        /// <summary>
        /// Организация
        /// </summary>
        public string OfficeName { get; set; }
        /// <summary>
        /// Должность
        /// </summary>
        public string JobPositionName { get; set; }
        /// <summary>
        /// Дата и время
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Сотрудник
        /// </summary>
        public Guid SEmployeesId { get; set; }

        public virtual DCase DCases { get; set; }
        public virtual SEmployee SEmployees { get; set; }
    }
}
