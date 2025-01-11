using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник типов объектов, передаваемых в МДМ.
    /// </summary>
    public partial class SMdmObjectType
    {
        /// <summary>
        /// Первичный ключ, идентификатор типа объекта.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Мнемоника типа объекта МДМ.
        /// </summary>
        public string ObjectTypeMnemo { get; set; }
        /// <summary>
        /// Наименование типа объекта МДМ.
        /// </summary>
        public string ObjectTypeName { get; set; }
    }
}
