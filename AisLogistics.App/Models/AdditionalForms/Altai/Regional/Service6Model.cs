

namespace AisLogistics.App.Models.AdditionalForms.Regional
{
    /// <summary>
    ///  Назначение и выплата компенсации расходов на оплату жилой площади и коммунальных услуг отдельным категориям граждан
    /// </summary>
    public class Service6Model : AbstractAdditionalFormModel
    {
        public Service6Model()
        {
            AppliedDocumentList = new[]
            {
                new AppliedDocument(),
            };
            AppliedFamilyList = new[]
            {
            new Info_Family()
            };
            AppliedCompensationList = new[]
            {
            new Info_Compensation()
            };
        }
        /// <summary>
        /// Получатель заявления
        /// </summary>
        public string Recipient { get; set; }

        /// <summary>
        /// Дата подачи
        /// </summary>
        public string DataZayavki { get; set; }

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
        /// OKATO
        /// </summary>
        public string OKATO { get; set; }

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
        /// категория
        /// </summary>
        public string Categoru { get; set; }


        /// <summary>
        /// Серия 
        /// </summary>
        public string SupportSeries { get; set; }

        /// <summary>
        /// Номер 
        /// </summary>
        public string SupportNumber { get; set; }


        /// <summary>
        /// СНИЛС
        /// </summary>
        public string AppSNILS { get; set; }



        /// <summary>
        /// Ф
        /// </summary>
        public string FRecipient { get; set; }

        /// <summary>
        /// И
        /// </summary>
        public string IRecipient { get; set; }

        /// <summary>
        /// О
        /// </summary>
        public string ORecipient { get; set; }

        /// <summary>
        /// место регистрации
        /// </summary>
        public string AdressRecipient { get; set; }


        /// <summary>
        /// Серия паспорта
        /// </summary>
        public string DocSeriesRecipient { get; set; }

        /// <summary>
        /// Номер паспорта
        /// </summary>
        public string DocNumberRecipient { get; set; }

        /// <summary>
        /// Кем выдан паспорт
        /// </summary>
        public string DocIssuerRecipient { get; set; }

        /// <summary>
        /// Дата выдачи паспорта
        /// </summary>
        public string DocIssueDateRecipient { get; set; }

        /// <summary>
        /// Кем выдан паспорт
        /// </summary>
        public string DocIssuerRecipien { get; set; }

        /// <summary>
        ///  на основании
        /// </summary>
        public string Osnova { get; set; }

        /// <summary>
        /// от
        /// </summary>
        public string OsnovaNumber { get; set; }

        /// <summary>
        /// Номер
        /// </summary>
        public string OsnovaDate { get; set; }


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
        /// Способ получения результата
        /// </summary>
        public string MethodResult { get; set; }
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

        /// <summary>
        /// Дополнительные сведения для предоставления компенсации:
        /// </summary>
        public Info_Compensation[] AppliedCompensationList { get; set; }

        public class Info_Compensation
        {
            /// <summary>
            /// Организации-поставщики ЖКУ
            /// </summary>
            public string Supplier_Organizations { get; set; }

            /// <summary>
            /// Виды потребляемых услуг
            /// </summary>
            public string Types_Services { get; set; }

            /// <summary>
            /// Степень благоустройства жилого помещения 
            /// </summary>
            public string Degree_Improvement { get; set; }

            /// <summary>
            /// Количество этажей в МКД/год постройки
            /// </summary>
            public string Number_Floors { get; set; }

            /// <summary>
            /// Количество комнат
            /// </summary>
            public string Number_Rooms { get; set; }

            /// <summary>
            /// Общая площадь жилого помещения
            /// </summary>

            public string Area_Space { get; set; }
        }

        /// <summary>
        /// Сведения о гражданах, зарегистрированных совместно 
        /// со мной по месту жительства:
        /// </summary>
        public Info_Family[] AppliedFamilyList { get; set; }
        public class Info_Family
        {
            /// <summary>
            /// ФИО 
            /// </summary>
            public string Fio_Family { get; set; }

            /// <summary>
            /// Дата рождения
            /// </summary>
            public DateTime? BirthDate { get; set; }

            /// <summary>
            /// СНИЛС
            /// </summary>
            public string SNILS { get; set; }


            /// <summary>
            /// Серия паспорта
            /// </summary>
            public string DocSeries_Family { get; set; }

            /// <summary>
            /// Номер паспорта
            /// </summary>
            public string DocNumber_Family { get; set; }
             
            /// <summary>
            /// Место выдачи документа
            /// </summary>
            public string DocIssuer_Family { get; set; }
             
            /// <summary>
            /// Дата выдачи паспорта
            /// </summary>
            /// 
            public string DocIssueDate_Family { get; set; }
        }

    }



}
