using System.Web.Mvc;

namespace UserRegistrationPortal.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet]
        public ActionResult UnhandleError()
        {
            return View();
        }
        [HttpGet]
        public ActionResult NotFound()
        {
            return View();
        }
    }
}