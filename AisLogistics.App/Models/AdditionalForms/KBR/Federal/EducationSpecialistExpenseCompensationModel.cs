namespace AisLogistics.App.Models.AdditionalForms.KBR.Federal;

/// <summary>
/// Ежемесячная компенсации расходов на оплату жилых помещений, специалистам образовательных учреждений, 
/// проживающим и работающим в сельских населенных пунктах КБР
/// </summary>
public class EducationSpecialistExpenseCompensationModel
{
    /// <summary>
    /// Тип специалиста
    /// 1 - специалист образовательных организаций
    /// 2 - специалист пенсионер
    /// </summary>
    public int SpecialistTypeId { get; set; }

    /// <summary>
    /// Способ доставки ежемесячной  компенсации
    /// 1 - Почта России
    /// 2 - Кредитная организация
    /// </summary>
    public int CompensationDeliveryTypeId { get; set; }

    /// <summary>
    /// Наименование кредитной организации, если CompensationDeliveryTypeId=2
    /// </summary>
    public string? CreditOrganizationName { get; set; }

    /// <summary>
    /// № лицевого счета, если CompensationDeliveryTypeId=2
    /// </summary>
    public string? CreditOrganizationAccount { get; set; }

    /// <summary>
    /// Уведомление о результате предоставления государственной услуги направить
    /// 1 - Почтовый адрес
    /// 2 - Электронный адрес
    /// 3 - Единый портал государственных и муниципальных услуг
    /// </summary>
    public int ReceiveResultMethodId { get; set; }

    /// <summary>
    /// Адрес эл. почты, если ReceiveResultMethodId=2
    /// </summary>
    public string? EMail { get; set; }

    /// <summary>
    /// Прилагаемые документы
    /// </summary>
    public string[] AppliedDocuments { get; set; } = Array.Empty<string>();
}
