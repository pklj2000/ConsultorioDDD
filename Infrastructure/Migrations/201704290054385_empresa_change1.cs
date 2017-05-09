namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class empresa_change1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Empresa", "Ativo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Empresa", "Ativo");
        }
    }
}
