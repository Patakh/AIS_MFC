namespace AisLogistics.App.Models;

/// <summary>
/// Утверждение схемы расположения земельного участка на кадастровом плане территории
/// </summary>
public class _132_LocationLandPlotModel : AbstractAdditionalFormModel
{
    /// <summary>
    /// адрес земельного участка
    /// </summary>
    public string LandPlotAddress { get; set; }

    /// <summary>
    /// Площадь земельного участка
    /// </summary>
    public string LandPlotArrea { get; set; }

    /// <summary>
    /// Кадастровый номер земельного участка
    /// </summary>
    public string LandPlotKadastrNumber { get; set; }

    /// <summary>
    /// основание предоставления земельного участка без проведения торгов
    /// </summary>
    public string Rason { get; set; }

    /// <summary>
    /// Вид права, на котором используется земельный участок  (собственность или аренда, постоянное (бессрочное) пользование и др.)
    /// </summary>
    public string LandPlotLegalType { get; set; }

    /// <summary>
    /// цель использования земельного участка
    /// </summary>
    public string Target { get; set; }
}
