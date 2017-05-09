namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usuario1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "Codigo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "Codigo");
        }
    }
}
