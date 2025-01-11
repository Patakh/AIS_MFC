using AisLogistics.App.Service;
using AisLogistics.App.Utils;
using AisLogistics.App.ViewModels.Cases;
using AisLogistics.DataLayer.Common.Dto.Case;
using SmevRouter;

namespace AisLogistics.App.Models.DTO.Services
{

    public class CasesDto
    {
        public CasesMainDto casesMainDto { get; set; }
        public List<CaseServiceDto> Services { get; set; } = new List<CaseServiceDto>();
        public CaseServiceDto? Service { get; set; }
        public ArchiveCasesMainDto archiveCasesMainDto { get; set; }
        public List<CaseApplicantPhoneDto> CaseApplicantPhoneDtos { get; internal set; }
    }

    public class ArchiveCasesMainDto
    {
        public string CaseId { get; internal set; }
        public string DateAdd { get; internal set; }
        public ApplicantDto Applicant { get; internal set; }
        public string ServiceName { get; internal set; }
        public string ProviderName { get; internal set; }
        public string EmployeeNameAdd { get; internal set; }
        public string EmployeeNameExecution { get; internal set; }
        public int StatusId { get; internal set; }
        public string StatusName { get; internal set; }
        public string StageName { get; internal set; }
    }


    public class CasesMainDto
    {
        public string CaseId { get; internal set; }
        public string? SearchString { get; internal set; }
        public string? NumberPKPVD { get; internal set; }
        public string DateAdd { get; internal set; }
        public ApplicantDto Applicant { get; internal set; }
        public int CustomerType { get; internal set; }
        public ApplicantDto? Recipient { get; internal set; }
        public List<NotesDto> Notes { get; set; } = new List<NotesDto>();
        public int CommentsCount { get; set; }
        public int NotificationsCount { get; set; }
        public int AuditCounts { get; set; }
        public string? Tiket { get; internal set; }
    }

    public class CaseServiceDto : ServiceDto
    {
        public string CaseId { get; internal set; }
        public SerivesStageDto SerivesStage { get; set; }
        //public StageDto Stage { get; set; }
        //public EmployeeDto EmployeeCurrent { get; set; }
        public int? Days { get; set; }
        public StatusDto Status { get; internal set; }
        public EmployeeDto EmployeeAdd { get; set; }
        public bool IsRoot { get; set; }
        public bool IsFavorite { get; internal set; }

    }

    public class SerivesStageDto
    {
        public StageDto Stage { get; set; }
        public EmployeeDto EmployeeCurrent { get; set; }
        public int? Days { get; set; }
        public string Office { get; internal set; }

    }

    public class ServiceDto
    {
        public ServiceDto() { }
        public ServiceDto(Guid id, string name, string office) : this()
        {
            Id = id;
            Name = name;
            Office = office;
        }
        public ServiceDto(Guid id, string name, string office, DateTime date) : this()
        {
            Id = id;
            Name = name;
            Office = office;
            Date = date;
        }

        public ServiceDto(Guid id, string name, string office, DateTime date, Guid officeId, Guid? departamentId, string departement, string interactionName) : this()
        {
            Id = id;
            Name = name;
            Office = office;
            Date = date;
            OfficeId = officeId;
            DepartamentName = departement;
            DepartamentId = departamentId;
            InteractionName = interactionName;
        }

        public Guid Id { get; internal set; }
        public Guid ServiceId { get; internal set; }
        public Guid ProcedureId { get; internal set; }
        public string Name { get; internal set; }
        public string InteractionName { get; internal set; }
        public string Office { get; internal set; }
        public Guid OfficeId { get; internal set; }
        public Guid? DepartamentId { get; internal set; }
        public string DepartamentName { get; internal set; }
        public string ProcedureName { get; internal set; }
        public DateTime? Date { get; internal set; }
    }

    public class EmployeeDto
    {
        public EmployeeDto() { }
        public EmployeeDto(Guid? id, string name, string job)
        {
            Id = id;
            Name = name;
            Job = job;
            NameBadge = NameSplitter.GetBadge(name);
        }
        public EmployeeDto(Guid? id, string name, string job, string office)
        {
            Id = id;
            Name = name;
            Job = job;
            NameBadge = NameSplitter.GetBadge(name);
            OfficeName = office;
        }

        public Guid? Id { get; internal set; }
        public string Name { get; internal set; }
        public char? NameBadge { get; internal set; }
        public string Job { get; internal set; }
        public string OfficeName { get; internal set; }
    }

    public class StatusDto
    {
        public StatusDto() { }
        public StatusDto(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; internal set; }
        public string Name { get; internal set; }
    }
    public class StageDto
    {
        public StageDto() { }

        public StageDto(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public StageDto(int id, string name, int days, string comment)
        {
            Id = id;
            Name = name;
            Days = days;
            Comment = comment;
        }
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public string Comment { get; internal set; }
        public int? Days { get; internal set; }
    }

