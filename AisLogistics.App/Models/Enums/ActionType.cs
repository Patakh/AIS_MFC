using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AisLogistics.App.Models
{
    public enum ActionType
    {
        [Description("Добавление")]
        [Display(Name = "Добавление")]
        Add,
        [Description("Редактирование")]
        [Display(Name = "Редактирование")]
        Edit
    }
}
