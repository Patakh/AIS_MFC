namespace AisLogistics.App.Models.AdditionalForms.KBR.Federal;

public class UnregisterDeadModel
{
    /// <summary>
    /// Адрес
    /// </summary>
    public string Address { get; set; } = null!;

    /// <summary>
    /// Тип умершего родственника
    /// </summary>
    public string? RelativeType { get; set; }

    /// <summary>
    /// Ф.И.О. усопшего
    /// </summary>
    public string DeadFullName { get; set; } = null!;
}
