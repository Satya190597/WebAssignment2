using System.ComponentModel.DataAnnotations;
using System.Linq;
using UserRegistrationPortal.Dal;

namespace UserRegistrationPortal.CustomAttributes
{
    public class UniqueEmailAttribute : ValidationAttribute
    {
        private UserRegistrationPortalContext context = new UserRegistrationPortalContext();

        /// <summary>
        /// Check whether the user email is already present or not.
        /// </summary>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string email = value.ToString();
                if (context.User.Any(u => u.Email.Equals(email)))
                {
                    return new ValidationResult("User Email Already Present");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            else
            {
                return new ValidationResult("Please Enter Your Email");
            }
        }
        
    }
}