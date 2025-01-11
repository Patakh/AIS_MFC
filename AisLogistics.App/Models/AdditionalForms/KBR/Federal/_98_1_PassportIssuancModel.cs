using AisLogistics.App.Models.AdditionalForms;
using System.ComponentModel;

namespace AisLogistics.App.Models;
public class _98_1_PassportIssuancModel : AbstractAdditionalFormModel
{

    public sealed class Address
    {

        /// <summary>
        /// Регион
        /// </summary>
        [DisplayName("Регион")]
        public string Region { get; set; }

        /// <summary>
        /// Район
        /// </summary>
        [DisplayName("Город/Район")]
        public string District { get; set; }

        /// <summary>
        /// Город, населенный пункт
        /// </summary>
        [DisplayName("село")]
        public string Locality { get; set; }

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
        /// Строение
        /// </summary>
        [DisplayName("Строение")]
        public string Building { get; set; }

        /// <summary>
        /// Квартира
        /// </summary>
        [DisplayName("Квартира")]
        public string Flat { get; set; }
    }

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
    /// Дата рождения
    /// </summary>
    [DisplayName("Дата рождения")]
    public string BirthDate { get; set; }

    /// <summary>
    /// Пол
    /// </summary>
    [DisplayName("Пол")]
    public string Gender { get; set; }

    /// <summary>
    /// Место рождения
    /// </summary>
    [DisplayName("Место рождения")]
    public string AddressBirth { get; set; }

    /// <summary>
    /// Семейное положение 
    /// </summary>
    [DisplayName("Семейное положение")]
    public string Fameli { get; set; }

    /// <summary>
    /// ФИО супруги (-а) 
    /// </summary>
    [DisplayName("ФИО супруги (-а)")]
    public string Wife { get; set; }

    /// <summary>
    /// Дата рождения 
    /// </summary>
    [DisplayName("Дата рождения")]
    public string WifeDateBirth { get; set; }

    /// <summary>
    /// Дата заключения брака (расторжения) брака 
    /// </summary>
    [DisplayName("Дата заключения брака (расторжения) брака")]
    public string FameliDate { get; set; }

    /// <summary>
    /// Наименование органа государственной регистрации заключения брака
    /// </summary>
    [DisplayName(" Наименование орган государственной регистрации заключения брака")]
    public string OrganBraka { get; set; }

    /// <summary>
    /// ФИО отца 
    /// </summary>
    [DisplayName("ФИО отца")]
    public string FioFather { get; set; }

    /// <summary>
    /// ФИО матери 
    /// </summary>
    [DisplayName("ФИО матери")]
    public string FioMother { get; set; }

    /// <summary>
    /// Адрес места жительства
    /// </summary>
    [DisplayName("Адрес места жительства")]
    public Address ResidenceAddress { get; set; }

    /// <summary>
    /// Место  
    /// </summary>
    [DisplayName("Место ")]
    public string Place { get; set; }

    /// <summary>
    /// Адрес места 
    /// </summary>
    [DisplayName("Адрес места")]
    public Address AddressPlace { get; set; }

    /// <summary>
    /// Телефон
    /// </summary>
    [DisplayName("Телефон")]
    public string Phone { get; set; }

    /// <summary>
    /// Адрес электронной почты(по желанию)
    /// </summary>
    [DisplayName("Email")]
    public string Email { get; set; }

    /// <summary>
    /// Состоял ли ранее в ином гражданстве
    /// </summary>
    [DisplayName("Состоял ли ранее в ином гражданстве")]
    public string LastGrajdan { get; set; }

    /// <summary>
    ///  иное гражданство
    /// </summary>
    [DisplayName("иное гражданство")]
    public string LastGrajdanContry { get; set; }

    /// <summary>
    ///  Основание приобретения гражданства Российской Федерации
    /// </summary>
    [DisplayName("Основание приобретения гражданства Российской Федерации")]
    public string ReasonGrajdanRF { get; set; }

    /// <summary>
    /// Прошу  
    /// </summary>
    [DisplayName("Прошу")]
    public string Please { get; set; }

    /// <summary>
    /// Дата заполнения  
    /// </summary>
    [DisplayName("Дата заполнения")]
    public string DataFillings { get; set; }

