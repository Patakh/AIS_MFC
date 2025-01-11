using AisLogistics.App.Models.AdditionalForms;

namespace AisLogistics.App.Models;

/// <summary>
/// Осуществление миграционного учета иностранных граждан и лиц без гражданства в Российской Федерации
/// Уведомление об убытии иностранного гражданина или лица без гражданства из места пребывания
/// </summary>
public class _92_2_DepartureModel : AbstractAdditionalFormModel
{
    /// <summary>
    /// гражданство 
    /// </summary>
    public string Citizenship { get; set; }

    public string DepartureDate { get; set; } 
    public string InformationRepresentatives { get; set; }
    public Address AddressPlaceStay { get; set; }
    public Address ActualResidenceAddress { get; set; }
    public Person ReceivingParty { get; set; }
    public Document ReceivingPartyLegalDocument { get; set; }
    public Person Applicant { get; set; }

    public class Person
    {
        /// <summary>
        /// Тип
        /// </summary> 
        public string Type { get; set; }

        /// <summary>
        /// Пол
        /// </summary> 
        public string Gender { get; set; }

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
        /// ФИО в родительном падеже
        /// </summary>
        public string FIOGen { get; set; }

        /// <summary>
        /// гражданство 
        /// </summary>
        public string Citizenship { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary> 
        public string BirthDate { get; set; }

        /// <summary>
        /// Место рождения
        /// </summary> 
        public string BirthPlace { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary> 
        public string Phone { get; set; }

        public Document IdentityDocument { get; set; }

        /// <summary>
        /// Адрес места жительства
        /// </summary> 
        public Address ResidenceAddress { get; set; }
        

        /// <summary>
        /// Наименование и реквизиты документа, подтверждающего право пользования жилым помещением
        /// </summary>
        public string UseLivingSpaceDocument { get; set; }

        /// <summary>
        /// Наименование организации 
        /// </summary>
        public string OrganizationName { get; set; }

        /// <summary>
        /// ИНН
        /// </summary>
        public string OrganizationINN { get; set; }

        /// <summary>
        /// Адрес организации 
        /// </summary>
        public string OrganizationAdressRegistration { get; set; }
    }

    public class Address
    {
        /// <summary>
        /// Область, край, республика, АО
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Район
        /// </summary>
        public string District { get; set; }

        /// <summary>
        /// Город или другой населенный пункт
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Улица
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Тип собственности
        /// </summary>
        public string TypeOwnership { get; set; }

        /// <summary>
        /// Дом
        /// </summary>
        public string House { get; set; }

        /// <summary>
        /// Корпус
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Строение
        /// </summary>
        public string Building { get; set; }

        /// <summary>
        /// Тип жилищного помещения
        /// </summary>
        public string TypeHousing { get; set; }

        /// <summary>
        /// Квартира
        /// </summary>
        public string Flat { get; set; }

        /// <summary>
        /// Место пребывания
        /// </summary>
        public string PlaceStay { get; set; }

        /// <summary>
        /// Кадастровый номер земельного участка
        /// </summary>
        public string CadastralNumber { get; set; }
    }
      
    public class Document
    {

        /// <summary>
        /// Вид
        /// </summary>
        public string Type { get; set; }

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
        public string IssuerPlace { get; set; }

        /// <summary>
        /// Дата выдачи
        /// </summary>
        public string IssuerDate { get; set; }

        /// <summary>
        /// Действителен до
        /// </summary>
        public string ValidUntil { get; set; }
    }
}