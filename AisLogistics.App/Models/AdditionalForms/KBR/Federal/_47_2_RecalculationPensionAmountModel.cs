namespace AisLogistics.App.Models.AdditionalForms.KBR.Federal;

public class _47_2_RecalculationPensionAmountModel
{
    #region Блок1

    /// <summary>
    /// Гражданство
    /// </summary>
    public string Citizenship { get; set; } = null!;

    /// <summary>
    /// Срок действия документа удостоверяющего личность
    /// </summary> 
    public string? ValidityPeriodDocument { get; set; }

    #endregion

    #region Блок2

    /// <summary>
    /// Представитель 
    /// </summary> 
    public string Representative { get; set; } = null!;

    /// <summary>
    /// Наименование организации, на которую возложено исполнение обязанностей опекуна или попечителя
    /// </summary>
    public string GuardianOrganizationName { get; set; } = null!;

    /// <summary>
    /// Адрес места нахождения организации
    /// </summary>
    public string GuardianOrganizationAddress { get; set; } = null!;

    #endregion

    #region Блок3

    /// <summary>
    /// вид пенсии, от которого происходит перерасчет
    /// </summary>
    public List<string> OldPensionName { get; set; } = null!;

    public class PensionRecalculationModel
    {
        /// <summary>
        /// увеличение величины индивидуального пенсионного коэффициента за периоды до 1 января 2015 года
        /// </summary>
        public bool IndividualCoefficientGrowth { get; set; }

        /// <summary>
        /// увеличение суммы коэффициентов, определяемых за каждый календарный год 
        /// </summary>
        public bool CoefficientSumGrowth { get; set; }

        /// <summary>
        /// наличие (увеличение количества) нетрудоспособных членов семьи, находящихся на иждивении пенсионера
        /// </summary>
        public bool DependentDisabledFamilyMembers { get; set; }

        /// <summary>
        /// приобретение необходимого календарного стажа работы в районах Крайнего Севера и (или) приравненных к ним местностях и страхового стажа
        /// </summary>
        public bool FarNorthWorkExperience { get; set; }

        /// <summary>
        /// переезд на новое место жительства в районы Крайнего Севера и приравненные к ним местности, в другие районы Крайнего Севера
        /// </summary>
        public bool FarNorthMigration { get; set; }

        /// <summary>
        /// переезд на новое место жительства в районы с тяжелыми климатическими условиями, 
        /// </summary>
        public bool HardClimateRegionMigration { get; set; }

        /// <summary>
        /// приобретение необходимого календарного стажа работы в сельском хозяйстве
        /// </summary>
        public bool AgricultureWorkExperience { get; set; }

        /// <summary>
        /// изменение категории нетрудоспособного члена семьи умершего кормильца
        /// </summary>
        public bool DisabledFamilyMemberCategoryChange { get; set; }

        /// <summary>
        /// изменение условий назначения социальной пенсии
        /// </summary>
        public bool SocialPensionChange { get; set; }

        /// <summary>
        /// увеличение продолжительности стажа государственной гражданской службы после назначения пенсии за выслугу лет
        /// </summary>
        public bool SeniorityStateGrowth { get; set; }

        /// <summary>
        /// замещение должности федеральной государственной гражданской службы не менее 12 полных месяцев с более высоким должностным окладом
        /// </summary>
        public bool FederalStateOccupationTwelveMonths { get; set; }

        /// <summary>
        /// увеличение продолжительности выслуги лет
        /// </summary>
        public bool SeniorityGrowth { get; set; }

        /// <summary>
        /// иное
        /// </summary>
        public bool OtherCase { get; set; }

        /// <summary>
        /// Описание, если выбран OtherCase
        /// </summary>
        public string? OtherCaseName { get; set; }
    }

    public PensionRecalculationModel PensionRecalculation { get; set; } = new();

    #endregion

    #region Блок4

    /// <summary>
    /// а) Трудоустройство:
    /// - работаю (true)
    /// - не работаю (false)
    /// </summary>
    public bool Employed { get; set; }

    #region б) на моем иждивении находятся 

    /// <summary>
    /// Тип на иждивении:
    /// 1 - нет нетрудоспособных членов семьи
    /// 2 - имеются нетрудоспособные члены семьи
    /// </summary>
    public int DependentTypeId { get; set; }

    /// <summary>
    /// Количество нетрудоспособных членов семьи на иждивении, если DependentTypeId = 1
    /// </summary>
    public int DependentAmount { get; set; }

    #endregion

    #endregion

    #region Блок5

    /// <summary>
    /// Я предупрежден (иное)
    /// </summary>
    public string? AdditionalWarningText { get; set; }

    #endregion

    #region Блок6

    /// <summary>
    /// Прилагаемые документы
    /// </summary>
    public AppliedDocument[] AppliedDocumentList { get; set; } = Array.Empty<AppliedDocument>();
    public class AppliedDocument
    {
        /// <summary>
        /// Наименование документа
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Количестов Экземпляров
        /// </summary>
        public int? NumdberOriginals { get; set; }
        /// <summary>
        /// Количество страниц
        /// </summary>
        public int? NumdberCopies { get; set; }
    }

    #endregion

    #region Блок7

    /// <summary>
    /// Тип информирования
    /// </summary>
    public Notification TypeNotification { get; set; }

    public class Notification
    {
        public bool NotificationTypeOne { get; set; }
        public bool NotificationTypeTwo { get; set; }
        public string? EmailOne { get; set; }
        public int NotificationTransmitionMethod { get; set; }
        public string? EmailTwo { get; set; }
        public string? SubscriberNumber { get; set; }
    }

    #endregion
}
