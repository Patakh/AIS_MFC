using Newtonsoft.Json;

namespace AisLogistics.App.Models.MDM
{
    /// <summary>
    /// 25 - Формирование талона
    /// </summary>
    public class MdmApplication
    {
        /// <summary>
        /// 98 - Идентификатор Дела в МФЦ.
        /// </summary>
        [JsonProperty("application_mfc_uuid")]
        public Guid ApplicationMfcUuid { get; set; }

        /// <summary>
        /// 174 - Идентификатор связанного объекта = UID 35
        /// </summary>
        [JsonProperty("reception_ended_mfc_uuid")]
        public Guid ReceptionEndedMfcUuid { get; set; }

        /// <summary>
        /// 203 - Временная метка события.
        /// </summary>
        [JsonProperty("application_timestamp")]
        public string ApplicationTimestamp { get; set; }

        /// <summary>
        /// 218 - Признак комплексного запроса: false – запрос не комплексный true – запрос комплексный 
        /// </summary>
        [JsonProperty("is_complex")]
        public bool IsComplex { get; set; }

        /// <summary>
        /// 226 - Признак поступления дела из другого МФЦ: true -  дело поступило из другого МФЦ false – дело не поступало из другого МФЦ
        /// </summary>
        [JsonProperty("from_other_mfc")]
        public bool FromOtherMfc { get; set; }
    }
}
