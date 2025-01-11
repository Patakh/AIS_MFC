using System.Text.Json.Serialization;

namespace AisLogistics.API.Models.Request
{
    public class TimePrerecordRequest
    {
        [JsonPropertyName("office_id")]
        public long OfficeId { get; set; }
        [JsonPropertyName("date")]
        public string Date { get; set; }
    }
}
