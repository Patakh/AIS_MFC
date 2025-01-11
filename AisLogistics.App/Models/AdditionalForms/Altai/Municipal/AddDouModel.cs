using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Models.AdditionalForms.Municipal
{
    /// <summary> 
    ///                             ЗАЯВЛЕНИЕ 
    /// Прошу внести моего ребенка в базу данных о детях, 
    /// нуждающихся в определении в дошкольные образовательные 
    /// учреждения Муниципального образования «Шебалинский район»
    public class AddDouModel : AbstractAdditionalFormModel
    {

        /// <summary>
        /// Ф.И.О Начальника МО
        /// </summary>
        public string FioChief { get; set; }
        
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
        /// Телефон
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///  Ф.И.О. моего ребенка 
        /// </summary>
        public string FioChild { get; set; }

        /// <summary>
        ///  число, месяц и год рождения
        /// </summary>
        public string DateChild { get; set; }


            /// <summary>
            /// место работы 
            /// </summary>
            public string MotherWork { get; set; }
            /// <summary>
            /// место работы 
            /// </summary>
            public string FatherWork { get; set; }
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
    }
}
