using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AisLogistics.App.Models
{
    public enum CalendarDateType
    {
        [Description("Выходной")]
        [Display(Name = "Выходной день")]
        Weekend,

        [Description("Рабочий")]
        [Display(Name = "Рабочий день")]
        Working,

        [Description("Праздник")]
        [Display(Name = "Праздник")]
        Holiday
    }
}
