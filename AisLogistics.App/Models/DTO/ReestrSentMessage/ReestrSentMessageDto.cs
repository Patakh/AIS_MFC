namespace AisLogistics.App.Models.DTO.ReestrSentMessage
{
    public class ReestrSentMessageDto
    {
        public Guid Id { get; set; }
        public string SetDate { get; set; }
        public DateTime? EnqueueDateSort { get; set; }
        public string EnqueueDate { get; set; }
        public string CustomerName { get; set; }
        public string CasesId { get; set; }
        public string SmsText { get; set; }
        public string PhoneNumber { get; set; }
        public int? SendStatus { get; set; }
        public int? SmsId { get; set; }
    }
}
