using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UserRegistrationPortal.Models;
using UserRegistrationPortal.Dal;
using System.Web.Security;
using UserRegistrationPortal.Services;
using UserRegistrationPortal.Filters;

namespace UserRegistrationPortal.Controllers
{
    public class AccountController : Controller
    {
        private UserRegistrationPortalContext context = new UserRegistrationPortalContext();

        private IUserService userService;
        private IAuthenticationService authenticationService;

        public AccountController(IUserService addUser,IAuthenticationService authenticationService)
        {
            this.userService = addUser;
            this.authenticationService = authenticationService;
        }
        /// <summary>
        /// GET : Handle User Register Request
        /// </summary>
        /// <returns>Register View</returns>
        [HttpGet]
        [UserLoginFilter]
        public ActionResult Register()
        {
            ViewBag.ContactTypeList = context.ContactType.ToList();
            return View();
        }

        /// <summary>
        /// POST : Register New User
        /// </summary>
        /// <param name="userRegistrationDetails">Used to accept user details as a view model</param>
        /// <returns>Redirect to login view with appropriate status on successful registration or Display user friendly error messages</returns>
        [HttpPost]
        public ActionResult Register(UserRegisterViewModels userRegistrationDetails)
        {
            if (ModelState.IsValid)
            {
                return userService.AddUserDetails(userRegistrationDetails) > 0 ? RedirectToAction("Login", "Account", new { status = "Registration Completed Successfully" }) : RedirectToAction("Login", "Account", new { status = "Sorry Something Went Wrong" });
            }
            else
            {
                ViewBag.ContactTypeList = context.ContactType.ToList();
                List<string> validationErrors = ModelState.Values.Where(e => e.Errors.Count > 0).SelectMany(e => e.Errors).Select(e => e.ErrorMessage).ToList();
                ViewBag.validationErrors = validationErrors;
                return View();
            }
        }

        /// <summary>
        /// GET : Handle Login Request
        /// </summary>
        /// <param name="status">Used to accept user friendly status messages</param>
        /// <returns>Login View</returns>
        [HttpGet]
        [UserLoginFilter]
        public ActionResult Login(string status)
        {
            ViewBag.status = status;
            return View();
        }

        /// <summary>
        /// POST : Handle Login Request
        /// </summary>
        /// <param name="loginDetails">Used to accept email and password as a view model</param>
        /// <returns>Redirect To Login view with appropriate status (If Authentication fails) Or Redirect to user index view (For successful Authentication)</returns>
        [HttpPost]
        public ActionResult Login(LoginViewModels loginDetails)
        {
            if (ModelState.IsValid)
            {
                return authenticationService.UserAuthentication(loginDetails.Email,loginDetails.Password) ? RedirectToAction("Index", "User") : RedirectToAction("Login", "Account", new { status = "Invalid Email Or Password !" });
            }
            else
            {
                return RedirectToAction("Login", "Account", new { status = "Invalid login credentials !" });
            }
        }

        /// <summary>
        /// GET : Handle Logout Request
        /// </summary>
        /// <returns>Redirect To Login view with appropriate status</returns>
        [Authorize]
        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account", new { status = "Logout Successful !"});
        }
    }
}