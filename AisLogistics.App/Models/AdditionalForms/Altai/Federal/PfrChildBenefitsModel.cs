namespace AisLogistics.App.Models.AdditionalForms
{
    /// <summary>
    /// Заявление о назначении единовременного при рождении или ежемесячного по уходу на ребенка ПФР
    /// </summary>
    public class PfrChildBenefitsModel : AbstractAdditionalFormModel
    {
        public PfrChildBenefitsModel()
        {
            Customer = new();
            Representative = new();
            OtherFamilyMemberList = new[]
            {
                new PersonType()
            };
            CreditOrganization = new();
            PostalOffice = new();
        }

        /// <summary>
        /// Вид пособия
        /// 1 - Ежемесячное пособие по уходу за ребенком  неработающим гражданам
        /// 2 - Единовременного пособия при рождении ребенка неработающим гражданам
        /// </summary>
        public string BenefitType { get; set; }

        /// <summary>
        /// Заявитель
        /// </summary>
        public CustomerType Customer { get; set; }


        /// <summary>
        /// Сведения для осуществления доставки пособия
        /// </summary>
        public string Delivery { get; set; }
        
        /// <summary>
        /// Сведения для осуществления доставки пособия1
        /// </summary>
        public string Delivery1 { get; set; }
        
        /// <summary>
        /// Сведения для осуществления доставки пособия2
        /// </summary>
        public string Delivery2 { get; set; }
        
        /// <summary>
        /// Сведения о втором родителе ребенка ФИО
        /// </summary>
        public string Parent_Fio { get; set; }

        /// <summary>
        ///  СНИЛС
        /// </summary>
        public string Parent_Snils { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public string Parent_BirthDate { get; set; }
        

        /// <summary>
        /// отц ребенка ФИО
        /// </summary>
        public string Father_Fio { get; set; }

        /// <summary>
        /// отц ребенка СНИЛС
        /// </summary>
        public string Father_Snils { get; set; }

        /// <summary>
        /// отц ребенка Дата рождения
        /// </summary>
        public string Father_BirthDate { get; set; }

        /// <summary>
        /// Наименование воинской части, в которой проходит служба по призыву 
        /// </summary>
        public string Name_Military { get; set; }

        /// <summary>
        /// Наименование военного комиссариата по месту призыва (в случае если военная служба окончена)
        /// </summary>
        public string Name_Commissariat { get; set; }

        /// <summary>
        /// Наименование военной  профессиональной образовательной организации или военной образовательной организации высшего образования, в которой проходит обучение
        /// </summary>
        public string Name_Military_Organizations { get; set; }

        /// <summary>
        /// Представитель
        /// </summary>
        public RepresentativeType Representative { get; set; }

        /// <summary>
        /// Другие члены семьи
        /// </summary>
        public PersonType[] OtherFamilyMemberList { get; set; }

        /// <summary>
        /// Кредитная организация
        /// </summary>
        public CreditOrganizationType CreditOrganization { get; set; }

        /// <summary>
        /// Почтовое отделение
        /// </summary>
        public PostalOfficeType PostalOffice { get; set; }

        public class PersonType
        {
            /// <summary>
            /// Ребенок на полном государственном обеспечении
            /// </summary>
            public string Opeka { get; set; }
            
            /// <summary>
            /// Заявитель является для ребенка
            /// </summary>
            public string Status { get; set; }

            /// <summary>
            /// ФИО
            /// </summary>
            public string Fio { get; set; }

            /// <summary>
            /// СНИЛС
            /// </summary>
            public string Snils { get; set; }

            /// <summary>
            /// Номер полиса ОМС
            /// </summary>
            public string PolisNumberOMS { get; set; }

            /// <summary>
            /// Дата рождения
            /// </summary>
            public DateTime? BirthDate { get; set; }

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
            /// Дата выдачи ДУл
            /// </summary>
            public string DocIssueDate { get; set; }

            /// <summary>
            /// Адрес регистрации
            /// </summary>
            public string RegistrationAddress { get; set; }

            /// <summary>
            /// Адрес места жительства
            /// </summary>
            public string ActualResidenceAddress { get; set; }

            /// <summary>
            /// Гражданство
            /// </summary>
            public string Citizenship { get; set; }

            /// <summary>
            /// Контактный телефон
            /// </summary>
            public string Phone { get; set; }

            /// <summary>
            /// адрес электронной почты
            /// </summary>
            public string Emaill { get; set; }


        }

        public class CustomerType : PersonType
        {
          
            /// <summary>
            /// Место рождения
            /// </summary>
            public string BirthPlace { get; set; }

            /// <summary>
            /// Адрес регистрации по месту пребывания
            /// </summary>
            public string StayAddress { get; set; }

            /// <summary>
            /// Обучаюсь по очной
            /// </summary>
            public string Study { get; set; }

            /// <summary>
            /// Наименование профессиональной образовательной организации
            /// </summary>
            public string StudyName { get; set; }
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
            /// Серия
            /// </summary>
            public string AuthorityDocSeries { get; set; }

            /// <summary>
            /// Дата выдачи документа, подтверждабщего полномочия представителя
            /// </summary>
            public DateTime? AuthorityDocIssueDate { get; set; }

            /// <summary>
            /// Кем выдан документ, подтверждающий полномочия представителя
            /// </summary>
            public string AuthorityDocIssuer { get; set; }
        }

        public class CreditOrganizationType
        {
            /// <summary>
            /// Наименование
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// БИК
            /// </summary>
            public string Bik { get; set; }

            /// <summary>
            /// КПП
            /// </summary>
            public string Kpp { get; set; }

            /// <summary>
            /// Номер счета заявителя
            /// </summary>
            public string AccountNumber { get; set; }
        }

        public class PostalOfficeType
        {
            /// <summary>
            /// Адрес получателя
            /// </summary>
            public string Address { get; set; }

            /// <summary>
            /// Номер почтового отделения
            /// </summary>
            public string Number { get; set; }
        }

    }
}
