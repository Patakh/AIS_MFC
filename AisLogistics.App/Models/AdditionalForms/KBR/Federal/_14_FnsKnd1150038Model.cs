namespace AisLogistics.App.Models;

/// <summary>
/// Приём уведомления о выбранном земельном участке, в отношении которого применяется налоговый вычет по земельному налогу
/// </summary>
public sealed class _14_FnsKnd1150038Model : AbstractAdditionalFormModel
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
    /// Кадастровый номер земельного участка
    /// </summary>
    public string  KadastrNumber { get; set; }
}
