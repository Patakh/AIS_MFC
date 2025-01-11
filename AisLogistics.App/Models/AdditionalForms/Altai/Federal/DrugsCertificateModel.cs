using System.ComponentModel;

namespace AisLogistics.App.Models.AdditionalForms
{
    public sealed class DrugsCertificateModel : AbstractAdditionalFormModel
    {
        public DrugsCertificateModel()
        {
            Person = new PersonType
            {
                IdentityDoc = new DocumentType()
            };
        }

        /// <summary>
        /// Тип заявления
        /// </summary>
        [DisplayName("Тип заявления")]
        public string ApplicationType { get; set; }

        /// <summary>
        /// Способ подачи заявления
        /// </summary>
        [DisplayName("Способ подачи заявления")]
        public string CustomerType { get; set; }

        /// <summary>
        /// Тип заявления
        /// </summary>
        [DisplayName("ФИО заявителя")]
        public string CustomerFio { get; set; }

        /// <summary>
        /// Дата подачи заявления
        /// </summary>
        [DisplayName("Дата подачи заявления")]
        public string ApplicationDate { get; set; }

        /// <summary>
        /// Номер заявления
        /// </summary>
        [DisplayName("Номер заявления")]
        public string ApplicationNumber { get; set; }

        /// <summary>
        /// Место направления заявления
        /// </summary>
        [DisplayName("Место направления заявления")]
        public string Recipient { get; set; }

        /// <summary>
        /// Допущенные опечатки (ошибки)
        /// </summary>
        [DisplayName("Допущенные опечатки (ошибки)")]
        public string[] Errors { get; set; }

        /// <summary>
        /// Приложенные документы
        /// </summary>
        [DisplayName("Приложенные документы")]
        public string[] AppliedDocuments { get; set; }

        /// <summary>
        /// Данные проверяемого лица
        /// </summary>
        public PersonType Person { get; set; }                      

        public sealed class PersonType
        {
            /// <summary>
            /// ФИО
            /// </summary>
            [DisplayName("ФИО")]
            public string Fio { get; set; }            

            /// <summary>
            /// Дата рождения
            /// </summary>
            [DisplayName("Дата рождения")]
            public string BirthDate { get; set; }

            /// <summary>
            /// Место рождения
            /// </summary>
            [DisplayName("Место рождения")]
            public string BirthPlace { get; set; }

            /// <summary>
            /// Адрес места жительства (пребывания)
            /// </summary>
            [DisplayName("Адрес места жительства (пребывания)")]
            public string Address { get; set; }
            
            /// <summary>
            /// Документ, удостоверяющий личность
            /// </summary>
            public DocumentType IdentityDoc { get; set; }      
        }

        public class DocumentType
        {
            /// <summary>
            /// Серия документа
            /// </summary>
            [DisplayName("Серия документа")]
            public string Series { get; set; }

            /// <summary>
            /// Номер документа
            /// </summary>
            [DisplayName("Номер документа")]
            public string Number { get; set; }

            /// <summary>
            /// Дата выдачи
            /// </summary>
            [DisplayName("Дата выдачи")]
            public string IssueDate { get; set; }

            /// <summary>
            /// Кем выдан документ
            /// </summary>
            [DisplayName("Кем выдан документ")]
            public string Issuer { get; set; }
        }        
    }    
}