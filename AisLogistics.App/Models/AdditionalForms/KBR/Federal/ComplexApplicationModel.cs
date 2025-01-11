namespace AisLogistics.App.Models.AdditionalForms.KBR.Federal;

/// <summary>
/// Комплексный запрос
/// </summary>
public class ComplexApplicationModel
{
    public class Service
    {
        /// <summary>
        /// Наименование государственной и (или) муниципальной услуги 
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Последовательность предоставления услуг
        /// </summary>
        public string? ProvisionSequence { get; set; }
    }

    /// <summary>
    /// Перечень услуг
    /// </summary>
    public Service[] Services { get; set; } = Array.Empty<Service>();

    /// <summary>
    /// Иные сведения
    /// </summary>
    public string[] OtherInformation { get; set; } = Array.Empty<string>();

    public class AppliedDocument
    {
        /// <summary>
        /// Наименование документа
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Реквизиты документа
        /// </summary>
        public string? Requisites { get; set; }

        /// <summary>
        /// Оригинал, кол-во экземпляров
        /// </summary>
        public int OriginalExemplarAmount { get; set; }

        /// <summary>
        /// Оригинал, кол-во страниц
        /// </summary>
        public int OriginalPageAmont { get; set; }

        /// <summary>
        /// Копия, кол-во экземпляров
        /// </summary>
        public int CopyExemplarAmount { get; set; }

        /// <summary>
        /// Копия, кол-во страниц
        /// </summary>
        public int CopyPageAmont { get; set; }
    }

    /// <summary>
    /// Прилагаемые документы
    /// </summary>
    public AppliedDocument[] AppliedDocuments { get; set; } = Array.Empty<AppliedDocument>();

    /// <summary>
    /// Общий срок выполнения комплексного запроса не позднее
    /// </summary>
    public string? ComplexApplicationEndDate { get; set; }

    /// <summary>
    /// Способ информирования заявителя
    /// 1 - По телефону
    /// 2 - По электронной почте
    /// 3 - В ходе личного обращения
    /// </summary>
    public int InformMethodId { get; set; }

    /// <summary>
    /// Телефонный номер, если InformMethodId=1
    /// </summary>
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Адрес электронной почты, если InformMethodId=2
    /// </summary>
    public string? EMail { get; set; }
}
