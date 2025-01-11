namespace AisLogistics.App.Models.AdditionalForms.KBR.Federal;

/// <summary>
/// 
/// </summary>
public class ReplaningPremisesModel
{
    /// <summary>
    /// Тип заявителя
    /// 1 - Физическое лицо
    /// 2 - Представитель физического лица
    /// 3 - Юридическое лицо
    /// 4 - Представитель юридического лица
    /// </summary>
    public int ApplicantTypeId { get; set; }

    #region Физическое лицо

    /// <summary>
    /// Ф.И.О. физического лица
    /// </summary>
    public string? ApplicantFullName { get; set; }

    /// <summary>
    /// Серия документа физического лица
    /// </summary>
    public string? ApplicantDocumentSeries { get; set; }

    /// <summary>
    /// Номер документа физического лица
    /// </summary>
    public string? ApplicantDocumentNumber { get; set; }

    /// <summary>
    /// Кем выдан документ физического лица
    /// </summary>
    public string? ApplicantDocumentGivenBy { get; set; }

    /// <summary>
    /// Дата выдачи документа физического лица
    /// </summary>
    public string? ApplicantDocumentGivenDate { get; set; }

    /// <summary>
    /// Телефон физического лица
    /// </summary>
    public string? ApplicantPhone { get; set; }

    /// <summary>
    /// Адрес физического лица
    /// </summary>
    public string? ApplicantAddress { get; set; }

    #endregion

    #region Представитель физического лица

    /// <summary>
    /// Ф.И.О. представителя физического лица
    /// </summary>
    public string? ApplicantAgentFullName { get; set; }

    /// <summary>
    /// Серия доверенности представителя физического лица
    /// </summary>
    public string? ApplicantAgentDocumentSeries { get; set; }

    /// <summary>
    /// Номер доверенности представителя физического лица
    /// </summary>
    public string? ApplicantAgentDocumentNumber { get; set; }

    /// <summary>
    /// Дата выдачи доверенности представителя физического лица
    /// </summary>
    public string? ApplicantAgentDocumentGivenDate { get; set; }

    #endregion

    #region Юридическое лицо

    /// <summary>
    /// Наименование юридического лица
    /// </summary>
    public string? LegalEntityFullName { get; set; }

    /// <summary>
    /// Организационно-правовая форма юридического лица
    /// </summary>
    public string? LegalEntityForm { get; set; }

    /// <summary>
    /// Адрес юридического лица
    /// </summary>
    public string? LegalEntityAddress { get; set; }

    /// <summary>
    /// Телефон юридического лица
    /// </summary>
    public string? LegalEntityPhone { get; set; }

    #endregion

    #region Представитель юридического лица

    /// <summary>
    /// Ф.И.О. уполномоченного представителя юридического лица
    /// </summary>
    public string? LegalEntityAgentFullName { get; set; }

    /// <summary>
    /// Серия доверенности представителя юридического лица
    /// </summary>
    public string? LegalEntityAgentDocumentSeries { get; set; }

    /// <summary>
    /// Номер доверенности представителя юридического лица
    /// </summary>
    public string? LegalEntityAgentDocumentNumber { get; set; }

    /// <summary>
    /// Дата выдачи доверенности представителя юридического лица
    /// </summary>
    public string? LegalEntityAgentDocumentGivenDate { get; set; }

    #endregion

    #region Место нахождения жилого помещения

    /// <summary>
    /// Наименование субъекта Российской Федерации
    /// </summary>
    public string? SubjectRussianFederationName { get; set; }

    /// <summary>
    /// Наименование муниципального района, городского округа или внутригородской территории (для городов федерального значения) 
    /// в составе субъекта Российской Федерации
    /// </summary>
    public string? MunicipalityName { get; set; }

    /// <summary>
    /// Наименование поселения
    /// </summary>
    public string? SettlementName { get; set; }

    /// <summary>
    /// Улица
    /// </summary>
    public string? Street { get; set; }

