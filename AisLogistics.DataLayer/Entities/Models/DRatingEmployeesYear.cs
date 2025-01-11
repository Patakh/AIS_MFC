using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Рейтинг по сотрудникам  за год. 
    /// </summary>
    public partial class DRatingEmployeesYear
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Сотрудник
        /// </summary>
        public Guid SEmployeesId { get; set; }
        /// <summary>
        /// Филиал
        /// </summary>
        public Guid SOfficesId { get; set; }
        /// <summary>
        /// Должность
        /// </summary>
        public int SEmployeesJobPositionId { get; set; }
        /// <summary>
        /// Сотрудник
        /// </summary>
        public string EmployeeName { get; set; }
        /// <summary>
        /// Филиал
        /// </summary>
        public string OfficeName { get; set; }
        /// <summary>
        /// Должность
        /// </summary>
        public string JobPositionName { get; set; }
        /// <summary>
        /// Дата
        /// </summary>
        public DateTime RatingDate { get; set; }
        /// <summary>
        /// Принято
        /// </summary>
        public int ReceivedCount { get; set; }
        /// <summary>
        /// Консультации
        /// </summary>
        public int ConsultationCount { get; set; }
        /// <summary>
        /// Выдано
        /// </summary>
        public int IssuedCount { get; set; }
        /// <summary>
        /// Исполненные услуги
        /// </summary>
        public int ExecutedCount { get; set; }
        /// <summary>
        /// Позиция по рейтингу 
        /// </summary>
        public int RatingPosition { get; set; }
        /// <summary>
        /// перемещение по позиции -1 вниз 0 на месте 1 вверх
        /// </summary>
        public int RatingMoving { get; set; }
        /// <summary>
        /// Значение рейтинга
        /// </summary>
        public int RatingValue { get; set; }
        /// <summary>
        /// Год
        /// </summary>
        public int Year { get; set; }
    }
}
