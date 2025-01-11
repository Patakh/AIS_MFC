using Newtonsoft.Json;

namespace AisLogistics.App.Models.MDM
{
    /// <summary>
    /// 5- Начало процесса регистации запроса на услугу
    /// </summary>
    public class MdmReceptionStarted
    {

        /// <summary>
        /// 15 - Временная метка. 'генерируется при создании обращения
        /// </summary>
        [JsonProperty("reception_started_timestamp")]
        public string ReceptionStartedTimestamp { get; set; }

        /// <summary>
        /// 17 - Идентификатор объекта в МФЦ. 'генерируется при создании обращения
        /// </summary>
        [JsonProperty("reception_started_mfc_uuid")]
        public Guid ReceptionStartedMfcUuid { get; set; }

        /// <summary>
        /// 157 - Канал поступления обращения:0 - Прочее, 1 - Личный прием, 2 - Портал, 3 - Заказное письмо
        /// </summary>
        [JsonProperty("id_reception_channel")]
        public int IdReceptionChannel { get; set; }

        /// <summary>
        /// 190 - Идентификатор окна
        /// </summary>
        [JsonProperty("window_id")]
        public int WindowId { get; set; }

        /// <summary>
        /// 196 - Идентификатор связанного объекта = UID 153
        /// </summary>
        [JsonProperty("ticket_result_mfc_uuid")]
        public Guid? TicketResultMfcUuid { get; set; }
    }
}
