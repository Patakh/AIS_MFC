using AisLogistics.App.Models.AdditionalForms;

namespace AisLogistics.App.Models;

/// <summary>
/// Подтверждение документов об образовании и (или) о квалификации
/// </summary>
public class _103_ConfirmationEducationModel : AbstractAdditionalFormModel
{
    public _103_ConfirmationEducationModel()
    {
        AppliedDocumentList = new []
        {
            new AppliedDocument()
        };
    }

    /// <summary>
    /// наименование и реквизиты документа об образовании и(или) о квалификации
    /// </summary>
    public string EducationDocument { get; set; }

    /// <summary>
    /// Серия
    /// </summary>
    public string EducationDocumentSeries { get; set; }

    /// <summary>
    /// Номер
    /// </summary>
    public string EducationDocumentNumber { get; set; }

    /// <summary>
    ///  Регистр. Номер
    /// </summary>
    public string EducationDocumentRegNumber { get; set; }

    /// <summary>
    /// Наименование организации, выдавшей предоставленный к подтверждению документ, дата выдачи
    /// </summary>
    public string NameOrganIssue { get; set; }
       
    /// <summary>
    /// Обращаюсь в связи с
    /// </summary>
    public string Reason { get; set; }

    /// <summary>
    /// что подтверждается
    /// </summary>
    public string WhichConfirmed { get; set; }

    /// <summary>
    /// Адрес отправки прошедший процедуру подтверждения
    /// </summary>
    public string Adress { get; set; }

    /// <summary>
    /// Оригинал документа об образовании и (или) о квалификации
    /// </summary>
    public string Original { get; set; }

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
