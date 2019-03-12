namespace UserRegistrationPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactsModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        contactNumber = c.String(maxLength: 20),
                        ContactTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContactTypesModels", t => t.ContactTypeId, cascadeDelete: true)
                .ForeignKey("dbo.UsersModels", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ContactTypeId);
            
            CreateTable(
                "dbo.ContactTypesModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactType = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UsersModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 255),
                        Password = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactsModels", "UserId", "dbo.UsersModels");
            DropForeignKey("dbo.ContactsModels", "ContactTypeId", "dbo.ContactTypesModels");
            DropIndex("dbo.ContactsModels", new[] { "ContactTypeId" });
            DropIndex("dbo.ContactsModels", new[] { "UserId" });
            DropTable("dbo.UsersModels");
            DropTable("dbo.ContactTypesModels");
            DropTable("dbo.ContactsModels");
        }
    }
}
