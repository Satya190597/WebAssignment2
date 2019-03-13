using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using UserRegistrationPortal.Services;
using UserRegistrationPortal.Models;
using UserRegistrationPortal.Dal;

namespace UserRegistrationPortal.Filters
{
    public class AuthorizeFilter : ActionFilterAttribute
    {
        public string Role { get; set; }
        private ICurrentUserService currentUserService = new CurrentUserServiceImplementation();
        private UserRegistrationPortalContext context = new UserRegistrationPortalContext();

        public AuthorizeFilter()
        {

        }
        public AuthorizeFilter(string role)
        {
            this.Role = role;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(!(context.Role.Find(currentUserService.GetCurrentUser(filterContext.HttpContext.Request).RoleId).RoleType == Role))
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "Index", controller = "User" }));
            }
        }
    }
}