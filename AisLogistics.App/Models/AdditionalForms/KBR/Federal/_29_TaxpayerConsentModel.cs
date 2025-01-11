using AisLogistics.App.Models.AdditionalForms; 

namespace AisLogistics.App.Models;

/// <summary>
/// Прием согласия налогоплательщика, плательщика сбора, плательщика страховых взносов, налогового агента на информирование о наличии недоимки и (или) задолженности по пеням, штрафам, процентам.
/// </summary>
public class _29_TaxpayerConsentModel : AbstractAdditionalFormModel
{
    /// <summary>
    /// КПП
    /// </summary>
    public string KPP { get; set; }

    /// <summary>
    /// Код налогового органа
    /// </summary>
    public string CodeFNS { get; set; }

    /// <summary>
    /// Налогоплательщик
    /// </summary>
    public string PleaseStopPayment  { get; set; }

    /// <summary>
    /// ФИО
    /// </summary>
    public string F  { get; set; }

    /// <summary>
    /// ФИО
    /// </summary>
    public string I  { get; set; }

    /// <summary>
    /// ФИО
    /// </summary>
    public string O  { get; set; }

    /// <summary>
    /// Наименование документа
    /// </summary>
    public string AuthorityDocName { get; set; }

    /// <summary>
    /// Серия, номер
    /// </summary>
    public string AuthorityDocSeriesNumber { get; set; }

    /// <summary>
    /// Дата выдачи
    /// </summary>
    public string AuthorityDocIssueDate { get; set; }

}