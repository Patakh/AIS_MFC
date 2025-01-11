using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Models.AdditionalForms.Regional
{
    
    public class Service20Model : AbstractAdditionalFormModel
    {

        public Service20Model()
        {
            AppliedDocumentList = new[]
            {
                new AppliedDocument(),

            };
        }

        /// <summary>
        /// Заявление оформлено представителем:
        /// </summary>
        public string IsPretstavitel { get; set; }

        /// <summary>
        /// ФИО
        /// </summary>
        public string Fio { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime? BirthDate { get; set; }   
        
        /// <summary>
        /// Адрес места жительства
        /// </summary>
        public string ResidenceAddress { get; set; }
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
        /// Представитель:
        /// </summary>
        public string PretstavitelFio { get; set; }
        
        /// <summary>
        /// Место регистрации
        /// </summary>
        public string PretstavitelResgisterAddress { get; set; }
        
        /// <summary>
        /// Серия паспорта
        /// </summary>
        public string  PretstavitelDocSeries { get; set; }

        /// <summary>
        /// Номер паспорта
        /// </summary>
        public string  PretstavitelDocNumber { get; set; }

        /// <summary>
        /// Кем выдан паспорт
        /// </summary>
        public string  PretstavitelDocIssuer { get; set; }

        /// <summary>
        /// Дата выдачи паспорта
        /// </summary>
        public string  PretstavitelDocIssueDate { get; set; }

        /// <summary>
        /// действующим на основании
        /// </summary>
        public string  PretstavitelOsnovanie { get; set; }

        /// <summary>
        /// действующим на основании от
        /// </summary>
        public string  PretstavitelOsnovanieDate { get; set; }

        /// <summary>
        /// действующим на основании №
        /// </summary>
        public string  PretstavitelOsnovanieNumber { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// кредитную организацию        
        /// </summary>
        public string Name_Oplat { get; set; }
        
        /// <summary>
        /// Лицевой счет        
        /// </summary>
        public string method_Oplat { get; set; }
        
        /// <summary>
        /// Лицевой счет        
        /// </summary>
        public string Pocht_Oplat { get; set; }

        /// <summary>
        /// Уведомление       
        /// </summary>
        public string Response { get; set; }

        public AppliedDocument[] AppliedDocumentList { get; set; }

        public class AppliedDocument
        {
            /// <summary>
            /// Наименование документа
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Количество экземпляров
            /// </summary>
            public int CopyCount { get; set; }
        }

    }
}
