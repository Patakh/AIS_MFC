using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник подуслуг
    /// </summary>
    public partial class SService
    {
        public SService()
        {
            APremiumFines = new HashSet<APremiumFine>();
            APremiumSteps = new HashSet<APremiumStep>();
            AServices = new HashSet<AService>();
            DEmployeesServicesFavorites = new HashSet<DEmployeesServicesFavorite>();
            DPremiumFines = new HashSet<DPremiumFine>();
            DPremiumSteps = new HashSet<DPremiumStep>();
            DServices = new HashSet<DService>();
            SServicesActives = new HashSet<SServicesActive>();
            SServicesCustomers = new HashSet<SServicesCustomer>();
            SServicesDocuments = new HashSet<SServicesDocument>();
            SServicesDocumentsResults = new HashSet<SServicesDocumentsResult>();
            SServicesLivingSituationJoins = new HashSet<SServicesLivingSituationJoin>();
            SServicesProcedures = new HashSet<SServicesProcedure>();
            SServicesReasons = new HashSet<SServicesReason>();
            SServicesRoutesStages = new HashSet<SServicesRoutesStage>();
            SServicesSmevRequestJoins = new HashSet<SServicesSmevRequestJoin>();
            SServicesTypeQualityJoins = new HashSet<SServicesTypeQualityJoin>();
            SServicesWayGetJoins = new HashSet<SServicesWayGetJoin>();
            SServicesFiles = new HashSet<SServicesFile>();
            SServicesForms = new HashSet<SServicesForm>();
            DReestrs = new HashSet<DReestr>();
            DReestrUnclaimeds = new HashSet<DReestrUnclaimed>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Наименование услуги
        /// </summary>
        public string ServiceName { get; set; }
        /// <summary>
        /// Мнемоника услуги
        /// </summary>
        public string ServiceMnemo { get; set; }
        /// <summary>
        /// Описание подуслуги
        /// </summary>
        public string ServiceDescription { get; set; }
        /// <summary>
        /// Расположение услуги, 0 - Универсальная, 1- Только как Главная, 2- Только как Подуслуга
        /// </summary>
        public int ServicePosition { get; set; }
        /// <summary>
        /// Вывод в отчетах. 
        /// </summary>
        public bool IsReportSelect { get; set; }
        /// <summary>
        /// Возможность редактирования тарифа
        /// </summary>
        public bool IsTariffEdit { get; set; }
        /// <summary>
        /// Участие услуги в ИАС МКГУ
        /// </summary>
        public bool IasMkgu { get; set; }
        /// <summary>
        /// Хэштеги
        /// </summary>
        public string Hashtag { get; set; }
        /// <summary>
        /// Реквизиты НПА
        /// </summary>
        public string LegalAct { get; set; }
        /// <summary>
        /// Признак удаления записи
        /// </summary>
        public bool IsRemove { get; set; }
        /// <summary>
        /// Комментарий
        /// </summary>
        public string Commentt { get; set; }
        /// <summary>
        /// Краткое наименование услуги
        /// </summary>
        public string ServiceNameSmall { get; set; }
        /// <summary>
        /// Дата и время добавления записи
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Сотрудник добавивший запись
        /// </summary>
        public string EmployeesFioAdd { get; set; }
        /// <summary>
        /// Учитывать в плане
        /// </summary>
        public bool IsPlan { get; set; }
        /// <summary>
        /// Способ взаимодействия
        /// </summary>
        public int SServicesInteractionId { get; set; }
        /// <summary>
        /// Тип услуги
        /// </summary>
        public int SServicesTypeId { get; set; }
        /// <summary>
        /// Организация, поставщик
        /// </summary>
        public Guid SOfficesId { get; set; }
        /// <summary>
        /// Индетификатор ФРГУ
        /// </summary>
        public string FrguServiceId { get; set; }
        /// <summary>
        /// Наименование ФРГУ
        /// </summary>
        public string FrguName { get; set; }
        /// <summary>
        /// Выдача в ОИВ
        /// </summary>
        public bool IsIssueAuthority { get; set; }
        /// <summary>
        /// Срок хранения услуги в МФЦ
        /// </summary>
        public int TimeStorage { get; set; }
        /// <summary>
        /// Отправка СМС
        /// </summary>
        public bool IsMessage { get; set; }
        /// <summary>
        /// Выгрузка для сайта
        /// </summary>
        public bool IsUploadingSite { get; set; }
        /// <summary>
        /// Наименование для сайта
        /// </summary>
        public string ServiceNameSite { get; set; }

        public virtual SServicesType SServicesType { get; set; }
        public virtual SServicesInteraction SServicesInteraction { get; set; }
        public virtual SOffice SOffice { get; set; }

        public virtual ICollection<APremiumFine> APremiumFines { get; set; }
        public virtual ICollection<APremiumStep> APremiumSteps { get; set; }
        public virtual ICollection<AService> AServices { get; set; }
        public virtual ICollection<DEmployeesServicesFavorite> DEmployeesServicesFavorites { get; set; }
        public virtual ICollection<DPremiumFine> DPremiumFines { get; set; }
        public virtual ICollection<DPremiumStep> DPremiumSteps { get; set; }
        public virtual ICollection<DService> DServices { get; set; }
        public virtual ICollection<SServicesActive> SServicesActives { get; set; }
        public virtual ICollection<SServicesCustomer> SServicesCustomers { get; set; }
        public virtual ICollection<SServicesDocument> SServicesDocuments { get; set; }
        public virtual ICollection<SServicesDocumentsResult> SServicesDocumentsResults { get; set; }
        public virtual ICollection<SServicesLivingSituationJoin> SServicesLivingSituationJoins { get; set; }
        public virtual ICollection<SServicesProcedure> SServicesProcedures { get; set; }
        public virtual ICollection<SServicesReason> SServicesReasons { get; set; }
        public virtual ICollection<SServicesRoutesStage> SServicesRoutesStages { get; set; }
        public virtual ICollection<SServicesSmevRequestJoin> SServicesSmevRequestJoins { get; set; }
        public virtual ICollection<SServicesTypeQualityJoin> SServicesTypeQualityJoins { get; set; }
        public virtual ICollection<SServicesWayGetJoin> SServicesWayGetJoins { get; set; }
        public virtual ICollection<SServicesFile> SServicesFiles { get; set; }
        public virtual ICollection<SServicesForm> SServicesForms { get; set; }
        public virtual ICollection<DReestr> DReestrs { get; set; }
        public virtual ICollection<DReestrUnclaimed> DReestrUnclaimeds { get; set; }
    }
}
