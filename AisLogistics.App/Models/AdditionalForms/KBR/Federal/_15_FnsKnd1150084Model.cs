namespace AisLogistics.App.Models;

/// <summary>
/// Приём заявления о выдаче налогового уведомления
/// </summary>
public sealed class _15_FnsKnd1150084Model : AbstractAdditionalFormModel
{ 
    /// <summary>
    /// Код налогового органа
    /// </summary>
    public string CodeFNS { get; set; }

    /// <summary>       
    /// Способ информирования
    /// </summary>
    public string MethodInforming { get; set; }

    /// <summary>       
    /// налоговый период
    /// </summary>
    public string PeriodYear { get; set; }
}
