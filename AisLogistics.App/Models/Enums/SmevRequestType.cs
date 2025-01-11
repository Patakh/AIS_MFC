using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AisLogistics.App.Models
{
    /// <summary>
    /// Тип запросов СМЭВ (s_smev_type_request)
    /// </summary>
    public enum SmevRequestType
    {
        [Description("Синхронный запрос")]
        [Display(Name = "Синхронный")]
        Synchronous = 1,
        [Description("Асинхронный запрос")]
        [Display(Name = "Асинхронный")]
        Asynchronous = 2,
    }
}
