using AisLogistics.App.ViewModels.Pagination;

namespace AisLogistics.App.ViewModels.Statistics
{
    public class StatisticsViewResponseModel
    {
        public object? Model { get; set; }
        public PaginationViewModel Pagination { get; set; }
    }
}
