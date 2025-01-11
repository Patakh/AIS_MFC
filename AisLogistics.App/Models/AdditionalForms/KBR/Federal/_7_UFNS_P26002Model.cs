using AisLogistics.App.Models.AdditionalForms; 

namespace AisLogistics.App.Models;

/// <summary>
/// Государственная регистрация юридических лиц, физических лиц в качестве индивидуальных предпринимателей и крестьянских (фермерских) хозяйств
/// - Государственная регистрация прекращения крестьянского (фермерского) хозяйства
/// </summary>
public class _7_UFNS_P26002Model : AbstractAdditionalFormModel
{
    /// <summary>
    /// ОГРНИП
    /// </summary>
    public string OGRNIP { get; set; }

    /// <summary>
    /// Эл. почта для отправки документов
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// выдать на бумажном носителе
    /// </summary>
    public bool IssuePaper { get; set; }

    /// <summary>
    /// Место предоставления заявление заявителем
    /// </summary>
    public string PlaceAppeal { get; set; }

    /// <summary>
    /// Засвидетельствовавшее лицо
    /// </summary>
    public string Witness { get; set; }

    /// <summary>
    /// ИНН засвидетельствовавшего лица
    /// </summary>
    public string WitnessINN { get; set; } 
}