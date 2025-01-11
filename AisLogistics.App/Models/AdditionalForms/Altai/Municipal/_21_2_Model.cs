using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace AisLogistics.App.Models.AdditionalForms.Municipal
{
    /// <summary>
    ///                           ЗАЯВЛЕНИЕ
    ///   В соответствии с Градостроительным кодексом Российской Федерации прошу
    ///            утвердить документацию по планировке территории
    /// </summary>
    public class _21_2_Model : AbstractAdditionalFormModel
    {
        public _21_2_Model()
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
        /// номер
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Дата выдачи 
        /// </summary>
        public DateTime? DocIssueDate { get; set; }

        /// <summary>
        /// организация разработчика
        /// </summary>
        public string Organization { get; set; }

        /// <summary>
        /// год разработки
        /// </summary>
        [Required]
        [StringLength(4, MinimumLength =0)]
        public string Year { get; set; }

        /// <summary>
        /// в составе
        /// </summary>
        public string AsOf { get; set; }

        /// <summary>
        /// выполненную на основании Распоряжения  от
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// на основании  номер 
        /// </summary>
        public string NumberOrders { get; set; }

        /// <summary>
        /// по планировке территории №
        /// </summary>
        public string LayoutNumber { get; set; }
        
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
    