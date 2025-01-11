using Newtonsoft.Json;

namespace AisLogistics.App.Models.MDM
{
    /// <summary>
    /// 22 - Завершение процесса оказания услуги
    /// </summary>
    public class MdmServiceProcessingEnded
    {
        /// <summary>
        /// 85 - Идентификатор объекта в МФЦ.
        /// </summary>
        [JsonProperty("application_processing_ended_mfc_uuid")]
        public Guid ApplicationProcessingEndedMfcUuid { get; set; }

        /// <summary>
        /// 86 - Временная метка окончания оказания услуги.
        /// </summary>
        [JsonProperty("application_processing_ended_timestamp")]
        public string ApplicationProcessingEndedTimestamp { get; set; }

        /// <summary>
        /// 87 - Причина окончания оказания услуги: 
        /// 0 - Прочее 1 - Результат оказания слуги подготовлен к выдаче в исходном МФЦ 
        /// 2 - Результат оказания услуги передан в ОГВ для выдачи 3 - Результат оказания услуги передан в другой МФЦ для выдачи 
        /// 4 - Оказание услуги прекращено по инициативе заявителя 5 - Оказание услуги прекращено по инициативе ОГВ
        /// </summary>
        [JsonProperty("application_processing_ended_cause")]
        public string ApplicationProcessingEndedCause { get; set; }

        /// <summary>
        /// 209 - Идентификатор связанного объекта = UID 47
        /// </summary>
        [JsonProperty("service_preocessing_started_mfc_uuid")]
        public Guid ServicePreocessingStartedMfcUuid { get; set; }

        /// <summary>
        /// 214 - Идентификатор связанного объекта
        /// </summary>
        [JsonProperty("reception_ended_mfc_uuid")]
        public string ReceptionEndedMfcUuid { get; set; }

        /// <summary>
        /// 225 - Признак нарушения сроков оказания услуги: true – сроки нарушены false – сроки не нарушены
        /// </summary>
        [JsonProperty("deadline_violated")]
        public bool DeadlineViolated { get; set; }
    }
}
