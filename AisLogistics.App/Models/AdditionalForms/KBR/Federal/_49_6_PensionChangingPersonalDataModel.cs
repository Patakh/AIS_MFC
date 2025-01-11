using AisLogistics.App.Models.AdditionalForms;

namespace AisLogistics.App.Models
{
    public sealed class _49_6_PensionChangingPersonalDataModel : AbstractAdditionalFormModel
    {
        public _49_6_PensionChangingPersonalDataModel()
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
        /// Прошу прекратить выплату
        /// </summary> 
        public string[] PleaseStopPayment { get; set; }

        /// <summary>
        /// Прошу прекратить ЕДВ
        /// </summary> 
        public string PleaseStopBARELY { get; set; }

        /// <summary>
        ///  направить уведомление, подтверждающее факт и дату приема территориальным органом Пенсионного
        /// </summary> 
        public string ResponseType { get; set; }

        /// <summary>
        /// адрес электронной почты гражданина
        /// </summary> 
        public string ResponseEmail { get; set; }

        /// <summary>
        /// адрес электронной почты гражданина
        /// </summary> 
        public string ResponseEmail2 { get; set; }

        /// <summary>
        /// осуществлять информирование
        /// </summary> 
        public string CarryInformation { get; set; }

        /// <summary>
        /// на абонентский номер устройства подвижной радиотелефонной связи
        /// </summary> 
        public string ResponsePhone { get; set; }

        /// <summary>
        ///  В связи с
        /// </summary> 
        public string Reason { get; set; }

        public int TypeDocumentAddressApplicant { get; set; }

        public int TypeDocumentAddressRecipient { get; set; }

        /// <summary>
        /// Приложенные документы
        /// </summary>
        public AppliedDocument[] AppliedDocumentList { get; set; }

        public TypePaymentModel TypePayment { get; set; }
        public Notification TypeNotification { get; set; }

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


        public class TypePaymentModel
        {
            public bool TypeOne { get; set; }
            public bool TypeTwo { get; set; }
            public bool TypeThree { get; set; }
            public bool TypeFour { get; set; }
            public bool TypeFive { get; set; }
            public bool TypeSix { get; set; }
            public bool TypeSeven { get; set; }
            public bool TypeEight { get; set; }
            public bool TypeNine { get; set; }
            public bool TypeTen { get; set; }
            public bool TypeEvelen { get; set; }
            public bool TypeTwelve { get; set; }
            public bool TypeThirteen { get; set; }
            public bool TypeFourteen { get; set; }
            public bool TypeFifteen { get; set; }
            public bool TypeSixteen { get; set; }
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
    }
}
