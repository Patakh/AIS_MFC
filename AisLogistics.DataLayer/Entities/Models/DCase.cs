using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Список текущих обращений
    /// </summary>
    public partial class DCase
    {
        public DCase()
        {
            APremiumFines = new HashSet<APremiumFine>();
            APremiumSteps = new HashSet<APremiumStep>();
            DAlertEmployees = new HashSet<DAlertEmployee>();
            DCasesFavorites = new HashSet<DCasesFavorite>();
            DCasesViews = new HashSet<DCasesView>();
            DEpguDocumentsLoads = new HashSet<DEpguDocumentsLoad>();
            DFsspUploads = new HashSet<DFsspUpload>();
            DIasMkguInfomatAnswerCommentts = new HashSet<DIasMkguInfomatAnswerCommentt>();
            DIasMkguInfomatAnswers = new HashSet<DIasMkguInfomatAnswer>();
            DIasMkguInfomatUploads = new HashSet<DIasMkguInfomatUpload>();
            DIasMkguSmsUploads = new HashSet<DIasMkguSmsUpload>();
            DPremiumFines = new HashSet<DPremiumFine>();
            DPremiumSteps = new HashSet<DPremiumStep>();
            DServices = new HashSet<DService>();
            DServicesAudits = new HashSet<DServicesAudit>();
            DServicesCommentts = new HashSet<DServicesCommentt>();
            DServicesCoverLetters = new HashSet<DServicesCoverLetter>();
            DServicesCustomersCalls = new HashSet<DServicesCustomersCall>();
            DServicesCustomersMessages = new HashSet<DServicesCustomersMessage>();
            DServicesCustomers = new HashSet<DServicesCustomer>();
            DServicesCustomersLegals = new HashSet<DServicesCustomersLegal>();
            DServicesDocuments = new HashSet<DServicesDocument>();
            DServicesDocumentsResults = new HashSet<DServicesDocumentsResult>();
            DServicesFileResults = new HashSet<DServicesFileResult>();
            DServicesFiles = new HashSet<DServicesFile>();
            DServicesPayments = new HashSet<DServicesPayment>();
            DServicesRoutesStages = new HashSet<DServicesRoutesStage>();
            DServicesSmevRequests = new HashSet<DServicesSmevRequest>();
            DSmsPollRegions = new HashSet<DSmsPollRegion>();
            DReestrServices = new HashSet<DReestrService>();
            DReestrUnclaimedServices = new HashSet<DReestrUnclaimedService>();
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

        public virtual DStepCancel DStepCancel { get; set; }
        public virtual ICollection<APremiumFine> APremiumFines { get; set; }
        public virtual ICollection<APremiumStep> APremiumSteps { get; set; }
        public virtual ICollection<DAlertEmployee> DAlertEmployees { get; set; }
        public virtual ICollection<DCasesFavorite> DCasesFavorites { get; set; }
        public virtual ICollection<DCasesView> DCasesViews { get; set; }
        public virtual ICollection<DEpguDocumentsLoad> DEpguDocumentsLoads { get; set; }
        public virtual ICollection<DFsspUpload> DFsspUploads { get; set; }
        public virtual ICollection<DIasMkguInfomatAnswerCommentt> DIasMkguInfomatAnswerCommentts { get; set; }
        public virtual ICollection<DIasMkguInfomatAnswer> DIasMkguInfomatAnswers { get; set; }
        public virtual ICollection<DIasMkguInfomatUpload> DIasMkguInfomatUploads { get; set; }
        public virtual ICollection<DIasMkguSmsUpload> DIasMkguSmsUploads { get; set; }
        public virtual ICollection<DPremiumFine> DPremiumFines { get; set; }
        public virtual ICollection<DPremiumStep> DPremiumSteps { get; set; }
        public virtual ICollection<DService> DServices { get; set; }
        public virtual ICollection<DServicesAudit> DServicesAudits { get; set; }
        public virtual ICollection<DServicesCommentt> DServicesCommentts { get; set; }
        public virtual ICollection<DServicesCoverLetter> DServicesCoverLetters { get; set; }
        public virtual ICollection<DServicesCustomersCall> DServicesCustomersCalls { get; set; }
        public virtual ICollection<DServicesCustomersMessage> DServicesCustomersMessages { get; set; }
        public virtual ICollection<DServicesCustomer> DServicesCustomers { get; set; }
        public virtual ICollection<DServicesCustomersLegal> DServicesCustomersLegals { get; set; }
        public virtual ICollection<DServicesDocument> DServicesDocuments { get; set; }
        public virtual ICollection<DServicesDocumentsResult> DServicesDocumentsResults { get; set; }
        public virtual ICollection<DServicesFileResult> DServicesFileResults { get; set; }
        public virtual ICollection<DServicesFile> DServicesFiles { get; set; }
        public virtual ICollection<DServicesPayment> DServicesPayments { get; set; }
        public virtual ICollection<DServicesRoutesStage> DServicesRoutesStages { get; set; }
        public virtual ICollection<DServicesSmevRequest> DServicesSmevRequests { get; set; }
        public virtual ICollection<DSmsPollRegion> DSmsPollRegions { get; set; }
        public virtual ICollection<DReestrService> DReestrServices { get; set; }
        public virtual ICollection<DReestrUnclaimedService> DReestrUnclaimedServices { get; set; }
    }
}
