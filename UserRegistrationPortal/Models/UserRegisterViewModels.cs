using System.ComponentModel.DataAnnotations;
using System.Web;
using UserRegistrationPortal.CustomAttributes;

namespace UserRegistrationPortal.Models
{
    public class UserRegisterViewModels
    {
        [Required(ErrorMessage = "First Name Cannot Be Blank")]
        [MinLength(2, ErrorMessage = "First Name Must Be Greater Than Two Characters")]
        [MaxLength(50, ErrorMessage = "First Name Cannot Be Greater Than Fifty Characters")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Invalid First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name Cannot Be Blank")]
        [MinLength(2, ErrorMessage = "Last Name Must Be Greater Than Two Characters")]
        [MaxLength(50, ErrorMessage = "Last Name Cannot Be Greater Than Fifty Characters")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Invalid Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email Cannot Be Blank")]
        [UniqueEmail]
        [MinLength(4, ErrorMessage = "Email Must Be Greater Than Four Characters")]
        [MaxLength(50, ErrorMessage = "Email Cannot Be Greater Than Fifty Characters")]
        [EmailAddress(ErrorMessage = "Please Enter A Valid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Address Cannot Be Blank")]
        [MinLength(5, ErrorMessage = "Address Must Be Greater Than Five Characters")]
        [MaxLength(255, ErrorMessage = "Address Cannot Be Greater Than Fifty Characters")]
        public string Address { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Password Must Be Greater Than Eight Characters")]
        [MaxLength(50, ErrorMessage = "Password Cannot Be Greater Than Fifty Characters")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Password Must Consist of One Lower Case, One Upper Case, One Digit And One Special Character")]
        public string Password { get; set; }
        [MinLength(1,ErrorMessage = "Contact Number Cannot Be Blank")]
        [CheckAllContactsAttribute]
        public string[] Contacts {get; set;}
        [MinLength(1,ErrorMessage = "Contact Type Cannot Be Blank")]
        [ValidContactType]
        public int[] ContactTypes { get; set; }
        [Required(ErrorMessage = "Confirm Password Cannot Be Blank")]
        [Compare("Password", ErrorMessage = "Password And Confirm Password Mismatch")]
        public string ConfirmPassword { get; set; }

        [Required]
        [ValidImage]
        public HttpPostedFileBase Image { get; set; }
    }
}