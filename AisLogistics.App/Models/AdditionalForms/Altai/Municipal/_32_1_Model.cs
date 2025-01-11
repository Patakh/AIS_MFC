using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Models.AdditionalForms.Municipal
{
    /// <summary>
    ///                         Заявление
    ///  о прекращении действия свидетельства об осуществлении перевозок
    ///            по маршруту регулярных перевозок и карты
    ///                 маршрута регулярных перевозок
    /// </summary> 
    public class _32_1_Model : AbstractAdditionalFormModel
    { 
        /// <summary>
        /// Место направления заявления
        /// </summary>
        public string Recipient { get; set; }

        /// <summary>
        /// ФИО
        /// </summary>
        public string Fio { get; set; }

        /// <summary>
        /// серия
        /// </summary>
        public string Series { get; set; }

        /// <summary>
        /// номер
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Кем выдан 
        /// </summary>
        public string DocIssuer { get; set; }

        /// <summary>
        /// Дата выдачи 
        /// </summary>
        public DateTime? DocIssueDate { get; set; }

        /// <summary>
        /// Адрес места жительства
        /// </summary>
        public string AddressLife { get; set; }

        /// <summary>
        /// телефон для связи
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// адрес электронной почты
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        /// ИНН
        /// </summary>
        public string INN { get; set; }

        /// <summary>
        /// начальный 
        /// </summary>
        public string Elementary { get; set; }

        /// <summary>
        /// конечный пункт маршрута 
        /// </summary>
        public string FinalRoute { get; set; }

        /// <summary>
        /// ФИО 
        /// Представитель или доверенное лицо заявителя
        /// ФИО 
        /// </summary>
        public string FioRepresentative { get; set; }

        /// <summary>
        /// серия
        /// </summary>
        public string SeriesRepresentative { get; set; }

        /// <summary>
        /// номер
        /// </summary>
        public string NumberRepresentative { get; set; }

        /// <summary>
        /// Кем выдан 
        /// </summary>
        public string DocIssuerRepresentative { get; set; }

        /// <summary>
        /// Дата выдачи 
        /// </summary>
        public DateTime? DocIssueDateRepresentative { get; set; }


        /// <summary>
        /// Доверенность (реквизиты)
        /// номер
        /// </summary>
        public string NumberAttorney { get; set; }

        /// <summary>
        /// Дата выдачи 
        /// </summary>
        public DateTime? DocIssueDateAttorney { get; set; }
       
    }
}
