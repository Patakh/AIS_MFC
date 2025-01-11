using AisLogistics.App.Models.AdditionalForms;

namespace AisLogistics.App.Models;

/// <summary>
/// Назначение и начисление ежемесячной выплаты лицам, удостоенным Государственных наград Кабардино-Балкарской Республики
/// </summary>
public class _71_StateAwardsModel : AbstractAdditionalFormModel
{
    public _71_StateAwardsModel()
    {
        AppliedDocumentList = new []
        {
            new AppliedDocument()
        };
    }

    /// <summary>
    /// Прошу выплачивать установленную выплату через почту (банк)
    /// </summary>
    public string Pay { get; set; }
      
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
