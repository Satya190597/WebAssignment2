namespace UserRegistrationPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserRolesAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleType = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.RoleId);
            
            AddColumn("dbo.UsersInfo", "RoleId", c => c.Int());
            CreateIndex("dbo.UsersInfo", "RoleId");
            AddForeignKey("dbo.UsersInfo", "RoleId", "dbo.Roles", "RoleId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersInfo", "RoleId", "dbo.Roles");
            DropIndex("dbo.UsersInfo", new[] { "RoleId" });
            DropColumn("dbo.UsersInfo", "RoleId");
            DropTable("dbo.Roles");
        }
    }
}
