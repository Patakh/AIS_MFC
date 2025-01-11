using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AisLogistics.App.Models
{
    public enum DocumentType
    {
        ServiceDocument,
        ServiceDocumentResult
    }

    public enum DocumentFileAddType
    {
        [Description("Сканирование")]
        [Display(Name = "Сканирование")]
        Scan = 1,

        [Description("Рабочий стол")]
        [Display(Name = "Рабочий стол")]
        Desktop = 2,

        [Description("Архив")]
        [Display(Name = "Архив")]
        Archive = 3,
    }
}