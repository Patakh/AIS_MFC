namespace AisLogistics.App.Models;


public sealed class _61_ProvisionMonthlyPaymentBirthBornOrAdoptionChildModel : AbstractAdditionalFormModel
{
    #region блок1 
    /// <summary>
    /// фамилия при рождение
    /// </summary>
    public string LastNameBirth { get; set; }
    /// <summary>
    /// принадлежность к гражданству
    /// </summary>
    public string Citizenship { get; set; }
    #endregion
    #region блок2 
    /// <summary>
    /// принадлежность к гражданству
    /// </summary>
    public string RecipientCitizenship { get; set; }
    #endregion
    #region блок3
    public class Child
    {
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string SecondName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? DateBirth { get; set; }
        /// <summary>
        /// принадлежность к гражданству
        /// </summary>
        public string Citizenship { get; set; }
        /// <summary>
        /// Лишение родительских прав
        /// </summary>
        public bool DeprivationParentalRights { get; set; }
        /// <summary>
        /// Решения об отмене усыновления
        /// </summary>
        public bool DecisionCancelAdoption { get; set; }
        /// <summary>
        /// Прекратить выплату
        /// </summary>
        public bool IsPaymentStop { get; set; }
        /// <summary>
        /// Причина
        /// </summary>
        public string PaymentStop { get; set; }

    }
    /// <summary>
    /// Информация о ребенке
    /// </summary>
    public Child ChildInfo { get; set; }
    #endregion
    #region блок4
    public class Income
    {
        /// <summary>
        /// Сведения о доходах за период - начало
        /// </summary>
        public DateTime? PeriodStart { get; set; }
        /// <summary>
        /// Сведения о доходах за период - конец
        /// </summary>
        public DateTime? PeriodEnd { get; set; }
        /// <summary>
        /// Доходы, полученные от трудовой деятельности
        /// </summary>
        public string Work { get; set; }
        /// <summary>
        /// Денежное довольствие
        /// </summary>
        public string CashAllowance { get; set; }
        /// <summary>
        /// Выплаты социального характера
        /// </summary>
        public string SocialBenefits { get; set; }
        /// <summary>
        /// Иные полученные доходы
        /// </summary>
        public string OtherReceived { get; set; }
        /// <summary>
        /// В том числе
        /// </summary>
        public string Including { get; set; }
        /// <summary>
        /// Доходы, полученные от предпринимательской деятельности
        /// </summary>
        public string BusinessActivities { get; set; }
        /// <summary>
        ///Алименты
        /// </summary>
        public string Alimony { get; set; }
        /// <summary>
        /// Прочие доходы
        /// </summary>
        public string Other { get; set; }
    }
    /// <summary>
    /// Информация о доходах
    /// </summary>
    public Income IncomeInfo { get; set; }
    #endregion
    #region блок5 
    public class Payment
    {
        /// <summary>
        /// Кредитная организация
        /// </summary>
        public string CreditOrganization { get; set; }
        /// <summary>
        /// Бик
        /// </summary>
        public string BIK { get; set; }
        /// <summary>
        /// Номер счета 
        /// </summary>
        public string NumberScore { get; set; }
    }
    /// <summary>
    /// Информация об олпте
    /// </summary>
    public Payment PaymentInfo { get; set; }
    #endregion
    #region блок6
    /// <summary>
    /// Приложенные документы
    /// </summary>
    public AppliedDocument[] AppliedDocumentList { get; set; } = Array.Empty<AppliedDocument>();
    public class AppliedDocument
    {
        /// <summary>
        /// Наименование документа
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Количестов Экземпляров
        /// </summary>
        public int? NumdberOriginals { get; set; }
        /// <summary>
        /// Количество страниц
        /// </summary>
        public int? NumdberCopies { get; set; }
    }
    #endregion
}


