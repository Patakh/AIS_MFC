using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Таблица FTP адресов Vipnet
    /// </summary>
    public partial class SFtpVipnet
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование провайдера
        /// </summary>
        public string ProviderName { get; set; }
        /// <summary>
        /// FTP сервер
        /// </summary>
        public string FtpServer { get; set; }
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string FtpUser { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        public string FtpPass { get; set; }
        /// <summary>
        /// Папка для входящих
        /// </summary>
        public string FtpIn { get; set; }
        /// <summary>
        /// Папка для исходящих
        /// </summary>
        public string FtpOut { get; set; }
        /// <summary>
        /// Папка для неизвестных
        /// </summary>
        public string FtpUnc { get; set; }
        /// <summary>
        /// Признак удаления записи
        /// </summary>
        public bool IsRemove { get; set; }
        /// <summary>
        /// Комментарий к записи
        /// </summary>
        public string Commentt { get; set; }
    }
}
