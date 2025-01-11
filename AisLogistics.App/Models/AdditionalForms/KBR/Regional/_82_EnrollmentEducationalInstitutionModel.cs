namespace AisLogistics.App.Models;

/// <summary>
/// Зачисление в общеобразовательное учреждение
/// </summary>
public class _82_EnrollmentEducationalInstitutionModel
{
    public _82_EnrollmentEducationalInstitutionModel()
    {
       
        AppliedDocumentList = new[]
        {
            new AppliedDocument()
        };
    }

    /// <summary>
    ///  Наименование ОУ
    /// </summary>
    public string OrganizationName { get; set; }

    /// ФИО в родительном падеже
    public string ApplicantFIOGen { get; set; }

    /// <summary>
    /// ФИО директора
    /// </summary>
    public string FIOShef { get; set; }

    /// <summary>
    /// ФИО директора в дательном падеже
    /// </summary>
    public string FIOShefDat { get; set; }

    /// <summary>
    /// Класс
    /// </summary>
    public string Class { get; set; }

    /// <summary>
    /// ФИО ребенка 
    /// </summary>
    public string FIO { get; set; }

    /// <summary>
    /// ФИО ребенка  в родительном падеже
    /// </summary>
    public string FIOGen { get; set; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    public string BirthDate { get; set; }

    /// <summary>
    /// Место рождения
    /// </summary>
    public string AdresBirth { get; set; }

    /// <summary>
    /// Место жительства
    /// </summary>
    public string AdresLive { get; set; }

    /// <summary>
    /// Адрес по прописке
    /// </summary>
    public string AdresRegistration { get; set; }

    /// <summary>
    /// Данные второго родителя
    /// ФИО
    /// </summary>
    public string FIOOther { get; set; }

    /// <summary>
    /// Адрес
    /// </summary>
    public string AdresOther { get; set; }

    /// <summary>
    /// Контактный телефон
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// Приложенные документы
    /// </summary>
    public AppliedDocument[] AppliedDocumentList { get; set; }
    public class AppliedDocument
    {
        /// <summary>
        /// Наименование документа
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// кол экз.
        /// </summary>
        public string NumdberCopies { get; set; }

        /// <summary>
        /// кол стр.
        /// </summary>
        public string NumdberPages { get; set; }
    }
}
