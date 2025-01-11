namespace AisLogistics.App.Models.AdditionalForms.Municipal;

/// <summary>  
/// постановка на учет детей и выдача направлений в образовательные учреждения
/// </summary>
public class Dou2Model : AbstractAdditionalFormModel
{ 
    /// <summary>
    /// подтверждающего представительство   
    /// </summary>
    public string СonfirmingRepresentation { get; set; }

    /// <summary>
    /// как  родитель (законный представитель)
    /// </summary>
    public string ApplicantType { get; set; }

    /// <summary>
    /// Желаемая дата приема на обучение
    /// </summary>
    public string DesiredDate { get; set; }

    /// <summary>
    /// наименование образовательной организации
    /// </summary>
    public string NamePreschool { get; set; }

    /// <summary>
    /// место нахождения образовательной организации
    /// </summary>
    public string DistrictDou { get; set; }

    /// <summary>
    /// Выбор языка образования   
    /// </summary>
    public string KindergartenLanguage { get; set; }

    /// <summary>
    /// Необходимый режим пребывания ребенка с
    /// </summary>
    public string With { get; set; }

    /// <summary>
    /// до
    /// </summary>
    public string Before { get; set; }

    /// <summary>
    /// Направленность дошкольной группы
    /// </summary>
    public string Focus { get; set; }

    /// <summary>
    /// реквизиты заключения психолого-медико-педагогической комиссии(при наличии)
    /// </summary>
    public string MedicalCertificates { get; set; }

    /// <summary>
    ///  Ф.И.О. ребенка 
    /// </summary>
    public string FioChild { get; set; }

    /// <summary>
    ///  дата  рождения
    /// </summary>
    public string DateChild { get; set; }

    /// <summary>
    ///  Реквизиты свидетельства о рождении ребенка
    /// </summary>
    public string BirthCertificates { get; set; }

    /// <summary>
    /// адрес места жительства
    /// </summary>
    public string FactAddressChild { get; set; }

    /// <summary>
    /// В связи с положенными мне специальными мерами поддержки прошу оказать данную услугу
    /// </summary>
    public string Queue { get; set; }

    /// <summary>
    /// (наименование образовательной организации из указанной в приоритете)
    /// </summary>
    public string DouDegree { get; set; }

    /// <summary>
    /// обучается брат (сестра)
    /// </summary>
    public string FioDegree { get; set; }
     
    /// <summary>
    /// образовательные организации
    /// </summary>
    public AppliedDocument[] DouList { get; set; }

    /// <summary>
    /// родитель
    /// </summary>
    public Person Applicant { get; set; }
      
    /// <summary>
    /// информировать по 
    /// </summary>
    public string Inform { get; set; }
     
    /// <summary>
    /// информировать по 
    /// </summary>
    public string InformAddress { get; set; }
     
    /// <summary>
    /// Приложение
    /// </summary>
    public AppliedDocument[] AppliedDocumentList { get; set; }
     
    public class AppliedDocument
    {
        /// <summary>
        /// Наименования
        /// </summary>
        public string Name { get; set; }
    }
     
    public class Person
    {
        /// <summary>
        /// Ф.И.О.
        /// </summary>
        public string Fio { get; set; }

        /// <summary>
        /// Серия  
        /// </summary>
        public string DocSeries { get; set; }

        /// <summary>
        /// Номер
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

}
