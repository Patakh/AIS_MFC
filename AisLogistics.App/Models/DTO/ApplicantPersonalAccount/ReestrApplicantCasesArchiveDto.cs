namespace AisLogistics.App.Models.DTO.ApplicantPersonalAccount
{
    public class ReestrApplicantCasesArchiveDto
    {
        public Guid Id { get; internal set; }
        public string CaseId { get; set; }
        public Guid ProviderId { get; internal set; }
        public string ProviderName { get; internal set; }
        public Guid? DepartamentId { get; internal set; }
        public string DepartamentName { get; internal set; }
        public string ProcedureName { get; internal set; }
        public DateTime DateAdd { get; internal set; }
        public string DateAddToString => DateAdd.ToShortDateString();
        public int StatusId { get; internal set; }
        public string StatusName { get; internal set; }
        public int StageId { get; internal set; }
        public string StageName { get; internal set; }
        public int? Days { get; internal set; }
        public string CurrentEmployeeName { get; internal set; }
        public string CurrentOfficeName { get; internal set; }
        public string CurrentJobName { get; internal set; }
    }
}
