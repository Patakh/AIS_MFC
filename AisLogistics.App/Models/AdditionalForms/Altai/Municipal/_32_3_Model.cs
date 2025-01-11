using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Models.AdditionalForms.Municipal
{
    /// <summary>
    ///             СОГЛАСИЕ
    ///  на обработку персональных данных
    /// </summary> 
    public class _32_3_Model : AbstractAdditionalFormModel
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
        /// Адрес регистрации
        /// </summary>
        public string AdressRegister { get; set; }

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
        /// телефон
        /// </summary>
        public string Phone { get; set; }
    }
}
