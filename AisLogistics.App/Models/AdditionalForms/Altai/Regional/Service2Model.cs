namespace AisLogistics.App.Models.AdditionalForms.Regional
{
   
    public class Service2Model : AbstractAdditionalFormModel
    {
        public Service2Model()
        {
            AppliedDocumentList = new []
            {
                new AppliedDocument()
            };
        }

        /// <summary>
        /// ФИО
        /// </summary>
        public string Fio { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Адрес проживания
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Адрес регистрации
        /// </summary>
        public string RegAddress { get; set; }        

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
        /// Телефон
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Адрес электронной почты
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Трудовой стаж
        /// </summary>
        public string Seniority { get; set; }        

        /// <summary>
        /// Награды
        /// </summary>
        public string Awards { get; set; }

        /// <summary>
        /// уведомить 
        /// </summary>
        public string Request { get; set; }

        /// <summary>
        /// Приложенные документы
        /// </summary>
        public AppliedDocument[] AppliedDocumentList { get; set; }

        public class AppliedDocument
        {
            /// <summary>
            /// Наименование документа
            /// </summary>
            public string Name { get; set; }
        }
    }
}
