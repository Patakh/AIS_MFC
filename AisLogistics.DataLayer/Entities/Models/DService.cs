using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Таблица текущих услуг
    /// </summary>
    public partial class DService
    {
        public DService()
        {
            APremiumFines = new HashSet<APremiumFine>();
            DAlertEmployees = new HashSet<DAlertEmployee>();
            DElkOrders = new HashSet<DElkOrder>();
            DPremiumSteps = new HashSet<DPremiumStep>();
            DServicesAudits = new HashSet<DServicesAudit>();
            DServicesDocuments = new HashSet<DServicesDocument>();
            DServicesDocumentsResults = new HashSet<DServicesDocumentsResult>();
            DServicesPayments = new HashSet<DServicesPayment>();
            DServicesRoutesStages = new HashSet<DServicesRoutesStage>();
            DServicesSmevRequests = new HashSet<DServicesSmevRequest>();
            DReestrServices = new HashSet<DReestrService>();
            DReestrUnclaimedServices = new HashSet<DReestrUnclaimedService>();
        }

        /// <summary>
        /// первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Связь с головной услугой
        /// </summary>
        public Guid DServicesIdParent { get; set; }
        /// <summary>
        /// Связь с делом
        /// </summary>
        public string DCasesId { get; set; }
        /// <summary>
        /// Связь с головным документом
        /// </summary>
        public Guid DServicesDocumentIdParent { get; set; }
        /// <summary>
        /// Связь с типом получателя
        /// </summary>
        public int SServicesCustomerTypeId { get; set; }
        /// <summary>
        /// Связь с подуслугой
        /// </summary>
        public Guid SServicesId { get; set; }
        /// <summary>
        /// Дата внесения услуги
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Дата планового заврешения услуги с учетом выше стоящих услуг
        /// </summary>
        public DateTime DateReg { get; set; }
        /// <summary>
        /// Дата фактического завершения услуги
        /// </summary>
        public DateTime? DateFact { get; set; }
        /// <summary>
        /// Количество дней на обработку
        /// </summary>
        public int CountDayProcessing { get; set; }
        /// <summary>
        /// Количество дней на возврат от исполнителя услуги
        /// </summary>
        public int CountDayReturn { get; set; }
        /// <summary>
        /// Колв-во дней на исполнение услуги(ОИВ) по регламенту
        /// </summary>
        public int CountDayExecution { get; set; }
        /// <summary>
        /// Связь с государственной пошлиной
        /// </summary>
        public int SServicesTariffTypeId { get; set; }
        /// <summary>
        /// Государственная пошлина
        /// </summary>
        public decimal TariffState { get; set; }
        /// <summary>
        /// Возможность редактирования государственной пошлины
        /// </summary>
        public bool TariffEdit { get; set; }
        /// <summary>
        /// Видимость в отчетах
        /// </summary>
        public bool IsReportSelect { get; set; }
        /// <summary>
        /// Учитывать в плане(Госзадание)
        /// </summary>
        public bool IsPlan { get; set; }
        /// <summary>
        /// Номер копии сопроводительного письма
        /// </summary>
        public int? NumberCopies { get; set; }
        /// <summary>
        /// Участие услуги в ИАС МКГУ
        /// </summary>
        public bool IasMkgu { get; set; }
        /// <summary>
        /// ID цели из ФРГУ
        /// </summary>
        public string FrguTargetId { get; set; }
        /// <summary>
        /// ID услуги ФРГУ
        /// </summary>
        public string FrguServiceId { get; set; }
        /// <summary>
        /// ID Поставщика ФРГУ
        /// </summary>
        public string FrguProviderId { get; set; }
        /// <summary>
        /// Связь с сотрудником принявшим услугу
        /// </summary>
        public Guid SEmployeesIdAdd { get; set; }
        /// <summary>
        /// Связь с филиалом в котором принята услуга
        /// </summary>
        public Guid SOfficesIdAdd { get; set; }
        /// <summary>
        /// Связь  с должностью сотрудника принявшего услугу
        /// </summary>
        public int SEmployeesJobPositionIdAdd { get; set; }
        /// <summary>
        /// Связь с сотрудником, исполнившим услугу
        /// </summary>
        public Guid? SEmployeesIdExecution { get; set; }
        /// <summary>
        /// Связь с филиалом в котором исполнили услугу
        /// </summary>
        public Guid? SOfficesIdExecution { get; set; }
        /// <summary>
        /// Связь с должностью сотрудника исполнившего услугу
        /// </summary>
        public int? SEmployeesJobPositionIdExecution { get; set; }
        /// <summary>
        /// Статус услуги
        /// </summary>
        public int SServicesStatusId { get; set; }
        /// <summary>
        /// Тариф для МФЦ
        /// </summary>
        public decimal TariffMfc { get; set; }
        /// <summary>
        /// Тип дня
        /// </summary>
        public int SServicesWeekId { get; set; }
        /// <summary>
        /// Путь этапов и ролей
        /// </summary>
        //public string RouteNext { get; set; }
        /// <summary>
        /// Дополнительная информация
        /// </summary>
        public string ExtraInfo { get; set; }
        /// <summary>
        /// Поставщик услуги
        /// </summary>
        public Guid SOfficesIdProvider { get; set; }
        /// <summary>
        /// id подуслуги из ФРГУ
        /// </summary>
        public string FrguServiceSubId { get; set; }
        /// <summary>
        /// наименование из ФРГУ
        /// </summary>
        public string FrguName { get; set; }
        /// <summary>
        /// Процедура
        /// </summary>
        public Guid SServicesProcedureId { get; set; }
        /// <summary>
        /// Отдел
        /// </summary>
        public Guid? SOfficesIdProviderDepartament { get; set; }
        /// <summary>
        /// Отдел
        /// </summary>
        public int SServicesTypeId { get; set; }
        /// <summary>
        /// Отдел
        /// </summary>
        public int SServicesInteractionId { get; set; }
        /// <summary>
        /// Выдача в ОИВ
        /// </summary>
        public bool IsIssueAuthority { get; set; }
        /// <summary>
        /// Заявитель
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Номер телефона 1
        /// </summary>
        public string CustomerPhone1 { get; set; }
        /// <summary>
        /// Номер телефона 2
        /// </summary>
        public string CustomerPhone2 { get; set; }
        /// <summary>
        /// Адрес
        /// </summary>
        public string CustomerAddress { get; set; }
        /// <summary>
        /// Поисковая строка
        /// </summary>
        public string SearchString { get; set; }
        /// <summary>
        /// Текущий этап
        /// </summary>
        public int SRoutesStageIdCurrent { get; set; }
        /// <summary>
        /// Текущий сотрудник
        /// </summary>
        public Guid SEmployeesIdCurrent { get; set; }
        /// <summary>
        /// Текущая должность
        /// </summary>
        public int SEmployeesJobPositionIdCurrent { get; set; }
        /// <summary>
        /// Текущая организация
        /// </summary>
        public Guid SOfficesIdCurrent { get; set; }
        /// <summary>
        /// Регламентная дата окончания тек этапа
        /// </summary>
        public DateTime? RoutesStageDateRegCurrent { get; set; }
        /// <summary>
        /// ID Поставщика ФРГУ Отдела
        /// </summary>
        public string FrguProviderIdDepartment { get; set; }

        public virtual DCase DCases { get; set; }
        public virtual SEmployee SEmployeesIdAddNavigation { get; set; }
        public virtual SEmployee SEmployeesIdExecutionNavigation { get; set; }
        public virtual SEmployee SEmployeesIdCurrentNavigation { get; set; }
        public virtual SEmployeesJobPosition SEmployeesJobPositionIdAddNavigation { get; set; }
        public virtual SEmployeesJobPosition SEmployeesJobPositionIdExecutionNavigation { get; set; }
        public virtual SEmployeesJobPosition SEmployeesJobPositionIdCurrentNavigation { get; set; }
        public virtual SOffice SOfficesIdAddNavigation { get; set; }
        public virtual SOffice SOfficesIdExecutionNavigation { get; set; }
        public virtual SOffice SOfficesIdCurrentNavigation { get; set; }
        public virtual SOffice SOfficesIdProviderNavigation { get; set; }
        public virtual SOffice SOfficesIdProviderDepartamentNavigation { get; set; }
        public virtual SService SServices { get; set; }
        public virtual SServicesCustomerType SServicesCustomerType { get; set; }
        public virtual SServicesStatus SServicesStatus { get; set; }
        public virtual SServicesTariffType SServicesTariffType { get; set; }
        public virtual SServicesWeek SServicesWeek { get; set; }
        public virtual SServicesProcedure SServicesProcedure { get; set; }
        public virtual SServicesInteraction SServicesInteraction { get; set; }
        public virtual SServicesType SServicesType { get; set; }
        public virtual SRoutesStage SRoutesStage { get; set; }
        public virtual ICollection<APremiumFine> APremiumFines { get; set; }
        public virtual ICollection<DAlertEmployee> DAlertEmployees { get; set; }
        public virtual ICollection<DElkOrder> DElkOrders { get; set; }
        public virtual ICollection<DPremiumStep> DPremiumSteps { get; set; }
        public virtual ICollection<DServicesAudit> DServicesAudits { get; set; }
        public virtual ICollection<DServicesDocument> DServicesDocuments { get; set; }
        public virtual ICollection<DServicesDocumentsResult> DServicesDocumentsResults { get; set; }
        public virtual ICollection<DServicesPayment> DServicesPayments { get; set; }
        public virtual ICollection<DServicesRoutesStage> DServicesRoutesStages { get; set; }
        public virtual ICollection<DServicesSmevRequest> DServicesSmevRequests { get; set; }
        public virtual ICollection<DReestrService> DReestrServices { get; set; }
        public virtual ICollection<DReestrUnclaimedService> DReestrUnclaimedServices { get; set; }
    }
}
