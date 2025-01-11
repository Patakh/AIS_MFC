using AisLogistics.App.Models.DTO.Statistics;

namespace AisLogistics.App.ViewModels.Statistics
{
    public class StatisticsNavViewRequestModel
    {
        public string NavId { get; set; }
        public string Url { get; set; }
        public List<StatisticsDto> Statistics { get; set; }
    }
}
