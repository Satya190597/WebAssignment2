using System.ComponentModel.DataAnnotations;

namespace UserRegistrationPortal.CustomAttributes
{
    public class CheckAllContactsAttribute : ValidationAttribute
    {
        /// <summary>
        /// Check whether each contact is valid or not
        /// </summary>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string[] allContacts = value as string[];
            foreach(string contact in allContacts)
            {
                if(contact.Length<5)
                {
                    return new ValidationResult("In Valid Contacts");
                }
            }
            return ValidationResult.Success;
        }
    }
}