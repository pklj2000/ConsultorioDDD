namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usuario2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "DataUltimoAcesso", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "DataUltimoAcesso");
        }
    }
}
