using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Models.AdditionalForms.Municipal
{
    /// <summary>
    ///                         ЗАЯВЛЕНИЕ 
    /// Прошу предоставить разрешение на осуществление земляных работ
    /// </summary>
    public class _30_4_Model : AbstractAdditionalFormModel
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
        /// адрес места жительства 
        /// </summary>
        public string AdressRecipient { get; set; }

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
        /// телефон для связи
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// вид работы
        /// </summary>
        public string TypeWork { get; set; }

        /// <summary>
        /// на срок : с
        /// </summary>
        public string With { get; set; }

        /// <summary>
        ///  по
        /// </summary>
        public string Before { get; set; }

        /// <summary>
        ///  по адресу 
        /// </summary>
        public string Adress { get; set; }
    }
}
    