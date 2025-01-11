namespace AisLogistics.App.Models;

/// <summary>
/// Создание приемной семьи 
/// </summary>
public class _233_CreatingFosterFamilyModel
{
    public _233_CreatingFosterFamilyModel()
    {
        FamilyMemberList = new[]
         {
            new FamilyMember()
        };

        FosterChildrenList = new[]
         {
            new FosterChildren()
        };
    }

    /// <summary>
    /// Родственники
    /// </summary>
    public FamilyMember[] FamilyMemberList { get; set; }

    /// <summary>
    /// Приемные дети
    /// </summary>
    public FosterChildren[] FosterChildrenList { get; set; }

    /// <summary>
    /// гражданство
    /// </summary>
    public string Citizenship { get; set; }

    /// <summary>
    /// ФИО Главы
    /// </summary>
    public string Leader { get; set; }

    /// <summary>
    /// место пребывания
    /// </summary>
    public string PlaceStay { get; set; }

    /// <summary>
    /// Доп. могу сообщить о себе следующее:
    /// </summary>
    public string ExtraInfo { get; set; }

    public class FosterChildren : Person
    {
        public FosterChildren()
        {
        
        }
    }

    public class FamilyMember : Person
    {
    }

    public class Person
    {
        /// <summary>
        /// Родство
        /// </summary>
        public string Kinship { get; set; }

        /// <summary>
        /// Ф.И.О.
        /// </summary>
        public string FIO { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public string BirthDate { get; set; }

        /// <summary>
        /// Адрес регистрации
        /// </summary>
        public string AdressRegistration { get; set; }

        /// <summary>
        /// Адрес фактического проживания
        /// </summary>
        public string AdressFakt { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Серия
        /// </summary>
        public string PassportSeries { get; set; }

        /// <summary>
        /// Номер
        /// </summary>
        public string PassportNumber { get; set; }

        /// <summary>
        /// Дата выдачи
        /// </summary>
        public string PassportDateIssue { get; set; }

        /// <summary>
        /// Место выдачи
        /// </summary>
        public string PassportPlakeIssue { get; set; }
    }
}
