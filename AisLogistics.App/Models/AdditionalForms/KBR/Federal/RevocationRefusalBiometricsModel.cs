namespace AisLogistics.App.Models.AdditionalForms.KBR.Federal;

/// <summary>
/// ОТЗЫВ ОТКАЗА от сбора и размещения биометрических персональных данных
/// </summary>
public class RevocationRefusalBiometricsModel
{
    /// <summary>
    /// Тип биометрических персональных данных 
    /// 1 - своих
    /// 2 - несовершеннолетнего
    /// 3 - недееспособного
    /// 4 - ограниченно дееспособного
    /// </summary>
    public int BiometricDataTypeId { get; set; }

    #region Сведения о человеке, в отношении которого представляется настоящий отзыв отказа (п-ты 2,3,4)

    /// <summary>
    /// Ф.И.О.
    /// </summary>
    public string? PersonFullName { get; set; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    public string? PersonBirthDate { get; set; }

    #region документ, удостоверяющий личность

    /// <summary>
    /// Вид документа
    /// </summary>
    public string? PersonDocumentType { get; set; }

    /// <summary>
    /// Серия
    /// </summary>
    public string? PersonDocumentSeries { get; set; }

    /// <summary>
    /// Номер
    /// </summary>
    public string? PersonDocumentNumber { get; set; }

    /// <summary>
    /// Дата выдачи
    /// </summary>
    public string? PersonDocumentGivenDate { get; set; }

    /// <summary>
    /// Кем выдан
    /// </summary>
    public string? PersonDocumentGivenBy { get; set ; }

    #endregion

    /// <summary>
    /// ИНН
    /// </summary>
    public string? INN { get; set; }

    #endregion

    /// <summary>
    /// Вид документа законного представителя
    /// </summary>
    public string? AgentDocumentType { get; set; }

    /// <summary>
    /// Серия и номер документа законного представителя
    /// </summary>
    public string? AgentDocumentSeriesNumber { get; set; }

    /// <summary>
    /// Когда выдан документ законного представителя
    /// </summary>
    public string? AgentDocumentGivenDate { get; set; }

    /// <summary>
    /// Кем выдан документ законного представителя
    /// </summary>
    public string? AgentDocumentGivenBy { get; set; }
}
