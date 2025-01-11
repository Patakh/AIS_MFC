using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace AisLogistics.App.Models.AdditionalForms.Municipal
{
    /// <summary>
    ///                     Заявление 
    /// о переустройстве и (или) перепланировке жилого помещения
    /// </summary>
    public class _16_Model : AbstractAdditionalFormModel
    {
        public _16_Model()
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
            /// серия
            /// </summary>
            public string Series { get; set; }

            /// <summary>
            /// номер
            /// </summary>
            public string Number { get; set; }

            /// <summary>
            /// Кем выдан 
            /// </summary>
            public string DocIssuer { get; set; }

            /// <summary>
            /// Дата выдачи 
            /// </summary>
            public DateTime? DocIssueDate { get; set; }

            /// <summary>
            /// почтовый адрес
            /// </summary>
            public string PostalAddress { get; set; }

            /// <summary>
            /// телефон для связи
            /// </summary>
            public string Phone { get; set; }

            /// <summary>
            /// адрес электронной почты
            /// </summary>
            public string Email { get; set; }

            /// <summary>
            /// полное наименование
            /// </summary>
            public string FullName { get; set; }

            /// <summary>
            /// ИНН 
            /// </summary>
            public string INN { get; set; }

            /// <summary>
            /// ИНН 
            /// </summary>
            public string INNLegal { get; set; }

            /// <summary>
            /// ОГРН
            /// </summary>
            public string OGRN { get; set; }

            /// <summary>
            /// адрес
            /// </summary>
            public string AddressLegal { get; set; }

            /// <summary>
            /// телефон для связи
            /// </summary>
            public string PhoneLegal { get; set; }

            /// <summary>
            /// адрес электронной почты
            /// </summary>
            public string EmailLegal { get; set; }

            /// <summary>
            /// Заявитель
            /// </summary>
            public string Applicant { get; set; }
        }

        /// <summary>
        /// Лицо Заявителя
        /// </summary>
        public string FaceApplicant { get; set; }

        /// <summary>
        ///  субъект Российской Федерации
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Наименование муниципального района, городского, муниципального округа или внутригородской территории
        /// </summary>
        public string Territories { get; set; }

        /// <summary>
        /// Наименование поселения
        /// </summary>
        public string Settlements { get; set; }

        /// <summary>
        /// улица
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// дом
        /// </summary>
        public string House { get; set; }

        /// <summary>
        /// корпус
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// квартира 
        /// </summary>
        public string Flat { get; set; }

        /// <summary>
        /// подъезд
        /// </summary>
        public string Entrance { get; set; }

        /// <summary>
        /// этаж
        /// </summary>
        public string Floor { get; set; }
        
        /// <summary>
        /// строение
        /// </summary>
        public string Building { get; set; }

        /// <summary>
        /// Заявитель
        /// </summary>
        public PersonType Applicant { get; set; }

        /// <summary>
        /// разрешение  
        /// </summary>
        public string Permission { get; set; }

        /// <summary>
        /// на основании    
        /// </summary>
        public string OnBasis { get; set; }

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
        public string[] Days { get; set; }

        /// <summary>
        /// дата договора социального найма
        /// </summary>
        public string DataContract { get; set; }

        /// <summary>
        /// номер договора социального найма
        /// </summary>
        public string NuberContract { get; set; }

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
        public Owner[] OwnerList{ get; set; }
        public class Owner
        {

            /// <summary>
            /// ФИО
            /// </summary>
            public string Fio { get; set; }

            /// <summary>
            /// серия
            /// </summary>
            public string Series { get; set; }

            /// <summary>
            /// номер
            /// </summary>
            public string Number { get; set; }

            /// <summary>
            /// Кем выдан 
            /// </summary>
            public string DocIssuer { get; set; }

            /// <summary>
            /// Дата выдачи 
            /// </summary>
            public string DocIssueDate { get; set; }

            /// <summary>
            /// почтовый адрес
            /// </summary>
            public string PostalAddress { get; set; }

            /// <summary>
            /// телефон для связи
            /// </summary>
            public string Phone { get; set; }

            /// <summary>
            /// адрес электронной почты
            /// </summary>
            public string Email { get; set; }

            /// <summary>
            /// полное наименование
            /// </summary>
            public string FullName { get; set; }

            /// <summary>
            /// ИНН 
            /// </summary>
            public string INN { get; set; }

            /// <summary>
            /// ИНН 
            /// </summary>
            public string INNLegal { get; set; }

            /// <summary>
            /// ОГРН
            /// </summary>
            public string OGRN { get; set; }

            /// <summary>
            /// адрес
            /// </summary>
            public string AddressLegal { get; set; }

            /// <summary>
            /// телефон для связи
            /// </summary>
            public string PhoneLegal { get; set; }

            /// <summary>
            /// адрес электронной почты
            /// </summary>
            public string EmailLegal { get; set; }

            /// <summary>
            /// Заявитель
            /// </summary>
            public string Applicant { get; set; }

            /// <summary>
            /// Лицо 
            /// </summary>
            public string Face { get; set; }
        }

        public Info_Family[] AppliedFamilyList { get; set; }
        public class Info_Family
        {
            /// <summary>
            /// ФИО членов семьи
            /// </summary>
            public string Fio_Family { get; set; }

            /// <summary>
            /// Дата рождения
            /// </summary>
            public string BirthDate { get; set; }

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
    