public sealed class _61_ProvisionMonthlyPaymentBirthBornOrAdoptionChildModelV2 : AbstractAdditionalFormModel
{
    public _61_ProvisionMonthlyPaymentBirthBornOrAdoptionChildModelV2()
    {
        fio = new Fio();
        address = new Address();
        detailsOfDissolutionOrConclusion = new DetailsOfDissolutionOrConclusion();
        DetailsOfDeathSpouse = new DetailsOfDeath();
        DetailsOfDeathMother = new DetailsOfDeath();
        Spouseinfo = new SpouseInfo
        {
            fio = new Fio()
        };
        Child = new ChildInfo[]
        {
            new()
                    {
                        fio = new Fio()
                    }
        };
        AdditionalFamilyInformationtype = new AdditionalFamilyInformationType();
        Payment = new PaymentType
        {
            Address = new Address()
        };
    }
    public Fio fio { get; set; }
    public string Snils { get; set; }
    public string Status { get; set; }
    public string DocType { get; set; }
    public string Series { get; set; }
    public string Number { get; set; }
    public DateTime? IssuedDate { get; set; }
    public string IssuedBy { get; set; }
    public DateTime? BirthDate { get; set; }
    public string MaritalStatus { get; set; }
    public Address address { get; set; }
    public int ActOfDissolutionOrConclusionMadeByForeignState { get; set; }
    public DetailsOfDissolutionOrConclusion detailsOfDissolutionOrConclusion { get; set; }
    public int ActOfDeathSpouseMadeByForeignState { get; set; }
    public DetailsOfDeath DetailsOfDeathSpouse { get; set; }
    public string PlaceWork { get; set; }
    public string INNEmployer { get; set; }
    public string BasisForPayment { get; set; }
    public DetailsOfDeath DetailsOfDeathMother { get; set; }
    public SpouseInfo Spouseinfo { get; set; }
    public ChildInfo[] Child { get; set; }
    public AdditionalFamilyInformationType AdditionalFamilyInformationtype { get; set; }
    public PaymentType Payment { get; set; }

    public class Fio
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
    }
    public class Address
    {
        public string FiasHouseCode { get; set; }
        public string Town { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Building { get; set; }
        public string Apartmen { get; set; }
        public string PostalCode { get; set; }
        public string FullAddress { get; set; }
    }
    public class DetailsOfDissolutionOrConclusion
    {
        public string NumberAct { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string NameRegistrationAuthority { get; set; }
    }
    public class DetailsOfDeath
    {
        public string NumberAct { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string NameRegistrationAuthority { get; set; }
        public Fio fio { get; set; }
        public DateTime? BirthDate { get; set; }
    }
    public class SpouseInfo
    {
        public Fio fio { get; set; }
        public string Snils { get; set; }
        public string DocType { get; set; }
        public string Series { get; set; }
        public string Number { get; set; }
        public DateTime? IssuedDate { get; set; }
        public string IssuedBy { get; set; }
        public DateTime? BirthDate { get; set; }
        public string PlaceWork { get; set; }
        public string INNEmployer { get; set; }
        public int IsCurrentlyInPrison { get; set; }
        public string SubjectOfRF { get; set; }
        public int WasInPrison { get; set; }
        public string WasSubjectOfRF { get; set; }
    }

    public class ChildInfo
    {
        public Fio fio { get; set; }
        public string Snils { get; set; }
        public string Citizenship { get; set; }
        public string ActOfDissolutionOrConclusionMadeByForeignState { get; set; }
        public DetailsOfDissolutionOrConclusion detailsOfDissolutionOrConclusion { get; set; }
        public string DocType { get; set; }
        public string Series { get; set; }
        public string Number { get; set; }
        public string IssuedDate { get; set; }
        public string IssuedBy { get; set; }
        public DateTime? BirthDate { get; set; }
        public string MonthlyAllowance { get; set; }
        public string IsCurrentlyInPrison { get; set; }
        public string SubjectOfRF { get; set; }
        public string WasInPrison { get; set; }
        public string WasSubjectOfRF { get; set; }
    }
    public class AdditionalFamilyInformationType
    {
        public int TypeDelivery { get; set; }
        public string NameOrganization { get; set; }
        public Address Address { get; set; }
        public string CreditOrganization { get; set; }
        public string CorrespondentAccount { get; set; }
        public bool IHaveBeenWarned { get; set; }
        public bool Pensions { get; set; }
        public bool Compensation { get; set; }
        public bool ScientificPayments { get; set; }
        public bool LiveInNewSubjects { get; set; }
        public bool Svo { get; set; }
    }
    public class PaymentType
    {
        public int TypeDelivery { get; set; }
        public string NameOrganization { get; set; }
        public Address Address { get; set; }
        public string CreditOrganization { get; set; }
        public string CorrespondentAccount { get; set; }
        public bool IHaveBeenWarned { get; set; }
    }
}
