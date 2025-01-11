using Newtonsoft.Json;

namespace AisLogistics.App.Models.MDM
{
    /// <summary>
    /// 34 - Завершение обработки талона 
    /// </summary>
    public class MdmTicketResult
    {
        /// <summary>
        /// 153 - Идентификатор события в МФЦ
        /// </summary>
        [JsonProperty("ticket_result_mfc_uuid")]
        public Guid TicketResultMfcUuid { get; set; }

        /// <summary>
        /// 155 - Результат обработки талона: 1 - Не указано 0 - Заявитель прибыл к окну 1 - Заявитель не прибыл к окну
        /// </summary>
        [JsonProperty("id_ticket_result")]
        public int IdTicketResult { get; set; }

        /// <summary>
        /// 193 - Идентификатор связанного объекта = UID 7
        /// </summary>
        [JsonProperty("ticket_called_mfc_uuid")]
        public Guid TicketCalledMfcUuid { get; set; }

        /// <summary>
        /// 216 - Временная метка события
        /// </summary>
        [JsonProperty("ticket_result_timestamp")]
        public string TicketResultTimestamp { get; set; }
    }
}
