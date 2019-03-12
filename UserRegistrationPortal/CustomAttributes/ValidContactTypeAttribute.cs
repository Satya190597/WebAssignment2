using System.ComponentModel.DataAnnotations;
using System.Linq;
using UserRegistrationPortal.Dal;

namespace UserRegistrationPortal.CustomAttributes
{
    public class ValidContactTypeAttribute : ValidationAttribute
    {
        private UserRegistrationPortalContext context = new UserRegistrationPortalContext();

        /// <summary>
        /// Check whether the contact types are valid or not
        /// </summary>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if (value.GetType() == typeof(int[]))
                {
                    int[] contactTypes = value as int[];
                    foreach (int ele in contactTypes)
                    {
                        if (!context.ContactType.Any(c => c.Id == ele))
                        {
                            return new ValidationResult("Contact Type Not Found");
                        }
                    }
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Contact Type Not Found");
                }
            }
            else
            {
                return new ValidationResult("Contact Type Not Found");
            }
        }
    }
}