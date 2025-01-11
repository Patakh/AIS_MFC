using AisLogistics.App.Models.DTO.Reporpts;
using AisLogistics.App.Models.Enums;
using AisLogistics.App.ViewModels.Reports;
using AisLogistics.DataLayer.Entities.Models;
using System.Collections;

namespace AisLogistics.App.Service
{
    public interface IReports
    {
        Task<List<ReportsDto>> GetReportsAsync();
        Task<ReportsDto?> GetReportAsync(Guid Id);
        Task<SForm?> GetReportsFileAsync(int id);
        Task<byte[]> GetReportsFileAsync(Guid id);
        Task<IList?> GetDataReport(ReportViewRequestModel requestModel, string connection);
        Task<byte[]?> ReportDataPrepare(byte[] reportFile, IList data, ReportViewRequestModel requestModel, BlankActionType type, string connection, string employeeName);
    }
}
