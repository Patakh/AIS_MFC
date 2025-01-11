namespace AisLogistics.App.Models;

/// <summary>
/// Выдача архивных справок о трудовом стаже и заработной плате
/// </summary>
public class _210_ArchivalDocumentsWorkExperienceModel : AbstractAdditionalFormModel
{
    /// <summary>
    /// ФИО начальника управления
    /// </summary>
    public string HeadName { get; set; }

    /// <summary>
    /// если менялась фамилия - указать
    /// </summary>
    public string LastName { get; set; }

    /// <summary> 
    ///  Дата рождения детей (для женщин)
    /// </summary>
    public Child[] ChildList { get; set; } = Array.Empty<Child>();

    public class Child
    {
        public DateTime? BirthsDate { get; set; }
    }

    /// <summary>
    /// Название организации (в период работы)
    /// </summary>
    public string OrgaizationName { get; set; }

    /// <summary>
    /// Прошу дать справку о трудовом стаже за период с
    /// </summary>
    public string WorkExperiencePeriodStartDate { get; set; }
     
    /// <summary>
    /// Прошу дать справку о трудовом стаже за период по
    /// </summary>
    public string WorkExperiencePeriodStopDate { get; set; }

    /// <summary>
    /// Прошу дать справку о заработной плате за период с
    /// </summary>
    public string SalaryPeriodStartDate { get; set; }

    /// <summary>
    /// Прошу дать справку о заработной плате за период по
    /// </summary>
    public string SalaryPeriodStopDate { get; set; }
}
