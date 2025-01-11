namespace AisLogistics.App.Models.AdditionalForms
{
    public class RosImProvidingExtractsModel : AbstractAdditionalFormModel
    {
        public RosImProvidingExtractsModel()
        {
            ObjectCharacteristicList = new[]
            {
                new ObjectCharacteristicType()
            };
            Customer = new();
            Representative = new();
        }

        /// <summary>
        /// характеристики объекта федерального имущества, позволяющие его однозначно определить
        /// </summary>
        public ObjectCharacteristicType[] ObjectCharacteristicList { get; set; }

        /// <summary>
        /// Заявитель
        /// </summary>
        public PersonType Customer { get; set; }

        /// <summary>
        /// Представитель
        /// </summary>
        public RepresentativeType Representative { get; set; }                

        /// <summary>
        /// Адрес получения результата
        /// </summary>
        public string AddressResult { get; set; }

        /// <summary>
        /// Адрес электронной почты для отправки результата в форме 
        /// электронного документа
        /// </summary>
        public string EmailResult { get; set; }
        
        /// <summary>
        /// Номер факса для информирования
        /// </summary>
        public string FaxInforming { get; set; }

        /// <summary>
        /// "Электронная почта для информирования
        /// </summary>
        public string EmailInforming { get; set; }

        /// <summary>
        /// Номер телефона для информирования
        /// </summary>
        public string PhoneInforming { get; set; }

        /// <summary>
        /// Почтовый адрес для информирования
        /// </summary>
        public string AddressInforming { get; set; }

        public class PersonType
        {
            /// <summary>
            /// Ф.И.О. физического лица/полное наименование юридического лица
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// ИНН
            /// </summary>
            public string Inn { get; set; }

            /// <summary>
            /// ОКПО
            /// </summary>
            public string Okpo { get; set; }

            /// <summary>
            /// адрес постоянного места жительства или преимущественного пребывания
            /// (область, город, улица, дом, корпус, квартира, в случае временной регистрации указать также и ее полный адрес)/юридический и фактический адрес
            /// </summary>
            public string Address { get; set; }

            /// <summary>
            /// Место рождения
            /// </summary>
            public string BirthPlace { get; set; }

            /// <summary>
            /// Наименование ДУЛ
            /// </summary>
            public string DocName { get; set; }

            /// <summary>
            /// Серия ДУЛ
            /// </summary>
            public string DocSeries { get; set; }

            /// <summary>
            /// Номер ДУЛ
            /// </summary>
            public string DocNumber { get; set; }

            /// <summary>
            /// Кем выдан ДУЛ
            /// </summary>
            public string DocIssuer { get; set; }

            /// <summary>
            /// Дата выдачи ДУЛ
            /// </summary>
            public string DocIssueDate { get; set; }

            /// <summary>
            /// Телефон
            /// </summary>
            public string Phone { get; set; }

            /// <summary>
            /// Адрес электронной почты
            /// </summary>
            public string Email { get; set; }

            /// <summary>
            /// СНИЛС
            /// </summary>
            public string Snils { get; set; }
        }

        public class RepresentativeType : PersonType
        {
            /// <summary>
            /// Наименование документа, подтверждающего полномочия представителя
            /// </summary>
            public string AuthorityDocName { get; set; }

            /// <summary>
            /// Номер документа, подтверждающего полномочия представителя
            /// </summary>
            public string AuthorityDocNumber { get; set; }

            /// <summary>
            /// Дата выдачи документа, подтверждабщего полномочия представителя
            /// </summary>
            public DateTime? AuthorityDocIssueDate { get; set; }
        }

        public class ObjectCharacteristicType
        {
            /// <summary>
            /// Наименование
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Значение
            /// </summary>
            public string Value { get; set; }
        }
    }
}
