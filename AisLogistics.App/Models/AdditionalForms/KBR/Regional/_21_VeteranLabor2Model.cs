using AisLogistics.App.Models.AdditionalForms;

namespace AisLogistics.App.Models;

/// <summary>
/// Присвоение звания «Ветеран труда» и выдача удостоверения «Ветеран труда»
/// </summary>
public class _21_VeteranLabor2Model : AbstractAdditionalFormModel
{
    public _21_VeteranLabor2Model()
    {
        AppliedDocumentList = new []
        {
            new AppliedDocument()
        };
    }

    /// <summary>
    /// в связи с
    /// </summary>
    public string Reason { get; set; }

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
