using AisLogistics.App.Models.AdditionalForms;

namespace AisLogistics.App.Models;

/// <summary>
/// Назначение и выплата ежемесячной денежной компенсации расходов на оплату жилого помещения и коммунальных услуг отдельным категориям граждан
/// </summary>
public class _28_IndividualCategoriesCompensationModel : AbstractAdditionalFormModel
{
    public _28_IndividualCategoriesCompensationModel()
    {
        PersonRegisteredList = new[]
        {
            new PersonRegistered()
        };

        PaymentHousing = new()
        {
            LandscapingList = new[]
            {
              new LandscapingData()
           }
        };
        Electric = new()
        {
            LandscapingList = new[]
            {
              new LandscapingData()
           }
        };
        MainsGas = new()
        {
            LandscapingList = new[]
            {
              new LandscapingData()
           }
        };
        ColdWater = new()
        {
            LandscapingList = new[]
            {
              new LandscapingData()
           }
        };
        WaterDisposal = new()
        {
            LandscapingList = new[]
            {
              new LandscapingData()
           }
        };
        CentralHeating = new()
        {
            LandscapingList = new[]
            {
              new LandscapingData()
           }
        };
        TKO = new()
        {
            LandscapingList = new[]
           {
              new LandscapingData()
           }
        };
    }

    /// <summary>
    /// название кредитной организации
    /// </summary>
    public string NameCreditOrgan { get; set; }

    /// <summary>
    /// лицевой счет
    /// </summary>
    public string PersonalAccount { get; set; }

    /// <summary>
    /// почтовое отделение
    /// </summary>
    public string PostOffice { get; set; }

    /// <summary>
    /// выплату через
    /// </summary>
    public string PaymentMethod { get; set; }

    /// <summary>
    /// Указать льготное отделение
    /// </summary>
    public string Categories { get; set; }

    /// <summary>
    ///Принадлежность жилого фонда
    /// </summary>
    public string AffiliationHousingStock { get; set; }

    /// <summary>
    /// Вид жилищного фонда
    /// </summary>
    public string TypeHousingStock { get; set; }

    /// <summary>
    /// Вид жилищного помещения
    /// </summary>
    public string TypeHousing { get; set; }

    /// <summary>
    /// Общая площадь (кв, м)
    /// </summary>
    public string TotalArea { get; set; }

    /// <summary>
    /// количество комнат
    /// </summary>
    public string NumberRooms { get; set; }

    /// <summary>
    /// количество этажей в доме
    /// </summary>
    public string NumberFloors { get; set; }

    /// <summary>
    /// количество зарегистрированных лиц
    /// </summary>
    public string NumberRegisteredPersons { get; set; }

    /// <summary>
    /// год постройки
    /// </summary>
    public string YearConstruction { get; set; }

    /// <summary>
    ///  о гражданах, зарегистрированных по месту жительства
    /// </summary>
    public PersonRegistered[] PersonRegisteredList { get; set; }

    /// <summary>
    /// Оплата жилья
    /// </summary>
    public Landscaping PaymentHousing { get; set; }

    /// <summary>
    /// Электроэнергия
    /// </summary>
    public Landscaping Electric { get; set; }

    /// <summary>
    /// Сетевой газ
    /// </summary>
    public Landscaping MainsGas { get; set; }

    /// <summary>
    /// Холодное водоснабжение
    /// </summary>
    public Landscaping ColdWater { get; set; }

    /// <summary>
    /// Водоотведение
    /// </summary>
    public Landscaping WaterDisposal { get; set; }

    /// <summary>
    /// Централизованное отопление
    /// </summary>
    public Landscaping CentralHeating { get; set; }

    /// <summary>
    /// Обращение TKO
    /// </summary>
    public Landscaping TKO { get; set; }

    public class PersonRegistered
    {
        /// <summary>
        /// ФИО
        /// </summary>
        public string FIO { get; set; }

        /// <summary>
        /// Адрес регистрации
        /// </summary>
        public string RegistrationAddress { get; set; }

        /// <summary>
        /// Отметка о постоянной (временной) регистрации
        /// </summary>
        public string RegistrationMark { get; set; }

        /// <summary>
        /// Степень родства
        /// </summary>
        public string DegreeKinship { get; set; }

        /// <summary>
        /// Примечание
        /// </summary>
        public string Note { get; set; }
    }

    public class Landscaping
    {

        /// <summary>
        /// Тип коммунальной услуги
        /// </summary>
        public string Type { get; set; }

        public LandscapingData[] LandscapingList { get; set; }
    }

    public class LandscapingData
    {

        /// <summary>
        /// Наименование коммунальной услуги
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Поставщик услуг
        /// </summary>
        public string Provider { get; set; }

        /// <summary>
        /// № лицевого счета
        /// </summary>
        public string PersonalAccount { get; set; }

        /// <summary>
        /// Наличие прибора учета (да/нет)
        /// </summary>
        public string AvailabilityMeteringDevice { get; set; }

        /// <summary>
        /// Наличие (отсутствие) задолженности
        /// </summary>
        public string HasArrears { get; set; }
    }
}