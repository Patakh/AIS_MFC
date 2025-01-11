using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Models.AdditionalForms.Municipal
{
    /// <summary> 
    ///                             ЗАЯВЛЕНИЕ 
    /// Прошу внести моего ребенка  в базу данных о детях, нуждающихся в направлении 
    ///            в муниципальную дошкольную образовательную организацию
    ///                          города Горно-Алтайска.
    /// </summary>
    public class DouModel : AbstractAdditionalFormModel
    {
        public DouModel()
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

        /// <summary>
        /// Заявитель
        /// </summary>
        public string Fio { get; set; }

        /// <summary>
        /// Адрес регистрации
        /// </summary>
        public string ResidenceAddress { get; set; }

        /// <summary>
        /// Фактический адрес проживания
        /// </summary>
        public string FactAddress { get; set; }

        /// <summary>
        ///  Ф.И.О. моего ребенка 
        /// </summary>
        public string FioChild { get; set; }

        /// <summary>
        ///  число, месяц и год рождения
        /// </summary>
        public string DateChild { get; set; }

        /// <summary>
        ///  Реквизиты свидетельства о рождении ребенка
        /// </summary>
        public string BirthCertificates { get; set; }

        /// <summary>
        /// Фактический адрес проживания ребенка:
        /// </summary>
        public string FactAddressChild { get; set; }


        public class Person
        {
            /// <summary>
            /// Ф.И.О.
            /// </summary>
            public string Fio { get; set; }
            
            /// <summary>
            /// Серия паспорта
            /// </summary>
            public string DocSeries { get; set; }

            /// <summary>
            /// Номер паспорта
            /// </summary>
            public string DocNumber { get; set; }

            /// <summary>
            /// Тип документа
            /// </summary>
            public string DocType { get; set; }

            /// <summary>
            /// Дата выдачи
            /// </summary>
            public string IssuedDate { get; set; }

            /// <summary>
            /// Орган выдачи
            /// </summary>
            public string IssuedBy { get; set; }

            /// <summary>
            /// Контактные телефоны
            /// </summary>
            public string Phone { get; set; }

            /// <summary>
            /// E-mail
            /// </summary>
            public string Email { get; set; }

        }
        /// <summary>
        /// Мама
        /// </summary>
        public Person Mother { get; set; }

        /// <summary>
        /// Папа 
        /// </summary>
        public Person Father { get; set; }

        /// <summary>
        /// Реквизиты документа, подтверждающего установление опеки (при наличии)
        /// </summary>
        public string Guardianship { get; set; }

        /// <summary>
        /// Выбор языка образования   
        /// </summary>
        public string KindergartenLanguage { get; set; }

        /// <summary>
        /// специальных условий для инвалида (при наличии)
        /// </summary>
        public string SpecialConditions { get; set; }

        /// <summary>
        /// Направленность дошкольной группы
        /// </summary>
        public string Focus { get; set; }

        /// <summary>
        /// Необходимый режим пребывания ребенка с
        /// </summary>
        public string With { get; set; }

        /// <summary>
        /// до
        /// </summary>
        public string Before { get; set; }

        /// <summary>
        /// Желаемая дата приема на обучение
        /// </summary>
        public string DesiredDate { get; set; }

        /// <summary>
        /// Наименование дошкольной образовательной организации
        /// </summary>
        public string NamePreschool { get; set; }

        /// <summary>
        /// Наличие права на специальные меры поддержки (гарантии) отдельных категорий граждан и их семей (при необходимости):
        /// </summary>
        public string NameAvailability  { get; set; }

        /// <summary>
        /// Прошу выдать направление в 
        /// </summary>
        public string Issue { get; set; }

        /// <summary>
        /// информировать по 
        /// </summary>
        public string Inform { get; set; }

        public AppliedDocument[] AppliedDocumentList { get; set; }

        public class AppliedDocument
        {
            /// <summary>
            /// Приложение
            /// </summary>
            public string Name { get; set; }
        }
    }
}
