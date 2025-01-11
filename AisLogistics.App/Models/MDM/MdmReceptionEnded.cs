using Newtonsoft.Json;

namespace AisLogistics.App.Models.MDM
{
    /// <summary>
    /// 8 - Завершение процесса регистрации запроса на услугу
    /// </summary>
    public class MdmReceptionEnded
    {
        /// <summary>
        /// 33 - Временная метка окончания приема документов
        /// </summary>
        [JsonProperty("reception_ended_timestamp")]
        public string ReceptionEndedTimestamp { get; set; }

        /// <summary>
        /// 34 - Идентификатор объекта начала приема документов в МФЦ = UID 17
        /// </summary>
        [JsonProperty("reception_started_mfc_uuid")]
        public Guid ReceptionStartedMfcUuid { get; set; }

        /// <summary>
        /// 35 - Идентификатор объекта в МФЦ
        /// </summary>
        [JsonProperty("reception_ended_mfc_uuid")]
        public Guid ReceptionEndedMfcUuid { get; set; }

        /// <summary>
        /// 164 - Результат обработки обращения: 0 - Обращение принято 1 - Процесс регистрации обращения прерван
        /// </summary>
        [JsonProperty("id_reception_result")]
        public int IdReceptionResult { get; set; }

        /// <summary>
        /// 222 - Идентификатор окна
        /// </summary>
        [JsonProperty("window_id")]
        public int WindowId { get; set; }
    }
}
