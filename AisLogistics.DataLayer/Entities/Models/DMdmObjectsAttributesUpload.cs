using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Таблица для передачи аттрибутов объектов в МДМ.
    /// </summary>
    public partial class DMdmObjectsAttributesUpload
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Идентификатор объекта МДМ, связь с таблицей data_mdm_objects_upload -&gt; id
        /// </summary>
        public long DMdmObjectsUploadId { get; set; }
        /// <summary>
        /// Идентификатор типа аттрибута объекта МДМ, связь с таблицей spr_mdm_object_attribute -&gt; id
        /// </summary>
        public int SMdmObjectAttributeId { get; set; }
        /// <summary>
        /// Значение аттрибута объекта МДМ.
        /// </summary>
        public string MdmAttributeValue { get; set; }
        public virtual DMdmObjectsUpload DMdmObjectsUploads { get; set; }
        public virtual SMdmObjectAttribute SMdmObjectAttributes { get; set; }
    }
}
