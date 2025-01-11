namespace AisLogistics.App.Models.AdditionalForms.KBR.Federal;

/// <summary>
/// Заявление на получение охотничего билета
/// </summary>
public class HuntingLicenseModel
{
    /// <summary>
    /// Ранее состоял на учете в
    /// </summary>
    public string? BeforeRegisteredBy { get; set; }

    #region охотничье оружие

    /// <summary>
    /// Вид охотничего оружия
    /// </summary>
    public string? HuntingWeaponTypeName { get; set; }

    /// <summary>
    /// Калибр оружия
    /// </summary>
    public string? HuntingWeaponCaliber { get; set; }

    /// <summary>
    /// Серия оружия
    /// </summary>
    public string? HuntingWeaponSeries { get; set; }

    /// <summary>
    /// Номер оружия
    /// </summary>
    public string? HuntingWeaponNumber { get; set; }

    #endregion

    #region разрешения на право хранения и ношения оружия

    /// <summary>
    /// Номер разрешения 
    /// </summary>
    public string? WeaponLicenseNumber { get; set; }

    /// <summary>
    /// Разрешение выдано
    /// </summary>
    public string? WeaponLicenseGivenBy { get; set; }

    /// <summary>
    /// Дата выдачи разрешения
    /// </summary>
    public string? WeaponLicenseGivenDate { get; set; }

    #endregion
}
