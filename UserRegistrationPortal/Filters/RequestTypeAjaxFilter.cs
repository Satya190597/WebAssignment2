using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserRegistrationPortal.Filters
{
    public class RequestTypeAjaxFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(!filterContext.HttpContext.Request.IsAjaxRequest())
            {
                throw new HttpException(404, "Page Not Found");
            }
        }
    }
}