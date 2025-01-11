using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник аттрибутов объектов для отправки в МДМ.
    /// </summary>
    public partial class SMdmObjectAttribute
    {
        public SMdmObjectAttribute()
        {
            DMdmObjectsAttributesUploads = new HashSet<DMdmObjectsAttributesUpload>();
        }
        /// <summary>
        /// Идентификатор аттрибута.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Ссылка на тип объекта МДМ, которому принадлежит аттрибут.
        /// </summary>
        public int SMdmObjectTypeV2Id { get; set; }
        /// <summary>
        /// Мнемоника аттрибута объекта МДМ.
        /// </summary>
        public string ObjectAttributeMnemo { get; set; }
        /// <summary>
        /// Наименовение аттрибута объекта МДМ.
        /// </summary>
        public string ObjectAttributeName { get; set; }
        /// <summary>
        /// Правило проверки значения аттрибута по Regex.
        /// </summary>
        public string ObjectAttributeRegex { get; set; }
        /// <summary>
        /// Является ли значение аттрибута UUID его объекта.
        /// </summary>
        public bool IsObjectUuid { get; set; }
        public virtual ICollection<DMdmObjectsAttributesUpload> DMdmObjectsAttributesUploads { get; set; }
    }
}
