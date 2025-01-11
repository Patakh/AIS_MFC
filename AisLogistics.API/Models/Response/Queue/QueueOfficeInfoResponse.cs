using Newtonsoft.Json;

namespace AisLogistics.API.Models.Responce
{
    public class QueueOfficeInfoObject : QueueObject
    {
        [JsonProperty("result")]
        public List<QueueOfficeInfoResponse>? Result { get; set; }
    }
    public class QueueOfficeInfoResponse
    {
        [JsonProperty("office_name")]
        public string? OfficeName { get; set; }
        [JsonProperty("ticket_all")]
        public int? TicketAll { get; set; }
        [JsonProperty("ticket_queue")]
        public int? TicketQueue { get; set; }
        [JsonProperty("ticket_work")]
        public int? TicketWork { get; set; }
        [JsonProperty("ticket_service")]
        public int? TicketService { get; set; }
        [JsonProperty("waiting_time")]
        public string? WaitingTime { get; set; }
        [JsonProperty("waiting_service")]
        public string? WaitingService { get; set; }
        [JsonProperty("window_count")]
        public int? WindowCount { get; set; }
        [JsonProperty("window_active")]
        public int? WindowActive { get; set; }
        [JsonProperty("window_reception")]
        public int? WindowReception { get; set; }
        [JsonProperty("window_stop")]
        public int? WindowStop { get; set; }
        [JsonProperty("ticket_less_normal")]
        public string? TicketLessNormal { get; set; }
        [JsonProperty("ticket_more_normal")]
        public string? TicketMoreNormal { get; set; }
        [JsonProperty("ticket_min_waiting")]
        public string? TicketMinWaiting { get; set; }
        [JsonProperty("ticket_max_waiting")]
        public string? TicketMaxWaiting { get; set; }
        [JsonProperty("ticket_min_waiting_service")]
        public string? TicketMinWaitingService { get; set; }
        [JsonProperty("ticket_max_waiting_service")]
        public string? TicketMaxWaitingService { get; set; }
    }
}
