namespace AisLogistics.App.Models.AdditionalForms.KBR.Federal;

/// <summary>
/// Заявление (уведомление) о ликвидации юридического лица
/// </summary>
public class R15016Model
{
    #region 1. Сведения о юридическом лице, содержатиеся в Едином государственном реестре юридических лиц 

    /// <summary>
    /// ОГРН
    /// </summary>
    public string? LegalEntityOGRN { get; set; }

    /// <summary>
    /// ИНН
    /// </summary>
    public string? LegalEntityINN { get; set; }

    #endregion

    /// <summary>
    /// Причина представления заявления (уведомления):
    /// 1 - принятие решения о ликвидации юридического лица
    /// 2 - формирование ликвидационной комиссии / назначение ликвидатора
    /// 3 - принятие решения о ликвидации юридического лица и формирование ликвидационной комиссии / назначение ликвидатора
    /// 4 - составление промежуточного ликвидационного баланса
    /// 5 - продление срока ликвидации общества с ограниченной ответственностью
    /// 6 - принятие решения об отмене ранее принятого решения о ликвидации юридического лица
    /// 7 - завершение ликвидации юридического лица
    /// </summary>
    public int NotificationReasonTypeId { get; set; }

    /// <summary>
    /// Срок ликвидации общества с ограниченной ответственностью, если NotificationReasonTypeId = 1, 3, 5
    /// </summary>
    public string? TerminationPeriod { get; set; }

    #region Сведения о лице, имеющем право без доверенности действовать от имени юридического лица

    #region 1. Сведения о российском юридическом лице

    /// <summary>
    /// ОГРН
    /// </summary>
    public string? ProxyLocalLegalEntityOGRN { get; set; }

    /// <summary>
    /// ИНН
    /// </summary>
    public string? ProxyLocalLegalEntityINN { get; set; }

    #endregion

    #region 2. Сведения об иностранном юридическом лице

    /// <summary>
    /// ИНН
    /// </summary>
    public string? ProxyForeignLegalEntityINN { get; set; }

    /// <summary>
    /// Номер записи об аккредитации (НЗА) в государственном реестре аккредитованных филиалов, представительств иностранных юридических лиц
    /// </summary>
    public string? ProxyForeignLegalEntityNZA { get; set; }

    #endregion

    #region 3. Сведения о физическом лице

    /// <summary>
    /// Фамилия
    /// </summary>
    public string ProxyLastName { get; set; } = null!;

    /// <summary>
    /// Имя
    /// </summary>
    public string ProxyFirstName { get; set; } = null!;

    /// <summary>
    /// Отчество
    /// </summary>
    public string? ProxyMiddleName { get; set; }

    /// <summary>
    /// ИНН
    /// </summary>
    public string? ProxyINN { get; set; }

    public int ProxyGender { get; set; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    public string? ProxyBirthDate { get; set; }

    /// <summary>
    /// Место рождения
    /// </summary>
    public string? ProxyBirthPlace { get; set; }

    /// <summary>
    /// Гражданство
    /// 1 - гражданин Российской Федерации
    /// 2 - иностранный гражданин
    /// 3 - лицо без гражданства
    /// </summary>
    public int ProxyCitizenShipTypeId { get; set; }

    /// <summary>
    /// Код страны гражданства, если ProxyCitizenShipTypeId - 2
    /// </summary>
    public string? ProxyCitizenShipCode { get; set; }

    #region Сведения о документе, удостоверяютем личность

    /// <summary>
    /// Вид документа (код)
    /// </summary>
    public string? ProxyDocumentTypeCode { get; set; }

    /// <summary>
    /// Серия и номер документа
    /// </summary>
    public string? ProxyDocumentSeriesNumber { get; set; }

    /// <summary>
    /// Дата вьдачи
    /// </summary>
    public string? ProxyDocumentGivenDate { get; set; }

    /// <summary>
    /// Кем вьдан
    /// </summary>
    public string? ProxyDocumentGivenBy { get; set; }

    /// <summary>
    /// Код подразделения
    /// </summary>
    public string? ProxyDocumentDepartmentCode { get; set; }

    /// <summary>
    /// Должность
    /// </summary>
    public string? ProxyDocumentPosition { get; set; }

    #endregion

    /// <summary>
    /// ОГРНИП (для управляющего)
    /// </summary>
    public string? OGRNIP { get; set; }

    /// <summary>
    /// Ограничение доступа к сведениям
    /// </summary>
    public bool RestrictAccess { get; set; }

    #endregion

    #endregion

    /// <summary>
    /// Обстоятелъства, которые являются основанием для ограничения доступа к сведениям о юридическом лице
    /// </summary>
    public string? RestrictAccessCircumstances { get; set; }


    #region Сведения о заявителе

    /// <summary>
    /// Заявителем является:
    /// 1 - лицо, действующее от имени юридического лица без доверенности
    /// 2 - лицо, действующее на основании полномочия, предусмотренного федеральным законом, актом специально уполномоченного 
    /// на то государственного органа или актом органа местного самоуправления
    /// </summary>
    public int ApplicantTypeId { get; set; }

    /// <summary>
    /// Фамилия
    /// </summary>
    public string ApplicantLastName { get; set; } = null!;

    /// <summary>
    /// Имя
    /// </summary>
    public string ApplicantFirstName { get; set; } = null!;

    /// <summary>
    /// Отчество
    /// </summary>
    public string? ApplicantMiddleName { get; set; }

    /// <summary>
    /// ИНН
    /// </summary>
    public string? ApplicantINN { get; set; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    public string? ApplicantBirthDate { get; set; }

    /// <summary>
    /// Место рождения
    /// </summary>
    public string? ApplicantBirthPlace { get; set; }

    #region Сведения о документе, удостоверяютем личность

    /// <summary>
    /// Вид документа (код)
    /// </summary>
    public string? ApplicantDocumentTypeCode { get; set; }

    /// <summary>
    /// Серия и номер документа
    /// </summary>
    public string? ApplicantDocumentSeriesNumber { get; set; }

    /// <summary>
    /// Дата вьдачи
    /// </summary>
    public string? ApplicantDocumentGivenDate { get; set; }

    /// <summary>
    /// Кем вьдан
    /// </summary>
    public string? ApplicantDocumentGivenBy { get; set; }

    /// <summary>
    /// Код подразделения
    /// </summary>
    public string? ApplicantDocumentDepartmentCode { get; set; }

    #endregion

    #endregion

    /// <summary>
    /// Документы, связанные с предоставлением государственной услуги по государственной регистрации юридического лица:
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
