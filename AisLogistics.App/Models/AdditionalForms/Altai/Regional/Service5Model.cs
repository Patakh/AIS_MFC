

namespace AisLogistics.App.Models.AdditionalForms.Regional
{
    /// <summary>
    /// Предоставление гражданам субсидий на оплату жилого помещения и коммунальных услуг
    /// </summary>
    public class Service5Model : AbstractAdditionalFormModel
    {
        public Service5Model()
        {
            AppliedDocumentList = new[]
            {
                new AppliedDocument(),

            };
            AppliedFamilyList = new[]
            {
            new Info_Family()
            };

        }
        
        /// <summary>
        /// Получатель заявления
        /// </summary>
        public string Recipient { get; set; }
        
        /// <summary>
        /// дата подачи заявления
        /// </summary>
        public string DataZayavki { get; set; }

        /// <summary>
        /// № заявления
        /// </summary>
        public string StatementNumber { get; set; }

        /// <summary>
        /// ФИО
        /// </summary>
        public string Fio { get; set; }

     
        /// <summary>
        /// СНИЛС
        /// </summary>
        public string SNILS { get; set; }
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
        /// Способ выплаты средств       
        /// </summary>
        public string PaymentMethod { get; set; }

        /// <summary>
        /// Лицевой счет        
        /// </summary>
        public string PersonalAccount { get; set; }

        /// <summary>
        /// почтовое отделение       
        /// </summary>
        public string Post_Office { get; set; }

        /// <summary>
        /// Количество проживающих       
        /// </summary>
        public string Col { get; set; }

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


        public Info_Family[] AppliedFamilyList { get; set; }
        public class Info_Family
        {
            /// <summary>
            /// ФИО членов семьи
            /// </summary>
            public string Fio_Family { get; set; }

            /// <summary>
            /// Степень родства
            /// </summary>
            public string Degree_Kinship { get; set; }
            
                /// <summary>
                /// Серия паспорта
                /// </summary>
                public string DocSeries_Family { get; set; }

                /// <summary>
                /// Номер паспорта
                /// </summary>
                public string DocNumber_Family { get; set; }

                /// <summary>
                /// Кем выдан паспорт
                /// </summary>
                public string DocIssuer_Family { get; set; }

                /// <summary>
                /// Дата выдачи паспорта
                /// </summary>
                /// 

                public string DocIssueDate_Family { get; set; }
            
                /// <summary>
                /// Наличие льгот
                /// </summary>
           
            public string Availability_Benefits { get; set; }

        }
    }
}
