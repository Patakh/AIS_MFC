using Newtonsoft.Json;

namespace AisLogistics.App.Models.MDM
{
    /// <summary>
    /// 3 - Вызов талона
    /// </summary>
    public class MdmTicketCalled
    {
        /// <summary>
        /// 7 - Идентификатор объекта в МФЦ.
        /// </summary>
        [JsonProperty("ticket_called_mfc_uuid")]
        public Guid TicketCalledMfcUuid { get; set; }

        /// <summary>
        /// 8 - Временная метка вызова талона.
        /// </summary>
        [JsonProperty("ticket_called_timestamp")]
        public string TicketCalledTimestamp { get; set; }

        /// <summary>
        /// 187 - Идентификатор окна
        /// </summary>
        [JsonProperty("window_id")]
        public int WindowId { get; set; }

        /// <summary>
        /// 192 - Идентификатор связанного объекта = UID 2
        /// </summary>
        [JsonProperty("ticket_issued_mfc_uuid")]
        public Guid TicketIssuedMfcUuid { get; set; }

    }
}
