using System.Web.Mvc;
using UserRegistrationPortal.Services;
using UserRegistrationPortal.Dal;
using UserRegistrationPortal.Filters;
using UserRegistrationPortal.Models;
using System;

namespace UserRegistrationPortal.Controllers
{
    public class UserController : Controller
    {
        private ICurrentUserService currentUser;
        private IUserService userService;
        private UserRegistrationPortalContext context = new UserRegistrationPortalContext();
        public UserController(ICurrentUserService currentUser, IUserService userService)
        {
            this.currentUser = currentUser;
            this.userService = userService;
        }
        /// <summary>
        ///     Get user details of an authenticated user.
        /// </summary>
        /// <returns>User detail view for an authenticated user</returns>
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            return View(userService.GetUserDetails(currentUser.GetCurrentUser(Request)));
        }
        [HttpPut]
        [RequestTypeAjaxFilter]
        public JsonResult Update(UserUpdateViewModels userDetails)
        {
            if (ModelState.IsValid)
            {
                var user = currentUser.GetCurrentUser(Request);
                return Json(userService.UpdateUserDetaisl(userDetails, user), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}