    public class StageAddDto
    {
        public StageAddDto() 
        {
            ServiceId = new List<Guid>();
            Stages = new List<StageDto>();
        }
        public List<StageDto>  Stages {get; internal set; }
        public Guid EmployeeId { get; internal set; }
        public Guid OfficeId { get; internal set; }
        //public Guid ServiceId { get; internal set; }
        public List<Guid> ServiceId { get; internal set; }


    }

    public class NotesDto
    {
        public Guid Id { get; set; }
        public string NotesText { get; set; }
        public DateTime? DateReminder { get; set; }
    }

    public class NotesAddDto
    {
        public Guid Id { get; set; }
        public string DCaseId { get;  set; }
        public string NotesText { get;  set; }
        public DateTime? DateReminder { get; set; }
    }

    public class NotesAddSaveDto : NotesAddDto
    {
      public Guid EmployeeId { get; set; }
    }

    


    public class EmployeesDtO
    {
        public EmployeesDtO() { }

        public EmployeesDtO(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        public Guid Id { get; internal set; }
        public string Name { get; internal set; }
    }

    public class ApplicantDto
    {
        public ApplicantDto() { }
        public ApplicantDto(string name, string address, string phone)
        {
            Name = name;
            Address = address;
            Phone = phone;
        }

        public ApplicantDto(Guid id,string name, string address, string phone)
        {
            Id = id;
            Name = name;
            Address = address;
            Phone = phone;
        }

        public ApplicantDto(string name, string address, string phone, string phone2)
        {
            Name = name;
            Address = address;
            Phone = phone;
            Phone2 = phone2;
        }

        public Guid Id  { get; internal set; }
        public string Name { get; internal set; }
        public string Address { get; internal set; }
        public string Phone { get; internal set; }
        public string Phone2 { get; internal set; }
    }

    public class ApplicantAdditionalDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? SecondName { get; set; }
        public int Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string? Snils { get; set; }
        public string? Inn { get; set; }
        public DateTime? BirthDate { get; set; }
        public CustomerType Type { get; set; }
        public string DocumentTypeCode { get; set; }
        public string? DocumentSerial { get; set; }
        public string? DocumentNumber { get; set; }
        public DateTime? DocumentIssueDate { get; set; }
        public string? DocumentIssueBody { get; set; }
        public string? DocumentCode { get; set; }
        public string? BirthPlace { get; set; }
        public string? Email { get; set; }
        public SubjectCustomerType SubjectCustomerType { get; set; }
        public AddressDetails AddressDetails { get; set; }
        public string? Okato { get; set; }
        public string? Oktmo { get; set; }
        public string? CodeRegion { get; set; }
        public string? Kpp { get; set; }
        public string? Ogrn { get; set; }
        public string? HeadPosition { get; set; }
    }

    public class CaseAuditDto
    {
        public ChangedAudit? Changed { get; internal set; }
        public DateTime DateAdd { get; internal set; }
        public string Type { get; internal set; }
        public EmployeeDto Employee { get; internal set; }
    }

    public class CaseCommentsDto
    {
        public Guid Id { get; internal set; }
        public string Comment { get; internal set; }
        public DateTime DateAdd { get; internal set; }
        public EmployeeDto EmployeeAdd { get; internal set; }
        public bool IsLeft { get; set; }
    }
    public class CaseNotificationsDto
    {
        public CaseNotificationsDto() {
            CaseApplicantPhoneDtos = new();
            NotificationsDtos = new();
        }
        public List<CaseApplicantPhoneDto> CaseApplicantPhoneDtos { get; internal set; }
        public List<NotificationsDto> NotificationsDtos { get; internal set; }
    }

    public class NotificationsDto
    {
        public Guid Id { get; internal set; }
        public string CustomerFio { get; internal set; }
        public string CustomerPhone { get; internal set; }
        public DateTime DateAdd { get; internal set; }
        public string Period { get; internal set; }
        public EmployeeDto EmployeeAdd { get; internal set; }
        public string Status { get; internal set; }
        public string TextMessage { get; internal set; }  
        public int Type { get; internal set; }
    }

    public class CaseApplicantPhoneDto { 
        public Guid Id { get; internal set; }
        public string ApplicantName { get; internal set; }
        public CustomerType CustomerType { get; internal set; }
        public string Phone1 { get; internal set; }
        public string Phone2 { get; internal set; }
    }

    public class CaseServiceDocumentsResultsDto : CaseServiceAbstractDocument
    {
        public string Method { get; set; }
        public string PeriodMfc { get; set; }
        public string PeriodProvider { get; set; }
        public bool? Result { get; set; }
    }

    public class CaseServiceDocumentsDto : CaseServiceAbstractDocument
    {
        public string CaseId { get; set; }
        public int DocumentNeedId { get; set; }
        public int DocumentTypeId { get; set; }
        public int DocumentCopyCount { get; set; }
        public bool IsCheck { get; set; }
        public int CountCopy { get; set; }
        public int CountOriginal { get; set; }
        public string? Commentt { get; set; }
    }

