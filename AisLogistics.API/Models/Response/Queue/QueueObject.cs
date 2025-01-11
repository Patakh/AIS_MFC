using Newtonsoft.Json;

namespace AisLogistics.API.Models.Responce
{
    public class QueueObject
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
}
