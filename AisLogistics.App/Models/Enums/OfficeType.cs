using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AisLogistics.App.Models
{
    public enum OfficeType
    {
        [Description("МФЦ")]
        [Display(Name = "МФЦ")]
        Mfc = 1,
        [Description("Муниципалитет")]
        [Display(Name = "Муниципалитет")]
        Municipality,
        [Description("Министерство")]
        [Display(Name = "Министерство")]
        Ministry,
        [Description("Комитет")]
        [Display(Name = "Комитет")]
        Committee,
        [Description("Управление")]
        [Display(Name = "Управление")]
        Management,
        [Description("Отдел")]
        [Display(Name = "Отдел")]
        Department,
        [Description("Фонд")]
        [Display(Name = "Фонд")]
        Fund,
        [Description("Агенство")]
        [Display(Name = "Агенство")]
        Agency,
        [Description("ТОСП")]
        [Display(Name = "ТОСП")]
        Tosp,
    }
}
