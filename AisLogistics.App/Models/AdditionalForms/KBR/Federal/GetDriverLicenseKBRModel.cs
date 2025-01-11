using AisLogistics.App.Models.AdditionalForms; 

namespace AisLogistics.App.Models;

/// <summary>
/// Водительское удостоверение
/// </summary>
public sealed class GetDriverLicenseKBRModel : AbstractAdditionalFormModel
{
    public GetDriverLicenseKBRModel()
    {
        AppliedDocumentList = new[]
        {
            new AppliedDocument()
        };
    }

    /// <summary>
    /// от кого
    /// </summary>
    public string FioGenitiveCase { get; set; }

    /// <summary>
    /// категория (подкатегория) ТС
    /// </summary>
    public string Categoryes { get; set; }

    /// <summary>
    /// Категория ТС
    /// </summary>
    public string CategoryDrive { get; set; }

    /// <summary>
    /// Цель обращения
    /// </summary> 
    public string Target { get; set; }

    /// <summary>
    /// Отдел ГИБДД
    /// </summary> 
    public string GibddDepartmentName { get; set; }

    /// <summary>
    /// водительское удостоверение
    /// Серия
    /// </summary> 
    public string SeriesDrive { get; set; }

    /// <summary>
    /// Номер
    /// </summary> 
    public string NumberDrive { get; set; }


    /// <summary>
    /// Дата выдачи
    /// </summary> 
    public string DateDrive { get; set; }

    /// <summary>
    /// Кем выдан
    /// </summary> 
    public string IssuerDrive { get; set; }

    /// <summary>
    /// Особые отметки
    /// </summary> 
    public string SpecialMarksDrive { get; set; }

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

        /// <summary>
        /// Вид документа
        /// </summary>
        public string Type { get; set; }
    }
}