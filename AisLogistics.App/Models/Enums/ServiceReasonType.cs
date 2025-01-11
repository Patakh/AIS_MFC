using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AisLogistics.App.Models
{
    public enum ServiceReasonType
    {
        [Description("Прием")]
        [Display(Name = "Отказ в приеме услуги")]
        Accept = 1,
        [Description("Предоставление")]
        [Display(Name = "Отказ в предоставлении услуги")]
        Provide = 2,
        [Description("Приостановка")]
        [Display(Name = "Приостановка")]
        Suspend = 3,
    }
}
