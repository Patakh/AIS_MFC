using AisLogistics.App.Models.AdditionalForms; 

namespace AisLogistics.App.Models;

/// <summary>
/// Индивидуальное информирование на основании запросов в устной форм
/// </summary>
public class _9_FNSExtractsModel : AbstractAdditionalFormModel
{
    /// <summary>
    /// предмет запроса
    /// </summary>
    public string SubjectRequest { get; set; }

    /// <summary>
    /// в случае необходимости указать срочность
    /// </summary>
    public string Urgency { get; set; } 
}