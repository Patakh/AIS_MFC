namespace AisLogistics.App.Models;

/// <summary>
/// Выдача копии технической документации
/// </summary>
public class _33_TechnicalDocumentationModel
{
    /// <summary>
    ///  Прошу выдать:
    /// </summary>
    public string? Service { get; set; }

    /// <summary>
    /// На объект недвижимости:
    /// </summary>
    public string? Object { get; set; }

    /// <summary>
    /// Адрес объекта недвижимости
    /// </summary>
    public string? ObjectAddress { get; set; }

    /// <summary>
    /// Выдача документа
    /// </summary>
    public string DocumentIssuance {  get; set; }
    /// <summary>
    /// Наименование иного документа
    /// </summary>
    public string? OtherDocument {  get; set; }

}
