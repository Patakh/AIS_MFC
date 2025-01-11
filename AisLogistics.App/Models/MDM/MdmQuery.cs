using Newtonsoft.Json;

namespace AisLogistics.App.Models.MDM
{
    /// <summary>
    /// 17 - Выполнение межведомственного запроса 
    /// </summary>
    public class MdmQuery
    {
        /// <summary>
        /// 66 - Идентификатор объекта – Запрос.
        /// </summary>
        [JsonProperty("query_mfc_uuid")]
        public Guid QueryMfcUuid { get; set; }

        /// <summary>
        /// 69 - Способ передачи межведомственного запроса в ОГВ: 0 - Отправка запроса с курьером 1 - Отправка электронного запроса через СМЭВ
        /// </summary>
        [JsonProperty("query_type")]
        public string QueryType { get; set; }

        /// <summary>
        /// 217 - Временная метка события
        /// </summary>
        [JsonProperty("query_timestamp")]
        public string QueryTimestamp { get; set; }

        /// <summary>
        /// 220 - Идентификатор связанного объекта
        /// </summary>
        [JsonProperty("reception_started_mfc_uuid")]
        public string ReceptionStartedMfcUuid { get; set; }

        /// <summary>
        /// 227 - Идентификатор связанного объекта
        /// </summary>
        [JsonProperty("consultation_mfc_uuid")]
        public string ConsultationMfcUuid { get; set; }

        /// <summary>
        /// 228 - Идентификатор связанного объекта
        /// </summary>
        [JsonProperty("service_processing_started_mfc_uuid")]
        public string ServiceProcessingStartedMfcUuid { get; set; }
    }
}
