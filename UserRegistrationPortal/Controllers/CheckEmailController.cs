using System.Linq;
using System.Web.Mvc;
using UserRegistrationPortal.Dal;
using UserRegistrationPortal.Filters;

namespace UserRegistrationPortal.Controllers
{
    public class CheckEmailController : Controller
    {
        private UserRegistrationPortalContext context = new UserRegistrationPortalContext();

        /// <summary>
        /// Return true as a json result if the user email in not present in the database otherwise false.
        /// </summary>
        /// <param name="email">Accept user email</param>
        /// <returns>True or False</returns>
        [HttpPost]
        [RequestTypeAjaxFilter]
        public JsonResult Verify(string email)
        {
            bool result = !context.User.Any(u => u.Email == email);
            return Json(result, "application/json", JsonRequestBehavior.AllowGet);
        }
    }
}