using System.Text.Json.Serialization;

namespace AisLogistics.API.Models.Request
{
    public class CanselPrerecordRequest
    {
        [JsonPropertyName("office_id")]
        public long OfficeId { get; set; }
        [JsonPropertyName("date")]
        public string Date { get; set; }
        [JsonPropertyName("code")]
        public long Code { get; set; }
    }
}
