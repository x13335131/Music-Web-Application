namespace musicWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Club",
                c => new
                    {
                        ClubId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ClubName = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Established = c.DateTime(nullable: false),
                        DjId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClubId)
                .ForeignKey("dbo.Dj", t => t.DjId, cascadeDelete: true)
                .Index(t => t.DjId);
            
            CreateTable(
                "dbo.Dj",
                c => new
                    {
                        DjId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Genre = c.String(),
                    })
                .PrimaryKey(t => t.DjId);
            
            CreateTable(
                "dbo.Tune",
                c => new
                    {
                        TuneId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SongName = c.String(),
                        DjId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TuneId)
                .ForeignKey("dbo.Dj", t => t.DjId, cascadeDelete: true)
                .Index(t => t.DjId);
            
            CreateTable(
                "dbo.Festival",
                c => new
                    {
                        FestivalId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Location = c.String(),
                        Date = c.String(),
                        DjId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FestivalId)
                .ForeignKey("dbo.Dj", t => t.DjId, cascadeDelete: true)
                .Index(t => t.DjId);
            
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
            DropForeignKey("dbo.Festival", "DjId", "dbo.Dj");
            DropForeignKey("dbo.Club", "DjId", "dbo.Dj");
            DropForeignKey("dbo.Tune", "DjId", "dbo.Dj");
            DropIndex("dbo.Review", new[] { "FestivalId" });
            DropIndex("dbo.Festival", new[] { "DjId" });
            DropIndex("dbo.Tune", new[] { "DjId" });
            DropIndex("dbo.Club", new[] { "DjId" });
            DropTable("dbo.Review");
            DropTable("dbo.Festival");
            DropTable("dbo.Tune");
            DropTable("dbo.Dj");
            DropTable("dbo.Club");
        }
    }
}
