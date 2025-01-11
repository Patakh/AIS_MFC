using Newtonsoft.Json;

namespace AisLogistics.API.Models.Responce
{
    public class OfficeQueueObject : QueueObject
    {
        [JsonProperty("result")]
        public List<OfficeQueueResponse>? Result;
    }

    public class OfficeQueueResponse
    {
        [JsonProperty("pk")]
        public long? Id { get; set; }
        [JsonProperty("office_name")]
        public string? Name { get; set; }
    }
}
