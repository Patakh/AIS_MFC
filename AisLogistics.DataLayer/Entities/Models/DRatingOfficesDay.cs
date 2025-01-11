using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Рейтинг филиалов по дням
    /// </summary>
    public partial class DRatingOfficesDay
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
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
        /// Значение 
        /// </summary>
        public int RatingValue { get; set; }
        /// <summary>
        /// Позиция по рейтингу 
        /// </summary>
        public int RatingPosition { get; set; }
        /// <summary>
        /// перемещение по позиции -1 вниз 0 на месте 1 вверх
        /// </summary>
        public int RatingMoving { get; set; }
        /// <summary>
        /// Филиал
        /// </summary>
        public Guid SOfficesId { get; set; }
        /// <summary>
        /// Филиал
        /// </summary>
        public string OfficeName { get; set; }
        /// <summary>
        /// Дата
        /// </summary>
        public DateTime RatingDate { get; set; }
    }
}
