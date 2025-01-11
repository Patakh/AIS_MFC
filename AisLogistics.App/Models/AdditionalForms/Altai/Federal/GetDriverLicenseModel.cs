using System.ComponentModel;

namespace AisLogistics.App.Models.AdditionalForms
{
    public sealed class GetDriverLicenseModel : AbstractAdditionalFormModel
    {
        public GetDriverLicenseModel()
        {
            Customer = new PersonType
            {
                IdentityDoc = new DocumentType()
            };
        }

        /// <summary>
        /// Отдел ГИБДД
        /// </summary>
        [DisplayName("Отдел ГИБДД")]
        public string GibddDepartmentName { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        [DisplayName("Пол")]
        public string Gender { get; set; }

        /// <summary>
        /// Цель обращения
        /// </summary>
        [DisplayName("Цель обращения")]
        public string Target { get; set; }

        /// <summary>
        /// Приложенные документы
        /// </summary>
        [DisplayName("Приложенные документы")]
        public string[] AppliedDocuments { get; set; }

        /// <summary>
        /// Данные заявителя
        /// </summary>
        public PersonType Customer { get; set; }                      

        public sealed class PersonType
        {
            /// <summary>
            /// Фамилия
            /// </summary>
            [DisplayName("Фамилия")]
            public string LastName { get; set; }

            /// <summary>
            /// Имя
            /// </summary>
            [DisplayName("Имя")]
            public string FirstName { get; set; }
            /// <summary>
            /// Отчество
            /// </summary>
            [DisplayName("Отчество")]
            public string SecondName { get; set; }

            /// <summary>
            /// Дата рождения
            /// </summary>
            [DisplayName("Дата рождения")]
            public DateTime? BirthDate { get; set; }

            /// <summary>
            /// Место рождения
            /// </summary>
            [DisplayName("Место рождения")]
            public string BirthPlace { get; set; }

            /// <summary>
            /// Адрес проживания
            /// </summary>
            [DisplayName("Алрес проживания")]
            public string Address { get; set; }

            /// <summary>
            /// Документ, удостоверяющий личность
            /// </summary>
            public DocumentType IdentityDoc { get; set; }      

            /// <summary>
            /// СНИЛС
            /// </summary>
            [DisplayName("СНИЛС")]
            public string Snils { get; set; }

            /// <summary>
            /// Мобильный телефон
            /// </summary>
            [DisplayName("Мобильный телефон")]
            public string Phone { get; set; }

            /// <summary>
            /// Электронная почта
            /// </summary>
            [DisplayName("Электронная почта")]
            public string Email { get; set; }
        }

        public class DocumentType
        {
            /// <summary>
            /// Наименование документа
            /// </summary>
            [DisplayName("Наименование документа")]
            public string Name { get; set; }

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

            /// <summary>
            /// Код подразделения
            /// </summary>
            [DisplayName("Код подразделения")]
            public string IssuerCode { get; set; }
        }

        /// <summary>
        /// Серия
        /// </summary>
        [DisplayName("Серия")]
        public string SeriesDrive { get; set; }

        /// <summary>
        /// Номер
        /// </summary>
        [DisplayName("Номер")]
        public string NumberDrive { get; set; }

        /// <summary>
        /// Категория ТС
        /// </summary>
        [DisplayName("Категория ТС")]
        public string CategoryDrive { get; set; }

        /// <summary>
        /// Дата выдачи
        /// </summary>
        [DisplayName("Дата выдачи")]
        public string DateDrive { get; set; }

        /// <summary>
        /// Кем выдан
        /// </summary>
        [DisplayName("Кем выдан")]
        public string IssuerDrive { get; set; }

        /// <summary>
        /// Особые отметки
        /// </summary>
        [DisplayName("Особые отметки")]
        public string SpecialMarksDrive { get; set; }

        /// <summary>
        /// Серия
        /// </summary>
        [DisplayName("Серия")]
        public string SeriesMedical { get; set; }

        /// <summary>
        /// Номер
        /// </summary>
        [DisplayName("Номер")]
        public string NumberMedical { get; set; }

        /// <summary>
        /// Дата выдачи
        /// </summary>
        [DisplayName("Дата выдачи")]
        public string DateMedical { get; set; }

        /// <summary>
        /// Регион выдачи
        /// </summary>
        [DisplayName("Регион выдачи")]
        public string IssuerMedical { get; set; }

        /// <summary>
        /// Наименование медицинского учереждения
        /// </summary>
        [DisplayName("Наименование медицинского учереждения")]
        public string NameMedical { get; set; }

        /// <summary>
        /// Категория
        /// </summary>
        [DisplayName("Категория")]
        public string CategoryMedical { get; set; }

        /// <summary>
        /// Медиинское ограничение
        /// </summary>
        [DisplayName("Медиинское ограничение")]
        public string LimitationMedical { get; set; }

        /// <summary>
        /// Медиинское показание
        /// </summary>
        [DisplayName("Медиинское показание")]
        public string IndicationMedical { get; set; }

        /// <summary>
        /// Стаж
        /// </summary>
        [DisplayName("Стаж")]
        public string Experience { get; set; }

        /// <summary>
        /// Свидетельство о профессии водителя
        /// </summary>
        /// <summary>
        /// Серия
        /// </summary>
        [DisplayName("Серия")]
        public string SeriesProfessions { get; set; }

        /// <summary>
        /// Номер
        /// </summary>
        [DisplayName("Номер")]
        public string NumberProfessions { get; set; }

        /// <summary>
        /// Дата выдачи
        /// </summary>
        [DisplayName("Дата выдачи")]
        public string DateProfessions { get; set; }

        /// <summary>
        /// Наименование организации выдавшей свидетельство
        /// </summary>
        [DisplayName("Наименование организации выдавшей свидетельство")]
        public string NameOrganization { get; set; }

        /// <summary>
        /// Тип трансмиссии
        /// </summary>
        [DisplayName("Тип трансмиссии")]
        public string TransmissionType { get; set; }
        
        /// <summary>
        /// Дополнительные сведения
        /// </summary>
        [DisplayName("Дополнительные сведения")]
        public string DopInfo { get; set; }
    }    
}