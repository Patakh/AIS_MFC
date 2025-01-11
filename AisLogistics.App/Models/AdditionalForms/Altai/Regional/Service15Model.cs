

namespace AisLogistics.App.Models.AdditionalForms.Regional
{
   
    public class Service15Model : AbstractAdditionalFormModel
    {
        public Service15Model()
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
        /// ДАта подачи заявления
        /// </summary>
        public string DataZayavki { get; set; }

        /// <summary>
        /// ФИО
        /// </summary>
        public string Fio { get; set; }

        /// <summary>
        /// ФИО Доверенного лица
        /// </summary>
        public string Fio_Dover_Person { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public string BirthDate { get; set; }

        /// <summary>
        /// Дата рождения Доверенного лица
        /// </summary>
        public string BirthDate_Dover_Person { get; set; }

        /// <summary>
        /// СНИЛС
        /// </summary>
        public string SNILS { get; set; }

        /// <summary>
        /// Адрес места жительства
        /// </summary>
        public string ResidenceAddress { get; set; }

        /// <summary>
        /// Адрес места жительства Доверенного лица
        /// </summary>
        public string ResidenceAddress_Dover_Person { get; set; }

        /// <summary>
        /// Серия паспорта
        /// </summary>
        public string DocSeries { get; set; }

        /// <summary>
        /// Серия подтвержадающие полномочия
        /// </summary>
        public string DocSeriesRoot { get; set; }

        /// <summary>
        /// Серия паспорта Доверенного лица
        /// </summary>
        public string DocSeries_Dover_Person { get; set; }

        /// <summary>
        /// Наименования документа
        /// </summary>
        public string DocName_Dover_Person { get; set; }

        /// <summary>
        /// Наименования документа подтвержадающие полномочия законого
        /// </summary>
        public string DocNameRoot_Dover_Person { get; set; }

        /// <summary>
        /// Наименования документа подтвержающее полномочия доверенного лица
        /// </summary>
        public string DocRoot_Dover_Person { get; set; }

        /// <summary>
        /// Номер паспорта
        /// </summary>
        public string DocNumber { get; set; }

        /// <summary>
        /// Номер подтвержадающие полномочия
        /// </summary>
        public string DocNumberRoot { get; set; }

        /// <summary>
        /// Номер паспорта Доверенного лица
        /// </summary>
        public string DocNumber_Dover_Person { get; set; }

        /// <summary>
        /// Кем выдан паспорт
        /// </summary>
        public string DocIssuer { get; set; }

        /// <summary>
        /// Кем выдан паспорт Доверенного лица
        /// </summary>
        public string DocIssuer_Dover_Person { get; set; }

        /// <summary>
        /// Дата выдачи паспорта
        /// </summary>
        public string DocIssueDate { get; set; }

        /// <summary>
        /// Дата выдачи паспорта Доверенного лица
        /// </summary>
        public string DocIssueDate_Dover_Person { get; set; }
        
        /// <summary>
        /// Дата выдачи полномочия
        /// </summary>
        public string DocIssueDateRoot_Dover_Person { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// о принадлежности к гражданству 
        /// </summary>
        public string Contry { get; set; }

        /// <summary>
        /// почтовый индекс
        /// </summary>
        public string Pochta_Index { get; set; }

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


        public Info_Family[] AppliedFamilyList { get; set; }
        public class Info_Family
        {
            /// <summary>
            /// Дата рождения
            /// </summary>
            public string BirthDate_Child { get; set; }
          
            /// <summary>
            /// Фамилия, имя, отчество ребенка
            /// </summary>
            public string Fio_Child { get; set; }
        
        }
    }
}