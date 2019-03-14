using UserRegistrationPortal.Models;

namespace UserRegistrationPortal.Services
{
    public interface IUserService
    {
        /// <summary>
        /// Add User Details (For Registration)
        /// </summary>
        int AddUserDetails(UserRegisterViewModels userRegistrationDetails);

        /// <summary>
        /// Get User Details
        /// </summary>
        UserViewModels GetUserDetails(User user);

        bool UpdateUserDetaisl(UserUpdateViewModels userUpdateDetails, User currentUser);

        bool DeleteUser(int id);
    }
}
