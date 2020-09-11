namespace GallaryPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addVideoGallery : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.videoGalleries",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        VideoName = c.String(nullable: false),
                        VideoID = c.String(nullable: false),
                        Actice = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.videoGalleries");
        }
    }
}
