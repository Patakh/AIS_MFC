using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Models.AdditionalForms.Municipal
{
    /// <summary>
    ///           СОГЛАСИЕ
    /// на обработку персональных данных
    /// </summary> 
    public class _8_1_Model : AbstractAdditionalFormModel
    {
        /// <summary>
        /// Место направления заявления
        /// </summary>
        public string Recipient { get; set; }

        /// <summary>
        /// Заявитель
        /// </summary>
        public string Fio { get; set; }

        /// <summary>
        /// зарегистрированной (го) по адресу
        /// </summary>
        public string ResidenceAddress { get; set; }

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
    }
}