    public abstract class CaseServiceAbstractDocument
    {
        protected CaseServiceAbstractDocument()
        {
            Files = new List<FileDto>();
        }
        public Guid Id { get; set; }
        public Guid DocumentId { get; set; }
        public string DocumentName { get; set; }
        public List<FileDto> Files { get; set; }
    }

    public class FileDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public int Size { get; set; }
        public DateTime DateAdd { get; set; }

        public bool IsViewing
        {
            get
            {
                var formats = new[] { ".png", ".jpg", ".jpeg" };
                return formats.Contains(Extension);
            }
        }

        public EmployeeDto EmployeeAdd { get; set; }
    }

    public class CaseServiceSmevСompletedDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateResponse { get; set; }
        public int Status { get; set; }
        public EmployeeDto EmployeeAdd { get; set; }
        public string Description { get; set; }
        public ServiceDto Service { get; set; }
        public string Provider { get; set; }
    }

    public class CaseServicePaymentsСompletedDto
    {
        public Guid Id { get; set; }
        public string EmployeeFio { get; set; }
        public string PayerFio { get; set; }
        public string TypePayment { get; set; }
        public string PaymentMethod { get; set; }
        public decimal? Summa { get; set; }
        public string Status { get; set;}
        public DateTime DateAdd { get; set; }
        public DateTime? DatePayment { get; set; }

        public string GetStatus ()
        {
            return Status switch
            {
                "IN_WORK" => "В процессе",
                "AWAIT" => "Ожидает оплаты",
                "SUCCESS" => "Оплачен",
                "FAILED" => "Ошибка",
                "UNKNOWN" => "Неизвестный",
                _ => string.Empty,
            };
        }
    }

    public class CaseServiceStageDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int? Days { get; set; }
        public DateTime DateAdd { get; set; }
        public bool IsAutomaticallyTransferred { get; set; }
        public EmployeeDto EmployeeCurrent { get; set; }
        public EmployeeDto EmployeeAdd { get; set; }
        public DateTime? DateReg { get; set; }
        public DateTime? DateFact { get; set; }
    }

    public class CaseServiceSmevActiveDto
    {
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public string Provider { get; internal set; }
        public int Days { get; internal set; }
        public string WeekTypeName { get; internal set; }
        public string Description { get; internal set; }
        public string ActionPath { get; set; }
        public string FormPath { get; set; }
    }

    public class CaseServiceSmevRequestDto
    {
        public Guid Id { get; set; }
        public int? CountDayExecution { get; set; }
        public DateTime DateAdd { get; set; }
        public DateTime DateReg { get; set; }
        public DateTime? DateRequest { get; set; }
        public ServiceDto Service { get; set; }
        public EmployeeDto Employee { get; set; }
    }

    public class CaseServicesRouteStagesNextDto
    {
        /// <summary>
        /// Индетификатор записи 
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Индетификатор головной записи 
        /// </summary>
        public Guid ParentId { get; set; }
        /// <summary>
        /// Наименование этапа 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Индетификатор этапа 
        /// </summary>
        public int StageId { get; set; }
        /// <summary>
        /// Количество дней на исполнение 
        /// </summary>
        public int Days { get; set; }
        /// <summary>
        /// Статус услуги 
        /// </summary>
        public int StatusId { get; set; }
        /// <summary>
        /// Завершение услуги 
        /// </summary>
        public bool IsDateFact { get; set; }
        /// <summary>
        /// Комментарий
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// Список должностей 
        /// </summary>
        public List<RolePositions> RolePosition { get; set; }

        /// <summary>
        /// Информация о сотруднике 
        /// </summary>
        public class RolePositions
        {
            /// <summary>
            /// Индетификатор должности 
            /// </summary>
            public Guid Id { get; set; }
            /// <summary>
            /// Наименование должности 
            /// </summary>
            public string Name { get; set; }
        }
    }

    public class CaseServiceBlankFile : CaseServiceBlank
    {
        public byte[] Content { get; set; }
        public int? Size { get; set; }
    }

    public class CaseServiceBlank
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Expansion { get; set; }
        public string Comment { get; set; }
        public Guid? ServiceId { get; set; }
    }

 
    public class CaseServicesDocumentAddModalDto
    {
        public CaseServicesDocumentAddModalDto() { }

        public CaseServicesDocumentAddModalDto(Guid serviceId, Guid documentId, DocumentFileAddType fileAddType)
        {
            ServiceId = serviceId;
            DocumentId = documentId;
            FileAddType = fileAddType;
        }

        public Guid ServiceId { get; }
        public Guid DocumentId { get; }
        public DocumentFileAddType FileAddType { get; }
    }

    public class CaseServicesDocumentResultsAddModalDto
    {
        public CaseServicesDocumentResultsAddModalDto() { }

        public CaseServicesDocumentResultsAddModalDto(Guid serviceId, Guid documentId, DocumentFileAddType fileAddType)
        {
            ServiceId = serviceId;
            DocumentId = documentId;
            FileAddType = fileAddType;
        }

        public Guid ServiceId { get; }
        public Guid DocumentId { get; }
        public DocumentFileAddType FileAddType { get; }
    }
}