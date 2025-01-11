using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace AisLogistics.App.Models.AdditionalForms.Municipal
{
    /// <summary>
    ///                            ЗАЯВЛЕНИЕ 
    ///   о предоставлении в собственность, аренду, постоянное (бессрочное) 
    ///      пользование, безвозмездное пользование земельного участка,
    ///    находящегося в государственной или муниципальной собственности,
    ///                       без проведения торгов
    /// </summary>
    public class _26_Model : AbstractAdditionalFormModel
    {
        public _26_Model()
        {
            AppliedDocumentList = new[]
            {
                new AppliedDocument()
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
            public string INNLegal { get; set; }

            /// <summary>
            /// ЕГРЮЛ
            /// </summary>
            public string USRLE { get; set; }

            /// <summary>
            /// почтовый адрес
            /// </summary>
            public string PostalAddressLegal { get; set; }

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
        /// Сведения о заявителе
        /// </summary>
        public string FaceApplicant { get; set; }

        /// <summary>
        /// Адрес
        /// </summary>
        public string Adress { get; set; }

        /// <summary>
        /// Площадь
        /// </summary>
        public string Arrea { get; set; }

        /// <summary>
        /// кадастровый номер земельного участка 
        /// </summary>
        public string Kadastr { get; set; }

        /// <summary>
        /// номер
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Дата выдачи 
        /// </summary>
        public DateTime? DocIssueDate { get; set; }

        /// <summary>
        /// основание предоставления земельного 
        /// </summary>
        public string Basis { get; set; }

        /// <summary>
        /// вид права
        /// </summary>
        public string TypeLaw { get; set; }

        /// <summary>
        /// цель 
        /// </summary>
        public string Purpose { get; set; }
        
        /// <summary>
        /// Способ получения результата 
        /// </summary>
        public string MethodResult{ get; set; }

        /// <summary>
        /// номер
        /// </summary>
        public string NumberFormed { get; set; }

        /// <summary>
        /// Дата выдачи 
        /// </summary>
        public DateTime? DocIssueDateFormed { get; set; }

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
        }

    }
}
    