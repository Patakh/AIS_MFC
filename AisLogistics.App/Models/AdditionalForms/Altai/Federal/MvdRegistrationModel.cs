using System.ComponentModel;

namespace AisLogistics.App.Models.AdditionalForms
{
    public sealed class MvdRegistrationModel : AbstractAdditionalFormModel
    {
        public MvdRegistrationModel()
        {
            RegistrationAddress = new();
            ProvidedAddress = new();
            RegistrationAddressPrev = new();
            RegistrationNewAddress = new();
            CountryPrev = new();
        }

        public Person Applicant { get; set; }
        public class Person
        {   
            /// <summary>
            /// Фамилия
            /// </summary>
            [DisplayName("Фамилия")]
            public string LastName { get; set; }

            /// <summary>
            /// Имя
            /// </summary>
            [DisplayName("Имя")]
            public string FirstName { get; set; }

            /// <summary>
            /// Отчество
            /// </summary>
            [DisplayName("Отчество")]
            public string SecondName { get; set; }

            /// <summary>
            /// ФИО в родительном падеже
            /// </summary>
            [DisplayName("ФИО")]
            public string FIOGen { get; set; }
             
            /// <summary>
            /// Дата рождения
            /// </summary>
            [DisplayName("Дата рождения")]
            public DateTime? BirthDate { get; set; }

            /// <summary>
            /// СНИЛС
            /// </summary>
            [DisplayName("СНИЛС")]
            public string Snils { get; set; }
            
            /// <summary>
            /// Степень родства
            /// </summary>
            [DisplayName("Степень родства")]
            public string RelationDegree { get; set; }

            /// <summary>
            /// Адрес регистрации
            /// </summary>
            [DisplayName("Адрес регистрации")]
            public Address RegistrationAddress { get; set; }

            /// <summary>
            /// Адрес места жительства
            /// </summary>
            [DisplayName("Адрес места жительства")]
            public Address ResidenceAddress { get; set; }

            /// <summary>
            /// Тип документа
            /// </summary>
            [DisplayName("Тип документа")]
            public string DocType { get; set; }

            /// <summary>
            /// Серия 
            /// </summary>
            [DisplayName("Серия")]
            public string DocSeries { get; set; }

            /// <summary>
            /// Номер 
            /// </summary>
            [DisplayName("Номер")]
            public string DocNumber { get; set; }

            /// <summary>
            /// Кем выдан 
            /// </summary>
            [DisplayName("Кем выдан")]
            public string DocIssuer { get; set; }


            /// <summary>
            /// Код подразделения
            /// </summary>
            [DisplayName("Код подразделения")]
            public string DocIssuerCode { get; set; }

            /// <summary>
            /// Дата выдачи 
            /// </summary>
            [DisplayName("Дата выдачи")]
            public string DocIssueDate { get; set; }



        }
        public string BasisInfo { get; set; }

        /// <summary>
        /// место рождения
        /// </summary>
        [DisplayName("место рождения")]
        public string BirthPlace { get; set; }
        
        /// <summary>
        /// место рождения
        /// </summary>
        [DisplayName("место рождения субъект")]
        public string BirthPlaceSubject { get; set; }

        /// <summary>
        /// код по ОКСМ
        /// </summary>
        [DisplayName("код по ОКСМ")]
        public string BirthPlaceCountryCod { get; set; }
        
        /// <summary>
        /// место рождения
        /// </summary>
        [DisplayName("место рождения ")]
        public string BirthPlaceCountry { get; set; }

        /// <summary>
        /// Адрес места регистрации(новое место жительства или место пребывания)
        /// </summary>
        [DisplayName("Адрес места регистрации(новое место жительства или место пребывания)")]
        public Address RegistrationNewAddress { get; set; }

        /// <summary>
        /// откуда прибыл
        /// </summary>
        [DisplayName("Адрес откуда прибыл")]
        public Address CountryPrev { get; set; }
        
        /// <summary>
        /// Гражданство
        /// </summary>
        [DisplayName("Гражданство")]
        public string Citizenship { get; set; }
        
        /// <summary>
        /// Гражданство
        /// </summary>
        [DisplayName("Гражданство предыдущее")]
        public string CitizenshipCod { get; set; }
        
