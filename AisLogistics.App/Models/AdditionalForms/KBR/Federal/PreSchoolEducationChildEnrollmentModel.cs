namespace AisLogistics.App.Models.AdditionalForms.KBR.Federal;

/// <summary>
/// Приём заявлений, постановка на учет и зачисление детей в государственные образовательные учреждения, 
/// реализующие основную образовательную программу дошкольного образования
/// </summary>
public class PreSchoolEducationChildEnrollmentModel
{
    /// <summary>
    /// Ф.И.О. ребенка
    /// </summary>
    public string ChildFullName { get; set; } = null!;

    /// <summary>
    /// Дата рождения ребенка
    /// </summary>
    public string ChildBirthDate { get; set; } = null!;

    /// <summary>
    /// Наименование образовательного учреждения
    /// </summary>
    public string? EducationalOrganizationName { get; set; }

    /// <summary>
    /// Желательный срок начала
    /// </summary>
    public string? StartDate { get; set; }

    /// <summary>
    /// Группа посещения
    /// </summary>
    public string? Group { get; set; }
}
