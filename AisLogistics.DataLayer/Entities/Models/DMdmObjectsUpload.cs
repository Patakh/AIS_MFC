using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Таблица для выгрузки данных в МДМ.
    /// </summary>
    public partial class DMdmObjectsUpload
    {
        public DMdmObjectsUpload() 
        {
            DMdmObjectsAttributesUploads = new HashSet<DMdmObjectsAttributesUpload>();
        }
        /// <summary>
        /// Первичный ключ, не uuid потому что важен порядок следования объектов.
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Идентификатор филиала МФЦ в МДМ.
        /// </summary>
        public Guid SOfficesIdMdm { get; set; }
        /// <summary>
        /// Идентификатор типа объекта МДМ, связь с spr_mdm_object_type -&gt; id
        /// </summary>
        public int SMdmObjectTypeId { get; set; }
        /// <summary>
        /// Дата и время создания объекта.
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Флаг, отправлен ли объект в МДМ.
        /// </summary>
        public bool ObjectIsSent { get; set; }
        /// <summary>
        /// Дата и время отправки объекта в МДМ
        /// </summary>
        public DateTime? SentDate { get; set; }
        /// <summary>
        /// ID сообщения СМЭВ 3
        /// </summary>
        public string MessageId { get; set; }
        /// <summary>
        /// true, если атрибуты объекты не полные.
        /// </summary>
        public bool ObjectInvalid { get; set; }
        /// <summary>
        /// Индетификатор услуги обращения
        /// </summary>
        public Guid? DServicesId { get; set; }

        public virtual ICollection<DMdmObjectsAttributesUpload> DMdmObjectsAttributesUploads { get; set; }
    }
}
