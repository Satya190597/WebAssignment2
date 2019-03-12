using System.ComponentModel.DataAnnotations;
using System.Web;

namespace UserRegistrationPortal.CustomAttributes
{
    public class ValidImageAttribute : ValidationAttribute
    {
        /// <summary>
        /// Check whether the user image is valid or not.
        /// </summary>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if (CheckImageSize(value as HttpPostedFileBase) && CheckImageType(value as HttpPostedFileBase))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return CheckImageType(value as HttpPostedFileBase) ? new ValidationResult("Image Size Must Be Less Than 1MB") : new ValidationResult("Image Must Be In .jpg, .jpeg or .png Format");
                }
            }
            else
            {
                return new ValidationResult("Please Select Your Image");
            }
        }
        protected bool CheckImageType(HttpPostedFileBase file)
        {
            return (file.ContentType.Equals("image/jpg") || file.ContentType.Equals("image/jpeg") || file.ContentType.Equals("image/png"));
        } 
        protected bool CheckImageSize(HttpPostedFileBase file)
        {
            return file.ContentLength < 1000000;
        }
    }
}