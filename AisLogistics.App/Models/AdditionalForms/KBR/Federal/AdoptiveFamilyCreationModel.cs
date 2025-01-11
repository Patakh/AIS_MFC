namespace AisLogistics.App.Models.AdditionalForms.KBR.Federal;

/// <summary>
/// Создание приемной семьи
/// </summary>
public class AdoptiveFamilyCreationModel
{
    /// <summary>
    /// Тип заявления
    /// 1 - заключение о возможности быть опекуном(попечителем)
    /// 2 - заключение о возможности быть приемным родителем
    /// 3 - передать под опеку(попечительство)
    /// 4 - передать под опеку(попечительство) на возмездной основе
    /// </summary>
    public int AdoptionTypeId { get; set; }

    /// <summary>
    /// Ребенок
    /// </summary>
    public class Child
    {
        /// <summary>
        /// Фамилия
        /// </summary>
        public string? FullName { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public string? BirthDate { get; set; }
    }

    /// <summary>
    /// Дети
    /// </summary>
    public Child[] Children { get; set; } = Array.Empty<Child>();

    /// <summary>
    /// Дополнительные свдения об опекуне(попечителе)
    /// </summary>
    public string? AdditionalInformation { get; set; }

    /// <summary>
    /// Человек, кот отдает ребенка под опеку???
    /// </summary>
    public string? OtherPersonFullName { get; set; }

    /// <summary>
    /// Стпень родства человека
    /// </summary>
    public string? OtherPersonKinship { get; set; }
}
