using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Архивные номера дел
    /// </summary>
    public partial class ACase
    {
        public ACase()
        {
            AServices = new HashSet<AService>();
            AServicesCommentts = new HashSet<AServicesCommentt>();
            AServicesCoverLetters = new HashSet<AServicesCoverLetter>();
            AServicesCustomersCalls = new HashSet<AServicesCustomersCall>();
            AServicesCustomersMessages = new HashSet<AServicesCustomersMessage>();
            AServicesCustomers = new HashSet<AServicesCustomer>();
            AServicesCustomersLegals = new HashSet<AServicesCustomersLegal>();
            AServicesDocuments = new HashSet<AServicesDocument>();
            AServicesDocumentsResults = new HashSet<AServicesDocumentsResult>();
            AServicesFileResults = new HashSet<AServicesFileResult>();
            AServicesFiles = new HashSet<AServicesFile>();
            AServicesPayments = new HashSet<AServicesPayment>();
            AServicesRoutesStages = new HashSet<AServicesRoutesStage>();
            AServicesSmevRequests = new HashSet<AServicesSmevRequest>();
            AServicesAudits = new HashSet<AServicesAudit>();
        }

        /// <summary>
        /// Номер дела
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Оценка полученая по СМС с таблицы d_poll_region_sms
        /// </summary>
        public int? SmsRating { get; set; }
        /// <summary>
        /// Номер талона электронной очереди
        /// </summary>
        public string TicketQueue { get; set; }
        /// <summary>
        /// Дата и время добавления записи
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Заявитель
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Адрес
        /// </summary>
        public string CustomerAddress { get; set; }
        /// <summary>
        /// Телефон 1
        /// </summary>
        public string CustomerPhone1 { get; set; }
        /// <summary>
        /// Телефон 2
        /// </summary>
        public string CustomerPhone2 { get; set; }
        /// <summary>
        /// Почта
        /// </summary>
        public string CustomerEmail { get; set; }
        /// <summary>
        /// ИНН
        /// </summary>
        public string CustomerInn { get; set; }
        /// <summary>
        /// снилс
        /// </summary>
        public string CustomerSnils { get; set; }
        /// <summary>
        /// Серия документа
        /// </summary>
        public string DocumentSerial { get; set; }
        /// <summary>
        /// Номер документа
        /// </summary>
        public string DocumentNumber { get; set; }
        /// <summary>
        /// Услуга
        /// </summary>
        public string ServiceName { get; set; }
        /// <summary>
        /// Поставщик услуги
        /// </summary>
        public string OfficeNameProvider { get; set; }
        /// <summary>
        /// Место приема услуги
        /// </summary>
        public string OfficeNameAdd { get; set; }
        /// <summary>
        /// Сотрудник принявший услугу
        /// </summary>
        public string EmployeeNameAdd { get; set; }
        /// <summary>
        /// Сотрудник исполнивший услугу
        /// </summary>
        public string EmployeeNameExecution { get; set; }
        /// <summary>
        /// Год приема
        /// </summary>
        public int? Year { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public string StatusName { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime? DocumentBirthDate { get; set; }
        /// <summary>
        /// Место приема услуги
        /// </summary>
        public Guid? SOfficesIdAdd { get; set; }
        /// <summary>
        /// Тип
        /// </summary>
        public int SServicesCustomerTypeId { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public int SServicesStatusId { get; set; }

        public virtual ICollection<AService> AServices { get; set; }
        public virtual ICollection<AServicesCommentt> AServicesCommentts { get; set; }
        public virtual ICollection<AServicesCoverLetter> AServicesCoverLetters { get; set; }
        public virtual ICollection<AServicesCustomersCall> AServicesCustomersCalls { get; set; }
        public virtual ICollection<AServicesCustomersMessage> AServicesCustomersMessages { get; set; }
        public virtual ICollection<AServicesCustomer> AServicesCustomers { get; set; }
        public virtual ICollection<AServicesCustomersLegal> AServicesCustomersLegals { get; set; }
        public virtual ICollection<AServicesDocument> AServicesDocuments { get; set; }
        public virtual ICollection<AServicesDocumentsResult> AServicesDocumentsResults { get; set; }
        public virtual ICollection<AServicesFileResult> AServicesFileResults { get; set; }
        public virtual ICollection<AServicesFile> AServicesFiles { get; set; }
        public virtual ICollection<AServicesPayment> AServicesPayments { get; set; }
        public virtual ICollection<AServicesRoutesStage> AServicesRoutesStages { get; set; }
        public virtual ICollection<AServicesSmevRequest> AServicesSmevRequests { get; set; }
        public virtual ICollection<AServicesAudit> AServicesAudits { get; set; }
    }
}
