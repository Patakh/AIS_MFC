using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник оздоровительных учреждений для запросов через МинОбр VipNet
    /// </summary>
    public partial class SHealthCamp
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Наименование оздоровительного учреждения
        /// </summary>
        public string CampName { get; set; }
        /// <summary>
        /// Разрешена ли запись на 1 смену
        /// </summary>
        public bool Shift1 { get; set; }
        /// <summary>
        /// Разрешена ли запись на 2 смену
        /// </summary>
        public bool Shift2 { get; set; }
        /// <summary>
        /// Разрешена ли запись на 3 смену
        /// </summary>
        public bool Shift3 { get; set; }
        /// <summary>
        /// Идентификатор оздоровительного учреждения для випнета
        /// </summary>
        public string CampId { get; set; }
        /// <summary>
        /// Признак удаления записи
        /// </summary>
        public bool IsRemove { get; set; }
        /// <summary>
        /// Комментарий к записи
        /// </summary>
        public string Commentt { get; set; }
    }
}
