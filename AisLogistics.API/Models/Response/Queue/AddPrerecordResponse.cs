using Newtonsoft.Json;

namespace AisLogistics.API.Models.Responce
{

    public class AddPrerecordObject : QueueObject
    {
        [JsonProperty("result")]
        public string? Result;
    }
    public class AddPrerecordResponse
    {
        public long Code { get; set; }
    }
}
