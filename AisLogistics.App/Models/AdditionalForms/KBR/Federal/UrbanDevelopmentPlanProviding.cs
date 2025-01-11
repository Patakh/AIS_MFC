namespace AisLogistics.App.Models.AdditionalForms.KBR.Federal;

/// <summary>
/// Предоставление градостроительного плана земельного участка
/// </summary>
public class UrbanDevelopmentPlanProvidingModel
{
    /// <summary>
    /// Адрес земельного участка
    /// </summary>
    public string LandPlotAddress { get; set; } = null!;

    /// <summary>
    /// Вид права, на котором используется земельный участок
    /// </summary>
    public string LandPlotLawType { get; set; } = null!;

    /// <summary>
    /// реквизиты документа, удостоверяющего право, на котором заявитель использует земельный участок
    /// </summary>
    public string? DocumentRequisites { get; set; }

    /// <summary>
    /// Площадь земельного участка
    /// </summary>
    public float LandPlotSquare { get; set; }

    /// <summary>
    /// Кадастровый номер земельного участка 
    /// </summary>
    public string? LandPlotCadastralNumber { get; set; }

    /// <summary>
    /// Результат предоставления муниципальной услуги
    /// 1 - вручить лично
    /// 2 - направить по месту фактического проживания (месту нахождения) в форме документа на бумажном носителе
    /// </summary>
    public int ResultProvidingTypeId { get; set; }
}
