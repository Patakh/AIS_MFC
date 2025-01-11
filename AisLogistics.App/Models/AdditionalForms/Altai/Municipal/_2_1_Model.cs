using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Models.AdditionalForms.Municipal
{
    /// <summary>
    ///           СОГЛАСИЕ 
    /// на обработку персональных данных
    /// </summary>
    public class _2_1_Model : AbstractAdditionalFormModel
    {
        /// <summary>
        /// Место направления заявления
        /// </summary>
        public string Recipient { get; set; }

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

        /// <summary>
        /// Адрес регистрации
        /// </summary>
        public string ResidenceAddress { get; set; }

        /// <summary>
        /// серия 
        /// </summary>
        public string Seria { get; set; }

        /// <summary>
        /// номер
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        ///  дата выдачи 
        /// </summary>
        public DateTime? Issued { get; set; }

    }
}
    