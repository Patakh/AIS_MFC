using AisLogistics.App.Models.AdditionalForms;
namespace AisLogistics.App.Models;

/// <summary>
/// Прием заявлений о предоставлении жителям г.Херсона и части Херсонской области,
/// вынужденно покинувшим место постоянного проживания и прибывшим в экстренном массовом порядке
/// в Кабардино-Балкарскую Республику на постоянное место жительства,
/// единовременной выплаты на обзаведение имуществом
/// </summary>
public class _121_MigrantModel : AbstractAdditionalFormModel
{
    public _121_MigrantModel()
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
    /// Дата регистрации постоянного адреса
    /// </summary>
    public string DateRegistration { get; set; }

    /// <summary>
    ///  Адрес регистрации по месту пребывания
    /// </summary>
    public string AdresPlaceStay { get; set; }

    /// <summary>
    /// Адрес предыдущего места жительства
    /// </summary>
    public string AdresPlaceResidence { get; set; }

    /// <summary>
    /// Уведомления о принятом решении прошу направить
    /// </summary>
    public string Notifications { get; set; }

    /// <summary>
    /// на адрес
    /// </summary>
    public string RussianPostAddress { get; set; }
      
    /// <summary>
    /// Номер счета 
    /// </summary>
    public string PersonalAccount { get; set; }
      
    /// <summary>
    ///  БИК
    /// </summary>
    public string BIK { get; set; }

    /// <summary>
    ///  Наименование банка
    /// </summary>
    public string NameCreditOrgan { get; set; }

    /// <summary>
    ///  ИНН
    /// </summary>
    public string INN { get; set; }

    /// <summary>
    ///  Корсчет
    /// </summary>
    public string Corset { get; set; }

    /// <summary>
    /// КПП
    /// </summary>
    public string KPP { get; set; }
     
    /// <summary>
    /// Приложенные документы
    /// </summary>
    public AppliedDocument[] AppliedDocumentList { get; set; }

    /// <summary>
    /// Сведения о членах семьи заявител
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
        /// ФИО
        /// </summary>
        public string FIO { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public string BirthDate { get; set; }

        /// <summary>
        /// Вид родства
        /// </summary>
        public string Kinship { get; set; }

        /// <summary>
        /// Документ, подтверждающий родство
        /// </summary>
        public string KinshipDokument { get; set; }
    }
}
