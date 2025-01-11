using Newtonsoft.Json;

namespace AisLogistics.App.Models.MDM
{
    /// <summary>
    /// 23 - Выдача результата оказания услуги
    /// </summary>
    public class MdmServiceResultsReceived
    {
        /// <summary>
        /// 88 - Идентификатор объекта.
        /// </summary>
        [JsonProperty("applicant_got_result_mfc_uuid")]
        public Guid ApplicantGotResultMfcUuid { get; set; }

        /// <summary>
        /// 89 - Временная метка объекта.
        /// </summary>
        [JsonProperty("applicant_got_result_timestamp")]
        public string ApplicantGotResultTimestamp { get; set; }

        /// <summary>
        /// 91 - Канал предоставления результата (1-бумажный, 2- электронный).
        /// </summary>
        [JsonProperty("chanel_type")]
        public string ChanelType { get; set; }

        /// <summary>
        /// 210 - Идентификатор связанного объекта = UID 85
        /// </summary>
        [JsonProperty("service_processing_ended_mfc_uuid")]
        public Guid ServiceProcessingEndedMfcUuid { get; set; }

        /// <summary>
        /// 215 - Идентификатор связанного объекта
        /// </summary>
        [JsonProperty("reception_ended_mfc_uuid")]
        public string ReceptionEndedMfcUuid { get; set; }
    }
}
