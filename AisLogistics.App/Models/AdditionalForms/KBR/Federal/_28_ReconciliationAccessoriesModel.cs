using AisLogistics.App.Models.AdditionalForms; 

namespace AisLogistics.App.Models;

/// <summary>
/// Прием запроса о предоставлении акта сверки принадлежности сумм денежных средств, перечисленных и (или) признаваемых в качестве единого налогового платежа, либо сумм денежных средств, перечисленных не в качестве единого налогового платежа и формата его представления.
/// </summary>
public class _28_ReconciliationAccessoriesModel : AbstractAdditionalFormModel
{
    public _28_ReconciliationAccessoriesModel()
    {
        AppliedDocumentList = new[]
        {
            new AppliedDocument()
        };
    }

    /// <summary>
    /// Признак заявителя
    /// </summary>
    public string ApplicantAttribute { get; set; }

    /// <summary>
    /// Код налогового органа
    /// </summary>
    public string CodeFNS { get; set; }

    /// <summary>
    /// Прошу выдать справку
    /// </summary>
    public string Certificate { get; set; }

    /// <summary>
    /// Способ выдачи справки
    /// </summary>
    public string CertificateDeviliry { get; set; }

    /// <summary>
    /// платежа за период с
    /// </summary>
    public string BeginDate { get; set; }

    /// <summary>
    /// по 
    /// </summary>
    public string EndDate { get; set; }
    
    /// <summary>
    /// Перечень КБК
    /// </summary>
    public AppliedDocument[] AppliedDocumentList { get; set; }

    public class AppliedDocument
    {
        /// <summary>
        /// КБК
        /// </summary>
        public string Code { get; set; } 
    }
}