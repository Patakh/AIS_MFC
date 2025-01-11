using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace AisLogistics.App.Models.AdditionalForms.Municipal
{
    /// <summary>
    ///                         ЗАЯВЛЕНИЕ
    ///   о переводе жилого(нежилого) помещения в жилое(нежилое) помещение
    /// </summary>
    public class _19_Model : AbstractAdditionalFormModel
    {
        public _19_Model()
        {
            AppliedDocumentList = new[]
            {
                new AppliedDocument()
            };
            OwnerList = new[]
           {
                new Owner()
            };
            AppliedFamilyList = new[]
            {
            new Info_Family()
            };
        }

        /// <summary>
        /// Место направления заявления
        /// </summary>
        public string Recipient { get; set; }

         public class PersonType
        {
            /// <summary>
            /// ФИО
            /// </summary>
            public string Fio { get; set; }

            /// <summary>
            /// почтовый адрес
            /// </summary>
            public string PostalAddress { get; set; }

            /// <summary>
            /// телефон для связи
            /// </summary>
            public string Phone { get; set; }

            /// <summary>
            /// полное наименование
            /// </summary>
            public string FullName { get; set; }

            /// <summary>
            /// почтовый адрес
            /// </summary>
            public string PostalAddressLegal { get; set; }

            /// <summary>
            /// телефон для связи
            /// </summary>
            public string PhoneLegal { get; set; }

            /// <summary>
            /// Заявитель
            /// </summary>
            public string Applicant { get; set; }
        }
        /// <summary>
        /// Сведения о заявителе
        /// </summary>
        public string FaceApplicant { get; set; }

        /// <summary>
        /// ФИО представителя
        /// </summary>
        public string Fio { get; set; }

        /// <summary>
        /// серия доверенности
        /// </summary>
        public string Series { get; set; }

        /// <summary>
        /// номер доверенности
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Дата выдачи  доверенности
        /// </summary>
        public string DocIssueDate { get; set; }

        /// <summary>
        /// Место нахождения переводимого помещения
        /// </summary>
        public string Adress { get; set; }

        /// <summary>
        /// разрешить  перевод
        /// </summary>
        public string AllowTranslation { get; set; }

        /// <summary>
        /// причину перевода
        /// </summary>
        public string ReasonTranslation { get; set; }

        /// <summary>
        /// Срок производства  
        /// </summary>
        public string ProductionPriod { get; set; }

        /// <summary>
        /// по  
        /// </summary>
        public string ByProductionPriod { get; set; }

        /// <summary>
        /// Режим производства 
        /// </summary>
        public string ProductionMode { get; set; }

        /// <summary>
        /// по
        /// </summary>
        public string ByProductionMode { get; set; }

        /// <summary>
        /// дни
        /// </summary>
        public string Days { get; set; }

        /// <summary>
        /// по
        /// </summary>
        public string ByDays { get; set; }

        /// <summary>
        /// Способ получения результата 
        /// </summary>
        public string ResultProviding { get; set; }

        /// <summary>
        /// Заявитель
        /// </summary>
        public PersonType Applicant { get; set; }

        /// <summary>
        /// Приложение
        /// </summary>
        public AppliedDocument[] AppliedDocumentList { get; set; }
        public class AppliedDocument
        {
            /// <summary>
            /// Приложение
            /// </summary>
            public string Applications { get; set; }

            /// <summary>
            /// Количество листов
            /// </summary>
            public string SumList { get; set; }

        }
        /// <summary>
        /// Собственники
        /// </summary>
        public Owner[] OwnerList { get; set; }
        public class Owner
        {
            /// <summary>
            /// ФИО
            /// </summary>
            public string Fio { get; set; }
        }
        public Info_Family[] AppliedFamilyList { get; set; }
        public class Info_Family
        {
            /// <summary>
            /// ФИО 
            /// </summary>
            public string Fio_Family { get; set; }

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
            public string DocIssueDate_Family { get; set; }
        }
    }
}
    