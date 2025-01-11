using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace AisLogistics.App.Models.AdditionalForms.Municipal
{
    /// <summary>
    ///                         ЗАЯВЛЕНИЕ 
    ///      на утверждение схемы расположения земельного участка
    ///      или земельных участков на кадастровом плане территории
    /// </summary>
    public class _28_Model : AbstractAdditionalFormModel
    {
        public _28_Model()
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
            /// место жительства  
            /// </summary>
            public string Adress { get; set; }

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
        /// разрешение на использование 
        /// </summary>
        public string InPlot { get; set; }

        /// <summary>
        /// в кадастровом квартале:
        /// </summary>
        public string Kadastr { get; set; }

        /// <summary>
        /// субъект Российской Федерации
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Город
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Район
        /// </summary>
        public string District { get; set; }

        /// <summary>
        /// Населенный пункт
        /// </summary>
        public string Locality { get; set; }

        /// <summary>
        /// улица
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        ///  для целей 
        /// </summary>
        public string Purposes { get; set; }
        
        /// <summary>
        ///  Площадь 
        /// </summary>
        public string Square { get; set; }

        /// <summary>
        ///  вид права 
        /// </summary>
        public string TypeLaw { get; set; }

        /// <summary>
        /// Способ получения результата
        /// </summary>
        public string MethodResult{ get; set; }

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
    