using System.ComponentModel.DataAnnotations;


namespace UserRegistrationPortal.Models
{
    public class LoginViewModels
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}