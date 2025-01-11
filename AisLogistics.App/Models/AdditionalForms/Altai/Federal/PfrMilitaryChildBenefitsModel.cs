namespace AisLogistics.App.Models.AdditionalForms
{
    /// <summary>
    /// Заявление о назначении единовременного при рождении или ежемесячного по уходу на ребенка ПФР
    /// </summary>
    public class PfrMilitaryChildBenefitsModel : AbstractAdditionalFormModel
    {
        public PfrMilitaryChildBenefitsModel()
        {
            Customer = new();
            Representative = new();
            ChildList = new[]
            {
                new PersonType()
            };
            CreditOrganization = new();
            PostalOffice = new();            
        }

        /// <summary>
        /// Дата начала периода подсчета доходов
        /// </summary>
        public DateTime? PeriodStartDate { get; set; }

        /// <summary>
        /// Дата окончания периода подсчета доходов
        /// </summary>
        public DateTime? PeriodEndDate { get; set; }

        /// <summary>
        /// Сумма доходов за период
        /// </summary>
        public string Profit { get; set; }

        /// <summary>
        /// Количество членов семьи
        /// </summary>
        public string FamilyMembersNumber { get; set; }

        /// <summary>
        /// Вид пособия        
        /// </summary>
        public string BenefitType { get; set; }

        /// <summary>
        /// Заявитель
        /// </summary>
        public PersonType Customer { get; set; }

        /// <summary>
        /// Другой родитель
        /// </summary>
        public PersonType OtherParent { get; set; }

        /// <summary>
        /// Представитель
        /// </summary>
        public RepresentativeType Representative { get; set; }

        /// <summary>
        /// Другие члены семьи
        /// </summary>
        public PersonType[] ChildList { get; set; }

        /// <summary>
        /// Кредитная организация
        /// </summary>
        public CreditOrganizationType CreditOrganization { get; set; }

        /// <summary>
        /// Почтовое отделение
        /// </summary>
        public PostalOfficeType PostalOffice { get; set; }

        /// <summary>
        /// Приложенные документы
        /// </summary>
        public string[] AppliedDocuments { get; set; }

        public class PersonType
        {
            /// <summary>
            /// ФИО
            /// </summary>
            public string Fio { get; set; }

            /// <summary>
            /// Статус
            /// </summary>
            public string Status { get; set; }

            /// <summary>
            /// Дата рождения
            /// </summary>
            public DateTime? BirthDate { get; set; }

            /// <summary>
            /// указывается место жительства (пребывания), наименование региона, района, 
            /// города, иного населенного пункта, улицы, номера дома, корпуса квартиры 
            /// (на основании записи в паспорте или иного документа, подтверждающего 
            /// место жительства)  адрес электронной почты (при наличии)
            /// </summary>
            public string StayAddress { get; set; }

            /// <summary>
            /// Контактный телефон
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
