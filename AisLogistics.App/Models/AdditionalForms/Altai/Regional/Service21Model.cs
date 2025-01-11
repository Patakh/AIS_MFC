using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.Serialization;

namespace AisLogistics.App.Models.AdditionalForms.Regional
{
    /// <summary>
    /// Выдача охотничьего билета
    /// </summary>
    public class Service21Model : AbstractAdditionalFormModel
    {

        public Service21Model()
        {
            
        }

        /// <summary>
        /// Получатель заявления
        /// </summary>
        public string Recipient { get; set; }

        /// <summary>
        /// ФИО
        /// </summary>
        public string Fio { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Место рождения
        /// </summary>
        public string ResidenceAddress { get; set; }

        /// <summary>
        /// почтовый адрес
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Pochta { get; set; }

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
        /// Серия Членский охотничий билет
        /// </summary>
        public string BiletSeries { get; set; }

        /// <summary>
        /// Номер Членский охотничий билет
        /// </summary>
        public string BiletNumber { get; set; }

        /// <summary>
        /// Кем выдан Членский охотничий билет
        /// </summary>
        public string BiletIssuer { get; set; }

        /// <summary>
        /// Дата выдачи Членский охотничий билет
        /// </summary>
        public string BiletIssueDate { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone { get; set; }
        
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Должность
        /// </summary>
        public string Stat { get; set; }

        /// <summary>
        /// Должность
        /// </summary>
        public string StatInfo { get; set; }

        /// <summary>
        /// Наименование и организационно-правовая форма юридического лица
        /// </summary>
        public string Ul { get; set; }

        /// <summary>
        /// Фамилия, имя, отчество индивидуального предпринимателя
        /// </summary>
        public string Ip { get; set; }

    }
}
