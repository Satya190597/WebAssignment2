using System.Collections.Generic;

namespace UserRegistrationPortal.Models
{
    public class UserViewModels
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public Role UserRole { get; set; }
        public ICollection<Contact> Contact { get; set; }

    }
}