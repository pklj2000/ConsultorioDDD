namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usuario21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "Ativo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "Ativo");
        }
    }
}
