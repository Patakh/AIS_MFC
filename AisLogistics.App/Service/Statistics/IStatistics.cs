using AisLogistics.App.Models.DTO.Statistics;
using AisLogistics.App.Models.Statistics;
using AisLogistics.App.ViewModels.Statistics;
using DataTables.AspNet.Core;

namespace AisLogistics.App.Service
{
    public interface IStatistics
    {
        Task<StatisticsResponse> GetAnaliticsAsync();
        Task<StatisticsGeneralResponse?> StatisticsGeneral();
        Task<List<StatisticsGeneralGraphic>?> StatisticsGeneralGraphicTypeDay(StatisticsViewRequestModel requestModel);
        Task<List<StatisticsGeneralGraphic>?> StatisticsGeneralGraphicTypeYear(StatisticsViewRequestModel requestModel);
        Task<(List<StatisticsMfcDataResponse>?, int)> StatisticsMfcData(IDataTablesRequest request, StatisticsViewRequestModel requestModel);
        Task<(List<StatisticsMfcDataResponse>?, int)> StatisticsEmployeeData(IDataTablesRequest request, StatisticsViewRequestModel requestModel);
        Task<(List<StatisticsMfcDataResponse>?, int)> StatisticsProviderData(IDataTablesRequest request, StatisticsViewRequestModel requestModel);
        Task<(List<StatisticsMfcDataResponse>?, int)> StatisticsServiceData(IDataTablesRequest request, StatisticsViewRequestModel requestModel);
        Task<(List<StatisticsMfcDataResponse>?, int)> StatisticsCustomerTypeData(IDataTablesRequest request, StatisticsViewRequestModel requestModel);
        Task<(List<StatisticsMfcDataResponse>?, int)> StatisticsServiceTypeData(IDataTablesRequest request, StatisticsViewRequestModel requestModel);
        Task<(List<StatisticsMfcDataResponse>?, int)> StatisticsInteractionTypeData(IDataTablesRequest request, StatisticsViewRequestModel requestModel);
        Task<(List<StatisticsSmevDataResponse>?, int)> StatisticsSmevData(IDataTablesRequest request, StatisticsViewRequestModel requestModel);
        Task<(List<StatisticsSmevDataResponse>?, int)> StatisticsSmevMfcData(IDataTablesRequest request, StatisticsViewRequestModel requestModel);
        Task<(List<StatisticsSmevDataResponse>?, int)> StatisticsSmevEmployeeData(IDataTablesRequest request, StatisticsViewRequestModel requestModel);
        Task<StatisticsServiceGeneralResponse?> StatisticsServicesGeneral();
        Task<Dictionary<string, int>> StatisticsServicesGeneralServiceType();
        Task<Dictionary<string, int>> StatisticsServicesGeneralCustomerType();
        Task<Dictionary<string, int>> StatisticsServicesGeneralInteractionType();
        Task<Dictionary<string, List<string>>?> StatisticsServicesGeneralGraphicTypeDay(StatisticsViewRequestModel requestModel);
        Task<Dictionary<string, List<string>>?> StatisticsServicesGeneralGraphicTypeYear(StatisticsViewRequestModel requestModel);
        Task<Dictionary<string, List<string>>?> StatisticsSmevGraphicTypeDay(StatisticsViewRequestModel requestModel);
        Task<Dictionary<string, List<string>>?> StatisticsSmevGraphicTypeYear(StatisticsViewRequestModel requestModel);
    }
}
