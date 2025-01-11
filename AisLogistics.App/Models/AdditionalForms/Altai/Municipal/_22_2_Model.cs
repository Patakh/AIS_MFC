using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace AisLogistics.App.Models.AdditionalForms.Municipal
{
    /// <summary>
    ///                   Уведомление
    ///  о планируемом сносе объекта капитального строительства
    /// </summary>
    public class _22_2_Model : AbstractAdditionalFormModel
    {
        public _22_2_Model()
        {
            AppliedDocumentList = new[]
            {
                new AppliedDocument()
            };
            ObjectAppliedDocumentList = new[]
            {
                new ObjectAppliedDocument()
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
            /// Место жительства
            /// </summary>
            public string AdressLife { get; set; }

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
            /// ОГРН
            /// </summary>
            public string OGRN { get; set; }

            /// <summary>
            /// ИНН 
            /// </summary>
            public string INNLegal { get; set; }

            /// <summary>
            /// Место жительства
            /// </summary>
            public string Adress { get; set; }

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
        }
            /// <summary>
            /// Заявитель
            /// </summary>
            public string FaceApplicant { get; set; }
        
        /// <summary>
        /// Кадастровый номер земельного участка 
        /// </summary>
        public string Kadastr { get; set; }

        /// <summary>
        /// Адрес или описание местоположения земельного участка
        /// </summary>
        public string AdressPlot { get; set; }

        /// <summary>
        /// правоустанавливающие документ
        /// </summary>
        public string NameDoc { get; set; }

        /// <summary>
        /// номер
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Дата выдачи 
        /// </summary>
        public DateTime? DocIssueDate { get; set; }

        public class Objekt
        {
            /// <summary>
            /// Кадастровый номер земельного участка 
            /// </summary>
            public string Kadastr { get; set; }

            /// <summary>
            /// Адрес или описание местоположения земельного участка
            /// </summary>
            public string AdressPlot { get; set; }

            /// <summary>
            /// правоустанавливающие документ
            /// </summary>
            public string NameDoc { get; set; }

            /// <summary>
            /// номер
            /// </summary>
            public string Number { get; set; }

            /// <summary>
            /// Дата выдачи 
            /// </summary>
            public DateTime? DocIssueDate { get; set; }
        }
            /// <summary>
            /// Сведения о решении суда или органа местного самоуправления
            /// </summary>
            public string Solution { get; set; }
        
        /// <summary>
        /// Сведения об объекте капитального строительства, подлежащем сносу
        /// </summary>
        public Objekt InfoObjekt { get; set; }

        /// <summary>
        /// Заявитель
        /// </summary>
        public PersonType Applicant { get; set; }

        /// <summary>
        /// Сведения о наличии прав иных лиц на земельный участок 
        /// </summary>
        public AppliedDocument[] AppliedDocumentList { get; set; }
        public class AppliedDocument
        {
            /// <summary>
            /// ФИО
            /// </summary>
            public string Fio { get; set; }

            /// <summary>
            /// правоустанавливающие документ
            /// </summary>
            public string NameDoc { get; set; }

            /// <summary>
            /// номер
            /// </summary>
            public string Number { get; set; }

            /// <summary>
            /// Дата выдачи 
            /// </summary>
            public string DocIssueDate { get; set; }

        }
        /// <summary>
        /// Сведения о наличии прав иных лиц на объект капитального строительства 
        /// </summary>
        public ObjectAppliedDocument[] ObjectAppliedDocumentList { get; set; }
        public class ObjectAppliedDocument
        {
            /// <summary>
            /// ФИО
            /// </summary>
            public string Fio { get; set; }

            /// <summary>
            /// правоустанавливающие документ
            /// </summary>
            public string NameDoc { get; set; }

            /// <summary>
            /// номер
            /// </summary>
            public string Number { get; set; }

            /// <summary>
            /// Дата выдачи 
            /// </summary>
            public string DocIssueDate { get; set; }

        }

    }
}
    