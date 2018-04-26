namespace musicWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTables2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Club", "DjId", "dbo.Dj");
            DropIndex("dbo.Club", new[] { "DjId" });
            RenameColumn(table: "dbo.Club", name: "DjId", newName: "Djs_DjId");
            AlterColumn("dbo.Club", "Djs_DjId", c => c.Int());
            CreateIndex("dbo.Club", "Djs_DjId");
            AddForeignKey("dbo.Club", "Djs_DjId", "dbo.Dj", "DjId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Club", "Djs_DjId", "dbo.Dj");
            DropIndex("dbo.Club", new[] { "Djs_DjId" });
            AlterColumn("dbo.Club", "Djs_DjId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Club", name: "Djs_DjId", newName: "DjId");
            CreateIndex("dbo.Club", "DjId");
            AddForeignKey("dbo.Club", "DjId", "dbo.Dj", "DjId", cascadeDelete: true);
        }
    }
}
