namespace AisLogistics.App.Models.AdditionalForms.KBR.Federal;

/// <summary>
/// Принятие на учет молодых семей, нуждающихся в улучшении жилищных условий
/// </summary>
public class YoungFamilyImproveHousingModel
{
    /// <summary>
    /// Ф.И.О. 1-го супруга
    /// </summary>
    public string Partner1FullName { get; set; } = null!;

    /// <summary>
    /// Дата рождения 1-го супруга
    /// </summary>
    public string Partner1BirthDate { get; set; } = null!;

    /// <summary>
    /// Серия паспорта 1-го супруга
    /// </summary>
    public string Partner1DocumentSeries { get; set; } = null!;

    /// <summary>
    /// Номер паспорта 1-го супруга
    /// </summary>
    public string Partner1DocumentNumber { get; set; } = null!;

    /// <summary>
    /// Паспорт 1-го супруга кем выдан
    /// </summary>
    public string? Partner1DocumentGivenBy { get; set; }

    /// <summary>
    /// Паспорт 1-го супруга дата выдачи
    /// </summary>
    public string? Partner1DocumentGivenDate { get; set; }

    /// <summary>
    /// Адрес 1-го супруга
    /// </summary>
    public string? Partner1Address { get; set; }


    /// <summary>
    /// Ф.И.О. 2-го супруга
    /// </summary>
    public string Partner2FullName { get; set; } = null!;

    /// <summary>
    /// Дата рождения 2-го супруга
    /// </summary>
    public string Partner2BirthDate { get; set; } = null!;

    /// <summary>
    /// Серия паспорта 2-го супруга
    /// </summary>
    public string Partner2DocumentSeries { get; set; } = null!;

    /// <summary>
    /// Номер паспорта 2-го супруга
    /// </summary>
    public string Partner2DocumentNumber { get; set; } = null!;

    /// <summary>
    /// Паспорт 2-го супруга кем выдан
    /// </summary>
    public string? Partner2DocumentGivenBy { get; set; }

    /// <summary>
    /// Паспорт 2-го супруга дата выдачи
    /// </summary>
    public string? Partner2DocumentGivenDate { get; set; }

    /// <summary>
    /// Адрес 2-го супруга
    /// </summary>
    public string? Partner2Address { get; set; }

    /// <summary>
    /// Ребенок
    /// </summary>
    public class Child
    {
        /// <summary>
        /// Ф.И.О. ребенка
        /// </summary>
        public string FullName { get; set; } = null!;

        /// <summary>
        /// Дата рождения ребенка
        /// </summary>
        public string BirthDate { get; set; } = null!;

        /// <summary>
        /// Тип документа ребенка
        /// 1 - свидетельство о рождении
        /// 2 - паспорт
        /// </summary>
        public int DocumentTypeId { get; set; }

        /// <summary>
        /// Серия документа ребенка
        /// </summary>
        public string? DocumentSeries { get; set; }

        /// <summary>
        /// Номер документа ребенка
        /// </summary>
        public string? DocumentNumber { get; set; }

        /// <summary>
        /// Кем выдан документ ребенка
        /// </summary>
        public string? DocumentGivenBy { get; set; }

        /// <summary>
        /// Дата выдачи документа ребенка
        /// </summary>
        public string? DocumentGivenDate { get; set; }

        /// <summary>
        /// Адрес ребенка
        /// </summary>
        public string? Address { get; set; }
    }

    /// <summary>
    /// Дети
    /// </summary>
    public Child[] Children { get; set; } = Array.Empty<Child>();

    public class AppliedDocument
    {
        /// <summary>
        /// Наименование документа
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Номер документа
        /// </summary>
        public string? Number { get; set; }

        /// <summary>
        /// Документ выдан
        /// </summary>
        public string? GivenBy { get; set; }

        /// <summary>
        /// Дата выдачи документа
        /// </summary>
        public string? GivenDate { get; set; }
    }

    /// <summary>
    /// Документы, прилагаемые к заявлению об оценке доходов и иных денежных средств
    /// </summary>
    public AppliedDocument[] ProfitCheckAppliedDocumentList { get; set; } = Array.Empty<AppliedDocument>();

    /// <summary>
    /// Документы, прилагаемые к заявлению о включении в состав участников мероприятия по обеспечению жильем молодых семей
    /// </summary>
    public AppliedDocument[] InclusionDocumentList { get; set; } = Array.Empty<AppliedDocument>();
}
