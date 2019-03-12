namespace UserRegistrationPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeColumnNames : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Contacts", name: "contactNumber", newName: "ContactNumber");
        }

        public override void Down()
        {
            RenameColumn(table: "dbo.Contacts", name: "ContactNumber", newName: "contactNumber");
        }
    }
}
