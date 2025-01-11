namespace AisLogistics.App.Models;

/// <summary>
/// Внесение в ЕГРЮЛ сведений о том, что юридическое лицо находится в процессе реорганизации
/// </summary>
public class _7_UFNS_P12003Model
{
    /// <summary>
    /// Причина представления уведомления: 
    /// </summary>
    public string NotificationReasonTypeId { get; set; }

    /// <summary>
    /// Форма реорганизации 
    /// </summary>
    public string ReorganizationFormTypeId { get; set; }
     
    /// <summary>
    /// ОГРН
    /// </summary>
    public string LegalEntityOGRN { get; set; }

    /// <summary>
    /// ИНН
    /// </summary>
    public string LegalEntityINN { get; set; }
      
    /// <summary>
    /// Сведения о состоянии юридического лица после заверения реорганизации 
    /// </summary>
    public string LegalEntityReorganizationStatusTypeId { get; set; }
      
    /// <summary>
    /// ГРН
    /// </summary>
    public string LegalEntityGRN { get; set; }
      
    /// <summary>
    /// Доступ к сведениям о том, что юридическое лицо находится в процессе реорганизации 
    /// </summary>
    public string LegalEntityReorganizationStatusAccessTypeId { get; set; } 
      
    /// <summary>
    /// 2.	Заявителем является: 
    /// </summary>
    public string ApplicantTypeId { get; set; }
       
    /// <summary>
    /// Документы, связанные с предоставлением государственной услуги по государственной регистрации юридического лица: 
    /// </summary>
    public  bool DocumentSendingTypeId { get; set; }

    /// <summary>
    /// Адрес электронной почты, если выбран DocumentSendingTypeId = 1
    /// </summary>
    public string DocumentSendingEmail { get; set; }
       
    /// <summary>
    /// Лицо, засвидетельствовавшее подлинность подписи заявителя: 
    /// </summary>
    public string PersonAuthenticatedSignatureTypeId { get; set; }

    /// <summary>
    /// ИНН лица, засвидетельствовавшего подлинность подписи заявителя
    /// </summary>
    public string PersonAuthenticatedSignatureINN { get; set; }
}
