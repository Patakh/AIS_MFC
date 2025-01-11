namespace AisLogistics.App.Models.AdditionalForms
{
    /// <summary>
    /// Заявление о назначении единовременного при рождении или ежемесячного по уходу на ребенка ПФР
    /// </summary>
    public class PfrPregnantWomanFiredModel : AbstractAdditionalFormModel
    {
        public PfrPregnantWomanFiredModel()
        {
            Customer = new();
            Representative = new();
            AppliedDocumentList = new[]
            {
                new AppliedDocumentType()
            };
        }

        /// <summary>
        /// Наименование органа социальной защиты населения
        /// </summary>
        public string SznName { get; set; }

        /// <summary>
        /// Вид пособия        
        /// </summary>
        public string BenefitName { get; set; }

        /// <summary>
        /// Заявитель
        /// </summary>
        public PersonType Customer { get; set; }

        /// <summary>
        /// кредитная организация (указываются банковские реквизиты, 
        /// номер лицевого счета получателя)
        /// </summary>
        public CreditOrganizationType CreditOrganization { get; set; }

        /// <summary>
        /// организацию федеральной почтовой связи 
        /// (указывается почтовый адрес, по которому осуществляется доставка пособия)
        /// </summary>
        public PostalOfficeType PostalOffice { get; set; }

        /// <summary>
        /// Представитель
        /// </summary>
        public RepresentativeType Representative { get; set; }                

        /// <summary>
        /// Приложенные документы
        /// </summary>
        public AppliedDocumentType[] AppliedDocumentList { get; set; }

        public class PersonType
        {
            /// <summary>
            /// ФИО
            /// </summary>
            public string Fio { get; set; }            

            /// <summary>
            /// Адрес места жительства (пребывания, фактического проживания)
            public string Address { get; set; }    
            
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
        }

        public class RepresentativeType : PersonType
        {
            /// <summary>
            /// Наименование документа, подтверждающего полномочия представителя
            /// </summary>
            public string AuthorityDocName { get; set; }

            /// <summary>
            /// Серия документа, подтверждающего полномочия представителя
            /// </summary>
            public string AuthorityDocSeries { get; set; }

            /// <summary>
            /// Номер документа, подтверждающего полномочия представителя
            /// </summary>
            public string AuthorityDocNumber { get; set; }

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
            /// ИНН
            /// </summary>
            public string Inn { get; set; }

            /// <summary>
            /// КПП
            /// </summary>
            public string Kpp { get; set; }

            /// <summary>
            /// Номер счета
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

        public class AppliedDocumentType
        {
            /// <summary>
            /// Наименование документа
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Серия и номер
            /// </summary>
            public string SeriesNumber { get; set; }

            /// <summary>
            /// Дата выдачи
            /// </summary>
            public DateTime? IssueDate { get; set; }

            /// <summary>
            /// Кем выдан
            /// </summary>
            public string Issuer { get; set; }
        }
    }
}
