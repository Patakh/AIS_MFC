using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// История просмотров обращений
    /// </summary>
    public partial class ACasesView
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Обращение
        /// </summary>
        public string ACasesId { get; set; }
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
        /// Дата и время добавления
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Сотрудник
        /// </summary>
        public Guid SEmployeesId { get; set; }
    }
}
