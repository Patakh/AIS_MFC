using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник филиалов 
    /// </summary>
    public partial class SOffice
    {
        public SOffice()
        {
            APremia = new HashSet<APremium>();
            APremiumFines = new HashSet<APremiumFine>();
            APremiumSteps = new HashSet<APremiumStep>();
            AServiceSOfficesIdAddNavigations = new HashSet<AService>();
            AServiceSOfficesIdExecutionNavigations = new HashSet<AService>();
            AServiceSOfficesIdProviderNavigations = new HashSet<AService>();
            AServicesCommentts = new HashSet<AServicesCommentt>();
            AServicesCustomerCalls = new HashSet<AServicesCustomersCall>();
            AServicesCustomerMessages = new HashSet<AServicesCustomersMessage>();
            AServicesCustomers = new HashSet<AServicesCustomer>();
            AServicesCustomersLegals = new HashSet<AServicesCustomersLegal>();
            AServicesFileResults = new HashSet<AServicesFileResult>();
            AServicesFiles = new HashSet<AServicesFile>();
            AServicesPayments = new HashSet<AServicesPayment>();
            AServicesRoutesStages = new HashSet<AServicesRoutesStage>();
            AServicesSmevRequests = new HashSet<AServicesSmevRequest>();
            DEmployeesIasMkguOfficesWebsites = new HashSet<DEmployeesIasMkguOfficesWebsite>();
            DIasMkguInfomatUploads = new HashSet<DIasMkguInfomatUpload>();
            DIasMkguSmsUploads = new HashSet<DIasMkguSmsUpload>();
            DIncomingCalls = new HashSet<DIncomingCall>();
            DPremiumFines = new HashSet<DPremiumFine>();
            DPremiumSteps = new HashSet<DPremiumStep>();
            DQueueAvgTimes = new HashSet<DQueueAvgTime>();
            DSalaryRecalculationLogs = new HashSet<DSalaryRecalculationLog>();
            DServiceSOfficesIdAddNavigations = new HashSet<DService>();
            DServiceSOfficesIdExecutionNavigations = new HashSet<DService>();
            DServiceSOfficesIdProviderNavigations = new HashSet<DService>();
            DServicesAudits = new HashSet<DServicesAudit>();
            AServicesAudits = new HashSet<AServicesAudit>();
            DServicesCommentts = new HashSet<DServicesCommentt>();
            DServicesCustomerCalls = new HashSet<DServicesCustomersCall>();
            DServicesCustomerMessages = new HashSet<DServicesCustomersMessage>();
            DServicesCustomers = new HashSet<DServicesCustomer>();
            DServicesCustomersLegals = new HashSet<DServicesCustomersLegal>();
            DServicesFileResults = new HashSet<DServicesFileResult>();
            DServicesFiles = new HashSet<DServicesFile>();
            DServicesPayments = new HashSet<DServicesPayment>();
            DServicesRoutesStages = new HashSet<DServicesRoutesStage>();
            DServicesSmevRequests = new HashSet<DServicesSmevRequest>();
            DSmsPollRegions = new HashSet<DSmsPollRegion>();
            DStepRecalculationLogs = new HashSet<DStepRecalculationLog>();
            SEmployeesOfficesJoins = new HashSet<SEmployeesOfficesJoin>();
            SOfficesAuthorizations = new HashSet<SOfficesAuthorization>();
            SEmployeesAuthorizationLogs = new HashSet<SEmployeesAuthorizationLog>();
            SOfficesPlans = new HashSet<SOfficesPlan>();
            SOfficesZags = new HashSet<SOfficesZag>();
            SOfficeAcquirings = new HashSet<SOfficesAcquiring>();
            SServicesActives = new HashSet<SServicesActive>();
            SServices = new HashSet<SService>();
            DReestrs= new HashSet<DReestr>();
            DReestrsNavigations = new HashSet<DReestr>();
            DReestrUnclaimedsDepartamentNavigations = new HashSet<DReestrUnclaimed>();
            DReestrUnclaimeds = new HashSet<DReestrUnclaimed>();
            DReestrUnclaimedsNavigations = new HashSet<DReestrUnclaimed>();
            DReestrsDepartamentNavigations = new HashSet<DReestr>();
            DServiceSOfficesIdProviderDepartamentNavigation = new HashSet<DService>();
            DServiceSOfficesIdCurrentNavigations = new HashSet<DService>();
            DTestEmployees = new HashSet<DTestEmployee>();
            SOfficesShedules = new HashSet<SOfficesShedule>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Наименование филиала
        /// </summary>
        public string OfficeName { get; set; }
        /// <summary>
        /// Краткое наименование филиала
        /// </summary>
        public string OfficeNameSmall { get; set; }
        /// <summary>
        /// Мнемоника филиала
        /// </summary>
        public string OfficeMnemo { get; set; }
        /// <summary>
        /// Номер телефона филиала
        /// </summary>
        public string OfficePhoneNumber { get; set; }
        /// <summary>
        /// Адрес сайта филиала
        /// </summary>
        public string OfficeWebsite { get; set; }
        /// <summary>
        /// Адрес Skype для бесплатной удаленной консультации
        /// </summary>
        public string OfficeSkype { get; set; }
        /// <summary>
        /// Официальная почта филиала
        /// </summary>
        public string OfficeEmail { get; set; }
        /// <summary>
        /// Логин почты филиала
        /// </summary>
        public string OfficeEmailLogin { get; set; }
        /// <summary>
        /// Пароль почты филиала
        /// </summary>
        public string OfficeEmailPass { get; set; }
        /// <summary>
        /// Сервер почты филиала
        /// </summary>
        public string OfficeEmailServer { get; set; }
        /// <summary>
        /// Порт почты филиала
        /// </summary>
        public string OfficeEmailPort { get; set; }
        /// <summary>
        /// Сервер call центра
        /// </summary>
        public string OfficeCallServer { get; set; }
        /// <summary>
        /// ИНН филиала - Идентификационный номер налогоплательщика
        /// </summary>
        public string OfficeInn { get; set; }
        /// <summary>
        /// ОГРН филиала - Основной государственный регистрационный номер
        /// </summary>
        public string OfficeOgrn { get; set; }
        /// <summary>
        /// ОКТМО филиала - Общероссийский классификатор территорий муниципальных образований
        /// </summary>
        public string OfficeOktmo { get; set; }
        /// <summary>
        /// ОКАТО филиала - Общероссийский классификатор объектов административно-территориального деления
        /// </summary>
        public string OfficeOkato { get; set; }
        /// <summary>
        /// КПП филиала - Код причины постановки на учет
        /// </summary>
        public string OfficeKpp { get; set; }
        /// <summary>
        /// Номер филиала для ИАС МКГУ(Информационно-аналитическая система мониторинга качества государственных услуг)
        /// </summary>
        public int? OfficeVendorId { get; set; }
        /// <summary>
        /// ЕСИА центр ID
        /// </summary>
        public string OfficeEsiaCentrId { get; set; }
        /// <summary>
        /// uuid филиала в системе МДМ
        /// </summary>
        public Guid? MdmUid { get; set; }
        /// <summary>
        /// Идентификатор МФЦ в ЦИК (для ВС &quot;Вид сведений для приема через ЕПГУ и МФЦ заявлений о включении избирателя в список избирателей по месту нахождения в день голосования на выборах в Российской Федерации&quot;
        /// </summary>
        public string OfficeCikId { get; set; }
        /// <summary>
        /// Наименование МФЦ для ЦИК
        /// </summary>
        public string OfficeCikName { get; set; }
        /// <summary>
        /// СНИЛС директора МФЦ для запросов ЕСИА
        /// </summary>
        public string EsiaOperatorSnils { get; set; }
        /// <summary>
        /// Количество населения на территории офиса
        /// </summary>
        public int? OfficeCountPopulation { get; set; }
        /// <summary>
        /// Адрес филиала
        /// </summary>
        public string OfficeAdress { get; set; }
        /// <summary>
        /// Географическая широта филиала
        /// </summary>
        public string OfficeLatitude { get; set; }
        /// <summary>
        /// Географическая долгота филиала
        /// </summary>
        public string OfficeLongitude { get; set; }
        /// <summary>
        /// Идентификатор МФЦ на ЕПГУ (интеграция с системой ЭОС Дело)
        /// </summary>
        public string OfficeEpguId { get; set; }
        /// <summary>
        /// Признак удаления записи
        /// </summary>
        public bool IsRemove { get; set; }
        /// <summary>
        /// ID  электронной очереди
        /// </summary>
        public string QueueId { get; set; }
        /// <summary>
        /// Наименование файла
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Расширение файла
        /// </summary>
        public string FileExtension { get; set; }
        /// <summary>
        /// Размер файла
        /// </summary>
        public int? FileSize { get; set; }
        /// <summary>
        /// Дата и время добавления записи
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Сотрудник добавивший запись
        /// </summary>
        public string EmployeesFioAdd { get; set; }
        /// <summary>
        /// Комментарий к записи
        /// </summary>
        public string Commentt { get; set; }
        /// <summary>
        /// Номер для ВипНет ПФР
        /// </summary>
        public string OfficeNum { get; set; }
        /// <summary>
        /// Идентификатор филиала ФРГУ
        /// </summary>
        public string OfficeFrguProviderId { get; set; }
        /// <summary>
        /// Идентификатор для загранпаспортов
        /// </summary>
        public string OfficeMvdOpvId { get; set; }
        /// <summary>
        /// Связь с FTP сервером
        /// </summary>
        public Guid? SFtpId { get; set; }
        /// <summary>
        /// Логин для шлюза смс рассылки
        /// </summary>
        public string MegalabsLogin { get; set; }
        /// <summary>
        /// Пароль для шлюза смс рассылки
        /// </summary>
        public string MegalabsPassword { get; set; }
        /// <summary>
        /// Имя отправителя СМС для Мегалабс
        /// </summary>
        public string MegalabsSender { get; set; }
        /// <summary>
        /// Тип
        /// </summary>
        public int SOfficesTypeId { get; set; }
        /// <summary>
        /// Наименование в ФРГУ
        /// </summary>
        public string OfficeFrguName { get; set; }
        /// <summary>
        /// ФИО руководителя
        /// </summary>
        public string OfficeHeadName { get; set; }
        /// <summary>
        /// Отправка в МДМ
        /// </summary>
        public bool SendMdm { get; set; }
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid ParentId { get; set; }
        /// <summary>
        /// Количество окон приема
        /// </summary>
        public int? ReceiveWindowsCount { get; set; }
        /// <summary>
        /// Ведет прием от заявителя
        /// </summary>
        public bool IsReceptionCustomer { get; set; }
        /// <summary>
        /// Орган предоставляющий услугу
        /// </summary>
        public bool IsProviderService { get; set; }
        /// <summary>
        /// Площадь
        /// </summary>
        public decimal? OfficeSquare { get; set; }
        /// <summary>
        /// Фото
        /// </summary>
        public byte[]? OfficeImage { get; set; }

        public virtual SFtp SFtp { get; set; }
        public virtual SOfficesType SOfficesType { get; set; }
        public virtual ICollection<APremium> APremia { get; set; }
        public virtual ICollection<APremiumFine> APremiumFines { get; set; }
        public virtual ICollection<APremiumStep> APremiumSteps { get; set; }
        public virtual ICollection<AService> AServiceSOfficesIdAddNavigations { get; set; }
        public virtual ICollection<AService> AServiceSOfficesIdExecutionNavigations { get; set; }
        public virtual ICollection<AService> AServiceSOfficesIdProviderNavigations { get; set; }
        public virtual ICollection<AServicesCommentt> AServicesCommentts { get; set; }
        public virtual ICollection<AServicesCustomersCall> AServicesCustomerCalls { get; set; }
        public virtual ICollection<AServicesCustomersMessage> AServicesCustomerMessages { get; set; }
        public virtual ICollection<AServicesCustomer> AServicesCustomers { get; set; }
        public virtual ICollection<AServicesCustomersLegal> AServicesCustomersLegals { get; set; }
        public virtual ICollection<AServicesFileResult> AServicesFileResults { get; set; }
        public virtual ICollection<AServicesFile> AServicesFiles { get; set; }
        public virtual ICollection<AServicesPayment> AServicesPayments { get; set; }
        public virtual ICollection<AServicesRoutesStage> AServicesRoutesStages { get; set; }
        public virtual ICollection<AServicesSmevRequest> AServicesSmevRequests { get; set; }
        public virtual ICollection<DEmployeesIasMkguOfficesWebsite> DEmployeesIasMkguOfficesWebsites { get; set; }
        public virtual ICollection<DIasMkguInfomatUpload> DIasMkguInfomatUploads { get; set; }
        public virtual ICollection<DIasMkguSmsUpload> DIasMkguSmsUploads { get; set; }
        public virtual ICollection<DIncomingCall> DIncomingCalls { get; set; }
        public virtual ICollection<DPremiumFine> DPremiumFines { get; set; }
        public virtual ICollection<DPremiumStep> DPremiumSteps { get; set; }
        public virtual ICollection<DQueueAvgTime> DQueueAvgTimes { get; set; }
        public virtual ICollection<DSalaryRecalculationLog> DSalaryRecalculationLogs { get; set; }
        public virtual ICollection<DService> DServiceSOfficesIdAddNavigations { get; set; }
        public virtual ICollection<DService> DServiceSOfficesIdExecutionNavigations { get; set; }
        public virtual ICollection<DService> DServiceSOfficesIdCurrentNavigations { get; set; }
        public virtual ICollection<DService> DServiceSOfficesIdProviderNavigations { get; set; }
        public virtual ICollection<DService> DServiceSOfficesIdProviderDepartamentNavigation { get; set; }
        public virtual ICollection<DServicesAudit> DServicesAudits { get; set; }
        public virtual ICollection<AServicesAudit> AServicesAudits { get; set; }
        public virtual ICollection<DServicesCommentt> DServicesCommentts { get; set; }
        public virtual ICollection<DServicesCustomersCall> DServicesCustomerCalls { get; set; }
        public virtual ICollection<DServicesCustomersMessage> DServicesCustomerMessages { get; set; }
        public virtual ICollection<DServicesCustomer> DServicesCustomers { get; set; }
        public virtual ICollection<DServicesCustomersLegal> DServicesCustomersLegals { get; set; }
        public virtual ICollection<DServicesFileResult> DServicesFileResults { get; set; }
        public virtual ICollection<DServicesFile> DServicesFiles { get; set; }
        public virtual ICollection<DServicesPayment> DServicesPayments { get; set; }
        public virtual ICollection<DServicesRoutesStage> DServicesRoutesStages { get; set; }
        public virtual ICollection<DServicesSmevRequest> DServicesSmevRequests { get; set; }
        public virtual ICollection<DSmsPollRegion> DSmsPollRegions { get; set; }
        public virtual ICollection<DStepRecalculationLog> DStepRecalculationLogs { get; set; }
        public virtual ICollection<SEmployeesOfficesJoin> SEmployeesOfficesJoins { get; set; }
        public virtual ICollection<SOfficesAuthorization> SOfficesAuthorizations { get; set; }
        public virtual ICollection<SEmployeesAuthorizationLog> SEmployeesAuthorizationLogs { get; set; }
        public virtual ICollection<SOfficesPlan> SOfficesPlans { get; set; }
        public virtual ICollection<SOfficesZag> SOfficesZags { get; set; }
        public virtual ICollection<SOfficesAcquiring> SOfficeAcquirings { get; set; }
        public virtual ICollection<SServicesActive> SServicesActives { get; set; }
        public virtual ICollection<SService> SServices { get; set; }
        public virtual ICollection<DReestr> DReestrs { get; set; }
        public virtual ICollection<DReestr> DReestrsNavigations { get; set; }
        public virtual ICollection<DReestr> DReestrsDepartamentNavigations { get; set; }
        public virtual ICollection<DReestrUnclaimed> DReestrUnclaimeds { get; set; }
        public virtual ICollection<DReestrUnclaimed> DReestrUnclaimedsNavigations { get; set; }
        public virtual ICollection<DReestrUnclaimed> DReestrUnclaimedsDepartamentNavigations { get; set; }
        public virtual ICollection<DTestEmployee> DTestEmployees { get; set; }
        public virtual ICollection<SOfficesShedule> SOfficesShedules { get; set; }
    }
}
