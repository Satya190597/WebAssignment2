namespace UserRegistrationPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeRoleColumnRequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UsersInfo", "RoleId", "dbo.Roles");
            DropIndex("dbo.UsersInfo", new[] { "RoleId" });
            AlterColumn("dbo.UsersInfo", "RoleId", c => c.Int(nullable:false));
            CreateIndex("dbo.UsersInfo", "RoleId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersInfo", "RoleId", "dbo.Roles");
            DropIndex("dbo.UsersInfo", new[] { "RoleId" });
            AlterColumn("dbo.UsersInfo", "RoleId", c => c.Int());
            CreateIndex("dbo.UsersInfo", "RoleId");
        }
    }
}
