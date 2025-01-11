namespace AisLogistics.App.Models.DTO.Identity.Applicant
{
    public class LegalsDto
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Связь с типами юридических лиц
        /// </summary>
        public int SServicesCustomerTypeId { get; set; }
        /// <summary>
        /// инн организации
        /// </summary>
        public string CustomerInn { get; set; }
        /// <summary>
        /// ОКАТО
        /// </summary>
        public string CustomerOkato { get; set; }
        /// <summary>
        /// ОКТМО
        /// </summary>
        public string CustomerOktmo { get; set; }
        /// <summary>
        /// КОД региона
        /// </summary>
        public string CustomerCodeRegion { get; set; }
        /// <summary>
        /// КПП юридического лица
        /// </summary>
        public string CustomerKpp { get; set; }
        /// <summary>
        /// ОГРН юридического лица
        /// </summary>
        public string CustomerOgrn { get; set; }
        /// <summary>
        /// Адрес
        /// </summary>
        public string CustomerAddress { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Адрес детальный
        /// </summary>
        public string CustomerAddressDetail { get; set; }
        /// <summary>
        /// Должность руководителя
        /// </summary>
        public string HeadPosition { get; set; }
        /// <summary>
        /// Номер телефона 1
        /// </summary>
        public string CustomerPhone1 { get; set; }
        /// <summary>
        /// Номер телефона 2
        /// </summary>
        public string CustomerPhone2 { get; set; }
        /// <summary>
        /// Электронная почта заявителя
        /// </summary>
        public string CustomerEmail { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string HeadFirstName { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string HeadLastName { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string HeadSecondName { get; set; }
    }
}
