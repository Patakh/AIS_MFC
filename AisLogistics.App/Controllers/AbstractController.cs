using AisLogistics.App.Service;
using NToastNotify;

namespace AisLogistics.App.Controllers
{
    public abstract class AbstractController : Controller
    {
        protected readonly IEmployeeManager _employeeManager;
        protected IToastNotification ToastNotity => HttpContext.RequestServices.GetService<IToastNotification>();

        protected AbstractController()
        {

        }

        public AbstractController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }

        [NonAction]
        protected void ShowSuccess(string message, string? title = "Готово") =>
            ToastNotity.AddSuccessToastMessage(message,
                new ToastrOptions { ToastClass = "btn-success", Title = title });

        [NonAction]
        protected void ShowError(string message, string? title = "Ошибка") =>
            ToastNotity.AddErrorToastMessage(message,
                new ToastrOptions { ToastClass = "btn-danger", Title = title });

        [NonAction]
        public ActionResult TableLayoutView<T>(T model) => PartialView("TableTemplate", model);

        [NonAction]
        protected ActionResult ModalLayoutView<T>(T model) => PartialView("Template/Modal", model);
        [NonAction]
        protected ActionResult PdfLayoutView<T>(T model) => PartialView("Template/Pdf", model);
    }
}