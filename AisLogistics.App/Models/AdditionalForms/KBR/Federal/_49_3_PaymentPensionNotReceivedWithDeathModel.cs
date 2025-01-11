using AisLogistics.App.Models.AdditionalForms;

namespace AisLogistics.App.Models;

    /// <summary>
    /// Выплата начисленных сумм государственной пенсии, причитавшихся пенсионеру и оставшихся не полученными в связи с его смертью
    /// </summary>
    public sealed class _49_3_PaymentPensionNotReceivedWithDeathModel : AbstractAdditionalFormModel
    {
        public _49_3_PaymentPensionNotReceivedWithDeathModel()
        {
            AppliedDocumentList = new[]
            {
                new AppliedDocument()
            };
        }
        /// <summary>
        /// принадлежность к гражданству
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
        /// и фамилия, имя, отчество  ее представителя
        /// </summary> 
        public string GuardianOrganizationRepresentative { get; set; }

        /// <summary>
        /// адрес места пребывания
        /// </summary>
        public string AddressPlaceStayRepresentative { get; set; }

        /// <summary>
        /// адрес места фактического проживания
        /// </summary> 
        public string AddressActualResidenceRepresentative { get; set; }

        /// <summary>
        /// адрес места нахождения организации 
        /// </summary> 
        public string LocationAddressGuardianOrganization { get; set; }

        /// <summary>
        /// Наименование документа, подтверждающего полномочия представителя
        /// </summary> 
        public string NameDocumentConfirmingRepresentative { get; set; }

        /// <summary>
        /// Серия, номер
        /// </summary> 
        public string SeriesNumberDocumentConfirmingRepresentative { get; set; }

        /// <summary>
        /// Кем выдан
        /// </summary> 
        public string IssuerDocumentConfirmingRepresentative { get; set; }

        /// <summary>
        /// Дата выдачи
        /// </summary> 
        public string IssueDateDocumentConfirmingRepresentative { get; set; }

        /// <summary>
        /// Срок действия полномочий
        /// </summary> 
        public string ValidityPeriodConfirming { get; set; }

        /// <summary>
        /// тип пенсии
        /// </summary> 
        public string[] PensionType { get; set; }

        /// <summary>
        /// Прошу прекратить ЕДВ
        /// </summary> 
        public string PleaseStopBARELY { get; set; }

        /// <summary>
        ///  В связи с
        /// </summary> 
        public string Reason { get; set; }

        public Death DeathInfo { get; set; }
        public Notification TypeNotification { get; set; }
        public string NotificationAcceptance { get; set; }
        /// <summary>
        /// Способ выплаты 
        /// </summary> 
        public PaymentType PaymentTypeInfo { get; set; }
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
            /// Количестов Экземпляров
            /// </summary>
            public int NumdberOriginals { get; set; }
            /// <summary>
            /// Количество страниц
            /// </summary>
            public int NumdberCopies { get; set; }
        }

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

        public class Notification
        {
            public bool NotificationTypeOne { get; set; }
            public bool NotificationTypeTwo { get; set; }
            public string EmailOne { get; set; }
            public int NotificationTransmitionMethod { get; set; }
            public string EmailTwo { get; set; }
            public string SubscriberNumber { get; set; }
        }


        public class Death
        {
            public string Fio { get; set; }
            public DateTime Date { get; set; }
            public string NotaryNumber { get; set; }
            public DateTime NotaryDate { get; set; }
            public Address Resident { get; set; }
            public Address ResidentBeforeLeaving { get; set; }
            public string ResidenceAnotherState { get; set; }
    }

        public class Address
        {
            public string Residence { get; set; }
            public string Stay { get; set; }
            public string ActualStay { get; set; }

        } 
        
    }