        /// <summary>
        /// Снилс
        /// </summary>
        [DisplayName("Снилс")]
        public string Snils { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        [DisplayName("Пол")]
        public string Gender { get; set; }

        /// <summary>
        /// № заявления
        /// </summary>
        [DisplayName("№ заявления")]
        public string StatementNumber { get; set; }

        /// <summary>
        /// Семейное положение
        /// </summary>
        [DisplayName("Семейное положение")]
        public string FamilyStatus { get; set; }

        /// <summary>
        /// Уровень образования
        /// </summary>
        [DisplayName("Уровень образования")]
        public string Education { get; set; }

        /// <summary>
        /// Вид занятий (профессия)
        /// </summary>
        [DisplayName("Вид занятий (профессия)")]
        public string Profession { get; set; }

        /// <summary>
        /// Основное обстоятельство
        /// </summary>
        [DisplayName("Основное обстоятельство")]
        public string RelocationReason { get; set; }

        /// <summary>
        /// Год, с которого проживал
        /// </summary>
        [DisplayName("Год, с которого проживал ")]
        public string RegistrationPrevYearStart { get; set; }
        
        /// <summary>
        /// Дата окончания срока пребывания
        /// </summary>
        [DisplayName("Дата окончания срока пребывания")]
        public string StayPeriodEnd { get; set; }
        
        /// <summary>
        /// Дата окончания срока пребывания
        /// </summary>
        [DisplayName("Вид регистрации")]
        public string RegistrationType { get; set; }

        /// <summary>
        /// телефон
        /// </summary>
        [DisplayName("телефон")]
        public string Phone { get; set; }


        public sealed class Address
        {
            /// <summary>
            /// Полный адрес
            /// </summary>
            [DisplayName("Полный адрес")]
            public string FullAdress { get; set; }

            /// <summary>
            /// Государство (код ОКСМ)
            /// </summary>
            [DisplayName("Государство")]
            public string Country { get; set; }

            /// <summary>
            /// Субъект Российской Федерации
            /// </summary>
            [DisplayName("Субъект Российской Федерации")]
            public string Region { get; set; }

            /// <summary>
            /// Муниципальный район, городской округ; внутригородское муниципальное образование города
            /// федерального значения.
            /// </summary>
            [DisplayName("Муниципальный район, городской округ")]
            public string Area { get; set; }

            /// <summary>
            /// Городское/сельское поселение
            /// </summary>
            [DisplayName("Городское/сельское поселение")]
            public string CitySettlement { get; set; }

            /// <summary>
            /// Город, поселок, сельский населенный пункт
            /// </summary>
            [DisplayName("Город, поселок, сельский населенный пункт")]
            public string Locality { get; set; }

            /// <summary>
            /// Внутригородской район, административный район (округа) города федерального значения
            /// </summary>
            [DisplayName("Внутригородской район, административный район (округа) города федерального значения")]
            public string IntracityTerritory { get; set; }

            /// <summary>
            /// Улица
            /// </summary>
            [DisplayName("Улица")]
            public string Street { get; set; }

            /// <summary>
            /// Дом
            /// </summary>
            [DisplayName("Дом")]
            public string House { get; set; }

            /// <summary>
            /// Корпус
            /// </summary>
            [DisplayName("Корпус")]
            public string Housing { get; set; }

            /// <summary>
            /// Квартира
            /// </summary>
            [DisplayName("Квартира")]
            public string Flat { get; set; }
        }
        public Person LegalRepresentative { get; set; }

        public Person OwnerRoom { get; set; }
      
        /// <summary>
        /// Законный представитель
        /// </summary>
        [DisplayName("Законный представитель")]
        public string LegalRepresentativeType { get; set; }

        /// <summary>
        /// Предыдущее место жительства (откуда прибыл)      
        /// </summary>
        [DisplayName("Предыдущее место жительства (откуда прибыл)")]
        public Address RegistrationAddress { get; set; }

        /// <summary>
        /// По адресу     
        /// </summary>
        [DisplayName("По адресу")]
        public Address ProvidedAddress { get; set; }

        /// <summary>
        /// документ, являющийся в соответствии с жилищным законодательством Российской Федерации основанием для вселения
        /// </summary>
        [DisplayName("документ, в соответствии с жилищным законодательством РФ основанием для вселения")]
        public string BasisMovingInto { get; set; }

        /// <summary>
        /// Принятое решение
        /// </summary>
        [DisplayName("Принятое решение")]
        public string Decision { get; set; }

        /// <summary>
        /// Дата подачи заявления
        /// </summary>
        [DisplayName("Дата подачи заявления")]
        public string FeedsDate { get; set; }

        /// <summary>
        /// Дата принятия заявления
        /// </summary>
        [DisplayName("Дата принятия заявления")]
        public string AcceptanceDate { get; set; }

        /// <summary>
        /// Свидетельство о регистрации по месту жительства лица не достигшего 14 лет №
        /// </summary>
        [DisplayName("Свидетельство о регистрации по месту жительства лица не достигшего 14 лет №")]
        public string RegistrationCert { get; set; }

        /// <summary>
        /// Адрес места жительства
        /// </summary>
        [DisplayName("Адрес места жительства")]
        public Address RegistrationAddressPrev { get; set; }
        
        /// <summary>
        /// Орган снятия с регистрационного учета
        /// </summary>
        [DisplayName("Орган снятия с регистрационного учета")]
        public string organizationWithdrawal { get; set; }
    }
}