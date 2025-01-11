namespace AisLogistics.App.Models.AdditionalForms.KBR.Federal;

/// <summary>
/// Заявление о государственной регистрации физического лица в качестве индивидуального предпринимателя
/// </summary>
public class R21001Model
{
    /// <summary>
    /// Фамилия
    /// </summary>
    public string LastName { get; set; } = null!;

    /// <summary>
    /// Имя
    /// </summary>
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// Отчество
    /// </summary>
    public string? MiddleName { get; set; }

    /// <summary>
    /// Фамилия по-латински
    /// </summary>
    public string LastNameLatin { get; set; } = null!;

    /// <summary>
    /// Имяя по-латински
    /// </summary>
    public string FirstNameLatin { get; set; } = null!;

    /// <summary>
    /// Отчествоя по-латински
    /// </summary>
    public string? MiddleNameLatin { get; set; }

    /// <summary>
    /// ИНН
    /// </summary>
    public string? INN { get; set; }

    /// <summary>
    /// Пол
    /// 1 - мужской
    /// 2 - женский
    /// </summary>
    public int Gender { get; set; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    public string? BirthDate { get; set; }

    /// <summary>
    /// Место рождения
    /// </summary>
    public string? BirthPlace { get; set; }

    /// <summary>
    /// Гражданство
    /// 1 - гражданин Российской Федерации
    /// 2 - иностранный гражданин
    /// 3 - лицо без гражданства
    /// </summary>
    public int CitizenShipTypeId { get; set; }

    /// <summary>
    /// Код страны гражданства иностранного гражданина, если CitizenShipTypeId = 2
    /// </summary>
    public string? CitizenShipCode { get; set; }

    #region Сведения о документе, удостоверяютем личность

    /// <summary>
    /// Вид документа (код)
    /// </summary>
    public string? DocumentTypeCode { get; set; }

    /// <summary>
    /// Серия и номер документа
    /// </summary>
    public string? DocumentSeriesNumber { get; set; }

    /// <summary>
    /// Дата выдачи
    /// </summary>
    public string? DocumentGivenDate { get; set; }

    /// <summary>
    /// Кем выдан
    /// </summary>
    public string? DocumentGivenBy { get; set; }

    /// <summary>
    /// Код подразделения
    /// </summary>
    public string? DocumentDepartmentCode { get; set; }

    #endregion

    #region Адрес регистрации по месту жительства в Российской Федерации

    /// <summary>
    /// Код субъекта Российской Федерации
    /// </summary>
    public string? CodeSubjectRussianFederation { get; set; }

    /// <summary>
    /// Муниципальный тип
    /// 0 - не выбрано
    /// 1 - Муниципалъный район
    /// 2 - городской округ
    /// 3 - внутригородская территория города федерального значения
    /// 4 - муниципалънъій округ 
    /// 5 - федеральная территория
    /// </summary>
    public int MunicipalityTypeId { get; set; }

    /// <summary>
    /// Наименование муниципалитета
    /// </summary>
    public string? MunicipalityName { get; set; }

    /// <summary>
    /// Поселение
    /// 1 - Городское поселение
    /// 2 - сельское поселение 
    /// 3 - межселенная территория в составе муниципального района
    /// 4 - внутригородской район городского округа
    /// </summary>
    public int SettlementTypeId { get; set; }

    /// <summary>
    /// Наименование поселения
    /// </summary>
    public string? SettlementName { get; set; }

    /// <summary>
    /// Населенный пункт
    /// </summary>
    public string? LocalityType { get; set; }

    /// <summary>
    /// Наименование населенного пункта
    /// </summary>
    public string? LocalityName { get; set; }

    /// <summary>
    /// Элемент планировочной структуры (тип)
    /// </summary>
    public string? PlanningStructureElementType { get; set; }

    /// <summary>
    /// Элемент планировочной структуры (наименование)
    /// </summary>
    public string? PlanningStructureElementName { get; set; }

    /// <summary>
    /// Элемент улично-дорожной сети (тип)
    /// </summary>
    public string? RoadNetworkElementType { get; set; }

    /// <summary>
    /// Элемент улично-дорожной сети (наименование)
    /// </summary>
    public string? RoadNetworkElementName { get; set; }

    /// <summary>
    /// Здание / сооружение (тип)
    /// </summary>
    public string? BuildingType { get; set; }

    /// <summary>
    /// Здание / сооружение (номер)
    /// </summary>
    public string? BuildingNumber { get; set; }

    /// <summary>
    /// Помещение в пределах здания, сооружения (тип)
    /// </summary>
    public string? ApartmentsType { get; set; }

    /// <summary>
    /// Помещение в пределах здания, сооружения (номер)
    /// </summary>
    public string? ApartmentsNumber { get; set; }

    /// <summary>
    /// Помещение в пределах квартиры (тип)
    /// </summary>
    public string? RoomType { get; set; }

    /// <summary>
    /// Помещение в пределах квартиры (номер)
    /// </summary>
    public string? RoomNumber { get; set; }

    #endregion

    #region Сведения о документе, подтверждающем право иностранного гражданина или лица без гражданства временно или постоянно проживать на территории Российской Федерации

    /// <summary>
    /// Тип документа:
    /// 1 - вид на жительство
    /// 2 - разрешение на временное проживание 
    /// </summary>
    public int ForeignDocumentTypeId { get; set; }

    /// <summary>
    /// Номер документа
    /// </summary>
    public string? ForeignDocumentNumber { get; set; }

    /// <summary>
    /// Дата выдачи
    /// </summary>
    public string? ForeignDocumentGivenDate { get; set; }

    /// <summary>
    /// Кем выдан
    /// </summary>
    public string? ForeignDocumentGivenBy { get; set; }

    /// <summary>
    /// Срок действия:
    /// 1 - бессрочно
    /// 2 - до
    /// </summary>
    public int ForeignDocumentValidityTypeId { get; set; }

    /// <summary>
    /// Дата срока действия документа, если ForeignDocumentValidityTypeId = 2
    /// </summary>
    public string? ForeignDocumentValidityDate { get; set; }

    #endregion

    /// <summary>
    /// Адрес электронной почты индивидуального предпринимателя
    /// </summary>
    public string? IndividualEntrepreneurEMail { get; set; }

    /// <summary>
    /// Индивидуальный предприниматель является главой крестьянского (фермерского) хозяйства в соответствии 
    /// со статьей 23 Гражданского кодекса Российской Федерации
    /// </summary>
    public bool IndividualEntrepreneurFarmHoldingHead { get; set; }

    /// <summary>
    /// Код основного вида деятельности
    /// </summary>
    public string? MainActivityCode { get; set; }

    /// <summary>
    /// Код дополнительного вида деятельности
    /// </summary>
    public class AdditionalActivityCodeModel
    {
        public string? Code { get; set; }
    }

    /// <summary>
    /// Коды дополнительных видов деятельности
    /// </summary>
    public AdditionalActivityCodeModel[] AdditionalActivityCodesList { get; set; } = Array.Empty<AdditionalActivityCodeModel>();

    /// <summary>
    /// Документы, свзянные с предоставлением государственной услуги:
    /// 1 - направить по e-mail
    /// 2 - выдать на бумажном носителе
    /// </summary>
    public int DocumentSendingTypeId { get; set; }

    /// <summary>
    /// Адрес электронной почты, если выбран DocumentSendingTypeId = 1
    /// </summary>
    public string? DocumentSendingEmail { get; set; }

    /// <summary>
    /// Телефон заявителя
    /// </summary>
    public string? ApplicantPhone { get; set; }

    /// <summary>
    /// Заявление представлено непосредственно заявителем:
    /// 1 - в регистрирующий орган
    /// 2 - в многофункциональный центр
    /// </summary>
    public int ApplicationProvidedTypeId { get; set; }

    /// <summary>
    /// Лицо, засвидетельствовавшее подлинность подписи заявителя:
    /// 1 - нотариус
    /// 2 - лицо, замещающее временно отсутствующего нотариуса
    /// 3 - должностное лицо, уполномоченное на совершение нотариального действия
    /// </summary>
    public int PersonAuthenticatedSignatureTypeId { get; set; }

    /// <summary>
    /// ИНН лица, засвидетелъствовавтего подлинность подписи заявителя
    /// </summary>
    public string? PersonAuthenticatedSignatureINN { get; set; }
}
