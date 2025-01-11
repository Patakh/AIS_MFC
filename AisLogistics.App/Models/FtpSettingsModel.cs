namespace AisLogistics.App.Models
{
    public class FtpSettingsModel
    {
        public Guid Id { get; set; }
        public string Server { get; set; }
        public int Port { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
