using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник ОКОПФ (Общероссийский классификатор организационно-правовых форм)
    /// </summary>
    public partial class SSmevClassOkopf
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// ID родительской записи
        /// </summary>
        public int? ParentId { get; set; }
        /// <summary>
        /// Код элемента справочника
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Описание элемента справочника
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Наименование элемента справочника
        /// </summary>
        public string Name { get; set; }
    }
}
