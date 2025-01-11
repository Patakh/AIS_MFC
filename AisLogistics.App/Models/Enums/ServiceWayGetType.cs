using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AisLogistics.App.Models
{
    /// <summary>
    /// Тип обращений
    /// </summary>
    public enum ServiceWayGetType
    {
        [Description("За услугой")]
        [Display(Name = "За услугой")]
        ForService = 1,
        [Description("За результатом")]
        [Display(Name = "За результатом")]
        ForResult = 2,
    }
}
