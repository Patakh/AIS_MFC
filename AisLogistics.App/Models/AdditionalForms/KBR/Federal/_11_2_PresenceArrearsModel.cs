using AisLogistics.App.Models.AdditionalForms; 

namespace AisLogistics.App.Models;

/// <summary>
/// Прием согласия налогоплательщика, плательщика сбора, плательщика страховых взносов, налогового агента на информирование о наличии недоимки и (или) задолженности по пеням, штрафам, процентам.
/// </summary>
public class _11_2_PresenceArrearsModel : AbstractAdditionalFormModel
{
    /// <summary>
    /// выдать справку
    /// </summary>
    public string Certificate { get; set; }

    /// <summary>
    /// по состоянию на
    /// </summary>
    public string OnDate { get; set; }

    /// <summary>
    /// способ получения ответа
    /// </summary>
    public string ResponseType { get; set; }
     
    /// <summary>
    /// способ получения ответа
    /// </summary>
    public string ResponsePostalAddress { get; set; }
}