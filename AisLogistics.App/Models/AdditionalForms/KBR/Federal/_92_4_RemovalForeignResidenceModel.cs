using AisLogistics.App.Models.AdditionalForms; 

namespace AisLogistics.App.Models;

/// <summary>
/// Осуществление миграционного учета иностранных граждан и лиц без гражданства в Российской Федерации
/// Регистрация иностранных граждан по месту жительства
/// </summary>
public class _92_4_RemovalForeignResidenceModel : AbstractAdditionalFormModel
{
    public _92_4_RemovalForeignResidenceModel()
    {
        AppliedDocumentList = new[]
        {
            new AppliedDocument()
        };
    }

    /// <summary>
    /// СВЕДЕНИИ О ЛИЦЕ, ПОДЛЕЖАЩЕМ ПОСТАНОВКЕ НА УЧЕТ ПО МЕСТУ ЖИТЕЛЬСТВА
    /// </summary>
    public _92_1_ImplementationMigrationRegistrationModel.Person Foreigner { get; set; }
      
    /// <summary>
    /// адрес места жительства
    /// </summary>
    public string NewResidenceAddress { get; set; }

    /// <summary>
    /// Наименование и реквизиты документа, подтверждающего право пользования жилым помещением
    /// </summary>
    public string UseLivingSpaceDocument  { get; set; }

    /// <summary>
    /// Документ, подтверждающий право на проживание в Российской Федерации:
    /// Наименование документа
    /// </summary>
    public string RightLiveDocName { get; set; }

    /// <summary>
    /// Серия, номер
    /// </summary>
    public string RightLiveDocSeriesNumber { get; set; }

    /// <summary>
    /// Дата выдачи
    /// </summary>
    public string RightLiveDocIssueDate { get; set; }

    /// <summary>
    /// кем выдан
    /// </summary>
    public string RightLiveDocIssuer { get; set; }

    /// <summary>
    /// срок действия
    /// </summary>
    public string RightLiveDocValidityPeriod { get; set; }

    /// <summary>
    /// Адрес регистрации по последнему месту жительства:
    /// </summary>
    public string AdressRegLast { get; set; }

    /// <summary>
    /// Подразделение по вопросам миграции для снятия с предыдущего места жительства
    /// </summary>
    public string PrevProviderName { get; set; }

    /// <summary>
    /// Принятое решение
    /// </summary>
    public string DecisionMadeRegistration { get; set; }

    /// <summary>
    /// Принятое решение
    /// </summary>
    public string DecisionMadeRegistration2 { get; set; }

    /// <summary>
    /// В случае наличия у иностранного гражданина или лица без гражданства иных жилых помещений, находящихся на территории Российской Федерации, указываются их адреса
    /// </summary>
    public AppliedDocument[] AppliedDocumentList { get; set; }

    public class AppliedDocument
    {
        /// <summary>
        /// Адрес
        /// </summary>
        public string Adress { get; set; }
    }
}