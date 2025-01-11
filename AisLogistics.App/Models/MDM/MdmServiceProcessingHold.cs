using Newtonsoft.Json;

namespace AisLogistics.App.Models.MDM
{
    /// <summary>
    /// 18 - Приостановка процесса оказания услуги
    /// </summary>
    public class MdmServiceProcessingHold
    {
        /// <summary>
        /// 70 - Идентификатор объекта в МФЦ.
        /// </summary>
        [JsonProperty("service_processing_hold_mfc_id")]
        public Guid ServiceProcessingHoldMfcId { get; set; }

        /// <summary>
        /// 71 - Временная метка приостановки оказания услуги.
        /// </summary>
        [JsonProperty("service _processing_hold_timestamp")]
        public string ServiceProcessingHoldTimestamp { get; set; }

        /// <summary>
        /// 72 - Идентификатор объекта начала оказания услуги. = UID 47
        /// </summary>
        [JsonProperty("service _processing_started_mfc_uuid")]
        public Guid ServiceProcessingStartedMfcUuid { get; set; }

        /// <summary>
        /// 181 - Причина приостановки оказания услуги: -1 - Не указано 0 - Оказание услуги приостановлено по инициативе ОГВ 1 - Оказание услуги приостановлено по инициативе заявителя
        /// </summary>
        [JsonProperty("id_service_hold_reason")]
        public string IdServiceHoldReason { get; set; }

        /// <summary>
        /// 212 - Идентификатор связанного объекта
        /// </summary>
        [JsonProperty("reception_ended_mfc_uuid")]
        public string ReceptionEndedMfcUuid { get; set; }
    }
}
