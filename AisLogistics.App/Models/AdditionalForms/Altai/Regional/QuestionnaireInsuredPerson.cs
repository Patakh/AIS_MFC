using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Models.AdditionalForms.Regional
{
    /// <summary>
    /// Прием от граждан анкет в целях регистрации в системе обязательного пенсионного страхования
    /// </summary>
    public class QuestionnaireInsuredPerson : AbstractAdditionalFormModel
    {


        /// <summary>
        /// Код по ОКУД
        /// </summary>
        public string Code { get; set; }
        

        /// <summary>
        /// Ф
        /// </summary>
        public string F { get; set; }

        /// <summary>
        /// И
        /// </summary>
        public string I { get; set; }

        /// <summary>
        /// О
        /// </summary>
        public string O { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        public string Gender { get; set; }

       
        /// <summary>
        /// город (село, дер., …)
        /// </summary>
        public string BirthAddressCity { get; set; }

        /// <summary>
        /// район
        /// </summary>
        public string BirthAddressDistrict { get; set; }

        /// <summary>
        /// область (край, респ., …)
        /// </summary>
        public string BirthAddressArea { get; set; }

        /// <summary>
        /// страна
        /// </summary>
        public string BirthAddressCountry { get; set; }

        /// <summary>
        /// Гражданство
        /// </summary>
        public string Citizenship { get; set; }

        /// <summary>
        /// Адрес места регистрации
        /// </summary>
        public string RegistrationAddress { get; set; }

        /// <summary>
        /// Адрес регистрации Индекс
        /// </summary>
        public string RegistrationAddressIndex { get; set; }
        
        /// <summary>
        /// Адрес места жительства
        /// </summary>
        public string ResidenceAddress { get; set; }

        /// <summary>
        /// Адрес места жительства Индекс
        /// </summary>
        public string ResidenceAddressIndex { get; set; }

        /// <summary>
        /// Документ, удостоверяющий личность
        /// </summary>
        public string DocType { get; set; }
        
        /// <summary>
        /// Серия паспорта
        /// </summary>
        public string DocSeries { get; set; }

        /// <summary>
        /// Номер паспорта
        /// </summary>
        public string DocNumber { get; set; }

        /// <summary>
        /// Кем выдан паспорт
        /// </summary>
        public string DocIssuer { get; set; }

        /// <summary>
        /// Дата выдачи паспорта
        /// </summary>
        public string DocIssueDate { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }



    }
}
