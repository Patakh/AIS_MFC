namespace AisLogistics.App.Models.AdditionalForms.KBR.Federal
{
    /// <summary>
    /// ЗАЯВЛЕНИЕ О ВЫПЛАТЕ НЕ ПОЛУЧЕННЫХ В СВЯЗИ СО СМЕРТЬЮ НЕТРУДОСПОСОБНОГО ГРАЖДАНИНА СУММ КОМПЕНСАЦИОННОЙ ВЫПЛАТЫ
    /// 
    public sealed class _64_8_PaymentRemainsCareDisabledCitizensModel : AbstractAdditionalFormModel
    {
        #region Блок1

        /// <summary>
        /// Гражданство
        /// </summary>
        public string Citizenship { get; set; } = null!;

        /// <summary>
        /// Срок действия документа удостоверяющего личность
        /// </summary> 
        public string? ValidityPeriodDocument { get; set; }

        #endregion

        #region Блок2

        /// <summary>
        /// Представитель 
        /// </summary> 
        public string Representative { get; set; } = null!;

        /// <summary>
        /// Наименование организации, на которую возложено исполнение обязанностей опекуна или попечителя
        /// </summary>
        public string GuardianOrganizationName { get; set; } = null!;

        /// <summary>
        /// Адрес места нахождения организации
        /// </summary>
        public string GuardianOrganizationAddress { get; set; } = null!;

        #endregion

        #region Блок3
        /// <summary>
        /// фамилия, имя, отчество (при наличии) нетрудоспособного гражданина, за которым осуществляется уход
        /// </summary>
        public string? DisabledCitizenFullName { get; set; }
        /// <summary>
        /// Доставка выплаты
        /// 1 - организацию почтовой связи по адресу
        /// 2 - кредитную организацию
        /// 3 - иную организацию, занимающуюся доставкой пенсии
        /// </summary>
        public int DeliverPaymentTypeId { get; set; }

        /// <summary>
        /// адрес, по которому необходимо произвести выплату суммы компенсационной выплаты
        /// </summary>
        public string? PochtaAddress { get; set; }

        /// <summary>
        /// полное наименование кредитной организации
        /// </summary>
        public string? CreditName { get; set; }

        /// <summary>
        /// номер счета в кредитной организации
        /// </summary>
        public string? CreditNumberScore { get; set; }

        /// <summary>
        /// полное наименование иной организации
        /// </summary>
        public string? DeliveryOthereName { get; set; }

        /// <summary>
        /// адрес, по которому необходимо произвести выплату суммы компенсационной выплаты
        /// </summary>
        public string? DeliveryOthereAddress { get; set; }

        #endregion

        #region Блок4

        /// <summary>
        /// Тип информирования
        /// </summary>
        public Notification TypeNotification { get; set; }

        public class Notification
        {
            public bool NotificationTypeOne { get; set; }
            public bool NotificationTypeTwo { get; set; }
            public string? EmailOne { get; set; }
            public int NotificationTransmitionMethod { get; set; }
            public string? EmailTwo { get; set; }
            public string? SubscriberNumber { get; set; }
        }

        #endregion
    }
}

