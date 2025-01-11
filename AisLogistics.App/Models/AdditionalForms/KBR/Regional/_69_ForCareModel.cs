namespace AisLogistics.App.Models;

/// <summary>
/// Назначение и выплата единовременной адресной социальной помощи на улучшение жилищных условий многодетным семьям, воспитывающим пятерых и более детей
/// </summary>
public class _69_ForCareModel : AbstractAdditionalFormModel
{
    public _69_ForCareModel()
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
    /// супруга (супруг) (фамилия, имя, отчество, дата рождения)
    /// </summary>
    public string SpouseFIO { get; set; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    public string SpouseBirthDate { get; set; }

    /// <summary>
    /// данные паспорта
    /// </summary>
    public string SpouseDataPasport { get; set; }

    /// <summary>
    /// адрес проживания
    /// </summary>
    public string SpouseAddressResidence { get; set; }

    /// <summary>
    /// Приложенные документы
    /// </summary>
    public AppliedDocument[] AppliedDocumentList { get; set; }

    /// <summary>
    /// дети
    /// </summary>
    public FamilyMembers[] FamilyMembersList { get; set; }

    public class AppliedDocument
    {
        /// <summary>
        /// Наименование документа
        /// </summary>
        public string Name { get; set; } 
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

        /// <summary>
        /// данные паспорта
        /// </summary>
        public string DataPasport { get; set; }

        /// <summary>
        /// данные паспорта
        /// </summary>
        public string BirthCertificates { get; set; }

        /// <summary>
        /// адрес проживания
        /// </summary>
        public string AddressResidence { get; set; }
    }
}
