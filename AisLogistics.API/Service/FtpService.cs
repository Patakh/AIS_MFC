using AisLogistics.API.Models.Dto;
using FluentFTP;

namespace AisLogistics.API.Service
{
    public class FtpService : IFtpService
    {
        private readonly ILogger<FtpService> _logger;

        public FtpService(ILogger<FtpService> logger)
        {
            _logger = logger;
        }

        private static async Task<FtpClient> Init(FtpSettingsDto ftp)
        {
            var _ftpClient = new FtpClient(host: ftp.Server, port: 21, user: ftp.Login, pass: ftp.Password);
            await _ftpClient.ConnectAsync();

            return _ftpClient;
        }

        public async Task<FtpStatus> UploadFileAsync(IFormFile file, string remotePath, FtpSettingsDto ftp)
        {
            try
            {
                using var ms = new MemoryStream();
                await file.CopyToAsync(ms);
                return await UploadFileAsync(ms.ToArray(), remotePath, ftp);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.InnerException?.Message);
                return FtpStatus.Failed;
            }
        }

        public async Task<FtpStatus> UploadFileAsync(byte[] bytes, string remotePath, FtpSettingsDto ftp)
        {
            FtpClient? _ftpClient = null;
            try
            {
                _ftpClient = await Init(ftp);
                return await _ftpClient.UploadAsync(bytes, remotePath, FtpRemoteExists.Overwrite, true);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.InnerException?.Message);
                return FtpStatus.Failed;
            }
            finally
            {
                if (_ftpClient is not null)
                    await _ftpClient.DisconnectAsync();
            }
        }

        public async Task<byte[]?> DownloadFileAsync(string remotePath, FtpSettingsDto ftp)
        {
            FtpClient? _ftpClient = null;
            try
            {
                _ftpClient = await Init(ftp);
                return await _ftpClient.DownloadAsync(remotePath, CancellationToken.None);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.InnerException?.Message);
                return null;
            }
            finally
            {
                if (_ftpClient is not null)
                    await _ftpClient.DisconnectAsync();
            }
        }
    }
}