    /// <summary>
    /// Дом
    /// </summary>
    public string? House { get; set; }

    /// <summary>
    /// Корпус
    /// </summary>
    public string? Housing { get; set; }

    /// <summary>
    /// Строение
    /// </summary>
    public string? Building { get; set; }

    /// <summary>
    /// квартира (комната)
    /// </summary>
    public string? Flat { get; set; }

    /// <summary>
    /// Подъезд
    /// </summary>
    public string? Entrance { get; set; }

    /// <summary>
    /// Этаж
    /// </summary>
    public string? Floor { get; set; }

    #endregion

    /// <summary>
    /// Собственник(и) жилого помещения
    /// </summary>
    public string? PremisesOwner { get; set; }

    /// <summary>
    /// Тип переустройства
    /// 1 - переустройство
    /// 2 - перепланировка
    /// 3 - переустройство и перепланировка
    /// </summary>
    public int ReplaningTypeId { get; set; }

    /// <summary>
    /// Жилое помещение занимается на основании
    /// 1 - право собственности
    /// 2 - договор найма
    /// 3 - договор аренды
    /// </summary>
    public int ReplaningPremisesReasonTypeId { get; set; }

    /// <summary>
    /// Дата начала производства ремонтно-строительных работ
    /// </summary>
    public string? ReconstructionWorkStartDate { get; set; }

    /// <summary>
    /// Дата конца производства ремонтно-строительных работ 
    /// </summary>
    public string? ReconstructionWorkEndDate { get; set; }

    /// <summary>
    /// Время начала ремонтно-строительных работ
    /// </summary>
    public string? ReconstructionWorkStartHour { get; set; }

    /// <summary>
    /// Время конца ремонтно-строительных работ
    /// </summary>
    public string? ReconstructionWorkEndHour { get; set; }

    /// <summary>
    /// Дни проведения ремонтно-строительных работ
    /// </summary>
    public string? ReconstructionWorkDaysName { get; set; }

    /// <summary>
    /// Дата договора социального найма
    /// </summary>
    public string? ReconstructionSocialContractDate { get; set; }

    /// <summary>
    /// Номер договора социального найма
    /// </summary>
    public string? ReconstructionSocialContractNumber { get; set; }

    /// <summary>
    /// Член семьи
    /// </summary>
    public class FamilyMember
    {
        /// <summary>
        /// Ф.И.О.
        /// </summary>
        public string? FullName { get; set; }

        /// <summary>
        /// Серия документа
        /// </summary>
        public string? DocumentSeries { get; set; }

        /// <summary>
        /// Номер документа
        /// </summary>
        public string? DocumentNumber { get; set; }

        /// <summary>
        /// Кем выдан документ
        /// </summary>
        public string? DocumentGivenBy { get; set; }

        /// <summary>
        /// Дата выдачи документа
        /// </summary>
        public string? DocumentGivenDate { get; set; }
    }

    /// <summary>
    /// Члены семьи
    /// </summary>
    public FamilyMember[] FamilyMembers { get; set; } = Array.Empty<FamilyMember>();

    public class AppliedDocument
    {
        /// <summary>
        /// Наименование документа
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Номер документа
        /// </summary>
        public string? Number { get; set; }

        /// <summary>
        /// Документ выдан
        /// </summary>
        public string? GivenBy { get; set; }

        /// <summary>
        /// Дата выдачи документа
        /// </summary>
        public string? GivenDate { get; set; }

        /// <summary>
        /// Кол-во листов
        /// </summary>
        public string? PagesAmount { get; set; }

        /// <summary>
        /// Тип документа
        /// 1 - подлинник
        /// 2 - нотариально заверенная копия
        /// </summary>
        public int TypeId { get; set; }
    }

    /// <summary>
    /// Прилагаемые документы
    /// </summary>
    public AppliedDocument[] AppliedDocumentList { get; set; } = Array.Empty<AppliedDocument>();
}
