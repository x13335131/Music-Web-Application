namespace musicWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Review",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        FestivalId = c.Int(nullable: false),
                        Content = c.String(),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.ReviewId)
                .ForeignKey("dbo.Festival", t => t.FestivalId, cascadeDelete: true)
                .Index(t => t.FestivalId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Review", "FestivalId", "dbo.Festival");
            DropIndex("dbo.Review", new[] { "FestivalId" });
            DropTable("dbo.Review");
        }
    }
}
