namespace musicWebApplication.Migrations.ApplicationDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAliasField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Alias", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Alias");
        }
    }
}
