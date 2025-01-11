using AisLogistics.API.Models.Dto;
using FluentFTP;

namespace AisLogistics.API.Service
{
    public interface IFtpService
    {
        Task<FtpStatus> UploadFileAsync(IFormFile file, string remotePath, FtpSettingsDto ftp);
        Task<FtpStatus> UploadFileAsync(byte[] bytes, string remotePath, FtpSettingsDto ftp);
        Task<byte[]?> DownloadFileAsync(string remotePath, FtpSettingsDto ftp);
    }
}
