using Newtonsoft.Json;

namespace AisLogistics.App.Models.MDM
{
    /// <summary>
    /// 4 - Формирование талона
    /// </summary>
    public class MdmTicket
    {
        /// <summary>
        /// 10 - Идентификатор талона в МФЦ.
        /// </summary>
        [JsonProperty("ticket_mfc_uuid")]
        public Guid TicketMfcUuid { get; set; }

        /// <summary>
        /// 152 - Тип предварительной записи: 1 - Не указано 0 - Талон без предварительной записи 1 - Обычная предварительная запись 2 - Талон с предварительной записью по пин-коду
        /// </summary>
        [JsonProperty("id_appointment_type")]
        public int IdAppointmentType { get; set; }

        /// <summary>
        /// 191 - Временная метка события
        /// </summary>
        [JsonProperty("appointment_timestamp")]
        public string AppointmentTimestamp { get; set; }

        /// <summary>
        /// 202 - Временная метка события
        /// </summary>
        [JsonProperty("ticket_timestamp")]
        public string TicketTimestamp { get; set; }

        /// <summary>
        /// 224 - Тип талона по количеству услуг: 1 - Не указано 0 - Простой талон 1 - Комплексный талон
        /// </summary>
        [JsonProperty("id_ticket_type")]
        public int IdTicketType { get; set; }
    }
}