    /// <summary>
    /// выдать временное удостоверение личности  
    /// </summary>
    [DisplayName("выдать временное удостоверение личности")]
    public string TimeGrajdan { get; set; }

    /// <summary>
    /// Основание выдачи (замены) паспорта 
    /// </summary>
    [DisplayName("Основание выдачи (замены) паспорта")]
    public string Core { get; set; }

    /// <summary>
    /// Предъявленный документ  (сведения об утраченном (похищенном) паспорте)
    /// Серия 
    /// </summary>
    [DisplayName("Серия")]
    public string RipDocSeries { get; set; }

    /// <summary>
    /// Тип документа 
    /// </summary>
    [DisplayName("Тип документа")]
    public string RipTypeDoc { get; set; }

    /// <summary>
    /// Номер 
    /// </summary>
    [DisplayName("Номер")]
    public string RipDocNumber { get; set; }

    /// <summary>
    /// Кем выдан 
    /// </summary>
    [DisplayName("Кем выдан")]
    public string RipDocIssuer { get; set; }

    /// <summary>
    /// Дата выдачи 
    /// </summary>
    [DisplayName("Дата выдачи")]
    public string RipDocIssueDate { get; set; }

    /// <summary>
    /// Переменил(а) ФИО и другие анкетные данные с
    /// Фамилия
    /// </summary>
    [DisplayName("Фамилия")]
    public string ApLastName { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    [DisplayName("Имя")]
    public string ApFirstName { get; set; }

    /// <summary>
    /// Отчество
    /// </summary>
    [DisplayName("Отчество")]
    public string ApSecondName { get; set; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    [DisplayName("Дата рождения")]
    public string ApBirthDate { get; set; }

    /// <summary>
    /// Пол
    /// </summary>
    [DisplayName("Пол")]
    public string ApGender { get; set; }

    /// <summary>
    /// Место рождения
    /// </summary>
    [DisplayName("Место рождения")]
    public string ApAddressBirth { get; set; }

    /// <summary>
    /// Реквизиты документа, послужившего основанием для замены паспорта
    /// </summary>
    [DisplayName("Реквизиты документа")]
    public string RecvizitDoc { get; set; }

    /// <summary>
    /// Результаты проверок
    /// </summary>
    [DisplayName("Результаты проверок")]
    public string RezultSreach { get; set; }

    /// <summary>
    /// Принятое решение
    /// </summary>
    [DisplayName("Принятое решение")]
    public string Rezult { get; set; }

    /// <summary>
    /// Дата
    /// </summary>
    [DisplayName("Дата")]
    public string RezultDate { get; set; }

    /// <summary>
    /// ФИО начальника подразделения по вопросам миграции
    /// </summary>
    [DisplayName("ФИО начальника подразделения по вопросам миграции")]
    public string FioGeneral { get; set; }

    /// <summary>
    /// Поступил запрос из (наименование подразделения)
    /// </summary>
    [DisplayName("наименование подразделения")]
    public string Reqvest { get; set; }

    /// <summary>
    ///   в связи с (указать причину)
    /// </summary>
    [DisplayName("в связи с")]
    public string ReasonReqvest { get; set; }

    /// <summary>
    ///  Поступило сообщение из (наименование подразделения по вопросам миграции)
    /// </summary>
    [DisplayName("наименование подразделения по вопросам миграции)")]
    public string Reaspone { get; set; }

    /// <summary>
    ///  в связи с (указать причину)
    /// </summary>
    [DisplayName("в связи с")]
    public string ReasonReaspone { get; set; }

    /// <summary>
    ///  Паспорт уничтожен по акту 
    /// </summary>
    [DisplayName("наименование подразделения по вопросам миграции, уничтожившего паспорт")]
    public string NameRipPasport { get; set; }

    /// <summary>
    ///  Код подразделения 
    /// </summary>
    [DisplayName("Код подразделения")]
    public string CodeRipPasport { get; set; }

    /// <summary>
    ///  Акт номер 
    /// </summary>
    [DisplayName("Акт номер")]
    public string ActNumberRipPasport { get; set; }

    /// <summary>
    ///  дата
    /// </summary>
    [DisplayName("дата")]
    public string DateRipPasport { get; set; }

    /// <summary>
    ///  Другие сведения
    /// </summary>
    [DisplayName("Другие сведения")]
    public string DopInfo { get; set; }
}