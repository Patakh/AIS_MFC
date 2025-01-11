namespace AisLogistics.App.Models.AdditionalForms.KBR.Federal;

/// <summary>
/// выезд на дом
/// </summary>
public class HomeVizitModel
{
    /// <summary>
    /// Оказываемая услуга
    /// </summary>
    public string ServiceName { get; set; } = null!;

    /// <summary>
    /// Выезд по адресу
    /// </summary>
    public string Address { get; set; } = null!;

    /// <summary>
    /// Причина выезда к клиенту
    /// </summary>
    public string ClientVizitReason { get; set; } = null!;

    /// <summary>
    /// Подтверждающий документ
    /// </summary>
    public string? DocumentRequsites { get; set; }
}
