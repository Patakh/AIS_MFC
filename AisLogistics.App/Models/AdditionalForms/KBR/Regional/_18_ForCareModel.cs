namespace AisLogistics.App.Models;

/// <summary>
/// Назначение и выплата единовременного пособия при рождении ребенка
/// </summary>
public class _18_ForCareModel : AbstractAdditionalFormModel
{
    public _18_ForCareModel()
    {
        FamilyMembersList = new[]
         {
            new FamilyMembers()
        };

        AppliedDocumentList = new[]
       {
            new AppliedDocument()
        };
    }
     
    /// <summary>
    /// Способ выплаты
    /// </summary>
    public string PaymentMethod { get; set; }

    /// <summary>
    ///  Наименование банка
    /// </summary>
    public string NameCreditOrgan { get; set; }

    /// <summary>
    /// лицевой счет
    /// </summary>
    public string PersonalAccount { get; set; }

    /// <summary>
    /// Расчетный счет
    /// </summary>
    public string PaymentAccount { get; set; }
     
    /// <summary>
    ///  БИК
    /// </summary>
    public string BIK { get; set; }

    /// <summary>
    ///  ИНН
    /// </summary>
    public string INN { get; set; }

    /// <summary>
    /// КПП
    /// </summary>
    public string KPP { get; set; }

    /// <summary>
    /// Номер банковской карты
    /// </summary>
    public string BankCardNumber { get; set; }

    /// <summary>
    /// почтовое отделение
    /// </summary>
    public string PostOffice { get; set; }
     
    /// <summary>
    /// Приложенные документы
    /// </summary>
    public AppliedDocument[] AppliedDocumentList { get; set; }

    /// <summary>
    /// Приложенные документы
    /// </summary>
    public FamilyMembers[] FamilyMembersList { get; set; }

    public class AppliedDocument
    {
        /// <summary>
        /// Наименование документа
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Количество листов
        /// </summary>
        public string NumdberCopies { get; set; } 
    }

    public class FamilyMembers
    {
        /// <summary>
        /// Ф.И.О.
        /// </summary>
        public string FIO { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public string BirthDate { get; set; }
    }
}
