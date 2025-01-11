using AisLogistics.App.Models.AdditionalForms;
using System.ComponentModel;

namespace AisLogistics.App.Models;

/// <summary>
/// Оформление и выдача паспортов гражданина Российской Федерации, 
/// удостоверяющих личность гражданина Российской Федерации за пределами территории Российской Федерации (5 лет)
/// </summary>
public class _99_2_InternationalPassportFiveYearModel : AbstractAdditionalFormModel
{  
    /// <summary>
    ///  Получено в электронном виде с Единого портала государственныx и муниципальных услуг и функций
    /// </summary> 
    public bool HasGosuslugi { get; set; }

    /// <summary>
    /// ранее имели другие фамилию, имя, отчество
    /// </summary> 
    public bool IsBefore { get; set; }

    /// <summary>
    /// Фамилия
    /// </summary> 
    public string LastNameBefore { get; set; }

    /// <summary>
    /// Имя
    /// </summary> 
    public string FirstNameBefore { get; set; }

    /// <summary>
    /// Отчество
    /// </summary> 
    public string SecondNameBefore { get; set; }

    /// <summary>
    /// Дата изменения
    /// </summary> 
    public string ShiftsDate { get; set; }

    /// <summary>
    /// Место изменения
    /// </summary> 
    public string ShiftsPlace { get; set; }

    /// <summary>
    /// Родитель
    /// Фамилия
    /// </summary> 
    public string ParentLastName { get; set; }

    /// <summary>
    /// Имя
    /// </summary> 
    public string ParentFirstName { get; set; }

    /// <summary>
    /// Отчество 
    /// </summary> 
    public string ParentSecondName { get; set; }

    /// <summary>
    /// Пол 
    /// </summary> 
    public string ParentGender { get; set; }

    /// <summary>
    /// Дата рождения 
    /// </summary> 
    public string ParentBirthDate{ get; set; }

    /// <summary>
    /// Место рождения (страна, республика, край, область, населенный пункт)
    /// </summary> 
    public string ParentBirthPlace{ get; set; }
     
    /// <summary>
    /// Других действующих паспортов не имею.
    /// </summary> 
    public bool OthersOverseasNotHas { get; set; }

    /// <summary>
    /// НЕ ВОЗРАЖАЮ ПРОТИВ ПОЛУЧЕНИЯ ПАСПОРТА
    /// </summary> 
    public bool DontMind { get; set; }

    /// <summary>
    /// Получение паспорта
    /// </summary> 
    public int GettingPassport { get; set; }

    /// <summary>
    /// Имеются документы, удостоверяющие личность гражданина Российской Федерации за пределами территории 
    /// Российской Федерации, в том числе содержащие электронный носитель информации(паспорта)
    /// </summary>
    public bool HasOverseas { get; set; }

    /// <summary>
    /// Адрес места жительства 
    /// </summary> 
    public Address ResidenceAddress { get; set; }

    /// <summary>
    /// Адрес 
    /// </summary> 
    public Address RegistrationAddress { get; set; }

    /// <summary>
    /// Адрес места жительства законного представителя
    /// </summary> 
    public Address RepresentativeResidenceAddress { get; set; }

    /// <summary>
    /// Адрес законного представителя
    /// </summary> 
    public Address RepresentativeRegistrationAddress { get; set; }

    /// <summary>
    /// Заграники
    /// </summary> 
    public Document Overseas1 { get; set; }
    public Document Overseas2 { get; set; }
     
    /// <summary>
    /// Документ, подтверждающий права законного представителя
    /// </summary> 
    public Document RepresentativeRigtDocument { get; set; }

    public class Address
    {
        /// <summary>
        /// Страна
        /// </summary> 
        public string Country { get; set; }

        /// <summary>
        /// Регион
        /// </summary> 
        public string Region { get; set; }

        /// <summary>
        /// Город/Район
        /// </summary> 
        public string District { get; set; }

        /// <summary>
        /// Село
        /// </summary> 
        public string Locality { get; set; }

        /// <summary>
        /// Улица
        /// </summary> 
        public string Street { get; set; }

        /// <summary>
        /// Дом
        /// </summary> 
        public string House { get; set; }

        /// <summary>
        /// Корпус
        /// </summary> 
        public string Housing { get; set; }

        /// <summary>
        /// Строение
        /// </summary> 
        public string Building { get; set; }

        /// <summary>
        /// Квартира
        /// </summary> 
        public string Flat { get; set; }

        /// <summary>
        /// Дата регистрации
        /// </summary> 
        public string DateRegstration { get; set; }

        /// <summary>
        /// Адрес
        /// </summary> 
        public string AddressType { get; set; }


        /// <summary>
        /// Дата регистрации
        /// </summary> 
        public string RegistrateDate { get; set; }

        /// <summary>
        /// Срок регистрации 
        /// </summary> 
        public string WithDate { get; set; }

        /// <summary>
        /// по
        /// </summary> 
        public string ByDate { get; set; }
    }
     
    public class Document
    { 
        /// <summary>
        /// Серия 
        /// </summary>
        public string Series { get; set; }

        /// <summary>
        /// Номер 
        /// </summary> 
        public string Number { get; set; }

        /// <summary>
        /// Кем выдан 
        /// </summary> 
        public string Issuer { get; set; }

        /// <summary>
        /// Дата выдачи 
        /// </summary> 
        public string IssueDate { get; set; }

        /// <summary>
        /// Утрачен
        /// </summary> 
        public bool Lost { get; set; }

        /// <summary>
        /// Будет представлен для аннулирования
        /// </summary> 
        public bool IsCancellation { get; set; }
    }
}