namespace AisLogistics.App.Models;

/// <summary>
/// Прием заявления о гибели или уничтожении объекта налогообложения по транспортному налогу
/// </summary>
public sealed class _21_FnsKnd1150076Model : AbstractAdditionalFormModel
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
    /// Сведения об объекте налогообложения, в отношении которого представляется заявление
    /// </summary>
    public VehicleType Vehicle { get; set; }
}
