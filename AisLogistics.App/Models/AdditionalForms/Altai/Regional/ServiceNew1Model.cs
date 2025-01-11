

namespace AisLogistics.App.Models.AdditionalForms.Regional
{
  
    public class ServiceNew1Model : AbstractAdditionalFormModel
    {
        public ServiceNew1Model()
        {
            AppliedDocumentList = new[]
            {
                new AppliedDocument(),

            };
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
        public string BirchDate { get; set; }
        
        /// <summary>
        /// Категория
        /// </summary>
        public string Categoru { get; set; }

        /// <summary>
        /// Адрес регистрации
        /// </summary>
        public string RegistrationAddress { get; set; }

        /// <summary>
        /// Адрес места жительства
        /// </summary>
        public string ResidenceAddress { get; set; }

        /// <summary>
        /// Серия 
        /// </summary>
        public string DocSeries { get; set; }

        /// <summary>
        /// Номер 
        /// </summary>
        public string DocNumber { get; set; }

        /// <summary>
        /// Кем выдан 
        /// </summary>
        public string DocIssuer { get; set; }

        /// <summary>
        /// Дата выдачи 
        /// </summary>
        public string DocIssueDate { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Способ выплаты средств       
        /// </summary>
        public string PaymentMethod { get; set; }

        /// <summary>
        /// Лицевой счет        
        /// </summary>
        public string PersonalAccount { get; set; }

        /// <summary>
        /// Дата       
        /// </summary>
        public string DataZayavki { get; set; }

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

            /// <summary>
            /// Количество экземпляров
            /// </summary>
            public int CopyCount { get; set; }
        }
    }
}
