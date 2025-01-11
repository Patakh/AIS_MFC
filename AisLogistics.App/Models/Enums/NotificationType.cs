using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AisLogistics.App.Models.Enums
{
    public enum NotificationType
    {
        [Description("Новая услуга")]
        [Display(Name = "Новая услуга")]
        NewCase = 1,
        [Description("Новый комментарий")]
        [Display(Name = "Новый комментарий")]
        NewComment,
        [Description("Ответ от СМЭВ")]
        [Display(Name = "Ответ от СМЭВ")]
        SmevRequest
    }
}
