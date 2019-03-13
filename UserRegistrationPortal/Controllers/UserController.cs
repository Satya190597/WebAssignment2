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
        [ChildActionOnly]
        [Authorize]
        public ActionResult Update()
        {
            return PartialView("~/Views/TestView/UpdateUser.cshtml");
        }
        //[HttpPut]
        //[RequestTypeAjaxFilter]
        //public JsonResult Update(UserUpdateViewModels userDetails)
        //{
        //    // -- Current User Is Working Properly --
        //    var user = currentUser.GetCurrentUser(Request);
        //    //throw new Exception();
        //}
    }
}