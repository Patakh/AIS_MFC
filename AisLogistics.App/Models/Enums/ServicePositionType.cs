using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AisLogistics.App.Models
{
    public enum ServicePositionType
    {
        [Description("Универсальная")]
        [Display(Name = "Универсальная")]
        Universal,

        [Description("Главная")]
        [Display(Name = "Только как Главная")]
        OnlyAsMain,

        [Description("Подуслуга")]
        [Display(Name = "Только как Подуслуга")]
        OnlyAsSubService
    }
}
