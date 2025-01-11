namespace AisLogistics.App.Models;

/// <summary>
/// Выдача и аннулирование охотничьего билета единого федерального образца в Кабардино-Балкарской Республике
/// </summary>
public class _9_HuntingTicketCancelModel
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
    /// серия охотничьего билета
    /// </summary>
    public string HuntingTicketSeries { get; set; }

    /// <summary>
    ///  номер охотничьего билета
    /// </summary>
    public string HuntingTicketNumber { get; set; }

    /// <summary>
    /// (обстоятельства, послужившие основанием аннулирования
    /// </summary>
    public string Reason { get; set; }
}
