using AisLogistics.App.Models.AdditionalForms;

namespace AisLogistics.App.Models;

/// <summary>
/// Присвоение звания «Ветеран труда» и выдача удостоверения «Ветеран труда»
/// </summary>
public class _21_VeteranLaborModel : AbstractAdditionalFormModel
{
    public _21_VeteranLaborModel()
    {
        AppliedDocumentList = new []
        {
            new AppliedDocument()
        };
    }

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
