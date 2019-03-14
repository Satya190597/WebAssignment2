using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserRegistrationPortal.Filters;
using UserRegistrationPortal.Services;
using UserRegistrationPortal.Models;
using UserRegistrationPortal.Dal;
using Newtonsoft.Json;
using System.Collections;

namespace UserRegistrationPortal.Controllers
{
    public class AdminController : Controller
    {
        private IUserService userService;
        private ICurrentUserService currentUserService;
        private UserRegistrationPortalContext context = new UserRegistrationPortalContext();
        public AdminController(IUserService userService,ICurrentUserService currentUserService)
        {
            this.userService = userService;
            this.currentUserService = currentUserService;
        }
        // GET: Admin
        [HttpGet]
        [Authorize]
        [AuthorizeFilter(role:"admin")]
        public ActionResult AllRecords()
        {
            List<UserViewModels> allUsersRecords = new List<UserViewModels>();
            int id = currentUserService.GetCurrentUser(Request).RoleId;
            var result = context.User.Where(u => u.RoleId!=id);
            foreach(var user in result)
            {
                allUsersRecords.Add(this.userService.GetUserDetails(user));
            }
            ViewBag.AllUsers = allUsersRecords;
            return View();
        }
        [HttpGet]
        [RequestTypeAjaxFilter]
        [Authorize]
        [AuthorizeFilter(role: "admin")]
        public JsonResult GetUser(int id)
        {
            var result = userService.GetUserDetails(context.User.Find(id));
            return Json(JsonCreater(result), "application/json",JsonRequestBehavior.AllowGet);
        }
        //Admin Update User Details
        [HttpPut]
        [RequestTypeAjaxFilter]
        [Authorize]
        [AuthorizeFilter(role: "admin")]
        public JsonResult UpdateUser(int id,UserUpdateViewModels userDetails)
        {
            if (ModelState.IsValid)
            {
                var user = context.User.Include("UserRole").Where(u => u.Id == id).FirstOrDefault();
                return Json(userService.UpdateUserDetaisl(userDetails, user), JsonRequestBehavior.AllowGet);
            }
           else
           {
                return Json(false, JsonRequestBehavior.AllowGet);
           }
        }
        [HttpDelete]
        [RequestTypeAjaxFilter]
        [Authorize]
        [AuthorizeFilter(role: "admin")]
        public JsonResult DeleteUser(int id)
        {
            
            return Json(userService.DeleteUser(id));
        }
        private Dictionary<string,object> JsonCreater(UserViewModels user)
        {
            Dictionary<string, object> userDetails = new Dictionary<string, object>();
            Dictionary<string,string> details = new Dictionary<string,string>();
            details.Add("FirstName", user.FirstName);
            details.Add("LastName", user.LastName);
            details.Add("Email", user.Email);
            details.Add("Image", user.Image);
            details.Add("Address", user.Address);
            userDetails.Add("Details", details);
            Dictionary<string, List<string>> contacts = new Dictionary<string, List<string>>();
            foreach(var contact in user.Contact)
            {
                List<string> contactWithType = new List<string>();
                contactWithType.Add(contact.ContactType.ContactTypeText);
                contactWithType.Add(contact.ContactNumber);
                contacts.Add(contact.Id.ToString(), contactWithType);
            }
            userDetails.Add("Contacts", contacts);
           return userDetails;
        }
    }
}