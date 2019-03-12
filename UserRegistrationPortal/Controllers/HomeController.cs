using System.Web.Mvc;
using UserRegistrationPortal.Services;
using UserRegistrationPortal.Models;

namespace UserRegistrationPortal.Controllers
{
    public class HomeController : Controller
    {
        private ICurrentUserService currentUser;
        public HomeController(ICurrentUserService currentUser)
        {
            this.currentUser = currentUser;
        }
        /// <summary>
        /// Get : Render Home View
        /// </summary>
        /// <returns>Home View</returns>
        [HttpGet]
        public ActionResult Index()
        {
            User users = currentUser.GetCurrentUser(Request);
            ViewBag.CurrentUser = users!=null ? users.Email : null;
            return View();
        }
    }
}