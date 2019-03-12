namespace UserRegistrationPortal.Migrations
{
    using System.Data.Entity.Migrations;
    using UserRegistrationPortal.Models;
    using System.Collections.Generic;

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
        }
    }
}
