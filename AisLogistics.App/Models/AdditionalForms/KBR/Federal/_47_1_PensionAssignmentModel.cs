namespace AisLogistics.App.Models.AdditionalForms.KBR.Federal;

/// <summary>
/// ЗАЯВЛЕНИЕ О НАЗНАЧЕНИИ ПЕНСИИ(ПЕРЕВОДЕ С ОДНОЙ ПЕНСИИ НА ДРУГУЮ) 
/// </summary>
public class _47_1_PensionAssignmentModel
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

    public class PensionModel
    {
        /// <summary>
        /// страховая пенсия по старости 
        /// </summary>
        public bool PensionOldAge { get; set; }

        /// <summary>
        /// страховая пенсия по инвалидности 
        /// </summary>
        public bool PensionDisability { get; set; }

        /// <summary>
        /// страховая пенсия по случаю потери кормильца 
        /// </summary>
        public bool PensionBreadwinnerLost { get; set; }

        /// <summary>
        /// доля страховой пенсии по старости
        /// </summary>
        public bool PensionOldAgePortion { get; set;}

        /// <summary>
        /// накопительная пенсия
        /// </summary>
        public bool PensionFunded { get; set; }

        /// <summary>
        /// Отображение в составе накопительной пенсии учитывать доход от взносов
        /// </summary>
        public bool IsVisualPensionFundedCheckAdditionalPaymentProfit { get; set; }

        /// <summary>
        /// В составе накопительной пенсии учитывать доход от взносов
        /// </summary>
        public bool PensionFundedCheckAdditionalPaymentProfit { get; set; }

        /// <summary>
        /// пенсия за выслугу лет по государственному пенсионному обеспечению
        /// </summary>
        public bool PensionSeniorityStateProvision { get; set; }

        /// <summary>
        /// пенсия по старости по государственному пенсионному обеспечению
        /// </summary>
        public bool PensionOldAgeStateProvision { get; set; }

        /// <summary>
        /// пенсия по инвалидности по государственному пенсионному обеспечению
        /// </summary>
        public bool PensionDisabilityStateProvision { get; set; }

        /// <summary>
        /// пенсия по случаю потери кормильца по государственному пенсионному обеспечению
        /// </summary>
        public bool PensionBreadwinnerLostStateProvision { get; set; }

        /// <summary>
        /// социальная пенсия по старости
        /// </summary>
        public bool PensionOldAgeSocial { get; set; }

        /// <summary>
        /// социальная пенсия по инвалидности
        /// </summary>
        public bool PensionDisabilitySocial { get; set; }

        /// <summary>
        /// социальная пенсия по случаю потери кормильца
        /// </summary>
        public bool PensionBreadwinnerLostSocial { get; set; }

        /// <summary>
        /// социальная пенся детям, оба родителя которых неизвестны
        /// </summary>
        public bool PensionOrphanSocial { get; set; }

        /// <summary>
        /// пенсия, предусмотренную Законом Российской Федерации от 19 апреля 1991 г. N 1032-1
        /// </summary>
        public bool PensionLow1032 { get; set; }

        /// <summary>
        /// пенсия, предусмотренную Законом Российской Федерации от 15 мая 1991 г. N 1244-1
        /// </summary>
        public bool PensionLow1244 { get; set; }

        /// <summary>
        /// Перевод с одной пенсии на другую
        /// </summary>
        public bool PensionTransfering { get; set; }

        /// <summary>
        /// федеральная социальная доплата к пенсии 
        /// </summary>
        public bool PensionFederalSocialSupplement { get; set; }

        /// <summary>
        /// пенсия (дополнительный выбор)
        /// </summary>
        public bool PensionOtherChoice { get; set; }

        /// <summary>
        /// пенсия (дополнительный выбор) название
        /// </summary>
        public string? PensionOtherChoiceName { get; set; }

        #region Перевод с одной пенсии на другую

        /// <summary>
        /// перевод с (вид пенсии)
        /// </summary>
        public string? PensionTransferingFrom { get; set; }

        /// <summary>
        /// законодательный акт
        /// </summary>
        public string? PensionTransferingAct { get; set; }

        /// <summary>
        /// перевод на (вид пенсии)
        /// </summary>
        public string? PensionTransferingTo { get; set; }

        #endregion
    }

    public PensionModel Pension { get; set; } = new();

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
    /// 1 - имеются нетрудоспособные члены семьи
    /// 2 - нет нетрудоспособных членов семьи
    /// </summary>
    public int DependentTypeId { get; set; }

    /// <summary>
    /// Количество нетрудоспособных членов семьи на иждивении, если DependentTypeId = 1
    /// </summary>
    public int DependentAmount { get; set; }

    #endregion

    /// <summary>
    /// Сведения о ребенке
    /// </summary>
    public class ChildDetail
    {
        /// <summary>
        /// Фамилия, имя, отчество (при наличии) в соответствии со свидетельством о рождении
        /// </summary>
        public string FullName { get; set; } = null!;

        /// <summary>
        /// Дата рождения
        /// </summary>
        public string? DateOfBirth { get; set; }

        /// <summary>
        /// СНИЛС
        /// </summary>
        public string? SNILS { get; set; }

        /// <summary>
        /// Родительских прав был лишен
        /// </summary>
        public bool ParentalRightsDeprived { get; set; } 

        /// <summary>
        /// Усыновление было отменено
        /// </summary>
        public bool AdoptionCanceled { get; set; } 
    }

    /// <summary>
    /// в) Сведения о детях (указывается в случае обращения за страховой пенсией по старости, страховой пенсией по инвалидности, накопительной пенсией)
    /// </summary>
    public ChildDetail[] Children { get; set; } = Array.Empty<ChildDetail>();

    #region г) проходил военную службу по призыву 

    /// <summary>
    /// Начало военной службы по призыву 
    /// </summary>
    public string? MilitaryServiceStartDate { get; set; }

    /// <summary>
    /// Конец военной службы по призыву 
    /// </summary>
    public string? MilitaryServiceFinishDate { get; set; }

    #endregion


    #region д) Военная служба, другой приравненной к ней службе, предусмотренную Законом Российской Федерации от 12 февраля 1993 г. N 4468-1

    /// <summary>
    /// Начало военной службы, другой приравненной к ней службе, предусмотренную Законом Российской Федерации от 12 февраля 1993 г. N 4468-1 
    /// </summary>
    public string? AlternativeMilitaryServiceStartDate { get; set; }

    /// <summary>
    /// Конец военной службы, другой приравненной к ней службе, предусмотренную Законом Российской Федерации от 12 февраля 1993 г. N 4468-1 
    /// </summary>
    public string? AlternativeMilitaryServiceFinishDate { get; set; }

    #endregion

    /// <summary>
    /// Информация об уходе за инвалидом
    /// </summary>
    public class CaringInvalidDetail
    {
        /// <summary>
        /// Фамилия, имя, отчество (при наличии)
        /// </summary>
        public string FullName { get; set; } = null!;

        /// <summary>
        /// СНИЛС
        /// </summary>
        public string? SNILS { get; set; }

        /// <summary>
        /// Начало периода
        /// </summary>
        public string? StartedAt { get; set; }

        /// <summary>
        /// Конец периода
        /// </summary>
        public string? FinishedAt { get; set; }
    }

    /// <summary>
    /// е) Уход за инвалидом I группы, ребенком-инвалидом в возрасте до 18 лет или за лицом, достигшим возраста 80 лет 
    /// (указывается в случае обращения за страховой пенсией по старости, страховой пенсией по инвалидности, накопительной пенсией)
    /// </summary>
    public CaringInvalidDetail[] CaringInvalid { get; set; } = Array.Empty<CaringInvalidDetail>();

    /// <summary>
    /// ж) Получатель пенсии в соответствии с законодательством иностранного государства
    /// 1 - не являюсь
    /// 2 - являюсь
    /// 4 - умерший кормилец не являлся
    /// 5 - умерший кормилец являлся
    /// 6 - сведений не имею
    /// </summary>
    public int ForeignPensionRecipient { get; set; }

    /// <summary>
    /// Название государства, если ForeignPensionRecipientId = 2
    /// </summary>
    public string? ForeignPensionCountry { get; set; }

    /// <summary>
    /// Название государства, если ForeignPensionRecipientId = 2
    /// </summary>
    public string? ForeignPensionCountryBreadwinnerLost { get; set; }

    /// <summary>
    /// з) Получатель пенсии в соответствии с Законом Российской Федерации "О пенсионном обеспечении лиц, проходивших военную службу ...
    /// 1 - не являюсь
    /// 2 - являюсь
    /// 3 - являлся
    /// 4 - умерший кормилец не являлся
    /// 5 - умерший кормилец являлся
    /// 6 - сведений не имею
    /// </summary>
    public int MilitaryPensionRecipientTypeId { get; set; }

    /// <summary>
    /// Вид пенсии, орган, осуществлявший пенсионное обеспечение, являюсь
    /// </summary>
    public string? MilitaryPensionTypeDetails { get; set; }
    /// <summary>
    /// Вид пенсии, орган, осуществлявший пенсионное обеспечение, являлся
    /// </summary>
    public string? MilitaryPensionTypeDetailsWas { get; set; }
    /// <summary>
    /// Вид пенсии, орган, осуществлявший пенсионное обеспечение, умерший кормилец являлся
    /// </summary>
    public string? MilitaryPensionTypeDetailsBreadwinnerLost { get; set; }

    /// <summary>
    /// и) Получатель иной пенсии
    /// </summary>
    public bool AlternativePensionRecipient { get; set; }

    /// <summary>
    /// к) Получатель ежемесячного пожизненного содержания 
    /// 1 - не являюсь
    /// 2 - являюсь
    /// 3 - являлся
    /// 4 - умерший кормилец не являлся
    /// 5 - умерший кормилец являлся
    /// 6 - сведений не имею
    /// </summary>
    public int MonthlyLifetimePensionRecipientTypeId { get; set; }

    /// <summary>
    /// л) Повторный брак
    /// </summary>
    public bool ReMarriageStatus { get; set; }

    /// <summary>
    /// м) Наличие постоянного место жительства на территории иностранного государства 
    /// </summary>
    public bool ForeignResidence { get; set; }

    /// <summary>
    /// н) согласен на перерасчет размера пенсии в сторону увеличения
    /// </summary>
    public bool ReCalculatePensionGrowth { get; set; }

    /// <summary>
    /// о) государственные должности Российской Федерации
    /// 1 - не замещаю
    /// 2 - замещаю
    /// 3 - замещал
    /// 4 - умерший кормилец не замещал
    /// 5 - умерший кормилец замещал
    /// 6 - сведений не имею
    /// </summary>
    public int StatePositionOccupation { get; set; }

    /// <summary>
    /// п) согласен с принятием решения о назначении пенсии
    /// </summary>
    public bool PensionResolutionAgreement { get; set; } = true;

    #region р) для идентификации личности гражданина
    /// <summary>
    /// вариант для идентификации личности гражданина
    /// </summary>
    public int SecretTypeId { get; set; }

    /// <summary>
    /// Тип вопроса 
    /// </summary>
    public int SecretAnswerType { get; set; }

    /// <summary>
    /// Ответ на котрольный вопрос 
    /// </summary>
    public string? SecretQuestionAnswer { get; set; }

    /// <summary>
    /// Секретный код
    /// </summary>
    public string? SecretCode { get; set; }

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
