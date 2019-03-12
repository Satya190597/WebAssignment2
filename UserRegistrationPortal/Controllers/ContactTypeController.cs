using System.Web.Mvc;
using UserRegistrationPortal.Dal;
using UserRegistrationPortal.Filters;

namespace UserRegistrationPortal.Controllers
{
    public class ContactTypeController : Controller
    {
        private UserRegistrationPortalContext context = new UserRegistrationPortalContext();

        /// <summary>
        /// Return all the contact types stored in a database as a json result.
        /// </summary>
        /// <returns>All Contact type as a json result</returns>
        [HttpGet]
        [RequestTypeAjaxFilter]
        public JsonResult Details()
        {
            return Json(context.ContactType,JsonRequestBehavior.AllowGet);
        }
    }
}


