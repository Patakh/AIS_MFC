using AisLogistics.App.Models.AdditionalForms;
using SmevRouter;

namespace AisLogistics.App.Models;

/// <summary>
/// Единовременная выплата средств пенсионных накоплений, учтенных в специальной части индивидуального лицевого счета
/// </summary>
public sealed class _49_10_PaymentPensionSavingsModel : AbstractAdditionalFormModel
{ 
    /// <summary>
    /// Гражданство
    /// </summary>
    public string Citizenship { get; set; }

    /// <summary>
    /// адрес места пребывания
    /// </summary>
    public string AddressPlaceStay { get; set; }

    /// <summary>
    /// адрес места фактического проживания
    /// </summary> 
    public string AddressActualResidence { get; set; }
      
    /// <summary>
    /// Способ выплаты 
    /// </summary> 
    public PaymentType PaymentTypeInfo { get; set; }

    public class PaymentType 
    {
        public int IsChecked { get; set; }
        public PaymentBank PaymentBankInfo { get; set; }
        public PaymentPochta PaymentPochtaInfo { get; set; }
        public PaymentOrher PaymentOrherInfo { get; set; }
    }

    public class PaymentBank
    {
        /// <summary>
        /// путем зачисления на счет №
        /// </summary> 
        public string Score { get; set; }
        /// <summary>
        /// открытый в
        /// </summary> 
        public string OpenIn { get; set; }
    }

    public class PaymentPochta
    {
        public int IsChecked { get; set; }
        /// <summary>
        /// через организацию почтовой связи
        /// путем вручения на дому по адресу
        /// </summary> 
        public string PostalDeliveryHome { get; set; }       
    }
    public class PaymentOrher
    {
        public int IsChecked { get; set; }
        /// <summary>
        /// название организации, занимающейся доставкой пенсий,
        /// </summary> 
        public string OtherDeliveryOrganizationName { get; set; }
        /// <summary>
        /// через организацию почтовой связи
        /// через иную организацию, занимающуюся доставкой пенсий 
        /// </summary> 
        public string OtherDeliveryHome { get; set; }
    }

}