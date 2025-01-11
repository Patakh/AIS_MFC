using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Models.AdditionalForms.Regional
{
    /// <summary>
    /// Прием заявления о выдаче дубликата свидетельства обязательного пенсионного страхования
    /// </summary>
    public class DuplicateExtraditionSnils : AbstractAdditionalFormModel
    {


        /// <summary>
        /// Код по ОКУД
        
        public string Code { get; set; }


        /// <summary>
        /// Данные, указанные в страховом свидетельстве
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

        /// </summary>


        /// <summary>
        /// Данные, действительные в настоящее время (указать только изменившиеся данные)
        /// </summary>

        /// <summary>
        /// Ф
        /// </summary>
        public string F_Changed { get; set; }

        /// <summary>
        /// И
        /// </summary>
        public string I_Changed { get; set; }

        /// <summary>
        /// О
        /// </summary>
        public string O_Changed { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime? BirthDate_Changed { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        public string Gender_Changed { get; set; }

       
        /// <summary>
        /// город (село, дер., …)
        /// </summary>
        public string BirthAddressCity_Changed { get; set; }

        /// <summary>
        /// район
        /// </summary>
        public string BirthAddressDistrict_Changed { get; set; }

        /// <summary>
        /// область (край, респ., …)
        /// </summary>
        public string BirthAddressArea_Changed { get; set; }

        /// <summary>
        /// страна
        /// </summary>
        public string BirthAddressCountry_Changed { get; set; }

        /// <summary>
        /// Гражданство
        /// </summary>
        public string Citizenship_Changed { get; set; }

        /// <summary>
        /// Адрес места регистрации
        /// </summary>
        public string RegistrationAddress_Changed { get; set; }

        /// <summary>
        /// Адрес регистрации Индекс
        /// </summary>
        public string RegistrationAddressIndex_Changed { get; set; }
        
        /// <summary>
        /// Адрес места жительства
        /// </summary>
        public string ResidenceAddress_Changed { get; set; }

        /// <summary>
        /// Адрес места жительства Индекс
        /// </summary>
        public string ResidenceAddressIndex_Changed { get; set; }

        /// <summary>
        /// Документ, удостоверяющий личность
        /// </summary>
        public string DocType_Changed { get; set; }
        
        /// <summary>
        /// Серия паспорта
        /// </summary>
        public string DocSeries_Changed { get; set; }

        /// <summary>
        /// Номер паспорта
        /// </summary>
        public string DocNumber_Changed { get; set; }

        /// <summary>
        /// Кем выдан паспорт
        /// </summary>
        public string DocIssuer_Changed { get; set; }

        /// <summary>
        /// Дата выдачи паспорта
        /// </summary>
        public string DocIssueDate_Changed { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone_Changed { get; set; }
        
    }
}
