namespace AisLogistics.API.Models.Dto
{
    public class FileDownLoanDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Extensions { get; set; }
        public byte[] Content { get; set; }
    }
}
