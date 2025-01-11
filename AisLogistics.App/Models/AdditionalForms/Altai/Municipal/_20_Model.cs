using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace AisLogistics.App.Models.AdditionalForms.Municipal
{
    /// <summary>
    ///                      ЗАЯВЛЕНИЕ
    ///   о предоставление разрешения на условно разрешенный вид 
    ///   использования земельного участка или объекта капитального 
    ///                     строительства
    /// </summary>
    public class _20_Model : AbstractAdditionalFormModel
    {
        public _20_Model()
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
        /// Разрешение на
        /// </summary>
        public string Permission { get; set; }

        /// <summary>
        /// кадастровым номером
        /// </summary>
        public string Kadastr { get; set; }
        
        /// <summary>
        /// Адрес
        /// </summary>
        public string Adress { get; set; }
        
        /// <summary>
        /// Для
        /// </summary>
        public string For { get; set; }

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
        }

    }
}
    