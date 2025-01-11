namespace AisLogistics.App.Models;

/// <summary>
/// Назначение ежемесячной денежной выплаты
/// Установление ежемесячной денежной выплаты отдельным категориям граждан в Российской Федерации
/// </summary>
public class _41_6_PfrAppointMonthlyCashPaymentsModel : AbstractAdditionalFormModel
{
    public _41_6_PfrAppointMonthlyCashPaymentsModel()
    {
        Customer = new CustomerType();
        Representative = new RepresentativeType();
        FamilyMembersList = new[]
       {
            new FamilyMembers()
        };
    }

    /// <summary>
    /// Заявитель
    /// </summary>
    public CustomerType Customer { get; set; }

    /// <summary>
    /// Представитель
    /// </summary>
    public RepresentativeType Representative { get; set; }

    /// <summary>
    /// Данные о других членах семьи Героя Советского Союза, Героя Российской Федерации
    /// или полного кавалера ордена Славы
    /// </summary>
    public FamilyMembers[] FamilyMembersList { get; set; }

    /// <summary>
    /// Место нахождения выплатного дела
    /// </summary>
    public string PaymentCaseLocation { get; set; }

    /// <summary>
    /// Категория лица, имеющего право на эжемесячную денежную выплату
    /// </summary>
    public string PersonCategory { get; set; }

    /// <summary>
    /// в соответствии с Федеральным законом
    /// </summary>
    public string Law { get; set; }

    /// <summary>
    /// наименование территориального органа ПФР, которым будет осуществляться ежемесячная денежная выплата
    /// </summary>
    public string PfrDepartmentPayName { get; set; }

    /// <summary>
    /// Сведения о документе, подтверждающем право гражданина на установление ежемесячной денежной выплаты
    /// Наименование правоустанавливающего документа
    /// </summary>
    public string DocConfirmRightName { get; set; }
    /// <summary>
    /// Серия документа, подтверждающего право на выплаты
    /// </summary>
    public string DocConfirmRightSeries { get; set; }

    /// <summary>
    /// Номер документа, подтверждающего право на выплаты
    /// </summary>
    public string DocConfirmRightNumber { get; set; }

    /// <summary>
    /// Дата выдачи документа, подтверждающего право на выплаты
    /// </summary>
    public string DocConfirmRightIssueDate { get; set; }

    /// <summary>
    /// Кем выдан документ, подтверждающий право на выплаты
    /// </summary>
    public string DocConfirmRightIssuer { get; set; }

    /// <summary>
    /// Получатель инфомарции о ходе и результатах заявления
    /// </summary>
    public string RecipientInformationCode { get; set; }
     

    /// <summary>
    /// Способ информирования о ходе и результате рассмотрения заявления
    /// 1 - Через «Личный кабинет» на сайте ПФР
    /// 2 - Через Единый портал государственных
    /// 3 - Путем передачи текстовых сообщений
    /// </summary>
    public string MethodResultCode { get; set; }

    /// <summary>
    /// тип связи
    /// </summary>
    public string MessageType { get; set; }

    /// <summary>
    /// на адрес электронной почты
    /// </summary> 
    public string MessageEmail { get; set; }

    /// <summary>
    /// на абонентский номер устройства подвижной радиотелефонной связи
    /// </summary> 
    public string MessagePhone { get; set; }

    /// <summary>
    /// тип идентификации
    /// </summary>
    public string VariantIdentity { get; set; }

    /// <summary>
    /// секретный вопрос
    /// </summary>
    public string SecretQuestionCode { get; set; }

    /// <summary>
    /// Ответ на котрольный вопрос 
    /// </summary>
    public string SecretQuestionAnswer { get; set; }

    /// <summary>
    /// Секретный код
    /// </summary>
    public string SecretCode { get; set; }

    public class CustomerType
    {
        /// <summary>
        /// Адрес места пребывания
        /// </summary>
        public string StayAddress { get; set; }

        /// <summary>
        /// Адрес фактического проживания
        /// </summary>
        public string ActualResidenceAddress { get; set; }

        /// <summary>
        /// Фамилия, которая была при рождении
        /// </summary>
        public string LastNameBirth { get; set; }

        /// <summary>
        /// Гражданство
        /// </summary>
        public string Citizenship { get; set; }
    }

    public class FamilyMembers
    {
        /// <summary>
        /// ФИО
        /// </summary>
        public string FIO { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public string BirthDate { get; set; }

        /// <summary>
        /// Степень родства
        /// </summary>
        public string Kinship { get; set; }
    }

    public class RepresentativeType
    {
        /// <summary>
        /// наименование организации (для представителя - организации)
        /// </summary>
        public string NameOrgan { get; set; }
        /// <summary>
        /// юридический адрес организации 
        /// </summary>
        public string OrganizationLegalAddress { get; set; }

        /// <summary>
        /// Место нахождения организации
        /// </summary>
        public string OrganizationLocation { get; set; }

        /// <summary>
        /// Наименование документа, подтверждающего полномочия представителя
        /// </summary>
        public string AuthorityDocName { get; set; }

        /// <summary>
        /// Серия и номер документа, подтверждающего полномочия представителя
        /// </summary>
        public string AuthorityDocSeriesNumber { get; set; }

        /// <summary>
        /// Дата выдачи документа, подтверждабщего полномочия представителя
        /// </summary>
        public string AuthorityDocIssueDate { get; set; }

        /// <summary>
        /// Кем выдан документ, подтверждающий полномочия представителя
        /// </summary>
        public string AuthorityDocIssuer { get; set; }

        /// <summary>
        /// Адрес места пребывания
        /// </summary>
        public string StayAddress { get; set; }

        /// <summary>
        /// Адрес фактического проживания
        /// </summary>
        public string ActualResidenceAddress { get; set; }
    }
}