namespace UserRegistrationPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameColumns : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ContactsModels", name: "Id", newName: "ContactId");
            RenameColumn(table: "dbo.ContactTypesModels", name: "Id", newName: "ContactTypeId");
            RenameColumn(table: "dbo.UsersModels", name: "Id", newName: "UserId");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.UsersModels", name: "UserId", newName: "Id");
            RenameColumn(table: "dbo.ContactTypesModels", name: "ContactTypeId", newName: "Id");
            RenameColumn(table: "dbo.ContactsModels", name: "ContactId", newName: "Id");
        }
    }
}
