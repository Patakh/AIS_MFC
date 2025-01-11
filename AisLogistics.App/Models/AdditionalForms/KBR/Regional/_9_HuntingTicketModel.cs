namespace AisLogistics.App.Models;

/// <summary>
/// Выдача и аннулирование охотничьего билета единого федерального образца в Кабардино-Балкарской Республике
/// </summary>
public class _9_HuntingTicketModel
{
    /// <summary>
    /// Место рождения гор. 
    /// </summary>
    public string BirthsTown { get; set; }

    /// <summary>
    /// Место работы
    /// </summary>
    public string PlaceWork { get; set; }

    /// <summary>
    /// Должность
    /// </summary>
    public string Post { get; set; }

    /// <summary>
    /// наименование организации
    /// </summary>
    public string OrganizationName { get; set; }

    /// <summary>
    /// серия охотничьего билета
    /// </summary>
    public string HuntingTicketSeries { get; set; }

    /// <summary>
    ///  номер охотничьего билета
    /// </summary>
    public string HuntingTicketNumber { get; set; }

    /// <summary>
    ///  дата выдачи охотничьего билета
    /// </summary>
    public string HuntingTicketIsueDate { get; set; }

    /// <summary>
    ///  вид и калибр оружия
    /// </summary>
    public string WeaponsType { get; set; }

    /// <summary>
    ///  серия и номер оружия
    /// </summary>
    public string WeaponsSeriesNumber { get; set; }

    /// <summary>
    /// номер разрешения на право хранения и ношения оружия
    /// </summary>
    public string RightNumber { get; set; }

    /// <summary>
    /// кем и когда выдано указанное разрешение
    /// </summary>
    public string RightIssuer { get; set; }

    /// <summary>
    /// кем и когда выдано указанное разрешение
    /// </summary>
    public string RightIssuerDate { get; set; }

}
