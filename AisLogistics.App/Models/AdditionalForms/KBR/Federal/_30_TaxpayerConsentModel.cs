namespace AisLogistics.App.Models;

/// <summary>
/// Прием уведомления о переходе на упрощенную систему налогообложения.
/// </summary>
public class _30_TransitionSimplifiedTaxSystemModel : AbstractAdditionalFormModel
{ 
    /// <summary>
    /// Код налогового органа
    /// </summary>
    public string CodeFNS { get; set; }

    /// <summary>
    /// Признак налогоплательщика
    /// </summary>
    public string SignTaxpayer  { get; set; }

    /// <summary>
    /// переходит на упрощенную систему налогообложения
    /// </summary>
    public string Pass { get; set; }

    /// <summary>
    /// 1 - с 1 января 
    /// </summary>
    public string PassYear { get; set; }

    /// <summary>
    /// 3 - с 
    /// </summary>
    public string PassYearMonth{ get; set; }
    
    /// <summary>
    /// В качестве объекта налогообложение выбраны
    /// </summary>
    public string ObjectsTaxation { get; set; }

    /// <summary>
    /// Год подачи уведомления о переходе на упрощённую систему налогообложения
    /// </summary>
    public string YearNotification { get; set; }

    /// <summary>
    /// Получено доходов за девять месяцев года подачи уведомления
    /// </summary>
    public string ReceivedIncome  { get; set; }

    /// <summary>
    /// Остаточная стоимость основанных средств на 1 октября года подачи уведомления составляет
    /// </summary>
    public string ResidualValue  { get; set; }
}