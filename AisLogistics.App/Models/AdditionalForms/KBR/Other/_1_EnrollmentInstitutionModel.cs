namespace AisLogistics.App.Models;

/// <summary>
/// Осуществление приема заявлений на получение услуг с выездом специалистов на дом (для отдельных категорий граждан)
/// </summary>
public class _1_DepartureSpecialistsModel
{
    /// <summary>
    ///  Прошу Вас оказать указать:
    /// </summary>
    public string Service { get; set; }

    /// <summary>
    /// с выездом на дом по адресу:
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// ФИО клиента
    /// </summary>
    public string ClienteFIO { get; set; }

    /// <summary>
    ///  Причина
    /// </summary>
    public List<string> Reasons { get; set; }

    /// <summary>
    /// Наименование подтверждающего документа
    /// </summary>
    public string RightDocumentName { get; set; }
}
