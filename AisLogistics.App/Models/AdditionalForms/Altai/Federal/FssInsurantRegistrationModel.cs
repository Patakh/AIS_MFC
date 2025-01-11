namespace AisLogistics.App.Models.AdditionalForms;

public class FssInsurantRegistrationModel : AbstractAdditionalFormModel
{
    public FssInsurantRegistrationModel()
    {
        Address = new();
        CustomerFio = new();
        CustomerDoc = new();
        License = new();
        CivilContract = new();
        ActionAddress = new();
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
    /// Дата рождения
    /// </summary>
    public DateTime? BirthDate { get; set; }

    /// <summary>
    /// Место рождения
    /// </summary>
    public string BirthPlace { get; set; }

    /// <summary>
    /// Адрес
    /// </summary>
    public AddressType Address { get; set; }

    /// <summary>
    /// Телефон (с указанием кода)
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// Адрес электронной почты
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Документ, удостоверяющий личность заявителя
    /// </summary>
    public DocType CustomerDoc { get; set; }

    /// <summary>
    /// Наименование органа, осуществляющего государственную регистрацию
    /// </summary>
    public string RegOrganizationName { get; set; }

    /// <summary>
    /// Регистрационный номер
    /// </summary>
    public string RegNumber { get; set; }

    /// <summary>
    /// Дата государственной регистрации  
    /// </summary>
    public DateTime? RegDate { get; set; }

    /// <summary>
    /// . Сведения о выданных лицензиях (иных документах, дающих право физическому лицу заниматься
    /// в установленном законодательством Российской Федерации порядке частной практикой)
    /// </summary>
    public DocType License { get; set; }
    
    /// <summary>
    /// Гражданско-правовой договор
    /// </summary>
    public DocType CivilContract { get; set; }
    
    /// <summary>
    /// Основной вид деятельности
    /// </summary>
    public string ActionType { get; set; }
    
    /// <summary>
    /// Код по ОКВЭД2
    /// </summary>
    public string Okved2Code { get; set; }
    
    /// <summary>
    /// Адрес места осуществления деятельности
    /// </summary>
    public AddressType ActionAddress { get; set; }
    
    /// <summary>
    /// Телефон (с указанием кода) по месту осуществления деятельности
    /// </summary>
    public string ActionPhone { get; set; }
    
    /// <summary>
    /// Код по ОКДП
    /// </summary>
    public string Okdp { get; set; }
    
    /// <summary>
    /// Наименование налогового органа, поставившего физическое лицо на учет
    /// </summary>
    public string FnsDepartmentName { get; set; }
    
    /// <summary>
    /// ИНН
    /// </summary>
    public string Inn { get; set; }
    
    /// <summary>
    /// Счет в кредитной организации
    /// </summary>
    public string CreditOrganizationAccount { get; set; }

    /// <summary>
    /// Наименование кредитной организации
    /// </summary>
    public string CreditOrganizationName { get; set; }
    
    /// <summary>
    /// БИК
    /// </summary>
    public string Bik { get; set; }
    
    /// <summary>
    /// Регистрационный номер страхователя
    /// Заполняется в случае регистрации в связи с изменением места жительства.
    /// </summary>
    public string InsuredRegistrationNumber { get; set; }
    
    /// <summary>
    /// заключение гражданско-правового договора с физическим лицом
    /// </summary>
    public bool ContractWithFl { get; set; }

    /// <summary>
    /// Причина регистрации
    /// </summary>
    public string RegReasonCode { get; set; }
    
    /// <summary>
    /// Способ получения результата
    /// </summary>
    public string MethodResultCode { get; set; } 
 
    public class DocType
    {
        /// <summary>
        /// Код вида документа
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Серия документа
        /// </summary>
        public string Series { get; set; }

        /// <summary>
        /// Номер документа
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Дата выдачи документа
        /// </summary>        
        public DateTime? IssueDate { get; set; }

        /// <summary>
        /// Дата окончания или «бессрочно»
        /// </summary>
        public string EndDate { get; set; }

        /// <summary>
        /// Кем выдан документ
        /// </summary>
        public string Issuer { get; set; }
    }

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
        /// Номер дома (влоадения)
        /// </summary>
        public string House { get; set; }

        /// <summary>
        /// Номер корпуса (строения)
        /// </summary>
        public string Housing { get; set; }

        /// <summary>
        /// Номер квартиры
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