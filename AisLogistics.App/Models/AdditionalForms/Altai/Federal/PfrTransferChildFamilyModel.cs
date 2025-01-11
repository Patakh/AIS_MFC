namespace AisLogistics.App.Models.AdditionalForms
{
    /// <summary>
    /// Заявление о назначении единовременного при рождении или ежемесячного по уходу на ребенка ПФР
    /// </summary>
    public class PfrTransferChildFamilyModel : AbstractAdditionalFormModel
    {
        public PfrTransferChildFamilyModel()
        {
            Customer = new();
            Representative = new();
            Spouse = new();
            BankingDetails = new();
        }

        /// <summary>
        /// Основание для получения пособия
        /// </summary>
        public string BasisObtainingBenefits { get; set; }
        /// <summary>
        /// Наименование муниципального образования
        /// </summary>
        public string Municipality { get; set; }

        /// <summary>
        /// Город/район
        /// </summary>
        public string CityArea { get; set; }

        /// <summary>
        /// Дата
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// Номер
        /// </summary>
        public string Number { get; set; }        

        /// <summary>
        /// ФИО ребенка
        /// </summary>
        public string ChildFio { get; set; }

        /// <summary>
        /// Дата рождения ребенка
        /// </summary>
        public DateTime? ChildBirthDate { get; set; }

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
        public PersonType Spouse { get; set; }

        /// <summary>
        /// Представитель
        /// </summary>
        public RepresentativeType Representative { get; set; }        

        /// <summary>
        /// Банковские реквизиты
        /// </summary>
        public CreditOrganizationType BankingDetails { get; set; }        

        /// <summary>
        /// Приложенные документы
        /// </summary>
        public string[] AppliedDocuments { get; set; }

        public class PersonType
        {
            /// <summary>
            /// Гражданство
            /// </summary>
            public string Citizenship { get; set; }

            /// <summary>
            /// ФИО
            /// </summary>
            public string Fio { get; set; }

            /// <summary>
            /// Дата рождения
            /// </summary>
            public DateTime? BirthDate { get; set; }

            /// <summary>
            /// сведения о месте жительства, месте пребывания 
            /// (на основании записи в паспорте или документе, 
            /// подтверждающем регистрация, с указанием почтового индекса) 
            public string StayAddress { get; set; }

            /// <summary>
            /// Адрес фактического проживания (почтовый индекс)
            /// </summary>
            public string ActualResidenceAddress { get; set; }

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
    }
}
