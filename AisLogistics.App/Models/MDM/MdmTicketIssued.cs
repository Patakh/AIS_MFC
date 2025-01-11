using Newtonsoft.Json;

namespace AisLogistics.App.Models.MDM
{
    /// <summary>
    /// 2 - Выдача талона
    /// </summary>
    public class MdmTicketIssued
    {
        /// <summary>
        /// 2 - Идентификатор объекта в МФЦ.
        /// </summary>
        [JsonProperty("ticket_issued_mfc_uuid")]
        public Guid TicketIssuedMfcUuid { get; set; }

        /// <summary>
        /// 3 - Временная метка выпуска талона.
        /// </summary>
        [JsonProperty("ticket_issued_timestamp")]
        public string TicketIssuedTimestamp { get; set; }

        /// <summary>
        /// 4 - Идентификатор связанного объекта = UID 10
        /// </summary>
        [JsonProperty("ticket_mfc_uuid")]
        public Guid TicketMfcUuid { get; set; }

        /// <summary>
        /// 223 - Идентификатор связанного объекта = UID 153
        /// </summary>
        [JsonProperty("ticket_result_mfc_uuid")]
        public Guid? TicketResultMfcUuid { get; set; }
    }
}
