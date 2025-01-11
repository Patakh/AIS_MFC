namespace AisLogistics.App.Models;

public sealed class _200_ThirdChildModel : AbstractAdditionalFormModel
{
    /// <summary>
    /// Гражданство
    /// </summary>
    public string Citizenship { get; set; }

    /// <summary>
    /// Гражданство Представителя
    /// </summary>
    public string CitizenshipRespasive { get; set; }

    /// <summary>
    /// ФИО
    /// </summary>
    public string ChildFIO { get; set; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    public string ChildDateBirth { get; set; }

    /// <summary>
    /// Гражданство
    /// </summary>
    public string ChildCitizenship { get; set; }

    /// <summary>
    /// о наличии факта лишения/не лишения  родительских прав:
    /// </summary>
    public string ParentalRights { get; set; }

    /// <summary>
    /// о наличии факта принятия/непринятия решения об отмене усыновления: 
    /// </summary>
    public string CancellationAdoption { get; set; }
     
    /// <summary>
    /// Информация о доходах
    /// </summary>
    public Income IncomeInfo { get; set; }

    /// <summary>
    /// Ежемесячную выплату прошу переводить на счет в кредитной организации
    /// </summary>
    public string PaymentInfo { get; set; }

    /// <summary>
    /// Приложенные документы
    /// </summary>
    public AppliedDocument[] AppliedDocumentList { get; set; }
      
    public class Income
    {
        /// <summary>
        /// Сведения о доходах за период  с
        /// </summary>
        public string PeriodStartDate { get; set; }

        /// <summary>
        /// Сведения о доходах за период  по
        /// </summary>
        public string PeriodStopDate { get; set; }

        /// <summary>
        /// Доходы, полученные от трудовой деятельности
        /// </summary>
        public string Work { get; set; }

        /// <summary>
        /// Денежное довольствие
        /// </summary>
        public string CashAllowance { get; set; }

        /// <summary>
        /// Выплаты социального характера
        /// </summary>
        public string SocialBenefits { get; set; }

        /// <summary>
        /// Иные полученные доходы
        /// </summary>
        public string OtherReceived { get; set; }

        /// <summary>
        /// В том числе
        /// </summary>
        public string Including { get; set; }

        /// <summary>
        /// Доходы, полученные от предпринимательской деятельности
        /// </summary>
        public string BusinessActivities { get; set; }

        /// <summary>
        /// Алименты
        /// </summary>
        public string Alimony { get; set; }

        /// <summary>
        /// Прочие доходы
        /// </summary>
        public string Other { get; set; }
    }

    public class AppliedDocument
    {
        /// <summary>
        /// Наименование документа
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Количество Экземпляров
        /// </summary>
        public int? NumdberOriginals { get; set; }

        /// <summary>
        /// Количество страниц
        /// </summary>
        public int? NumdberPage { get; set; }
    }
}
