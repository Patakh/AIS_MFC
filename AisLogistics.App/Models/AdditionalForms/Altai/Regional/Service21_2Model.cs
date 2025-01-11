using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.Serialization;

namespace AisLogistics.App.Models.AdditionalForms.Regional
{
    /// <summary>
    /// Аннулирование охотничьего билета
    /// </summary>
    public class Service21_2Model : AbstractAdditionalFormModel
    {

        public Service21_2Model()
        {
            
        }

        /// <summary>
        /// ФИО
        /// </summary>
        public string Fio { get; set; }

        /// <summary>
        /// почтовый адрес
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Pochta { get; set; }

        /// <summary>
        /// Серия охотничий билет
        /// </summary>
        public string BiletSeries { get; set; }

        /// <summary>
        /// Номер охотничий билет
        /// </summary>
        public string BiletNumber { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone { get; set; }
        
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }


        /// <summary>
        /// в связи с    
        /// </summary>
        public string Reason { get; set; }
        
        /// <summary>
        /// Приложение
        /// </summary>
        public string Doc { get; set; }

    }
}
