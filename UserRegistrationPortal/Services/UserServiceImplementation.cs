using System.Linq;
using System.Web.Helpers;
using UserRegistrationPortal.Models;
using UserRegistrationPortal.Dal;
using System.Data.Entity;
using System;

namespace UserRegistrationPortal.Services
{
    public class UserServiceImplementation : IUserService
    {
        private IUploadFileService uploadFile;
        private UserRegistrationPortalContext context = new UserRegistrationPortalContext();

        public UserServiceImplementation(IUploadFileService uploadFile)
        {
            this.uploadFile = uploadFile;
        }
        public int AddUserDetails(UserRegisterViewModels userRegistrationDetails)
        {
            uploadFile.UploadFile(userRegistrationDetails.Image, "~/Uploads/Images/", userRegistrationDetails.Email + ".jpeg");
            User user = new User
            {
                FirstName = userRegistrationDetails.FirstName,
                LastName = userRegistrationDetails.LastName,
                Email = userRegistrationDetails.Email,
                Address = userRegistrationDetails.Address,
                Password = Crypto.HashPassword(userRegistrationDetails.Password),
                Image = "~/Uploads/Images/" + userRegistrationDetails.Email + ".jpeg"

            };
            context.User.Add(user);
            context.SaveChanges();
            for (int index = 0; index < userRegistrationDetails.ContactTypes.Length; index++)
            {
                context.Contact.Add(new Contact
                {
                    User = user,
                    ContactNumber = userRegistrationDetails.Contacts[index],
                    ContactType = context.ContactType.Find(userRegistrationDetails.ContactTypes[index])
                });
            }
            return context.SaveChanges();
        }

        public UserViewModels GetUserDetails(User user)
        {
            UserViewModels userView = new UserViewModels
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Address = user.Address,
                Image = user.Image != null && user.Image != "" ? user.Image : "~/Uploads/Images/default_user_profile.png",
                Contact = context.Contact.Include("ContactType").Where(c => c.UserId == user.Id).ToList(),
                UserRole = user.UserRole
            };
            return userView;
        }

        public bool DeleteUser(int id)
        {
            User user = context.User.Find(id);
            if(user!=null)
            {
                context.User.Remove(user);
                context.SaveChanges();
            }
           return true;
        }
        public bool UpdateUserDetaisl(UserUpdateViewModels userUpdateDetails,User currentUser)
        {
            currentUser.FirstName = userUpdateDetails.FirstName;
            currentUser.LastName = userUpdateDetails.LastName;
            currentUser.Address = userUpdateDetails.Address;
            context.Entry(currentUser).State = EntityState.Modified;
            return context.SaveChanges() >= 1;
        }
    }
}