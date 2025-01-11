using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace AisLogistics.App.Models.AdditionalForms.Municipal
{
    /// <summary>
    ///                      УВЕДОМЛЕНИЕ
    ///  об аннулировании разрешения на установку и эксплуатацию
    ///                 рекламной конструкции
    /// </summary>
    public class _18_1_Model : AbstractAdditionalFormModel
    {
        public _18_1_Model()
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
            /// ИНН 
            /// </summary>
            public string INNLegal { get; set; }

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
        /// номер рекламной конструкции     
        /// </summary>
        public string NumberAdvertisingBesign { get; set; }
        
        /// <summary>
        /// Дата рекламной конструкции     
        /// </summary>
        public string DateAdvertisingBesign { get; set; }
        
        /// <summary>
        /// Вид рекламной конструкции     
        /// </summary>
        public string TypeAdvertisingBesign { get; set; }
        
        /// <summary>
        /// Адрес рекламной конструкции     
        /// </summary>
        public string AdressAdvertisingBesign { get; set; }

        /// <summary>
        /// в связи с   
        /// </summary>
        public string InConnect { get; set; }

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
    