using System.ComponentModel;

namespace AisLogistics.App.Models.AdditionalForms
{
    public sealed class GuardianshipModel : AbstractAdditionalFormModel
    {
        /// <summary>
        /// Муниципальный район
        /// </summary>
        [DisplayName("Муниципальный район")]
        public string MunicipalDistricts { get; set; }

        /// <summary>
        /// Глава района
        /// </summary>
        [DisplayName("Глава района")] 
        public string HeadRegion { get; set; }

        /// <summary>
        /// Вариант опеки
        /// </summary>
        [DisplayName("Вариант опеки")] 
        public string GuardianshipType { get; set; }

        /// <summary>
        /// Опекаемый
        /// </summary>
        [DisplayName("Опекаемый")] 
        public string FosterChildren { get; set; }

        /// <summary>
        /// Навыки
        /// </summary>
        [DisplayName("Навыки")] 
        public string Skills { get; set; }

        /// <summary>
        ///  Место работы
        /// </summary>
        [DisplayName("Место работы")] 
        public string PlaceOfWork { get; set; }

        /// <summary>
        /// Дополнительные сведения
        /// </summary>
        [DisplayName("Дополнительные сведения")] 
        public string MoreDetails { get; set; }

        /// <summary>
        /// Опекаемый
        /// </summary>
        public Fosterling Fosterling { get; set; }
        /// <summary>
        /// Супруг(га)
        /// </summary>
        public Spouse Spouse { get; set; }

        public Conclusion Conclusion { get; set; }
    }

    public sealed class Conclusion
    {
        /// <summary>
        /// Наименование органа
        /// </summary>
        [DisplayName("Наименование органа")]
        public string Name { get; set; }
        /// <summary>
        /// Дата
        /// </summary>
        [DisplayName("Дата")] 
        public string Date { get; set; }
        /// <summary>
        /// Номер
        /// </summary>
        [DisplayName("Номер")] 
        public string Number { get; set; }
    }

    public sealed class Spouse : PersonDate
    {
        /// <summary>
        /// Место работы
        /// </summary>
        [DisplayName("Место работы")]
        public string PlaceOfWork { get; set; }
    }

    public sealed class Fosterling: PersonDate
    {
       
    }

    public class PersonDate
    {
        /// <summary>
        /// ФИО
        /// </summary>
        [DisplayName("ФИО")]
        public string Name { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        [DisplayName("Дата рождения")]
        public string BirthDate { get; set; }

        /// <summary>
        /// Адрес проживания
        /// </summary>
        [DisplayName("Адрес проживания")]
        public string ResidentialAddress { get; set; }

        /// <summary>
        /// Адрес регистрации
        /// </summary>
        [DisplayName("Адрес регистрации")]
        public string RegistrationAddress { get; set; }

        /// <summary>
        /// Серия документа
        /// </summary>
        [DisplayName("Серия документа")]
        public string DocumentSeries { get; set; }

        /// <summary>
        /// Номер документа
        /// </summary>
        [DisplayName("Номер документа")]
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Кем выдан
        /// </summary>
        [DisplayName("Кем выдан")] 
        public string IssuedBy { get; set; }

        /// <summary>
        /// Дата выдачи
        /// </summary>
        [DisplayName("Дата выдачи")] 
        public string IssueDate { get; set; }
    }
}