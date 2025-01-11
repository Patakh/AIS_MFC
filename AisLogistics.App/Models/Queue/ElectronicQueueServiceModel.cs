using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace AisLogistics.App.Models.Queue
{
    #region Request
    [DataContract(Namespace = "CountAbonRequest")]
    public class CountAbonRequestClient
    {
        /// <summary>
        /// Id МФЦ (для электронной очереди)
        /// </summary>
        [DataMember(Name = "Mfc")]
        public int Mfc { get; set; }
        /// <summary>
        /// “json” (Возврат данных будет в json)
        /// </summary>
        [DataMember(Name = "Type_data")]
        public string Type_data { get; set; } = "json";
        /// <summary>
        /// IP адрес оператора в формате “255.255.255.255”
        /// </summary>
        [DataMember(Name = "Ip_operator")]
        public string Ip_operator { get; set; }
    }

    [DataContract(Namespace = "NextAbonRequest")]
    public class NextAbonRequestClient
    {
        /// <summary>
        /// “json” (Возврат данных будет в json)
        /// </summary>
        [DataMember(Name = "Type_data")]
        public string Type_data { get; set; } = "json";

        /// <summary>
        /// (В случае если необходимо вызвать определенного абонента по номеру в num передается номер абонента Например A015. 
        /// Если нужно вызвать просто следующего абонента то передаем пустую строку “”)
        /// </summary>
        [DataMember(Name = "Num")]
        public string Num { get; set; }

        /// <summary>
        /// IP адрес оператора в формате “255.255.255.255”
        /// </summary>
        [DataMember(Name = "Ip_operator")]
        public string Ip_operator { get; set; }

        /// <summary>
        /// Id МФЦ (для электронной очереди)
        /// </summary>
        [DataMember(Name = "Mfc")]
        public int Mfc { get; set; }

        /// <summary>
        /// 0 или 1. Если необходимо завершить работу с текущим абонентом и вызвать следующего, то передаем 0. 
        /// Если необходимо просто завершить обслуживание текущего абонента без вызова следующего, то 1. 
        /// Если передать 0, а в очереди нет больше абонентов, то просто завершится обслуживание текущего. 
        /// </summary>
        [DataMember(Name = "End_call")]
        public int End_call { get; set; } = 1;

        /// <summary>
        /// Id оператора
        /// </summary>
        [DataMember(Name = "operator_guid")]
        public string operator_guid;
    }
    #endregion
    #region Response ListAbonInQueueResponse
    [Serializable()]
    [JsonObject]
    [DataContract(Namespace = "ListAbonInQueueResponse")]
    public class ListAbonDelayResponseClient : QueueResponse
    {
        /// <summary>
        /// Список отложенных абонентов
        /// </summary>
        [DataMember(Name = "abonents_delayed"), JsonProperty("abonents_delayed")]
        public List<ListAbonDelayClient> Abonents { get; set; }
    }

    [Serializable()]
    [JsonObject]
    [DataContract(Namespace = "abonents_delayed")]
    public class ListAbonDelayClient
    {
        /// <summary>
        /// Номер 
        /// </summary>
        [DataMember(Name = "NUM"), JsonProperty("NUM")]
        public string Num { get; set; }

        /// <summary>
        /// Тип 
        /// </summary>
        [DataMember(Name = "USLUGA_NAME"), JsonProperty("USLUGA_NAME")]
        public string Services_name { get; set; }

        /// <summary>
        /// Дата регистрации 
        /// </summary>
        [DataMember(Name = "DATE_DELAYED"), JsonProperty("DATE_DELAYED")]
        public string Data_delayed { get; set; }

        /// <summary>
        /// Время регистрации 
        /// </summary>
        [DataMember(Name = "TIME_DELAY"), JsonProperty("TIME_DELAY")]
        public string Time_delay { get; set; }
    }

    [Serializable()]
    [JsonObject]
    [DataContract(Namespace = "ListAbonInQueueResponse")]
    public class ListAbonInQueueResponseClient : QueueResponse
    {
        /// <summary>
        /// Список людей в очереди 
        /// </summary>
        [DataMember(Name = "abonents"), JsonProperty("abonents")]
        public List<ListAbonInQueueClient>? Abonents { get; set; }
    }

    [Serializable()]
    [JsonObject]
    [DataContract(Namespace = "Abonents")]
    public class ListAbonInQueueClient
    {
        /// <summary>
        /// Номер 
        /// </summary>
        [DataMember(Name = "NUM"), JsonProperty("NUM")]
        public string Num { get; set; }

        /// <summary>
        /// Тип 
        /// </summary>
        [DataMember(Name = "USLUGA_NAME"), JsonProperty("USLUGA_NAME")]
        public string Services_name { get; set; }

        /// <summary>
        /// Дата регистрации 
        /// </summary>
        [DataMember(Name = "DATA_REGISTR"), JsonProperty("DATA_REGISTR")]
        public string Data_registr { get; set; }

        /// <summary>
        /// Время регистрации 
        /// </summary>
        [DataMember(Name = "TIME_REGISTR"), JsonProperty("TIME_REGISTR")]
        public string Time_registr { get; set; }
    }

    [Serializable()]
    [JsonObject]
    [DataContract(Namespace = "ListAbonRedirectResponse")]
    public class ListAbonRedirectResponseClient : QueueResponse
    {
        /// <summary>
        /// Список людей в очереди 
        /// </summary>
        [DataMember(Name = "abonents_redirect"), JsonProperty("abonents_redirect")]
        public List<ListAbonRedirectClient> Abonents { get; set; }
    }

    [Serializable()]
    [JsonObject]
    [DataContract(Namespace = "abonents_redirect")]
    public class ListAbonRedirectClient
    {
        /// <summary>
        /// Номер 
        /// </summary>
        [DataMember(Name = "NUM"), JsonProperty("NUM")]
        public string Num { get; set; }

        /// <summary>
        /// Тип 
        /// </summary>
        [DataMember(Name = "USLUGA_NAME"), JsonProperty("USLUGA_NAME")]
        public string Services_name { get; set; }

        /// <summary>
        /// Дата регистрации 
        /// </summary>
        [DataMember(Name = "DATA_REDIRECT"), JsonProperty("DATA_REDIRECT")]
        public string Data_redirect { get; set; }

        /// <summary>
        /// Время перенаправления 
        /// </summary>
        [DataMember(Name = "TIME_REDIRECT"), JsonProperty("TIME_REDIRECT")]
        public string Time_redirect { get; set; }

        /// <summary>
        /// От 
        /// </summary>
        [DataMember(Name = "FROM_WINDOW"), JsonProperty("FROM_WINDOW")]
        public string From_window { get; set; }
    }

    [Serializable()]
    [JsonObject]
    [DataContract(Namespace = "ListWindow")]
    public class ListWindowResponseClient : QueueResponse
    {
        /// <summary>
        /// Список окон 
        /// </summary>
        [DataMember(Name = "windows"), JsonProperty("windows")]
        public List<ListWindowClient> Windows { get; set; }
    }

    [Serializable()]
    [JsonObject]
    [DataContract(Namespace = "Windows")]
    public class ListWindowClient
    {
        /// <summary>
        /// Id 
        /// </summary>
        [DataMember(Name = "WINDOW_ID"), JsonProperty("WINDOW_ID")]
        public string Id { get; set; }

        /// <summary>
        /// Наименование 
        /// </summary>
        [DataMember(Name = "WINDOW_NAME"), JsonProperty("WINDOW_NAME")]
        public string Name { get; set; }
    }

    [Serializable()]
    [JsonObject]
    [DataContract(Namespace = "CountAbonResponse")]
    public class CountAbonResponseClient : QueueResponse
    {
        /// <summary>
        /// Кол-во абонентов в очереди для данного оператора
        /// </summary>
        [DataMember(Name = "CountAbon"), JsonProperty("CountAbon")]
        public int? CountAbon { get; set; }
        /// <summary>
        /// Кол-во VIP абонентов в очереди для данного оператора 
        /// </summary>
        [DataMember(Name = "CountAbonVIP"), JsonProperty("CountAbonVIP")]
        public int? CountAbonVIP { get; set; }
        /// <summary>
        /// Кол-во отложенных абонентов
        /// </summary>
        [DataMember(Name = "CountDelay"), JsonProperty("CountDelay")]
        public int? CountDelay { get; set; }
        /// <summary>
        /// Кол-во перенаправленных абонентов
        /// </summary>
        [DataMember(Name = "CountRedirect"), JsonProperty("CountRedirect")]
        public int? CountRedirect { get; set; }

        public string request_ip { get; set; }
    }

    [Serializable()]
    [JsonObject]
    [DataContract(Namespace = "NextAbonResponse")]
    public class NextAbonResponseClient : QueueResponse
    {
        /// <summary>
        /// Номер вызванного абонента
        /// </summary>
        [DataMember(Name = "NUM"), JsonProperty("NUM")]
        public string Num { get; set; }

        /// <summary>
        /// Id талона
        /// </summary>
        [DataMember(Name = "GUID_TICKET"), JsonProperty("GUID_TICKET")]
        public string ticket_mfc_uuid { get; set; }

        /// <summary>
        /// Время 
        /// </summary>
        [DataMember(Name = "DATETIME_REGISTR"), JsonProperty("DATETIME_REGISTR")]
        public string ticket_timestamp { get; set; }

        /// <summary>
        /// тип предварительной записи
        /// </summary>
        [DataMember(Name = "APPOINTMENT_TYPE"), JsonProperty("APPOINTMENT_TYPE")]
        public string id_appointment_type { get; set; }

        /// <summary>
        /// временная метка вызова талона 
        /// </summary>
        [DataMember(Name = "DATETIME_CALL"), JsonProperty("DATETIME_CALL")]
        public string ticket_сalled_timestamp { get; set; }

        /// <summary>
        /// идентификатор окна
        /// </summary>
        [DataMember(Name = "SPR_WINDOW_ID"), JsonProperty("SPR_WINDOW_ID")]
        public string window_id { get; set; }
    }

    [Serializable()]
    [JsonObject]
    [DataContract(Namespace = "NumAbonOnWindowResponse")]
    public class NumAbonOnWindowResponseClient : QueueResponse
    {
        /// <summary>
        /// Номер талона
        /// </summary>
        [DataMember(Name = "NUM"), JsonProperty("NUM")]
        public string Num { get; set; }

        /// <summary>
        /// Id талона
        /// </summary>
        [DataMember(Name = "GUID_TICKET"), JsonProperty("GUID_TICKET")]
        public string ticket_mfc_uuid { get; set; }

        /// <summary>
        /// Время 
        /// </summary>
        [DataMember(Name = "DATETIME_REGISTR"), JsonProperty("DATETIME_REGISTR")]
        public string ticket_timestamp { get; set; }

        /// <summary>
        /// тип предварительной записи
        /// </summary>
        [DataMember(Name = "APPOINTMENT_TYPE"), JsonProperty("APPOINTMENT_TYPE")]
        public string id_appointment_type { get; set; }

        /// <summary>
        /// временная метка вызова талона 
        /// </summary>
        [DataMember(Name = "DATETIME_CALL"), JsonProperty("DATETIME_CALL")]
        public string ticket_сalled_timestamp { get; set; }

        /// <summary>
        /// идентификатор окна
        /// </summary>
        [DataMember(Name = "SPR_WINDOW_ID"), JsonProperty("SPR_WINDOW_ID")]
        public string window_id { get; set; }

        /// <summary>
        /// серверное время
        /// </summary>
        [DataMember(Name = "SERVER_TIME"), JsonProperty("SERVER_TIME")]
        public string server_time { get; set; }

    }

    [Serializable()]
    [JsonObject]
    public class QueueResponse
    {
        /// <summary>
        /// Код ошибки
        /// </summary>
        [DataMember(Name = "ErrorCode"), JsonProperty("ErrorCode")]
        public int? ErrorCode { get; set; }
        /// <summary>
        /// Описание ошибки
        /// </summary>
        [DataMember(Name = "ErrorMessage"), JsonProperty("ErrorMessage")]
        public string ErrorMessage { get; set; }
    }

    #endregion

}

