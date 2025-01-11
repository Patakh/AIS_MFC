using System.ComponentModel;
using Newtonsoft.Json;

namespace AisLogistics.App.Models.Queue
{
    #region Request

    public class RequestData
    {
        [JsonProperty("id")]
        public int Id => 123;

        [JsonProperty("jsonrpc")]
        public string Jsonrpc => "2.0";

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("params")]
        public object Params { get; set; }
    }

    public class GetDeferredTicketsRequestData
    {
        [JsonProperty("window_ip")]
        public string WindowIp { get; set; }

        [JsonProperty("office_id")]
        public int OfficeId { get; set; }
    }

    public class GetTicketsInQueueRequestData
    {
        [JsonProperty("office_id")]
        public int OfficeId { get; set; }
    }

    public class GetTransferedTicketsRequestData
    {
        [JsonProperty("window_ip")]
        public string WindowIp { get; set; }

        [JsonProperty("office_id")]
        public int OfficeId { get; set; }
    }

    public class GetWindowsRequestData
    {
        [JsonProperty("office_id")]
        public int OfficeId { get; set; }
    }

    public class TransferTicketRequestData
    {
        [JsonProperty("office_id")]
        public int OfficeId { get; set; }

        [JsonProperty("from_window_ip")]
        public string FromWindowIp { get; set; }

        [JsonProperty("to_window_ip")]
        public string ToWindowIp { get; set; }

        [JsonProperty("ticket_id")]
        public int TicketId { get; set; }
    }

    public class PostponeTicketRequestData
    {
        [JsonProperty("office_id")]
        public int OfficeId { get; set; }

        [JsonProperty("ticket_id")]
        public int TicketId { get; set; }

        [JsonProperty("window_ip")]
        public string WindowIp { get; set; }
    }

    public class CallTicketRequestData
    {
        [JsonProperty("office_id")]
        public int OfficeId { get; set; }

        [JsonProperty("ticket_id")]
        public int TicketId { get; set; }

        [JsonProperty("window_ip")]
        public string WindowIp { get; set; }
    }

    public class WindowTicketsInQueueStatRequestData
    {
        [JsonProperty("office_id")]
        public int OfficeId { get; set; }

        [JsonProperty("window_ip")]
        public string WindowIp { get; set; }
    }

    public class CallNextTicketInQueueRequestData
    {
        [JsonProperty("office_id")]
        public int OfficeId { get; set; }

        [JsonProperty("window_ip")]
        public string WindowIp { get; set; }
    }

    public class CompleteTicketRequestData
    {
        [JsonProperty("office_id")]
        public int OfficeId { get; set; }

        [JsonProperty("ticket_id")]
        public int TicketId { get; set; }

        [JsonProperty("window_ip")]
        public string WindowIp { get; set; }
    }

    public class ClientNotComeRequestData
    {
        [JsonProperty("office_id")]
        public int OfficeId { get; set; }

        [JsonProperty("ticket_id")]
        public int TicketId { get; set; }

        [JsonProperty("window_ip")]
        public string WindowIp { get; set; }
    }

    public class TakeTicketToWorkRequestData
    {
        [JsonProperty("office_id")]
        public int OfficeId { get; set; }

        [JsonProperty("ticket_id")]
        public int TicketId { get; set; }

        [JsonProperty("window_ip")]
        public string WindowIp { get; set; }
    }

    public class GetTimesForPrerecordRequestData
    {
        [JsonProperty("office_id")]
        public int OfficeId { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }
    }

    public class AddPrerecordRequestData
    {
        [JsonProperty("office_id")]
        public int OfficeId { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("start_time")]
        public DateTime StartTime { get; set; }

        [JsonProperty("stop_time")]
        public DateTime StopTime { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
    }

    public class CancelPrerecordRequestData
    {
        [JsonProperty("office_id")]
        public int OfficeId { get; set; }

        [JsonProperty("code_prerecord")]
        public int CodePrerecord { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }
    }

    public class GetWindowStateRequestData
    {
        [JsonProperty("office_id")]
        public int OfficeId { get; set; }

        [JsonProperty("window_ip")]
        public string WindowIp { get; set; }
    }

    #endregion

    #region Response

    public class ResponseData
    {
        [JsonProperty("error")]
        public ResponseError Error { get; set; }
    }
    public class ResponseError
    {
        [JsonProperty("data")]
        public ErrorData Data;
    }

    public class ErrorData
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public class GetDeferredTicketsResponseData : ResponseData
    {
        [JsonProperty("result")]
        public List<ResponseObject>? Result { get; set; }

        public class ResponseObject
        {
            /// <summary>
            /// Id талона 
            /// </summary>
            [JsonProperty("pk")]
            public int Pk { get; set; }

            [JsonProperty("ticket_number_full")]
            public string TicketNumberFull { get; set; }

            [JsonProperty("s_service")]
            public string Service { get; set; }

            [JsonProperty("date_registration")]
            public DateTime DateRegistration { get; set; }

            [JsonProperty("time_registration")]
            public DateTime TimeRegistration { get; set; }
        }
    }

    public class GetTicketsInQueueResponseData : ResponseData
    {
        [JsonProperty("result")]
        public List<ResponseObject>? Result { get; set; }

        public class ResponseObject
        {
            /// <summary>
            /// Id талона 
            /// </summary>
            [JsonProperty("pk")]
            public int Pk { get; set; }

            [JsonProperty("ticket_number_full")]
            public string TicketNumberFull { get; set; }

            [JsonProperty("s_service")]
            public string Service { get; set; }

            [JsonProperty("date_registration")]
            public DateTime DateRegistration { get; set; }

            [JsonProperty("time_registration")]
            public DateTime TimeRegistration { get; set; }
        }
    }

    public class GetTransferedTicketsResponseData : ResponseData
    {
        [JsonProperty("result")]
        public List<ResponseObject>? Result { get; set; }

        public class ResponseObject
        {
            /// <summary>
            /// Id талона 
            /// </summary>
            [JsonProperty("pk")]
            public int Pk { get; set; }

            [JsonProperty("ticket_number_full")]
            public string TicketNumberFull { get; set; }

            [JsonProperty("s_service")]
            public string Service { get; set; }

            [JsonProperty("date_registration")]
            public DateTime DateRegistration { get; set; }

            [JsonProperty("time_registration")]
            public DateTime TimeRegistration { get; set; }

            [JsonProperty("window_name_from")]
            public string WindowNameFrom { get; set; }
        }
    }

    public class GetWindowsResponseData : ResponseData
    {
        [JsonProperty("result")]
        public List<ResponseObject>? Result { get; set; }

        public class ResponseObject
        {
            [JsonProperty("pk")]
            public int Pk { get; set; }

            [JsonProperty("window_ip")]
            public string WindowIp { get; set; }

            [JsonProperty("window_name")]
            public string WindowName { get; set; }
        }
    }

    public class TransferTicketResponseData : ResponseData
    {
        [JsonProperty("result")]
        public bool Result { get; set; }
    }

    public class PostponeTicketResponseData : ResponseData
    {
        [JsonProperty("result")]
        public bool Result { get; set; }
    }

    public class CallTicketResponseData : ResponseData
    {
        [JsonProperty("result")]
        public string Result { get; set; }
    }

    public class WindowTicketsInQueueStatResponseData : ResponseData
    {
        [JsonProperty("result")]
        public ResponseObject? Result { get; set; }

        public class ResponseObject
        {
            [JsonProperty("in_queue_total")]
            public int InQueueTotal { get; set; }

            [JsonProperty("postponed_count")]
            public int PostponedCount { get; set; }

            [JsonProperty("transferred_count")]
            public int TransferredCount { get; set; }
        }
    }

    public class CallNextTicketInQueueResponseData : ResponseData
    {
        [JsonProperty("result")]
        public ResponseObject Result { get; set; }

        public class ResponseObject
        {
            [JsonProperty("pk")]
            public int Pk { get; set; }

            [JsonProperty("ticket_number_full")]
            public string? TicketNumberFull { get; set; }
        }
    }

    public class CompleteTicketResponseData : ResponseData
    {
        [JsonProperty("result")]
        public string Result { get; set; }
    }

    public class ClientNotComeResponseData : ResponseData
    {
        [JsonProperty("result")]
        public bool Result { get; set; }
    }

    public class TakeTicketToWorkResponseData : ResponseData
    {
        [JsonProperty("result")]
        public bool Result { get; set; }
    }

    public class GetOfficesResponseData : ResponseData
    {
        [JsonProperty("result")]
        public List<ResponseObject>? Result;

        public class ResponseObject
        {
            [JsonProperty("pk")]
            public int Pk { get; set; }

            [JsonProperty("office_name")]
            public string OfficeName { get; set; }
        }
    }

    public class GetTimesForPrerecordResponseData : ResponseData
    {
        [JsonProperty("result")]
        public ResponseObject[] Result;

        public class ResponseObject
        {
            [JsonProperty("day_name")]
            public string DayName { get; set; }

            [JsonProperty("date")]
            public DateTime Date { get; set; }

            [JsonProperty("start_time")]
            public DateTime StartTime { get; set; }

            [JsonProperty("stop_time")]
            public DateTime StopTime { get; set; }
        }
    }

    public class AddPrerecordResponseData : ResponseData
    {
        [JsonProperty("result")]
        public int Result { get; set; }
    }

    public class CancelPrerecordResponseData : ResponseData
    {
        [JsonProperty("result")]
        public bool Result { get; set; }
    }

    public class GetWindowStateResponseData : ResponseData
    {
        [JsonProperty("result")]
        public ResponseObject Result;

        public class ResponseObject
        {
            [JsonProperty("d_ticket")]
            public string DTicket { get; set; }

            [JsonProperty("ticket_number_full")]
            public string TicketNumberFull { get; set; }

            [JsonProperty("date_registration")]
            public DateTime? DateRegistration { get; set; }

            [JsonProperty("time_call")]
            public DateTime? TimeCall { get; set; }

            [JsonProperty("s_office_window")]
            public string SOfficeWindow { get; set; }

            [JsonProperty("time_start_service")]
            public DateTime? TimeStartService { get; set; }

            [JsonProperty("server_time")]
            public DateTime? ServerTime { get; set; }
        }
    }

    #endregion
}
