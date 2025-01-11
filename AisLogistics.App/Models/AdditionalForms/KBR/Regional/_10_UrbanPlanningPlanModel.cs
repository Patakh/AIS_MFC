namespace AisLogistics.App.Models;

/// <summary>
/// Предоставление градостроительного плана земельного участка
/// </summary>
public class _10_UrbanPlanningPlanModel : AbstractAdditionalFormModel
{
    /// <summary>
    /// адрес земельного участка
    /// </summary>
    public string LandPlotAddress { get; set; }

    /// <summary>
    /// Вид права, на котором используется земельный участок  (собственность или аренда, постоянное (бессрочное) пользование и др.)
    /// </summary>
    public string LandPlotLegalType { get; set; }

    /// <summary>
    /// реквизиты документа, удостоверяющего право, на котором заявитель использует земельный участок
    /// </summary>
    public string LandPlotRekrizits { get; set; }

    /// <summary>
    /// Площадь земельного участка
    /// </summary>
    public string LandPlotArrea { get; set; }

    /// <summary>
    /// Кадастровый номер земельного участка
    /// </summary>
    public string LandPlotKadastrNumber { get; set; }

    /// <summary>
    /// Результат предоставления  (вручить лично, направить по месту фактического проживания (месту нахождения) в форме документа на бумажном носителе)
    /// </summary>
    public string Response { get; set; } 
}
