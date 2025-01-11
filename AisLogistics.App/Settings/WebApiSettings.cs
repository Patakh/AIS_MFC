using System.Linq;
using AisLogistics.DataLayer.Concrete;

namespace AisLogistics.App.Settings;

/// <summary>
/// Настройки Web API
/// </summary>
public class WebApiSettings
{
    public WebApiSettings()
    {
        GetType().GetFields().ToList().ForEach(f =>
        {
            new AisLogisticsContext().SSettings.ToList().ForEach(setting =>
            {
                var attributes = (SettingNameAttribute[])f.GetCustomAttributes(typeof(SettingNameAttribute), false);
                if (attributes.Any(a => a.SettingName == setting.ParamName))
                {
                    f.SetValue(this, setting.ParamValue);
                }

            });
        });
    }
    /// <summary>
    /// IP адрес сервера FTP
    /// </summary>
    [SettingName("ftp_server")] public string FtpHost;
    /// <summary>
    /// Папка с файлами на сервере FTP
    /// </summary>
    [SettingName("ftp_folder")] public string FtpFolder;
    /// <summary>
    /// Имя пользователя для авторизации на сервере FTP
    /// </summary>
    [SettingName("ftp_user")] public string FtpUser;
    /// <summary>
    /// Пароль для авторизации на сервере FTP
    /// </summary>
    [SettingName("ftp_password")] public string FtpPassword;
    /// <summary>
    /// Наименование папки с фотографиями сотрудников
    /// </summary>
    [SettingName("ftp_employee_photo_folder")] public string FtpEmployeePhotoFolder;
    /// <summary>
    /// Наименование папки с фотографиями зданий филиалов
    /// </summary>
    [SettingName("ftp_office_photo_folder")] public string FtpOfficePhotoFolder;
    /// <summary>
    /// Наименование папки с файлами и бланками для услуг
    /// </summary>
    [SettingName("ftp_sub_service_file_folder")] public string FtpServiceFileFolder;

}