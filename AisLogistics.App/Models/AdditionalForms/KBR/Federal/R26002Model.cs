namespace AisLogistics.App.Models.AdditionalForms.KBR.Federal;

/// <summary>
/// Заявление о государственной регистрации прекращения физическим лицом деятельности
/// в качестве индивидуального предпринимателя (Форма № P26002)
/// </summary>
public class R26002Model
{
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
