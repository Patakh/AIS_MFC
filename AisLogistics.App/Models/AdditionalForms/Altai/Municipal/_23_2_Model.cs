using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace AisLogistics.App.Models.AdditionalForms.Municipal
{
    /// <summary>
    ///                          ЗАЯВЛЕНИЕ
    ///   об исправлении допущенных ошибок (опечаток) в выданных в результате
    ///          предоставления муниципальной услуги документах 
    /// </summary>
    public class _23_2_Model : AbstractAdditionalFormModel
    {
        public _23_2_Model()
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
        ///  собственник, иной законный владелец земельного участка, здания
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        ///  населённый пункт  
        /// </summary>
        public string Locality { get; set; }

        /// <summary>
        /// Улица/Проспект
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        ///  Дом
        /// </summary>
        public string Hous { get; set; }

        /// <summary>
        ///  с
        /// </summary>
        public string With { get; set; }

        /// <summary>
        ///  до
        /// </summary>
        public string Before { get; set; }

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
    