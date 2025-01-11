using Newtonsoft.Json;

namespace AisLogistics.API.Models.Responce
{

    public class CanselPrerecordObject : QueueObject
    {
        [JsonProperty("result")]
        public string? Result;
    }
    public class CanselPrerecordResponse
    {
        public bool Succses { get; set; }
    }
}
