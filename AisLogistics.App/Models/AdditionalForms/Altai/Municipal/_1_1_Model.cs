using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Models.AdditionalForms.Municipal
{

    /// <summary>
    ///                      ЗАЯВЛЕНИЕ 
    /// Прошу внести изменение в заявление о внесении моего ребенка
    /// </summary>детские сады
    public class _1_1_Model : AbstractAdditionalFormModel
    {
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
        /// Контактные телефоны
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// E-mail
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///  Ф.И.О. моего ребенка 
        /// </summary>
        public string FioChild { get; set; }

        /// <summary>
        /// число, месяц и год рождения
        /// </summary>
        public string DateChild { get; set; }

        /// <summary>
        /// Ф.И.О. матери
        /// </summary>
        public string FioMother { get; set; }

        /// <summary>
        /// Ф.И.О. отца
        /// </summary>
        public string FioFather { get; set; }

        /// <summary>
        /// место работы отца
        /// </summary>
        public string FatherWorck { get; set; }

        /// <summary>
        /// место работы матери
        /// </summary>
        public string MotherWorck { get; set; }

        /// <summary>
        /// Дата заполнения 
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// Адрес регистрации
        /// </summary>
        public string RegisterAddress { get; set; }

        /// <summary>
        /// наименование дошкольной образовательной организации:   
        /// </summary>
        public string Kindergarten { get; set; }

        /// <summary>
        /// наличие льготы для получения места
        /// </summary>
        public string Benefits { get; set; }
    }
}
