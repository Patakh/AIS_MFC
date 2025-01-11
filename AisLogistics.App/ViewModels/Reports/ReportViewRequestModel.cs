using AisLogistics.App.Models.Enums;

namespace AisLogistics.App.ViewModels.Reports
{
    public class ReportViewRequestModel
    {
        public Guid Id { get; set; }
        public ReportsType Method { get; set; }
        public string ModelType { get; set; }
        public string? DateStart { get; set; }
        public string? DateStop { get; set; }
        public Guid? MfcId { get; set; }
        public int? SpsId { get; set; }
        public List<string>? MfcIdList { get; set; }
        public Guid? EmployeeId { get; set; }
        public List<Guid>? EmployeeIdList { get; set; }
        public Guid? ProviderId { get; set; }
        public List<Guid>? ProviderIdList { get; set; }
        public Guid? ServiceId { get; set; }
        public List<Guid>? ServiceIdList { get; set; }
        public Guid? SmevId { get; set; }
        public List<Guid>? SmevIdList { get; set; }
        public int? SmevRequestId { get; set; }
        public List<int>? SmevRequestIdList { get; set; }
    }
}
