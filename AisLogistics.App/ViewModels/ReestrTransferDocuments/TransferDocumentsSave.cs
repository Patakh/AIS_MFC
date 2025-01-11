namespace AisLogistics.App.ViewModels.ReestrTransferDocuments
{
    public class TransferDocumentsSaveRequest
    {
        public List<Guid> DserviceId { get; set; }
        public Guid providerId { get; set; }
        public Guid? DepartamentId { get; set; }
        public Guid ServiceId { get; set; }
    }
    public class TransferDocumentsSaveResponce
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid OfficeId { get; set; }
    }

    public class TransferDocumentsCommentsSaveRequest
    {
        public List<string> CaseId { get; set; }
        public string Text { get; set; }
    }

    public class EditTransferDocumentsRequest
    {
        public Guid Id { get; set; }
        public string ReestrNumber { get; set; }
    }

}
