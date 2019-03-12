using System.Data.Entity;
using UserRegistrationPortal.Models;

namespace UserRegistrationPortal.Dal
{
    public class UserRegistrationPortalContext : DbContext
    {
        public UserRegistrationPortalContext():base("UserRegistrationPortalDb")
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<ContactType> ContactType { get; set; }
    }
}