using AisLogistics.App.Models.AdditionalForms;

namespace AisLogistics.App.Models;

/// <summary>
/// Выдача гражданам справок о размере пенсий (иных выплат)
/// Получение сведений о размере пенсии и доплат, устанавливаемых к пенсии, застрахованного лица за период
/// </summary>
public class _69_1_AmountPensionsModel : AbstractAdditionalFormModel
{   
    /// <summary>
    /// Начало периода
    /// </summary>
    public string DateStart { get; set; }

    /// <summary>
    /// Окончание периода
    /// </summary>
    public string DateEnd { get; set; }
}