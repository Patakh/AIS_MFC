namespace AisLogistics.App.Models.Statistics
{
    public class StatisticsResponse
    {
        public StatisticsResponse()
        {
            InfoForTotay = new();
            Top = new();
            ServicesInfo = new();
        }
        public StatisticsGeneralInfo? InfoForTotay { get; set; }
        public StatisticsGeneralTop? Top { get; set; }
        public StatisticsServicesGeneralInfo? ServicesInfo { get; set; }
    }

    public class StatisticsGeneralInfo
    {
        public int ReceivedCount { get; set; }
        public int IssuedCount { get; set; }
        public int ConsultationCount { get; set; }
        public int ExecutionCount { get; set; }
        public int ExpiredCount { get; set; }
        public int SmevRequestCount { get; set; }
        public int SmevResponseCount { get; set; }
        public decimal ServiceStateTaskCount { get; set; }
    }

    public class StatisticsGeneralTop
    {
        public StatisticsGeneralTop()
        {
            OfficesList = new();
            ProvidersList = new();
            ServicesList = new();
        }
        public List<string> OfficesList { get; set; }
        public List<string> ProvidersList { get; set; }
        public List<string> ServicesList { get; set; }
    }

    public class StatisticsGeneralGraphic
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }

    public class StatisticsServicesGeneralInfo
    {
        public int CountDay { get; set; }
        public int CountMonth { get; set; }
        public int CountQuarter { get; set; }
        public int CountYear { get; set; }
        public int CountExecution { get; set; }
        public int CountExpired { get; set; }
    }

    public class StatisticsServicesGeneralPie
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
