namespace AisLogistics.API.Models.Responce
{
    public class ServiceStateTaskInfoResponse
    {
        public int StateTaskCount { get; set; }
        public int ExecutedCount { get; set; }
        public decimal ExecutedPercent { get; set; }
        public int Forecastcount { get; set; }
        public decimal Forecastpercent { get; set; }
    }
}
