using System.Web;
using UserRegistrationPortal.Models;

namespace UserRegistrationPortal.Services
{
    public interface ICurrentUserService
    {
        /// <summary>
        /// Identify Current Authenticated User
        /// </summary>
        /// <param name="request">Used to read HTTP values sent by client during a web request</param>
        /// <returns>Current User</returns>
        User GetCurrentUser(HttpRequestBase request);
    }
}
