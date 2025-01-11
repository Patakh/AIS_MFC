using AisLogistics.App.Models.DTO.Reporpts;

namespace AisLogistics.App.ViewModels.Reports
{
    public class ReportNavViewRequestModel
    {
        public string NavId { get; set; }
        public string Url { get; set; }
        public List<ReportsDto> Reports { get; set; }
    }
}
