namespace AisLogistics.App.ViewModels.Statistics
{
    public class StatisticsViewRequestModel
    {
        public string? DateStart { get; set; }
        public string? DateStop { get; set; }
        public int? StageId {  get; set; }
        public int? YearId { get; set; }
        public int? MonthId { get; set; }
        public Guid? MfcId { get; set; }
        public Guid? EmployeeId { get; set; }
        public Guid? ProviderId { get; set; }
        public Guid? ServiceId { get; set; }
        public Guid? SmevId { get; set; }
        public int? PeriodTypeId { get; set; }
        public int? ServiceTypeId { get; set; }
        public int? CustomerTypeId { get; set; }
        public int? InteractionTypeId { get; set; }
        public int? SmevRequestId { get; set; }
    }
}
