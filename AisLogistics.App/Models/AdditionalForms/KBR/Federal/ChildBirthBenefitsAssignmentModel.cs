namespace AisLogistics.App.Models.AdditionalForms.KBR.Federal;

/// <summary>
/// Назначение и выплата единовременного пособия при рождении ребенка
/// </summary>
public class ChildBirthBenefitsAssignmentModel
{
    /// <summary>
    /// Ребенок
    /// </summary>
    public class Child
    {
        /// <summary>
        /// Ф.И.О.
        /// </summary>
        public string FullName { get; set; } = null!;

        /// <summary>
        /// Дата рождения
        /// </summary>
        public string? BirthDate { get; set; }
    }

    /// <summary>
    /// Дети
    /// </summary>
    public Child[] Children { get; set; } = Array.Empty<Child>();

    /// <summary>
    /// метод перечисления пособия
    /// 1 - кредитная организация
    /// 2 - отделение организации федеральной почтовой связи
    /// </summary>
    public int PaymentMethodId { get; set; }

    /// <summary>
    /// Название кредитной организации, если PaymentMethodId=1
    /// </summary>
    public string? CreditOrganizationName { get; set; }

    /// <summary>
    /// Номер счета получателя, если PaymentMethodId=1
    /// </summary>
    public string? CreditOrganizationAccount { get; set; }

    #region Банковские реквизиты для выплаты

    /// <summary>
    /// Лицевой счет
    /// </summary>
    public string? AccountNumber { get; set; }

    /// <summary>
    /// Расчетный счет
    /// </summary>
    public string? PaymentAccountNumber { get; set; }

    /// <summary>
    /// Наименование банка
    /// </summary>
    public string? BankName { get; set; }

    /// <summary>
    /// БИК
    /// </summary>
    public string? BIK { get; set; }

    /// <summary>
    /// ИНН
    /// </summary>
    public string? INN { get; set; }

    /// <summary>
    /// КПП
    /// </summary>
    public string? KPP { get; set; }

    /// <summary>
    /// Номер банковской карты
    /// </summary>
    public string? CardNumber { get; set; }

    #endregion

    #region Законный представитель

    /// <summary>
    /// Ф.И.О. законного представителя
    /// </summary>
    public string? AgentFullName { get; set; }

    /// <summary>
    /// Наименование документа законного представителя
    /// </summary>
    public string? AgentDocumentName { get; set; }

    /// <summary>
    /// Серия документа законного представителя
    /// </summary>
    public string? AgentDocumentSeries { get; set; }

    /// <summary>
    /// Номер документа законного представителя
    /// </summary>
    public string? AgentDocumentNumber { get; set; }

    /// <summary>
    /// Дата выдачи документа законного представителя
    /// </summary>
    public string? AgentDocumentGivenDate { get; set; }

    /// <summary>
    /// Кем выдан документ законного представителя
    /// </summary>
    public string? AgentDocumentGivenBy { get; set; }

    /// <summary>
    /// Адрес законного представителя
    /// </summary>
    public string? AgentAddress { get; set; }

    /// <summary>
    /// Телефон законного представителя
    /// </summary>
    public string? AgentPhone { get; set; }

    #endregion

    /// <summary>
    /// Прилагаемый документ
    /// </summary>
    public class AppliedDocument
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Количество листов
        /// </summary>
        public int PageAmount { get; set; }
    }

    /// <summary>
    /// Прилагаемые документы
    /// </summary>
    public AppliedDocument[] AppliedDocuments { get; set; } = Array.Empty<AppliedDocument>();
}
