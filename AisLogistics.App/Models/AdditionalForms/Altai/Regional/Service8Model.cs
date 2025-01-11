

namespace AisLogistics.App.Models.AdditionalForms.Regional
{
    /// <summary>
    ///  Назначение и выплата ежемесячного пособия на ребенка
    /// </summary>
    public class Service8Model : AbstractAdditionalFormModel
    {
        public Service8Model()
        {
            AppliedDocumentList = new[]
            {
                new AppliedDocument()
            };
            AppliedFamilyList = new[]
            {
              new Info_Family()
            };

            AppliedChildList = new[]
            {
              new Info_Child()
            };

        }

        /// <summary>
        /// № заявления
        /// </summary>
        public string StatementNumber { get; set; }

        /// <summary>
        /// Дата подачи заявления
        /// </summary>
        public string FeedsDate { get; set; }

        /// <summary>
        /// Дата принятия
        /// </summary>
        public string AcceptanceDate { get; set; }
        
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
        public string BirthDate { get; set; }
        
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
        /// Категория гражданина
        /// </summary>
        public string PersonCategory { get; set; }

        /// <summary>
        /// Прожиточный минимум в среднем на душу населения 
        /// </summary>
        public string Min { get; set; }

        /// <summary>
        /// на(дата месяц год)      
        /// </summary>
        public string MinDate { get; set; }

        /// <summary>
        /// Среднедушевой доход семьи      
        /// </summary>
        public string Srednee { get; set; }
        
        /// <summary>
        /// Способ выплаты средств       
        /// </summary>
        public string PaymentMethod { get; set; }

        /// <summary>
        /// доход с    
        /// </summary>
        public string WithDate { get; set; }

        /// <summary>
        /// по     
        /// </summary>
        public string ByDate { get; set; }

        /// <summary>
        /// Ежемесячную выплату прошу выплачивать       
        /// </summary>
        public string PaymentType { get; set; }

        /// <summary>
        /// Адрес получателя      
        /// </summary>
        public string Pochtalddress { get; set; }

        /// <summary>
        /// Номер почтового отделения        
        /// </summary>
        public string PostalCode { get; set; }
        
        /// <summary>
        /// Лицевой счет        
        /// </summary>
        public string PersonalAccount { get; set; }

        /// <summary>
        /// исключить из общей суммы дохода 
        /// </summary>

        public string Exclude_Income_Sum { get; set; }
        /// <summary>
        ///основание для удержания алиментов 
        /// </summary>

        public string Exclude_Income_Info { get; set; }

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
            public string CopyCount { get; set; }
        }

        public Info_Child[] AppliedChildList { get; set; }

        public class Info_Child
        {
            /// <summary>
            /// Фамилия, имя, отчество ребенка
            /// </summary>
            public string Fio_Child { get; set; }
            /// <summary>
            /// Число, месяц и год рождения ребенка
            /// </summary>
            public string BirthDate_Child { get; set; }


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
            /// Дата рождения
            /// </summary>
            public string BirthDate_Family { get; set; }
          
            /// <summary>
            /// Тип полученного дохода
            /// </summary>

            public string Type_Income { get; set; }

            /// <summary>
            /// Сумма дохода.(руб.,коп.)
            /// </summary>

            public string Amount_Income { get; set; }

            /// <summary>
            /// Место получения дохода с указанием работодателя
            /// </summary>

            public string Place_Of_Income { get; set; }
           
            
            /// <summary>
            /// Место получения дохода с указанием работодателя
            /// </summary>

            public string Grounds_Withholding { get; set; }
        }
    }
}