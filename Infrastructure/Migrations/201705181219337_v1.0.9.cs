namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v109 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Perfils", "AtivoCheck", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Perfils", "AtivoCheck");
        }
    }
}
