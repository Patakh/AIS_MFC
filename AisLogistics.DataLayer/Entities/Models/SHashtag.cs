using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник хэштегов
    /// </summary>
    public partial class SHashtag
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование хештага
        /// </summary>
        public string HashtagName { get; set; }
        /// <summary>
        /// Видимость хештега на форме &quot;Новое обращение&quot;
        /// </summary>
        public bool IsHashtagVisible { get; set; }
    }
}
