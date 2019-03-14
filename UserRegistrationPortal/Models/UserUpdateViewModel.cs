using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserRegistrationPortal.Models
{
    public class UserUpdateViewModels
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
        [Required(ErrorMessage = "Address Cannot Be Blank")]
        [MinLength(5, ErrorMessage = "Address Must Be Greater Than Five Characters")]
        [MaxLength(255, ErrorMessage = "Address Cannot Be Greater Than Fifty Characters")]
        public string Address { get; set; }

    }
}