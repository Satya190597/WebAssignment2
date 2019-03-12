namespace UserRegistrationPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameImageColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UsersInfo", "ImageUrl", c => c.String(nullable: false));
            DropColumn("dbo.UsersInfo", "image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UsersInfo", "image", c => c.String(nullable: false));
            DropColumn("dbo.UsersInfo", "ImageUrl");
        }
    }
}
