using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Models.AdditionalForms.Regional
{
    /// <summary>
    /// Выдача справок о том, является или не является лицо подвергнутым административному наказанию за потребление наркотических средств или психотропных веществ 
    /// без назначения врача либо новых потенциально опасных психоактивных веществ
    /// </summary>
    public class NarcoModel : AbstractAdditionalFormModel
    {

        /// <summary>
        /// Получатель заявления
        /// </summary>
        public string Recipient { get; set; }

        /// <summary>
        /// ФИО
        /// </summary>
        public string Fio { get; set; }
        
        /// <summary>
        /// ФИО
        /// </summary>
        public string FioP { get; set; }
        
        /// <summary>
        /// ФИО
        /// </summary>
        public string FioPI { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Адрес регистрации по месту жительства(пребывания)
        /// </summary>
        public string RegAddress { get; set; }
        
        /// <summary>
        /// место рождения
        /// </summary>
        public string BirthAddress { get; set; }

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
        /// Кем 
        /// </summary>
        public string Doc { get; set; }
        
        /// <summary>
        /// реквизиты 
        /// </summary>
        public string DocRecvizit { get; set; }

        /// <summary>
        /// Дата выдачи паспорта
        /// </summary>
        public string DocIssueDate { get; set; }

        /// <summary>
        /// дата подачи      
        /// </summary>
        public string Data { get; set; }

            /// <summary>
            /// Наименование документа
            /// </summary>
            public string Name { get; set; }
        
    }
}
