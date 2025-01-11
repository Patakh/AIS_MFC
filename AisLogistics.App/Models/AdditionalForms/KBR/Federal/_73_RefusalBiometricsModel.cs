namespace AisLogistics.App.Models;

/// <summary>
/// Отказ от сбора биометрии
/// </summary>
public class _73_RefusalBiometricsModel
{
    /// <summary>
    /// Тип заявления
    /// </summary>
    public string AppealType { get; set; }

    /// <summary>
    /// Тип биометрических персональных данных  
    /// </summary>
    public string BiometricDataTypeId { get; set; }
     
    /// <summary>
    /// Ф.И.О.
    /// </summary>
    public string PersonFullName { get; set; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    public string  PersonBirthDate { get; set; }
     
    /// <summary>
    /// Вид документа
    /// </summary>
    public string PersonDocumentType { get; set; }

    /// <summary>
    /// Серия
    /// </summary>
    public string PersonDocumentSeries { get; set; }

    /// <summary>
    /// Номер
    /// </summary>
    public string PersonDocumentNumber { get; set; }

    /// <summary>
    /// Дата выдачи
    /// </summary>
    public string PersonDocumentGivenDate { get; set; }

    /// <summary>
    /// Кем выдан
    /// </summary>
    public string PersonDocumentGivenBy { get; set; }
     
    /// <summary>
    /// ИНН
    /// </summary>
    public string INN { get; set; }
      
    /// <summary>
    /// Вид документа законного представителя
    /// </summary>
    public string AgentDocumentType { get; set; }

    /// <summary>
    /// Серия и номер документа законного представителя
    /// </summary>
    public string AgentDocumentSeriesNumber { get; set; }

    /// <summary>
    /// Когда выдан документ законного представителя
    /// </summary>
    public string AgentDocumentGivenDate { get; set; }

    /// <summary>
    /// Кем выдан документ законного представителя
    /// </summary>
    public string AgentDocumentGivenBy { get; set; }
}