using AisLogistics.App.Models.AdditionalForms;
namespace AisLogistics.App.Models;

/// <summary>
/// Предоставление ежемесячной денежной компенсации расходов на уплату взноса на капитальный ремонт 
/// общего имущества в многоквартирном доме отдельным категориям граждан
/// </summary>
public class _69_ForCareapartmentBuildingModel : AbstractAdditionalFormModel
{
    public _69_ForCareapartmentBuildingModel()
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
    /// Указать льготное отделение
    /// </summary>
    public string Categories { get; set; }

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
        /// Количество
        /// </summary>
        public string NumdberCopies { get; set; } 
    }

    public class FamilyMembers
    {
        /// <summary>
        /// ФИО
        /// </summary>
        public string FIO { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public string BirthDate { get; set; }

        /// <summary>
        /// Адрес
        /// </summary>
        public string Adres { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Серия
        /// </summary>
        public string Series { get; set; }

        /// <summary>
        /// Номер
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// кем выдано
        /// </summary>
        public string IssueBody { get; set; }

        /// <summary>
        /// дата выдачи
        /// </summary>
        public string IssueDate { get; set; }

        /// <summary>
        /// ФИО представителя (при наличии)
        /// </summary>
        public string FIORespensive { get; set; } 
    }
}
