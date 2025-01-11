using System;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Госзадание
    /// </summary>
    public partial class SStateTask
    {
        /// <summary>
        /// Ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Количество услуг 
        /// </summary>
        public int CountService { get; set; }
        /// <summary>
        /// Год
        /// </summary>
        public int YearTask { get; set; }
        /// <summary>
        /// Кто добавил
        /// </summary>
        public string EmployeesFioAdd { get; set; }
        /// <summary>
        /// Дата и время добавления
        /// </summary>
        public DateTime DateAdd { get; set; }
    }
}
