using System.Linq;
using UserRegistrationPortal.Dal;
using System.Web.Helpers;
using System.Web.Security;

namespace UserRegistrationPortal.Services
{
    public class AuthenticationServiceImplementation : IAuthenticationService
    {
        private UserRegistrationPortalContext context = new UserRegistrationPortalContext();
        public bool UserAuthentication(string  email,string password)
        {
            if(context.User.Any(u => u.Email == email) && Crypto.VerifyHashedPassword(context.User.Where(u => u.Email == email).FirstOrDefault().Password, password))
            {
                FormsAuthentication.SetAuthCookie(email, false);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}