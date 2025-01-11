using AisLogistics.App.Models.AdditionalForms;

namespace AisLogistics.App.Models;

/// <summary>
/// Субсидии на оплату жилого помещения и коммунальных услуг
/// </summary>
public class _101_RuralSettlementsSubsidiesModel : AbstractAdditionalFormModel
{
    /// <summary>
    /// как специалисту образовательных организаций или как специалисту пенсионеру
    /// </summary>
    public string AsSpecialist { get; set; }

    /// <summary>
    /// Управления Федеральной почтовой связи КБР - ФГУП "Почта России"
    /// </summary>
    public string RussianPost { get; set; }

    /// <summary>
    /// кредитную организацию
    /// </summary>
    public string CreditInstitution { get; set; }

    /// <summary>
    /// Способ выплаты
    /// </summary>
    public string PaymentMethod { get; set; }

    /// <summary>
    /// лицевой счет
    /// </summary>
    public string PersonalAccount { get; set; }

    /// <summary>
    /// Наименования организации
    /// </summary>
    public string OrganizationName { get; set; }

    /// <summary>
    /// Уведомление о результате направить по средствам (почтовый адрес, электронный адрес, портал)
    /// </summary>
    public string Response { get; set; }
     
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
