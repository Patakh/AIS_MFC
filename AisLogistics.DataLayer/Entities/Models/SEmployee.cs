using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник сотрудников
    /// </summary>
    public partial class SEmployee
    {
        public SEmployee()
        {
            APremia = new HashSet<APremium>();
            APremiumFines = new HashSet<APremiumFine>();
            APremiumSteps = new HashSet<APremiumStep>();
            AServiceSEmployeesIdAddNavigations = new HashSet<AService>();
            AServiceSEmployeesIdExecutionNavigations = new HashSet<AService>();
            AServicesCommenttEmployees = new HashSet<AServicesCommenttEmployee>();
            AServicesCommentts = new HashSet<AServicesCommentt>();
            AServicesCoverLetters = new HashSet<AServicesCoverLetter>();
            AServicesCustomerCalls = new HashSet<AServicesCustomersCall>();
            AServicesCustomerMessages = new HashSet<AServicesCustomersMessage>();
            AServicesCustomers = new HashSet<AServicesCustomer>();
            AServicesCustomersLegals = new HashSet<AServicesCustomersLegal>();
            AServicesFileResults = new HashSet<AServicesFileResult>();
            AServicesFiles = new HashSet<AServicesFile>();
            AServicesPayments = new HashSet<AServicesPayment>();
            AServicesRoutesStageSEmployees = new HashSet<AServicesRoutesStage>();
            AServicesRoutesStageSEmployeesIdAddNavigations = new HashSet<AServicesRoutesStage>();
            AServicesSmevRequests = new HashSet<AServicesSmevRequest>();
            DAlertEmployees = new HashSet<DAlertEmployee>();
            DCasesFavorites = new HashSet<DCasesFavorite>();
            DCasesViews = new HashSet<DCasesView>();
            DEmployeesServicesFavorites = new HashSet<DEmployeesServicesFavorite>();
            DIasMkguInfomatUploads = new HashSet<DIasMkguInfomatUpload>();
            DIasMkguSmsUploads = new HashSet<DIasMkguSmsUpload>();
            DIncomingCalls = new HashSet<DIncomingCall>();
            DInformationRecipients = new HashSet<DInformationRecipient>();
            DNotes = new HashSet<DNote>();
            DPremiumFines = new HashSet<DPremiumFine>();
            DPremiumSteps = new HashSet<DPremiumStep>();
            DSalaryRecalculationLogs = new HashSet<DSalaryRecalculationLog>();
            DServiceSEmployeesIdAddNavigations = new HashSet<DService>();
            DServiceSEmployeesIdExecutionNavigations = new HashSet<DService>();
            DServiceSEmployeesIdCurrentNavigations = new HashSet<DService>();
            DServicesAudits = new HashSet<DServicesAudit>();
            AServicesAudits = new HashSet<AServicesAudit>();
            DServicesCommenttEmployees = new HashSet<DServicesCommenttEmployee>();
            DServicesCommentts = new HashSet<DServicesCommentt>();
            DServicesCoverLetters = new HashSet<DServicesCoverLetter>();
            DServicesCustomerCalls = new HashSet<DServicesCustomersCall>();
            DServicesCustomerMessages = new HashSet<DServicesCustomersMessage>();
            DServicesCustomers = new HashSet<DServicesCustomer>();
            DServicesCustomersLegalGisgmps = new HashSet<DServicesCustomersLegalGisgmp>();
            DServicesCustomersLegals = new HashSet<DServicesCustomersLegal>();
            DServicesFileResults = new HashSet<DServicesFileResult>();
            DServicesFiles = new HashSet<DServicesFile>();
            DServicesPayments = new HashSet<DServicesPayment>();
            DServicesRoutesStageSEmployees = new HashSet<DServicesRoutesStage>();
            DServicesRoutesStageSEmployeesIdAddNavigations = new HashSet<DServicesRoutesStage>();
            DServicesSmevRequests = new HashSet<DServicesSmevRequest>();
            DSmsPollRegions = new HashSet<DSmsPollRegion>();
            DStepCancels = new HashSet<DStepCancel>();
            DStepRecalculationLogs = new HashSet<DStepRecalculationLog>();
            RefreshTokens = new HashSet<RefreshToken>();
            SEmployeesActives = new HashSet<SEmployeesActive>();
            SEmployeesAuthorizationLogs = new HashSet<SEmployeesAuthorizationLog>();
            SEmployeesCombinationJobs = new HashSet<SEmployeesCombinationJob>();
            SEmployeesCoverLetters = new HashSet<SEmployeesCoverLetter>();
            SEmployeesExecutions = new HashSet<SEmployeesExecution>();
            SEmployeesFileFolders = new HashSet<SEmployeesFileFolder>();
            SEmployeesOfficesJoins = new HashSet<SEmployeesOfficesJoin>();
            SOfficesAuthorizations = new HashSet<SOfficesAuthorization>();
            SEmployeesRolesExecutors = new HashSet<SEmployeesRolesExecutor>();
            SEmployeesStatusJoins = new HashSet<SEmployeesStatusJoin>();
            SEmployeesTemplates = new HashSet<SEmployeesTemplate>();
            SEmployeesWorkingTimeJoins = new HashSet<SEmployeesWorkingTimeJoin>();
            DReestrs= new HashSet<DReestr>();
            DReestrUnclaimeds = new HashSet<DReestrUnclaimed>();
            DTestEmployees = new HashSet<DTestEmployee>();
            DServicesDocuments = new HashSet<DServicesDocument>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// ФИО сотрудника
        /// </summary>
        public string EmployeeName { get; set; }
        /// <summary>
        /// Номер телефона сотрудника
        /// </summary>
        public string EmployeePhone { get; set; }
        /// <summary>
        /// Электронная почта сотрудника
        /// </summary>
        public string EmployeeEmail { get; set; }
        /// <summary>
        /// Табельный номер
        /// </summary>
        public string EmployeePersonalNumber { get; set; }
        /// <summary>
        /// Номер сертификата
        /// </summary>
        public string EmployeeCertificateNumber { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime? EmployeeDocBirthDate { get; set; }
        /// <summary>
        /// Место рождения
        /// </summary>
        public string EmployeeDocBirthPlace { get; set; }
        /// <summary>
        /// Серия паспорта
        /// </summary>
        public string EmployeeDocSerial { get; set; }
        /// <summary>
        /// Номер паспорта
        /// </summary>
        public string EmployeeDocNumber { get; set; }
        /// <summary>
        /// Дата выдачи паспорта
        /// </summary>
        public DateTime? EmployeeDocIssueDate { get; set; }
        /// <summary>
        /// Кем выдан
        /// </summary>
        public string EmployeeDocIssuePlace { get; set; }
        /// <summary>
        /// Код документа
        /// </summary>
        public string EmployeeDocCode { get; set; }
        /// <summary>
        /// СНИЛС - Страховой номер индивидуального лицевого счёта
        /// </summary>
        public string EmployeeSnils { get; set; }
        /// <summary>
        /// ИНН - Идентификационный номер налогоплательщика
        /// </summary>
        public string EmployeeInn { get; set; }
        /// <summary>
        /// Дата и время добавления записи
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Сотрудник добавивший запись
        /// </summary>
        public string EmployeesFioAdd { get; set; }
        /// <summary>
        /// Признак удаления записи
        /// </summary>
        public bool IsRemove { get; set; }
        /// <summary>
        /// Связь с пользователем
        /// </summary>
        public Guid? AspNetUserId { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
        public virtual ICollection<APremium> APremia { get; set; }
        public virtual ICollection<APremiumFine> APremiumFines { get; set; }
        public virtual ICollection<APremiumStep> APremiumSteps { get; set; }
        public virtual ICollection<AService> AServiceSEmployeesIdAddNavigations { get; set; }
        public virtual ICollection<AService> AServiceSEmployeesIdExecutionNavigations { get; set; }
        public virtual ICollection<AServicesCommenttEmployee> AServicesCommenttEmployees { get; set; }
        public virtual ICollection<AServicesCommentt> AServicesCommentts { get; set; }
        public virtual ICollection<AServicesCoverLetter> AServicesCoverLetters { get; set; }
        public virtual ICollection<AServicesCustomersCall> AServicesCustomerCalls { get; set; }
        public virtual ICollection<AServicesCustomersMessage> AServicesCustomerMessages { get; set; }
        public virtual ICollection<AServicesCustomer> AServicesCustomers { get; set; }
        public virtual ICollection<AServicesCustomersLegal> AServicesCustomersLegals { get; set; }
        public virtual ICollection<AServicesFileResult> AServicesFileResults { get; set; }
        public virtual ICollection<AServicesFile> AServicesFiles { get; set; }
        public virtual ICollection<AServicesPayment> AServicesPayments { get; set; }
        public virtual ICollection<AServicesRoutesStage> AServicesRoutesStageSEmployees { get; set; }
        public virtual ICollection<AServicesRoutesStage> AServicesRoutesStageSEmployeesIdAddNavigations { get; set; }
        public virtual ICollection<AServicesSmevRequest> AServicesSmevRequests { get; set; }
        public virtual ICollection<DAlertEmployee> DAlertEmployees { get; set; }
        public virtual ICollection<DCasesFavorite> DCasesFavorites { get; set; }
        public virtual ICollection<DCasesView> DCasesViews { get; set; }
        public virtual ICollection<DEmployeesServicesFavorite> DEmployeesServicesFavorites { get; set; }
        public virtual ICollection<DIasMkguInfomatUpload> DIasMkguInfomatUploads { get; set; }
        public virtual ICollection<DIasMkguSmsUpload> DIasMkguSmsUploads { get; set; }
        public virtual ICollection<DIncomingCall> DIncomingCalls { get; set; }
        public virtual ICollection<DInformationRecipient> DInformationRecipients { get; set; }
        public virtual ICollection<DNote> DNotes { get; set; }
        public virtual ICollection<DPremiumFine> DPremiumFines { get; set; }
        public virtual ICollection<DPremiumStep> DPremiumSteps { get; set; }
        public virtual ICollection<DSalaryRecalculationLog> DSalaryRecalculationLogs { get; set; }
        public virtual ICollection<DService> DServiceSEmployeesIdAddNavigations { get; set; }
        public virtual ICollection<DService> DServiceSEmployeesIdExecutionNavigations { get; set; }
        public virtual ICollection<DService> DServiceSEmployeesIdCurrentNavigations { get; set; }
        public virtual ICollection<DServicesAudit> DServicesAudits { get; set; }
        public virtual ICollection<AServicesAudit> AServicesAudits { get; set; } 
        public virtual ICollection<DServicesCommenttEmployee> DServicesCommenttEmployees { get; set; }
        public virtual ICollection<DServicesCommentt> DServicesCommentts { get; set; }
        public virtual ICollection<DServicesCoverLetter> DServicesCoverLetters { get; set; }
        public virtual ICollection<DServicesCustomersCall> DServicesCustomerCalls { get; set; }
        public virtual ICollection<DServicesCustomersMessage> DServicesCustomerMessages { get; set; }
        public virtual ICollection<DServicesCustomer> DServicesCustomers { get; set; }
        public virtual ICollection<DServicesCustomersLegalGisgmp> DServicesCustomersLegalGisgmps { get; set; }
        public virtual ICollection<DServicesCustomersLegal> DServicesCustomersLegals { get; set; }
        public virtual ICollection<DServicesFileResult> DServicesFileResults { get; set; }
        public virtual ICollection<DServicesFile> DServicesFiles { get; set; }
        public virtual ICollection<DServicesPayment> DServicesPayments { get; set; }
        public virtual ICollection<DServicesRoutesStage> DServicesRoutesStageSEmployees { get; set; }
        public virtual ICollection<DServicesRoutesStage> DServicesRoutesStageSEmployeesIdAddNavigations { get; set; }
        public virtual ICollection<DServicesSmevRequest> DServicesSmevRequests { get; set; }
        public virtual ICollection<DSmsPollRegion> DSmsPollRegions { get; set; }
        public virtual ICollection<DStepCancel> DStepCancels { get; set; }
        public virtual ICollection<DStepRecalculationLog> DStepRecalculationLogs { get; set; }
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
        public virtual ICollection<SEmployeesActive> SEmployeesActives { get; set; }
        public virtual ICollection<SEmployeesAuthorizationLog> SEmployeesAuthorizationLogs { get; set; }
        public virtual ICollection<SEmployeesCombinationJob> SEmployeesCombinationJobs { get; set; }
        public virtual ICollection<SEmployeesCoverLetter> SEmployeesCoverLetters { get; set; }
        public virtual ICollection<SEmployeesExecution> SEmployeesExecutions { get; set; }
        public virtual ICollection<SEmployeesFileFolder> SEmployeesFileFolders { get; set; }
        public virtual ICollection<SEmployeesOfficesJoin> SEmployeesOfficesJoins { get; set; }
        public virtual ICollection<SOfficesAuthorization> SOfficesAuthorizations { get; set; }
        public virtual ICollection<SEmployeesRolesExecutor> SEmployeesRolesExecutors { get; set; }
        public virtual ICollection<SEmployeesStatusJoin> SEmployeesStatusJoins { get; set; }
        public virtual ICollection<SEmployeesTemplate> SEmployeesTemplates { get; set; }
        public virtual ICollection<SEmployeesWorkingTimeJoin> SEmployeesWorkingTimeJoins { get; set; }
        public virtual ICollection<DReestr> DReestrs { get; set; }
        public virtual ICollection<DReestrUnclaimed> DReestrUnclaimeds { get; set; }
        public virtual ICollection<DTestEmployee> DTestEmployees { get; set; }
        public virtual ICollection<DServicesDocument> DServicesDocuments { get; set; }

    }
}
