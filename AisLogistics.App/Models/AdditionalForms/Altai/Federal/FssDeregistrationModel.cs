namespace AisLogistics.App.Models.AdditionalForms;

public class FssDeregistrationModel : AbstractAdditionalFormModel
{
    public FssDeregistrationModel()
    {
        CustomerFio = new();
        Address = new();        
    }
    
    /// <summary>
    /// наименование территориального органа Фонда социального страхования Российской Федерации
    /// </summary>
    public string FssDepartmentName { get; set; }    

    /// <summary>
    /// ФИО заявителя
    /// </summary>
    public FioType CustomerFio { get; set; }

    /// <summary>
    /// Адрес
    /// </summary>
    public AddressType Address { get; set; }

    /// <summary>
    /// Регистрационный номер
    /// </summary>
    public string RegNumber { get; set; }

    /// <summary>
    /// Наличие действующих гражданско-правовых договоров
    /// </summary>
    public bool HasCurrentContract { get; set; }

    /// <summary>
    /// Способ получения копии решения о снятии с регистрационного учета
    /// 1 - вручить
    /// 2 - направить по почте    
    /// </summary>
    public string MethodResultCode { get; set; }        
 
    public class AddressType
    {
        /// <summary>
        /// Почтовый индекс
        /// </summary>
        public string PostCode { get; set; }

        /// <summary>
        /// Код региона
        /// </summary>
        public string RegionCode { get; set; }

        /// <summary>
        /// Город, область, иной населенный пункт
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Улица (проспект, переулок)
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
        /// Квартира
        /// </summary>
        public string Flat { get; set; }
    }

    public class FioType
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
    }
}