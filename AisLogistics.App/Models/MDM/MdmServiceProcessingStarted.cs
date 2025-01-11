using Newtonsoft.Json;

namespace AisLogistics.App.Models.MDM
{
    /// <summary>
    /// 11 - Взятие услуги в работу работником МФЦ
    /// </summary>
    public class MdmServiceProcessingStarted
    {
        /// <summary>
        /// 47 - Идентификатор объекта в МФЦ
        /// </summary>
        [JsonProperty("service_processing_started_mfc_uuid")]
        public Guid ServiceProcessingStartedMfcUuid { get; set; }

        /// <summary>
        /// 48 - Идентификатор Дела в МФЦ. = UID 98
        /// </summary>
        [JsonProperty("application_mfs_uuid")]
        public Guid ApplicationMfsUuid { get; set; }

        /// <summary>
        /// 49 - Временная метка начала оказания услуги.
        /// </summary>
        [JsonProperty("service_processing_started_timestamp")]
        public string ServiceProcessingStartedTimestamp { get; set; }

        /// <summary>
        /// 204 - Идентификатор услуги МФЦ
        /// </summary>
        [JsonProperty("service_mfc_uuid")]
        public Guid ServiceMfcUuid { get; set; }
    }
}
