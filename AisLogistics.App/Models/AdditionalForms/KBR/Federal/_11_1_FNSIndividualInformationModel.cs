using AisLogistics.App.Models.AdditionalForms; 

namespace AisLogistics.App.Models;

/// <summary>
/// Индивидуальное информирование на основании запросов в устной форм
/// </summary>
public class _11_1_FNSIndividualInformationModel : AbstractAdditionalFormModel
{
    /// <summary>
    /// тема запроса
    /// </summary>
    public string SubjectRequest { get; set; }

    /// <summary>
    /// Вопрос
    /// </summary>
    public string Question { get; set; }

    /// <summary>
    /// способ получения ответа
    /// </summary>
    public string ResponseType { get; set; }
}