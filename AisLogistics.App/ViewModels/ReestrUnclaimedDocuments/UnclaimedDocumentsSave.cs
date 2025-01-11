namespace AisLogistics.App.ViewModels.ReestrUnclaimedDocuments
{
    public class UnclaimedDocumentsSaveRequest
    {
        public List<Guid> DserviceId { get; set; }
        public Guid providerId { get; set; }
        public Guid? DepartamentId { get; set; }
        public Guid ServiceId { get; set; }
    }
    public class UnclaimedDocumentsSaveResponce
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
    }

    public class UnclaimedDocumentsCommentsSaveRequest
    {
        public List<string> CaseId { get; set; }
        public string Text { get; set; }
    }

    public class EditUnclaimedDocumentsRequest
    {
        public Guid Id { get; set; }
        public string ReestrNumber { get; set; }
    }
}
