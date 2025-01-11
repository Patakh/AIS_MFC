namespace AisLogistics.App.Models.DTO.Cases
{
    public class FileDownloadDto
    {
        public Guid Id { get; set; }
        public string DcaseId { get; set; }
        public string FileName { get; set; }
        public string FileExtention { get; set; }
        public int FileSize { get; set; }
        public FtpSettingsModel Ftp {get;set;}
    }
}
