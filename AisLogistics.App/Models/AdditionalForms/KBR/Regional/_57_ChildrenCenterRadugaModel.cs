namespace AisLogistics.App.Models;

/// <summary>
/// Заявление
/// О направлении на медико-социальную реабилитацию в ГКУ "Базовый
/// республиканский детский социально-реабилитационный центр "Радуга"
/// </summary>
public class _57_ChildrenCenterRadugaModel
{
    /// <summary>
    /// Дата начала заезда
    /// </summary>
    public string CheckInStartDate { get; set; }

    /// <summary>
    /// Дата конца заезда
    /// </summary>
    public string CheckInEndDate { get; set; }

    /// <summary>
    /// Дети
    /// </summary>
    public Child[] Children { get; set; }

    /// <summary>
    /// Прилагаемые документы
    /// </summary>
    public AppliedDocument[] AppliedDocuments { get; set; }

    /// <summary>
    /// Ребенок
    /// </summary>
    public class Child
    {
        /// <summary>
        /// Ф.И.О. ребенка
        /// </summary>
        public string FullName { get; set; } = null!;

        /// <summary>
        /// Дата рождения ребенка
        /// </summary>
        public string? BirthDate { get; set; }
    }

    public class AppliedDocument
    {
        /// <summary>
        /// Наименование документа
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Количество экземпляров
        /// </summary>
        public string PageAmount { get; set; }
    }
}
