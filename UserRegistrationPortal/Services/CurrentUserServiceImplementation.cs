using System.Linq;
using System.Web;
using System.Web.Security;
using UserRegistrationPortal.Models;
using UserRegistrationPortal.Dal;

namespace UserRegistrationPortal.Services
{
    public class CurrentUserServiceImplementation : ICurrentUserService
    {
        private UserRegistrationPortalContext context = new UserRegistrationPortalContext();
        public User GetCurrentUser(HttpRequestBase request)
        {
            if (request.IsAuthenticated)
            {
                string email = FormsAuthentication.Decrypt(request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
                return context.User.Where(u => u.Email.Equals(email)).FirstOrDefault();
            }
            else
            {
                return null;
            }
        }
    }
}