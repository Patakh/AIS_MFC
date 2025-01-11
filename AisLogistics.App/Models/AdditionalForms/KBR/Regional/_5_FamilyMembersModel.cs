using AisLogistics.App.Models.AdditionalForms;
namespace AisLogistics.App.Models;

public class _5_FamilyMembersModel : AbstractAdditionalFormModel
{
    private string _fio;
    public _5_FamilyMembersModel()
    {
        AppliedDocumentList = new[]
        {
            new FamilyMembers()
        };
    }

    /// <summary>
    /// ФИО в дательном падеже
    /// </summary>
    public string FIO
    {
        get => _fio;
        set
        {
            _fio = value;

        }
    }

    /// <summary>
    /// Состав семьи (кол-во человек)
    /// </summary>
    public string NumberFamilies { get; set; }

    /// <summary>
    /// Количество экземпляров
    /// </summary>
    public string NumberCopies { get; set; }

    /// <summary>
    /// Тип подачи 
    /// </summary>
    public int AddressType { get; set; }

    /// <summary>
    /// Приложенные документы
    /// </summary>
    public FamilyMembers[] AppliedDocumentList { get; set; }

    public class FamilyMembers
    {
        /// <summary>
        /// Ф.И.О.
        /// </summary>
        public string FIO { get; set; }

        /// <summary>
        /// Год рождения
        /// </summary>
        public string BirthDateYear { get; set; }

        /// <summary>
        /// Родственные отношения
        /// </summary>
        public string FamilyRelations { get; set; }
    }
}
