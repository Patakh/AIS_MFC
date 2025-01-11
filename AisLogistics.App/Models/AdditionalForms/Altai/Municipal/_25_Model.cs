using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace AisLogistics.App.Models.AdditionalForms.Municipal
{
    /// <summary>
    ///                        ЗАЯВЛЕНИЕ 
    ///      о предоставлении сведений об объектах имущества,
    ///   предназначенного для предоставления во владение и (или)
    ///  пользование субъектам малого и среднего предпринимательства
    ///  и организациям, образующим инфраструктуру поддержки субъектов
    ///            малого и среднего предпринимательства
    /// </summary>
    public class _25_Model : AbstractAdditionalFormModel
    {
        public _25_Model()
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
            /// адрес постоянного места жительства 
            /// </summary>
            public string Address { get; set; }

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
            /// фактический адрес
            /// </summary>
            public string FacteAddressLegal { get; set; }

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
        /// количество экземпляров 
        /// </summary>
        public string Number  { get; set; }

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
    