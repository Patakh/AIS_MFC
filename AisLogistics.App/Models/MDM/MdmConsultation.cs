using Newtonsoft.Json;

namespace AisLogistics.App.Models.MDM
{
    public class MdmConsultation
    {
        /// <summary>
        /// 36 - Идентификатор консультации в МФЦ.
        /// </summary>
        [JsonProperty("consultation_event_mfc_uuid")]
        public Guid ConsultationEventMfcUuid { get; set; }
        /// <summary>
        /// 37 - Временная метка начала консультации.
        /// </summary>
        [JsonProperty("consultation_started_timestamp")]
        public string ConsultationStartedTimestamp { get; set; }
        /// <summary>
        /// 38 - Временная метка завершения консультации.
        /// </summary>
        [JsonProperty("consultation_ended_timestamp")]
        public string ConsultationEndedTimestamp { get; set; }
        /// <summary>
        /// 42 - Канал, по которому производится консультация (0-не определен, 1-личный прием, 2-по телефону).
        /// </summary>
        [JsonProperty("consultation_event_chanel")]
        public int ConsultationEventChanel { get; set; }
        /// <summary>
        /// 189 - Идентификатор окна
        /// </summary>
        [JsonProperty("window_id")]
        public int WindowId { get; set; }
        /// <summary>
        /// 195 - Идентификатор связанного объекта = 153
        /// </summary>
        [JsonProperty("ticket_result_mfc_uuid")]
        public Guid? TicketResultMfcUuid { get; set; }
    }
}
