namespace UserRegistrationPortal.Services
{
    public interface IAuthenticationService
    {
        /// <summary>
        /// Used To Authenticate User
        /// </summary>
        /// <param name="email">User Email</param>
        /// <param name="password">User Password</param>
        /// <returns>True for valid login credentials and false for invalid login credentials</returns>
        bool UserAuthentication(string email,string password);
    }
}
