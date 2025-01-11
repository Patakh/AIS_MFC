using System.ComponentModel;

namespace AisLogistics.App.Models.AdditionalForms
{
    /// Документ не заполняется, если указан ИНН
    public sealed class _67_7Model : AbstractAdditionalFormModel
    {

        public _67_7Model()
        {
            CustomerFio = new();
            RepresentativeFio = new();

        }
        /// <summary>
        /// ФИО заявителя
        /// </summary>
        public FioType CustomerFio { get; set; }

        /// <summary>
        /// ФИО представителя
        /// </summary>
        public FioType RepresentativeFio { get; set; }

        /// <summary>
        /// ИНН
        /// </summary>
        public string Inn { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Место рождения
        /// </summary>
        public string BirthPlace { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        public string CustomerGender { get; set; }

        /// <summary>
        /// Код подразделения
        /// </summary>
        public string DocCode { get; set; }

        /// <summary>
        /// Серия и номер документа
        /// </summary>
        public string DocSeriesNumber { get; set; }

        /// <summary>
        /// Дата выдачи документа
        /// </summary>
        public DateTime? DocIssueDate { get; set; }

        /// <summary>
        /// Кем выдан документ
        /// </summary>
        public string DocIssuer { get; set; }

        /// <summary>
        /// СНИЛС Заявителя
        /// </summary>
        public string CustomerSnils { get; set; }

        /// <summary>
        /// ИНН
        /// </summary>
        public string CustomerInn { get; set; }


        /// <summary>
        /// Наименование коренного малочисленного народа
        /// </summary>
        public string Nation { get; set; }
        public class AdressRegistration
        {
            /// <summary>
            /// Почтовый индекс				
            /// </summary>
            public string PostalCode { get; set; }

            /// <summary>
            /// Субъект Российской Федерации (код)
            /// </summary>
            public string RussiaCode { get; set; }

            /// <summary>
            /// Район
            /// </summary>
            public string District
            { get; set; }

            /// <summary>
            /// Населенный пункт
            /// </summary>
            public string Locality
            { get; set; }

            /// <summary>
            /// Улица
            /// </summary>
            public string Street
            { get; set; }

            /// <summary>
            /// Номер дома
            /// </summary>
            public string HouseNumber
            { get; set; }

            /// <summary>
            /// Номер корпуса
            /// </summary>
            public string CaseNumber
            { get; set; }

            /// <summary>
            /// Номер квартиры
            /// </summary>
            public string ApartmentNumber
            { get; set; }
        }

        /// <summary>
        /// Адрес регистрации по месту жительства в Российской Федерации
        /// </summary>
        public AdressRegistration Residence { get; set; }

        /// <summary>
        /// Адрес регистрации по месту пребывания в Российской Федерации (при наличии)
        /// </summary>
        public AdressRegistration Stay { get; set; }

        /// <summary>
        /// Веду традиционный образ жизни и традиционную хозяйственную деятельность:
        /// </summary>
        public string LeadingTraditional
        { get; set; }

        /// <summary>
        /// Традиционная хозяйственной деятельности является подсобной по отношению к основному виду деятельности:
        /// </summary>
        public string Auxiliary
        { get; set; }

        /// <summary>
        /// Осуществляемый вид (виды) традиционной хозяйственной деятельности:
        /// </summary>
        public string TypesActivities 
        { get; set; }
        
        public class Info_Economic_Activity
        {
            /// <summary>
            /// Полное наименование организации
            /// </summary>
            public string FullNameOrganization
            { get; set; }


            /// <summary>
            /// ОГРН
            /// </summary>
            public string OGRN
            { get; set; }

            /// <summary>
            /// ИНН
            /// </summary>
            public string INN
            { get; set; }

        }
        /// <summary>
        /// Работа в организации, осуществляющей традиционную хозяйственную деятельность (при наличии)
        /// </summary>
        public Info_Economic_Activity TraditionalHousehold { get; set; }

        /// <summary>
        /// Членство в общине коренных малочисленных народов (при наличии)
        /// </summary>
        public Info_Economic_Activity Membership { get; set; }

        /// <summary>
        ///  Уведомление прошу направить (выдать):
        /// </summary>
        public string Notification
        { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        public string Telephone
        { get; set; }

        /// <summary>
        /// E-mail (адрес электронной почты)
        /// </summary>
        public string Email
        { get; set; }

        public class Regarding
        {
            public Info_Economic_Activity info_Economic_Activity { get; set; }
            public FioType Fio { get; set; }

            /// <summary>
            /// Документы представлены
            /// </summary>
            public string Submitted
            { get; set; }


            /// <summary>
            /// Должность
            /// </summary>
            public string Post
            { get; set; }

            /// <summary>
            /// Код подразделения
            /// </summary>
            public string DocCode { get; set; }

            /// <summary>
            /// Серия и номер документа
            /// </summary>
            public string DocSeriesNumber { get; set; }

            /// <summary>
            /// Дата выдачи документа
            /// </summary>
            public DateTime? DocIssueDate { get; set; }

            /// <summary>
            /// Кем выдан документ
            /// </summary>
            public string DocIssuer { get; set; }

        }

        public class FioType
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
        }


    }
}
