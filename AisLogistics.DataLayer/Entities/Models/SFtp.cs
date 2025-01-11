using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник FTP серверов
    /// </summary>
    public partial class SFtp
    {
        public SFtp()
        {
            AServicesCustomerCalls = new HashSet<AServicesCustomersCall>();
            AServicesFileResults = new HashSet<AServicesFileResult>();
            AServicesFiles = new HashSet<AServicesFile>();
            DIncomingCalls = new HashSet<DIncomingCall>();
            DServicesCustomerCalls = new HashSet<DServicesCustomersCall>();
            DServicesFileResults = new HashSet<DServicesFileResult>();
            DServicesFiles = new HashSet<DServicesFile>();
            SOffices = new HashSet<SOffice>();
        }

        /// <summary>
        /// Адрес FTP сервера
        /// </summary>
        public string FtpServer { get; set; }
        /// <summary>
        /// Папка FTP сервера
        /// </summary>
        public string FtpFolder { get; set; }
        /// <summary>
        /// Логин FTP сервера
        /// </summary>
        public string FtpLogin { get; set; }
        /// <summary>
        /// Пароль FTP сервера
        /// </summary>
        public string FtpPassword { get; set; }
        /// <summary>
        /// Признак удаления
        /// </summary>
        public bool IsRemove { get; set; }
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }

        public virtual ICollection<AServicesCustomersCall> AServicesCustomerCalls { get; set; }
        public virtual ICollection<AServicesFileResult> AServicesFileResults { get; set; }
        public virtual ICollection<AServicesFile> AServicesFiles { get; set; }
        public virtual ICollection<DIncomingCall> DIncomingCalls { get; set; }
        public virtual ICollection<DServicesCustomersCall> DServicesCustomerCalls { get; set; }
        public virtual ICollection<DServicesFileResult> DServicesFileResults { get; set; }
        public virtual ICollection<DServicesFile> DServicesFiles { get; set; }
        public virtual ICollection<SOffice> SOffices { get; set; }
    }
}
