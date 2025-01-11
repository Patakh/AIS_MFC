using AisLogistics.App.Models.AdditionalForms;
using System.ComponentModel;

namespace AisLogistics.App.Models;

/// <summary>
/// Оформление и выдача паспортов гражданина Российской Федерации, 
/// удостоверяющих личность гражданина Российской Федерации за пределами территории Российской Федерации (5 лет)
/// </summary>
public class _99_1_InternationalPassportFiveYearModel : AbstractAdditionalFormModel
{
    public _99_1_InternationalPassportFiveYearModel()
    {
        AppliedDocumentList = new[]
        {
                new AppliedDocument(),
            };

    } 

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
    /// Место смены 
    /// </summary> 
    public string ShiftsPlace { get; set; }

    /// <summary>
    /// Адрес места жительства 
    /// </summary> 
    public Address ResidenceAddress { get; set; }

    /// <summary>
    /// Адрес 
    /// </summary> 
    public Address RegistrationAddress { get; set; }

    /// <summary>
    /// Получение паспорта
    /// </summary> 
    public int GettingPassport { get; set; }

    /// <summary>
    /// Имеются ли обстоятельства, при которых может быть ограничено Ваше право на выезд из Российской Федерации
    /// </summary> 
    public bool IsLimitedDeparture { get; set; }

    public bool LimitedDepartureSet0 { get; set; }
    public bool LimitedDepartureSet1 { get; set; }
    public bool LimitedDepartureSet2 { get; set; }
    public bool LimitedDepartureSet3 { get; set; }
    public bool LimitedDepartureSet4 { get; set; }

    /// <summary>
    /// допуск к государственной тайне
    /// </summary> 
    public bool IsRoote { get; set; }

    /// <summary>
    /// Организация
    /// </summary> 
    public string RootOrganization { get; set; }

    /// <summary>
    /// Год
    /// </summary> 
    public string RootDate { get; set; }

    /// <summary>
    ///  препятствия выезда за границу
    /// </summary> 
    public bool IsObstacles { get; set; }

    /// <summary>
    /// Организация
    /// </summary> 
    public string ObstaclesOrganization { get; set; }

    /// <summary>
    /// Год
    /// </summary> 
    public string ObstaclesDate { get; set; }

    /// <summary>
    /// Имеются документы, удостоверяющие личность гражданина Российской Федерации за пределами территории 
    /// Российской Федерации, в том числе содержащие электронный носитель информации(паспорта)
    /// </summary>
    public bool HasOverseas { get; set; }

    /// <summary>
    ///  Прошу внести в мой паспорт сведения о моих детях – гражданах Российской Федерации в возрасте до 14 лет
    /// </summary> 
    public bool IsInsert { get; set; }

    /// <summary>
    /// Подаю заявление в отношении гражданина, признанного судом недееспособным (ограниченно дееспособным)
    /// </summary> 
    public bool IsServing { get; set; }

    /// <summary>
    /// Заграники
    /// </summary> 
    public OverseasDocument Overseas1 { get; set; }
    public OverseasDocument Overseas2 { get; set; }

    /// <summary>
    /// Других действующих паспортов не имею.
    /// </summary> 
    public bool OthersOverseasNotHas { get; set; }

    public sealed class Address
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

    public AppliedDocument[] AppliedDocumentList { get; set; }

    public class AppliedDocument
    {
        /// <summary>
        /// поступления
        /// </summary>
        public string ReceiptsDate { get; set; }

        /// <summary>
        /// увольнения
        /// </summary>
        public string DismissalsDate { get; set; }

        /// <summary>
        /// Должность и место работы,номер войсковой части
        /// </summary>
        public string Post { get; set; }

        /// <summary>
        /// Адрес организации, войсковой части
        /// </summary>
        public string AdressOrganization { get; set; }
    }

    public class OverseasDocument
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