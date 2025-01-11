namespace AisLogistics.App.Models.AdditionalForms.KBR.Federal;

/// <summary>
/// 
/// </summary>
public class LargeFamiliesOneTimeTargetedSocialAssistanceModel
{
    /// <summary>
    /// Ф.И.О. другого супруга
    /// </summary>
    public string? OtherPartnerFullName { get; set; }

    /// <summary>
    /// Дата рождения другого супруга
    /// </summary>
    public string? OtherPartnerBirthDate { get; set; }

    /// <summary>
    /// Данные документа, удостоверяющего личность другого супруга
    /// </summary>
    public string? OtherPartnerDocumentRequisites { get; set; }

    /// <summary>
    /// Адрес проживания другого супруга
    /// </summary>
    public string? OtherPartnerAddress { get; set; }

    /// <summary>
    /// Ребенок
    /// </summary>
    public class Child
    {
        /// <summary>
        /// Ф.И.О. другого супруга
        /// </summary>
        public string? FullName { get; set; }

        /// <summary>
        /// Дата рождения другого супруга
        /// </summary>
        public string? BirthDate { get; set; }

        /// <summary>
        /// Данные документа, удостоверяющего личность другого супруга
        /// </summary>
        public string? DocumentRequisites { get; set; }

        /// <summary>
        /// Адрес проживания другого супруга
        /// </summary>
        public string? Address { get; set; }
    }

    /// <summary>
    /// Дети
    /// </summary>
    public Child[] Children { get; set; } = Array.Empty<Child>();

    /// <summary>
    /// Прилагаемые документы
    /// </summary>
    public string[] AppliedDocuments { get; set; } = Array.Empty<string>();
}
