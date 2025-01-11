using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Models.AdditionalForms.Municipal
{
    /// <summary>
    ///                               ЗАЯВЛЕНИЕ  
    /// о признании гражданина малоимущим в целях постановки на учет в качестве нуждающегося 
    ///              в жилом помещении муниципального жилищного фонда,
    ///               предоставляемого по договору социального найма
    /// </summary> 
     public class _8_2_Model : AbstractAdditionalFormModel
       {
            public _8_2_Model()
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
            /// ФИО
            /// </summary>
            public string Fio { get; set; }
        
            /// <summary>
            /// Дата рождения
            /// </summary>
            public DateTime? BirthDate { get; set; }
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
            /// Телефон
            /// </summary>
            public string Phone { get; set; }

        /// <summary>
        /// сведения об осуществлении трудовой (предпринимательской) деятельности
        /// </summary>
        public string Activities { get; set; }

        /// <summary>
        /// причина перемены фамилии 
        /// </summary>
        public string Reason { get; set; }
        
        /// <summary>
        /// количество человек в семье
        /// </summary>
        public string NumberPeople { get; set; }

            /// <summary>
            /// Лицевой счет        
            /// </summary>
            public string PersonalAccount { get; set; }

        /// <summary>
        /// ФИО 
        /// </summary>
        public string Fio_Spouse { get; set; }

        /// <summary>
        /// Дата рождения Супруг(а
        /// </summary>
        public DateTime? BirthDateSpouse { get; set; }

        /// <summary>
        /// место работы (службы, иной деятельности) Супруг(а
        /// </summary>

        public string PlaceWorkSpouse { get; set; }

        /// <summary>
        /// СНИЛС Супруг(а
        /// </summary>
        public string SNILSSpouse { get; set; }

        /// <summary>
        /// выплаченные алименты в сумме 
        /// </summary>
        public string Alimony { get; set; }

        /// <summary>
        /// основание для удержания алиментов
        /// </summary>
        public string Footing { get; set; }

        /// <summary>
        /// фамилия, имя, отчество (последнее при наличии) лица, с которого осуществляется удержание
        /// </summary>
        public string RetentionFio { get; set; }

        /// <summary>
        /// уплаченные налоги 
        /// </summary>
        public string TaxesPaid { get; set; }

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
            /// место работы (службы, иной деятельности)
            /// </summary>

            public string PlaceWork { get; set; }

            /// <summary>
            /// СНИЛС
            /// </summary>
            public string SNILS { get; set; }

          }
     }
 }
