namespace UserRegistrationPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ContactNumber = c.String(nullable: false, maxLength: 20),
                        ContactTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContactId)
                .ForeignKey("dbo.ContactTypes", t => t.ContactTypeId, cascadeDelete: true)
                .ForeignKey("dbo.UsersInfo", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ContactTypeId);
            
            CreateTable(
                "dbo.ContactTypes",
                c => new
                    {
                        ContactTypeId = c.Int(nullable: false, identity: true),
                        ContactType = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.ContactTypeId);
            
            CreateTable(
                "dbo.UsersInfo",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 255),
                        Password = c.String(nullable: false, maxLength: 255),
                        ImageUrl = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "UserId", "dbo.UsersInfo");
            DropForeignKey("dbo.Contacts", "ContactTypeId", "dbo.ContactTypes");
            DropIndex("dbo.Contacts", new[] { "ContactTypeId" });
            DropIndex("dbo.Contacts", new[] { "UserId" });
            DropTable("dbo.UsersInfo");
            DropTable("dbo.ContactTypes");
            DropTable("dbo.Contacts");
        }
    }
}
