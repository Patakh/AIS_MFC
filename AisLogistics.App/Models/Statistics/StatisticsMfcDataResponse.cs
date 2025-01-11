namespace AisLogistics.App.Models.Statistics
{
    public class StatisticsMfcDataResponse
    {
        public string Name { get; set; }
        public int ReceivedCount { get; set; }
        public decimal ReceivedStateSum { get; set; }
        public int IssuedCount { get; set; }
        public int ConsultationCount { get; set; }
        public int ALLCount => ReceivedCount + IssuedCount + ConsultationCount;
        public int RefusalCount { get; set; }
        public int ExpiredCount { get; set; }
        public int ExecutionCount { get; set; }
        public decimal ExpiredPercentCount => Math.Round(((decimal)ExpiredCount / ExecutionCount) * 100, 2);
        public int ServiceStateTaskCount { get; set; }
        public decimal ServiceStateTaskPercentCount => StateTaskYear != 0 ? Math.Round(((decimal)ServiceStateTaskCount / StateTaskYear) * 100, 2) : 0;
        public int StateTaskYear {  get; set; }
    }
}
