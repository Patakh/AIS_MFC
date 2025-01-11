namespace AisLogistics.App.Models;

/// <summary>
/// Выдача архивных справок, копий и выписок по тематике обращения
/// </summary>
public class _1_ArchiveInformationAppealModel
{
    /// <summary>
    /// Начальник архивного отдела местной администрации
    /// Фамилия 
    /// </summary>
    public string ChiefLastName { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    public string ChiefFirstName { get; set; }

    /// <summary>
    /// Отчество
    /// </summary>
    public string ChiefSecondName { get; set; }
    
    /// <summary>
    /// Прошу предоставить  архивную справку (архивную выписку, архивную копию)
    /// </summary>
    public string Request { get; set; }
}
