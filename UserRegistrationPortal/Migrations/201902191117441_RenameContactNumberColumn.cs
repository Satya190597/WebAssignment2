namespace UserRegistrationPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameContactNumberColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UsersInfo", "image", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UsersInfo", "image");
        }
    }
}
