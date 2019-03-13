namespace UserRegistrationPortal.Migrations
{
    using System.Data.Entity.Migrations;
    using UserRegistrationPortal.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Helpers;
    using System;

    internal sealed class Configuration : DbMigrationsConfiguration<UserRegistrationPortal.Dal.UserRegistrationPortalContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(UserRegistrationPortal.Dal.UserRegistrationPortalContext context)
        {
            List<ContactType> contactTypesList = new List<ContactType>();
            contactTypesList.Add(new ContactType() { ContactTypeText = "home" });
            contactTypesList.Add(new ContactType() { ContactTypeText = "fax" });
            contactTypesList.Add(new ContactType() { ContactTypeText = "office" });
            contactTypesList.Add(new ContactType() { ContactTypeText = "personal" });
            contactTypesList.Add(new ContactType() { ContactTypeText = "others" });
            foreach (ContactType contactType in contactTypesList)
            {
                context.ContactType.AddOrUpdate(c => c.ContactTypeText, new ContactType() { ContactTypeText = contactType.ContactTypeText });
            }

            // + Add Specific Roles +
            List<Role> rolesList = new List<Role>();
            rolesList.Add(new Role { RoleType = "admin"});
            rolesList.Add(new Role { RoleType = "user"});
            foreach(Role role in rolesList)
            {
                context.Role.AddOrUpdate(r => r.RoleType, new Role() { RoleType = role.RoleType});
            }
            // + Ends +


            // + Add A Single Admin +
            context.User.AddOrUpdate(r => r.Email, new User()
            {
                FirstName = "Admin",
                LastName = "Mindfire",
                Email = "admin@yahoo.in",
                Address = "BBSR Odisha",
                Image = "~/Uploads/Images/default_user_profile.png",
                Password = Crypto.HashPassword("Admin@1234"),
                UserRole = context.Role.Where(r => r.RoleType == "admin").FirstOrDefault()
            });
            
            // + End +
        }
    }
}
