using AisLogistics.App.Models.AdditionalForms;

namespace AisLogistics.App.Models;

/// <summary>
/// Назначение и выплата социального пособия на погребение отдельных категорий граждан
/// </summary>
public class _6_BurialModel : AbstractAdditionalFormModel
{
    public _6_BurialModel()
    {
        AppliedDocumentList = new []
        {
            new AppliedDocument()
        };
    }

    /// <summary>
    /// ФИО умершего
    /// </summary>
    public string DeceasedFIO { get; set; }

    /// <summary>
    /// ФИО дата рождения 
    /// </summary>
    public string DeceasedBirthDate { get; set; }

    /// <summary>
    /// дата смерти
    /// </summary>
    public string DeathDate { get; set; }

    /// <summary>
    /// Приложенные документы
    /// </summary>
    public AppliedDocument[] AppliedDocumentList { get; set; }

    public class AppliedDocument
    {
        /// <summary>
        /// Наименование документа
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// кол экз.
        /// </summary>
        public string NumdberCopies { get; set; }

        /// <summary>
        /// кол стр.
        /// </summary>
        public string NumdberPages { get; set; }
    }
}
