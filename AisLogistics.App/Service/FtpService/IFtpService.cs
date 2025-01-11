using AisLogistics.App.Models;
using FluentFTP;

namespace AisLogistics.App.Service
{
    public interface IFtpService
    {
        Task<FtpStatus> UploadFileAsync(IFormFile file, string remotePath, FtpSettingsModel ftp);
        Task<FtpStatus> UploadFileAsync(byte[] bytes, string remotePath, FtpSettingsModel ftp);
        Task<byte[]?> DownloadFileAsync(string remotePath, FtpSettingsModel ftp);
    }
}
