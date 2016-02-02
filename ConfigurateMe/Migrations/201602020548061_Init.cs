namespace ConfigurateMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "Privacy", c => c.Boolean(nullable: false));
            AddColumn("dbo.Options", "Pictures", c => c.Binary());
            DropColumn("dbo.Companies", "Publ");
            DropColumn("dbo.Options", "PictureId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Options", "PictureId", c => c.Int(nullable: false));
            AddColumn("dbo.Companies", "Publ", c => c.Boolean(nullable: false));
            DropColumn("dbo.Options", "Pictures");
            DropColumn("dbo.Companies", "Privacy");
        }
    }
}
