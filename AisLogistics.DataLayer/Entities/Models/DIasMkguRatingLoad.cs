using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Оценки загруженные из ИАС МКГУ
    /// </summary>
    public partial class DIasMkguRatingLoad
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// ID фргу органа власти
        /// </summary>
        public string FrguProviderId { get; set; }
        /// <summary>
        /// ID фргу услуги
        /// </summary>
        public string FrguServiceId { get; set; }
        /// <summary>
        /// Связь с индекатором критерия
        /// </summary>
        public int SIasMkguIndicatorId { get; set; }
        /// <summary>
        /// Связь с источником оценок
        /// </summary>
        public int SIasMkguCategoryId { get; set; }
        /// <summary>
        /// Дата и время создания оценки
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Значение оценки
        /// </summary>
        public short? RatingValue { get; set; }
        /// <summary>
        /// Процент удовлетворенности
        /// </summary>
        public short? PositivePercent { get; set; }
        /// <summary>
        /// Дата и вреемя добавления записи
        /// </summary>
        public DateTime DateAdd { get; set; }

        public virtual SIasMkguCategory SIasMkguCategory { get; set; }
        public virtual SIasMkguIndicator SIasMkguIndicator { get; set; }
    }
}
