using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace AisLogistics.App.Models.AdditionalForms
{
    /// <summary>
    ///  Предоставление заинтересованным лицам сведений, содержащихся в реестре дисквалифицированных лиц
    /// </summary>
    public class DisqualifiedPersonsModel : AbstractAdditionalFormModel
    {
        /// <summary>
        ///  наименование налогового органа
        /// </summary>
        public string Recipient { get; set; }
        public sealed class Address
        {
            /// <summary>
            /// почтовый индекс
            /// </summary>
            public string PostalСode { get; set; }

              /// <summary>
            /// Субъект РФ
            /// </summary>
            public string Region { get; set; }

            /// <summary>
            /// Город, район, населенный пункт
            /// </summary>
            public string Locality { get; set; }

            /// <summary>
            /// Улица
            /// </summary>
            public string Street { get; set; }

            /// <summary>
            /// Дом
            /// </summary>
            public string House { get; set; }
        }

        public class PersonType
        {
            /// <summary>
            /// Фамилия
            /// </summary>
            public string LastName { get; set; }

            /// <summary>
            /// Имя
            /// </summary>
            public string FirstName { get; set; }

            /// <summary>
            /// Отчество
            /// </summary>
            public string SecondName { get; set; }

            /// <summary>
            /// Дата рождения
            /// </summary>
            public DateTime? BirthDate { get; set; }

            /// <summary>
            /// полное наименование юридического лица
            /// </summary>
            public string FullName { get; set; }

            /// <summary>
            /// ИНН 
            /// </summary>
            public string INNLegal { get; set; }

            /// <summary>
            /// ОГРН
            /// </summary>
            public string OGRN { get; set; }

            /// <summary>
            /// Заявитель
            /// </summary>
            public string Applicant { get; set; }

            /// <summary>
            /// место рождения
            /// </summary>
            public Address PlaceBirth { get; set; }

            /// <summary>
            ///  место жительства
            /// </summary>
            public Address Residence { get; set; }

        }

        /// <summary>
        /// Сведения о застройщике
        /// </summary>
        public string FaceApplicant { get; set; }

        /// <summary>
        /// Заявитель
        /// </summary>
        public PersonType Applicant { get; set; }

        /// <summary>
        /// Заявитель
        /// </summary>
        public PersonType ApplicantLegal { get; set; }

        /// <summary>
        /// в лице  
        /// </summary>
        public PersonType InPerson { get; set; }

        /// <summary>
        /// Номер доверенности 
        /// </summary>
        public string DocNumber { get; set; }

        /// <summary>
        /// Кем выдан 
        /// </summary>
        public string DocIssuer { get; set; }

        /// <summary>
        /// Дата выдачи 
        /// </summary>
        public string DocIssueDate { get; set; }

        /// <summary>
        /// лица , о котором запрашивается информация 
        /// </summary>
        public PersonType RequestedFace { get; set; }

        /// <summary>
        /// Информирование
        /// </summary>
        public string Info { get; set; }

        /// <summary>
        /// адрес электронной почты 
        /// </summary>
        public string Email { get; set; }


        /// <summary>
        /// почтовый адрес
        /// </summary>
        public string PostalAddress { get; set; }

    }
}
    