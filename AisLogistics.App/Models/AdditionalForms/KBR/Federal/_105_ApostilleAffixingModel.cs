using AisLogistics.App.Models.AdditionalForms;

namespace AisLogistics.App.Models;

/// <summary>
/// Проставление апостиля на российских официальных документах, подлежащих вывозу за пределы Российской Федерации
/// </summary>
public class _105_ApostilleAffixingModel : AbstractAdditionalFormModel
{
    public _105_ApostilleAffixingModel()
    {
        AppliedDocumentList = new []
        {
            new AppliedDocument()
        };
    }

    /// <summary>
    /// страна предъявления документов
    /// </summary>
    public string Country { get; set; }

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
        /// Количество экземпляров
        /// </summary>
        public string Count { get; set; }
    }
}
