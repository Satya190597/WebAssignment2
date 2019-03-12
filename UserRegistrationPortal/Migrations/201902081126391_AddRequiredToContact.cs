namespace UserRegistrationPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredToContact : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ContactsModels", "contactNumber", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ContactsModels", "contactNumber", c => c.String(maxLength: 20));
        }
    }
}
