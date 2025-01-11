namespace AisLogistics.App.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet("[controller]/[action]/{code}")]
        public IActionResult Page(int code) //TODO ПЕРЕДЕЛАТЬ
        {
            if(code == 404)
                return View("Page404");

            return View("Page404");
        }
    }
}
