namespace AisLogistics.App.ViewModels.ApplicantPersonalAccount
{
    public class SearchApplicantsRequestData
    {
        public string? Search {  get; set; }
    }

    public class SearchApplicantCasesRequestData
    {
        public Guid Id { get; set; }
        public string? Search { get; set; }
    }

    public class SearchApplicantCasesArchiveRequestData
    {
        public Guid Id { get; set; }
        public string? Search { get; set; }
    }

    public class SearchApplicantCasesHistoryRequestData
    {
        public Guid Id { get; set; }
        public string? Search { get; set; }
    }

}
