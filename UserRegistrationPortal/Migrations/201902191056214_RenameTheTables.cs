namespace UserRegistrationPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTheTables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ContactsModels", newName: "Contacts");
            RenameTable(name: "dbo.ContactTypesModels", newName: "ContactTypes");
            RenameTable(name: "dbo.UsersModels", newName: "UsersInfo");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.UsersInfo", newName: "UsersModels");
            RenameTable(name: "dbo.ContactTypes", newName: "ContactTypesModels");
            RenameTable(name: "dbo.Contacts", newName: "ContactsModels");
        }
    }
}
