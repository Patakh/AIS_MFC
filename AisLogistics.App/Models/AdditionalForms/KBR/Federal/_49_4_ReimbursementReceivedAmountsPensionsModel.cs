using AisLogistics.App.Models.AdditionalForms;

namespace AisLogistics.App.Models
{
    /// <summary>
    /// ЗАЯВЛЕНИЕ О ДОБРОВОЛЬНОМ ВОЗМЕЩЕНИИ ИЗЛИШНЕ ПОЛУЧЕННЫХ СУММ ПЕНСИИ
    /// </summary>
    public class _49_4_ReimbursementReceivedAmountsPensionsModel : AbstractAdditionalFormModel
    {
        /// <summary>
        /// принадлежность к гражданству
        /// </summary>
        public string Citizenship { get; set; }
        // <summary>
        /// Срок действия документа удостоверяющего личность
        /// </summary> 
        public string ValidityPeriodDocument { get; set; }
        /// <summary>
        /// Представитель 
        /// </summary> 
        public string Representative { get; set; }
        /// <summary>
        /// наименование организации на которую возложено исполнение обязанностей опекуна 
        /// </summary> 
        public string GuardianOrganization { get; set; }
        /// <summary>
        /// адрес места нахождения организации 
        /// </summary> 
        public string LocationAddressGuardianOrganization { get; set; }
        /// <summary>
        /// Замещаемая должность 
        /// </summary>
        public int JobType {  get; set; }
        /// <summary>
        /// тип пенсии
        /// </summary> 
        public string[] PensionType { get; set; }
        /// <summary>
        /// период пенсии
        /// </summary>
        public string PensionPeriod { get; set; }
        /// <summary>
        /// тип взымание выплаты
        /// </summary>
        public int AmountsType { get; set; }
        /// <summary>
        /// Проценты
        /// </summary>
        public string AmountPercent { get; set; }
        /// <summary>
        /// Твердая сумма
        /// </summary>
        public string AmountFixed { get; set; } 
        /// <summary>
        /// Сумма пенсии
        /// </summary>
        public string AmountCount { get; set; }
        /// <summary>
        /// Оповещение о приеме
        /// </summary>
        public string NotificationAcceptance { get; set; }
    }
}
