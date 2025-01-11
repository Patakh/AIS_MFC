using AisLogistics.App.Models.AdditionalForms;

namespace AisLogistics.App.Models;

/// <summary>
/// Назначение и выплата ежемесячной денежной выплаты отдельным категориям граждан
/// </summary>
public class _29_IndividualCategoriesModel : AbstractAdditionalFormModel
{
    public _29_IndividualCategoriesModel()
    {
        AppliedDocumentList = new[]
        {
            new AppliedDocument()
        };
    }

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
    /// Уведомить о результате
    /// </summary>
    public string Notify { get; set; }

    /// <summary>
    /// выплату через
    /// </summary>
    public string PaymentMethod { get; set; }

    /// <summary>
    /// категорий граждан
    /// </summary>
    public string Categories { get; set; }

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
    }
}
