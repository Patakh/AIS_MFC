using AisLogistics.App.Models.AdditionalForms;
namespace AisLogistics.App.Models;

/// <summary>
/// Назначение и выплата ежемесячного пособия по уходу за ребенком-инвалидом
/// </summary>
public class _20_ForCareDisabledChildModel : AbstractAdditionalFormModel
{
    public _20_ForCareDisabledChildModel()
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
    /// Документ, подтверждающий полномочия законного  представителя (доверенного лица)
    /// Наименование
    /// </summary>
    public string RepresentativeDocName { get; set; }

    /// <summary>
    /// серия 
    /// </summary>
    public string RepresentativeDocSeries { get; set; }

    /// <summary>
    /// номер  
    /// </summary>
    public string RepresentativeDocNumber { get; set; }

    /// <summary>
    /// дата выдачи  
    /// </summary>
    public string RepresentativeDocDateIssuer { get; set; }

    /// <summary>
    /// кем выдан
    /// </summary>
    public string RepresentativeDocIssuerBody { get; set; }

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
