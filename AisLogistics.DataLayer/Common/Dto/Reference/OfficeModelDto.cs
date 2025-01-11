using System;
using System.ComponentModel.DataAnnotations;

namespace AisLogistics.DataLayer.Common.Dto.Reference
{
    public class OfficeModelDto
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Наименование филиала
        /// </summary>
        [Required]
        public string OfficeName { get; set; }

        /// <summary>
        /// Краткое наименование филиала
        /// </summary>
        [Required]
        public string OfficeNameSmall { get; set; }

        /// <summary>
        /// Мнемоника филиала
        /// </summary>
        [Required]
        public string OfficeMnemo { get; set; }

        /// <summary>
        /// Номер телефона филиала
        /// </summary>
        public string OfficePhoneNumber { get; set; }

        /// <summary>
        /// Адрес сайта филиала
        /// </summary>
        public string OfficeWebsite { get; set; }

        /// <summary>
        /// Адрес Skype для бесплатной удаленной консультации
        /// </summary>
        public string OfficeSkype { get; set; }

        /// <summary>
        /// Официальная почта филиала
        /// </summary>
        public string OfficeEmail { get; set; }

        /// <summary>
        /// Логин почты филиала
        /// </summary>
        public string OfficeEmailLogin { get; set; }

        /// <summary>
        /// Пароль почты филиала
        /// </summary>
        public string OfficeEmailPass { get; set; }

        /// <summary>
        /// Сервер почты филиала
        /// </summary>
        public string OfficeEmailServer { get; set; }

        /// <summary>
        /// Порт почты филиала
        /// </summary>
        public string OfficeEmailPort { get; set; }

        /// <summary>
        /// ИНН филиала - Идентификационный номер налогоплательщика
        /// </summary>
        public string OfficeInn { get; set; }

        /// <summary>
        /// ОГРН филиала - Основной государственный регистрационный номер
        /// </summary>
        public string OfficeOgrn { get; set; }

        /// <summary>
        /// ОКТМО филиала - Общероссийский классификатор территорий муниципальных образований
        /// </summary>
        public string OfficeOktmo { get; set; }

        /// <summary>
        /// ОКАТО филиала - Общероссийский классификатор объектов административно-территориального деления
        /// </summary>
        public string OfficeOkato { get; set; }

        /// <summary>
        /// КПП филиала - Код причины постановки на учет
        /// </summary>
        public string OfficeKpp { get; set; }

        /// <summary>
        /// Номер филиала для ИАС МКГУ(Информационно-аналитическая система мониторинга качества государственных услуг)
        /// </summary>
        public int? OfficeVendorId { get; set; }

        /// <summary>
        /// ЕСИА центр ID
        /// </summary>
        public string OfficeEsiaCentrId { get; set; }

        /// <summary>
        /// СНИЛС директора МФЦ для запросов ЕСИА
        /// </summary>
        public string EsiaOperatorSnils { get; set; }

        /// <summary>
        /// uuid филиала в системе МДМ
        /// </summary>
        public Guid? MdmUid { get; set; }

        public bool SendMdm { get; set; }

        /// <summary>
        /// Идентификатор МФЦ в ЦИК (для ВС &quot;Вид сведений для приема через ЕПГУ и МФЦ заявлений о включении избирателя в список избирателей по месту нахождения в день голосования на выборах в Российской Федерации&quot;
        /// </summary>
        public string OfficeCikId { get; set; }

        /// <summary>
        /// Наименование МФЦ для ЦИК
        /// </summary>
        public string OfficeCikName { get; set; }

        /// <summary>
        /// Количество населения на территории офиса
        /// </summary>
        public int? OfficeCountPopulation { get; set; }

        /// <summary>
        /// Адрес филиала
        /// </summary>
        [Required]
        public string OfficeAdress { get; set; }

        /// <summary>
        /// Географическая широта филиала
        /// </summary>
        public string OfficeLatitude { get; set; }

        /// <summary>
        /// Географическая долгота филиала
        /// </summary>
        public string OfficeLongitude { get; set; }

        /// <summary>
        /// Идентификатор МФЦ на ЕПГУ (интеграция с системой ЭОС Дело)
        /// </summary>
        public string OfficeEpguId { get; set; }

        /// <summary>
        /// ID  электронной очереди
        /// </summary>
        public string QueueId { get; set; }

        /// <summary>
        /// Номер для ВипНет ПФР
        /// </summary>
        public string OfficeNum { get; set; }

        /// <summary>
        /// Комментарий к записи
        /// </summary>
        public string Commentt { get; set; }

        /// <summary>
        /// Сотрудник добавивший
        /// </summary>
        public Guid SEmployeesIdAdd { get; set; }

        /// <summary>
        /// Сотрудник добавивший запись
        /// </summary>
        public string EmployeesFioAdd { get; set; }

        /// <summary>
        /// Идентификатор филиала ФРГУ
        /// </summary>
        public string OfficeFrguProviderId { get; set; }

        /// <summary>
        /// Идентификатор для загранпаспортов
        /// </summary>
        public string OfficeMvdOpvId { get; set; }

        /// <summary>
        /// Тип
        /// </summary>
        public int SOfficesTypeId { get; set; }

        /// <summary>
        /// Наименование в ФРГУ
        /// </summary>
        public string OfficeFrguName { get; set; }

        /// <summary>
        /// ФИО руководителя
        /// </summary>
        public string OfficeHeadName { get; set; }
        /// <summary>
        /// Головной ОФис
        /// </summary>
        public Guid ParentId { get; set; }

        /// <summary>
        /// Количество окон приема
        /// </summary>
        public int? ReceiveWindowsCount { get; set; }
        /// <summary>
        /// Ведет прием от заявителя
        /// </summary>
        public bool IsReceptionCustomer { get; set; }
        /// <summary>
        /// Орган предоставляющий услугу
        /// </summary>
        public bool IsProviderService { get; set; }

        /// <summary>
        /// FTP
        /// </summary>
        public Guid? SFtpId { get; set; }

        public string OfficesTypeName {get; set;}

        public string OffcesParentName { get; set; }

        public string FtpServerName { get; set; }

        public decimal? OfficeSquare { get; set; }
        public byte[] OfficeImage { get; set; }
    }
}
