namespace AisLogistics.App.Models.AdditionalForms.KBR.Federal;

/// <summary>
/// Заявление о внесении в Единый государственный реестр юридических лиц записи о прекращении
/// унитарного предприятия, государственного или муниципального учреждения
/// </summary>
public class R16002Model
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
    /// 2.	Основание прекращения:
    /// Для унитарного предприятия
    /// 1 - продажа имущественного комплекса
    /// 2 - внесение имущественного комплекса в уставный капитал акционерного общества
    /// 3 - передача имущественного комплекса в собственность государственной корпорации
    /// Для государственного или муниципалъного учреждения
    /// 4 - внесение имущества в уставный капитал акционерного общества
    /// 5 - передача имущества в собственность государственной корпорации
    /// </summary>
    public int TerminationReasonTypeId { get; set; }

    #region 3. Сведения о заявителе

    /// <summary>
    /// Заявителем является:
    /// 1 - представителъ уполномоченного федералъного органа исполнителъной власти
    /// 2 - представителъ уполномоченного органа субъекта Российской Федерации
    /// 3 - представителъ уполномоченного органа муниципалъного образования
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
