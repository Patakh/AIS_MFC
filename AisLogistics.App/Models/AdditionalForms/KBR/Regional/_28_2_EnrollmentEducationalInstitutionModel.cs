namespace AisLogistics.App.Models;

/// <summary>
/// Зачисление в образовательное учреждение 1 класс
/// </summary>
public class _28_2_EnrollmentEducationalInstitutionModel
{
    /// <summary>
    /// Руководитель (Ф.И.О.)
    /// </summary>
    public string ShefFIO { get; set; }

    /// <summary>
    ///  наименование общеобразовательного учреждения
    /// </summary>
    public string MOUNumber { get; set; }

    /// <summary>
    /// ребенок (Ф.И.О.)
    /// </summary>
    public string ChildFIO { get; set; }

    /// <summary>
    /// ребенок дата рождения
    /// </summary>
    public string ChildBirdsDate { get; set; } 
}
