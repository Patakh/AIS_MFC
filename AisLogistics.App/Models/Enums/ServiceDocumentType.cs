using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AisLogistics.App.Models
{
    public enum ServiceDocumentType
    {
        [Description("Оригинал")]
        [Display(Name = "Оригинал")]
        Original,
        [Description("Копия")]
        [Display(Name = "Копия")]
        Copy
    }
}
