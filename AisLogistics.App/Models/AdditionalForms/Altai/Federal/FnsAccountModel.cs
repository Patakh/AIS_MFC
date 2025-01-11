using System.ComponentModel;

namespace AisLogistics.App.Models.AdditionalForms
{
    // Документ не заполняется, если указан ИНН
    public sealed class FnsAccountModel : AbstractAdditionalFormModel
    {
        public FnsAccountModel()
        {
            CustomerFio = new();
            CustomerDoc = new();
            RepresentativeFio = new();            
            RepresentativeDoc = new();
        }

        /// <summary>
        /// Тип заявления
        /// </summary>
        public string ApplicationType { get; set; }

        /// <summary>
        /// Тип заявителя
        /// </summary>
        public string CustomerType { get; set; }

        /// <summary>
        /// ФИО заявителя
        /// </summary>
        public FioType CustomerFio { get; set; }

        /// <summary>
        /// ФИО представителя
        /// </summary>
        public FioType RepresentativeFio { get; set; }

        /// <summary>
        /// Сведения о документе, подтверждающем полномочия представителя физического лица
        /// </summary>
        public DocType RepresentativeDoc { get; set; }

        /// <summary>
        /// ИНН
        /// </summary>
        public string Inn { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Дата неудачной попытки регистрации
        /// </summary>
        public DateTime? FailedRegDate { get; set; }

        /// <summary>
        /// Код налогового органа при неучдачной регистрации
        /// </summary>
        public string FnsDepartmentFailedRegCode { get; set; }

        /// <summary>
        /// Код налогового органа
        /// </summary>
        public string FnsDepartmentCode { get; set; }

        /// <summary>
        /// Место рождения
        /// </summary>
        public string BirthPlace { get; set; }

        /// <summary>
        /// Сведения о документе, удостоверяющем личность физического лица
        /// </summary>
        public DocType CustomerDoc { get; set; }       

        /// <summary>
        /// Цель обращения
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// Номер контактного телефона
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Адрес электронной почты
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Способ получения Регистрационной карты для получения доступа 
        /// к личному кабинету налогоплательщика
        /// </summary>
        public string MethodResult { get; set; }

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

        public class DocType
        {
            /// <summary>
            /// Наименование
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Серия
            /// </summary>
            public string Series { get; set; }

            /// <summary>
            /// Номер
            /// </summary>
            public string Number { get; set; }

            /// <summary>
            /// Дата выдачи
            /// </summary>
            public DateTime? IssueDate { get; set; }
        }
    }
}
