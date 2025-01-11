using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AisLogistics.App.Models
{
    public enum ServiceDocumentNeedsType
    {
        [Description("Обязательный")]
        [Display(Name = "Обязательный")]
        Required,

        [Description("Не обязательный")]
        [Display(Name = "Не обязательный")]
        NonRequired,

        [Description("При наличии")]
        [Display(Name = "При наличии")]
        InPresence
    }
}
