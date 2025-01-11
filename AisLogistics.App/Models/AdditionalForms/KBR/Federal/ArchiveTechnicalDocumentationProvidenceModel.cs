namespace AisLogistics.App.Models.AdditionalForms.KBR.Federal;

/// <summary>
/// Заявление о предоставлении копий учетно-технической документации и/или содержащихся в ней сведений
/// </summary>
public class ArchiveTechnicalDocumentationProvidenceModel
{
    /// <summary>
    /// Наименование документа
    /// </summary>
    public string DocumentName { get; set; } = null!;

    /// <summary>
    /// Объект недвижимости
    /// </summary>
    public string RealtyObject { get; set; } = null!;

    /// <summary>
    /// Приложение
    /// </summary>
    public string Application { get; set; } = null!;
}
