using AisLogistics.App.Models.AdditionalForms;

namespace AisLogistics.App.Models;

/// <summary>
/// Назначение и выплата государственных единовременных пособий, ежемесячных денежных компенсаций гражданам при возникновении у них поствакцинальных осложнений
/// </summary>
public class _17_PostVaccinationComplicationsModel : AbstractAdditionalFormModel
{
    public _17_PostVaccinationComplicationsModel()
    {
        AppliedDocumentList = new[]
        {
            new AppliedDocument()
        };
    }

    /// <summary>
    /// категорий граждан
    /// </summary>
    public string Categories { get; set; }

    /// <summary>
    /// название кредитной организации
    /// </summary>
    public string NameCreditOrgan { get; set; }

    /// <summary>
    /// лицевой счет
    /// </summary>
    public string PersonalAccount { get; set; }

    /// <summary>
    /// почтовое отделение
    /// </summary>
    public string PostOffice { get; set; }

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
        /// Количество листов
        /// </summary>
        public string CountList { get; set; }
    }
}
