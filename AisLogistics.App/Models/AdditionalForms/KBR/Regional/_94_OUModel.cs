namespace AisLogistics.App.Models;

/// <summary>
/// Приём заявлений, постановка на учет и зачисление детей в государственные образовательные учреждения, реализующие основную образовательную программу дошкольного образованияе 
/// </summary>
public class _94_OUModel
{
    /// <summary>
    /// Прошу зачислить моего(ю) сына(дочь)(Ф.И.О.)
    /// </summary>
    public string ChildFio { get; set; }

    /// <summary>
    ///  дата рождения
    /// </summary>
    public string BirthDate { get; set; }

    /// <summary>
    ///  группу посещения ОУ
    /// </summary>
    public string OU { get; set; }

    /// <summary>
    /// Указать желательный срок
    /// </summary>
    public string TimeStay { get; set; }
}
