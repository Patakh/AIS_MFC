namespace AisLogistics.App.Models.Statistics
{
    public class StatisticsGeneralResponse
    {
        public StatisticsGeneralResponse()
        {
            Info = new();
            Top = new();
        }
        public StatisticsGeneralInfo Info { get; set; }
        public StatisticsGeneralTop Top { get; set; }
    }

    
}
