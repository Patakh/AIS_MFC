namespace AisLogistics.API.Models.Request.Queue
{
    public class QueueRequest
    {
        public QueueRequest(string method) 
        {
            Method = method;
        }

        public int Id => 123;
        public string Jsonrpc => "2.0";
        public string Method { get; set;} 
        public object Params { get; set;}
    }
}
