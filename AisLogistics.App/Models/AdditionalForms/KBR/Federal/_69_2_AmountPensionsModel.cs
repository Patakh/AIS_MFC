using AisLogistics.App.Models.AdditionalForms;

namespace AisLogistics.App.Models;

/// <summary>
/// Выдача гражданам справок о размере пенсий (иных выплат)
/// Получение сведений о размере пенсии и доплат, устанавливаемых к пенсии, застрахованного лица на дату
/// </summary>
public class _69_2_AmountPensionsModel : AbstractAdditionalFormModel
{
    /// <summary>
    /// Дата
    /// </summary>
    public string DateFor { get; set; }
}