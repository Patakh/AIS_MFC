namespace AisLogistics.App.Models.AdditionalForms.Regional
{
    /// <summary>
    /// Предоставление меры социальной поддержки отдельных категорий граждан по газификации 
    /// жилых помещений в Республике Алтай сетевым газом
    /// </summary>
    public class Service3Model : AbstractAdditionalFormModel
    {
        public Service3Model()
        {
            AppliedDocumentList = new[]
            {
                new AppliedDocument()
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
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Адрес регистрации
        /// </summary>
        public string RegistrationAddress { get; set; }

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
        /// Телефон
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Категория гражданина
        /// </summary>
        public string PersonCategory { get; set; }

        /// <summary>
        /// Способ выплаты средств       
        /// </summary>
        public string PaymentMethod { get; set; }

        /// <summary>
        /// Лицевой счет        
        /// </summary>
        public string PersonalAccount { get; set; }

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
