using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Архивные услуги
    /// </summary>
    public partial class AService
    {
        public AService()
        {
            AServicesAudits = new HashSet<AServicesAudit>();
            AServicesDocuments = new HashSet<AServicesDocument>();
            AServicesDocumentsResults = new HashSet<AServicesDocumentsResult>();
            AServicesPayments = new HashSet<AServicesPayment>();
            AServicesRoutesStages = new HashSet<AServicesRoutesStage>();
            AServicesSmevRequests = new HashSet<AServicesSmevRequest>();
        }

        /// <summary>
        /// первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Связь с головной услугой
        /// </summary>
        public Guid AServicesIdParent { get; set; }
        /// <summary>
        /// Связь с делом
        /// </summary>
        public string ACasesId { get; set; }
        /// <summary>
        /// Связь с головным документом
        /// </summary>
        public Guid AServicesDocumentIdParent { get; set; }
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
        public DateTime DateFact { get; set; }
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
        public bool ReportSelect { get; set; }
        /// <summary>
        /// Номер копии сопроводительного письма
        /// </summary>
        public int? NumberCopies { get; set; }
        /// <summary>
        /// Участие услуги в ИАС МКГУ
        /// </summary>
        public bool? IasMkgu { get; set; }
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
        /// Дополнительная информация
        /// </summary>
        public string ExtraInfo { get; set; }
        /// <summary>
        /// Поставщик услуги
        /// </summary>
        public Guid SOfficesIdProvider { get; set; }
        /// <summary>
        /// id подуслуги ФРГУ
        /// </summary>
        public string FrguServiceSubId { get; set; }
        /// <summary>
        /// ФРГУ наименование
        /// </summary>
        public string FrguName { get; set; }
        /// <summary>
        /// Процедура
        /// </summary>
        public Guid? SServicesProcedureId { get; set; }

        public virtual ACase ACases { get; set; }
        public virtual SEmployee SEmployeesIdAddNavigation { get; set; }
        public virtual SEmployee SEmployeesIdExecutionNavigation { get; set; }
        public virtual SEmployeesJobPosition SEmployeesJobPositionIdAddNavigation { get; set; }
        public virtual SEmployeesJobPosition SEmployeesJobPositionIdExecutionNavigation { get; set; }
        public virtual SOffice SOfficesIdAddNavigation { get; set; }
        public virtual SOffice SOfficesIdExecutionNavigation { get; set; }
        public virtual SOffice SOfficesIdProviderNavigation { get; set; }
        public virtual SService SServices { get; set; }
        public virtual SServicesCustomerType SServicesCustomerType { get; set; }
        public virtual SServicesStatus SServicesStatus { get; set; }
        public virtual SServicesTariffType SServicesTariffType { get; set; }
        public virtual SServicesWeek SServicesWeek { get; set; }
        public virtual ICollection<AServicesDocument> AServicesDocuments { get; set; }
        public virtual ICollection<AServicesDocumentsResult> AServicesDocumentsResults { get; set; }
        public virtual ICollection<AServicesPayment> AServicesPayments { get; set; }
        public virtual ICollection<AServicesRoutesStage> AServicesRoutesStages { get; set; }
        public virtual ICollection<AServicesSmevRequest> AServicesSmevRequests { get; set; }
        public virtual ICollection<AServicesAudit> AServicesAudits { get; set; }
    }
}
