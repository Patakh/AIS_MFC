using System.Text.Json.Serialization;

namespace AisLogistics.API.Models.Request
{
    public class AddPrerecordRequest
    {
        [JsonPropertyName("office_id")]
        public long OfficeId { get; set; }
        [JsonPropertyName("date")]
        public string Date { get; set; }
        [JsonPropertyName("start_time")]
        public string StartTime { get; set; }
        [JsonPropertyName("stop_time")]
        public string StopTime { get; set; }
        [JsonPropertyName("full_name")]
        public string FullName { get; set; }
        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }
    }
}
