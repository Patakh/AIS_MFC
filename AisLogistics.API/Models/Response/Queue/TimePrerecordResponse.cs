using Newtonsoft.Json;

namespace AisLogistics.API.Models.Responce
{
    public class TimePrerecordObject : QueueObject
    {
        [JsonProperty("result")]
        public List<TimePrerecordResponse>? Result;
    }
    public class TimePrerecordResponse
    {
        [JsonProperty("day_name")]
        public string? DayName { get; set; }
        [JsonProperty("date")]
        public string? Date { get; set; }
        [JsonProperty("start_time")]
        public string? StartTime { get; set; }
        [JsonProperty("stop_time")]
        public string? StopTime { get; set; }
    }
}
