using System.Web.Mvc;
using System.Web.Routing;

namespace UserRegistrationPortal.Filters
{
    public class UserLoginFilter : ActionFilterAttribute
    {
        /// <summary>
        /// Check whether the user is already login or not.
        /// </summary>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(filterContext.HttpContext.Request.IsAuthenticated)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "Index", controller = "User"}));
            }
        }
    }
}