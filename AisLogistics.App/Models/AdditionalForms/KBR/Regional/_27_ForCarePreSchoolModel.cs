using AisLogistics.App.Models.AdditionalForms;
namespace AisLogistics.App.Models;

/// <summary>
/// Компенсация части родительской платы за присмотр и уход за ребенком в образовательных организациях,
/// реализующих образовательную программу дошкольного образования в КБР
/// </summary>
public class _27_ForCarePreSchoolModel : AbstractAdditionalFormModel
{
    public _27_ForCarePreSchoolModel()
    {
        FamilyMembersList = new[]
         {
            new FamilyMembers()
        };

        AppliedDocumentList = new[]
       {
            new AppliedDocument()
        };
    }


    /// <summary>
    /// за период с
    /// </summary>
    public string Period { get; set; }
      
    /// <summary>
    /// Приложенные документы
    /// </summary>
    public AppliedDocument[] AppliedDocumentList { get; set; }

    /// <summary>
    /// Приложенные документы
    /// </summary>
    public FamilyMembers[] FamilyMembersList { get; set; }

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

    public class FamilyMembers
    {
        /// <summary>
        /// Ф.И.О.
        /// </summary>
        public string FIO { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public string BirthDate { get; set; }
    }
}
