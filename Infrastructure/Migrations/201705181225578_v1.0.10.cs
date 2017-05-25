namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1010 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Perfils", newName: "Perfil");
            AlterColumn("dbo.Perfil", "Descricao", c => c.String(nullable: false, maxLength: 200));
            DropColumn("dbo.Perfil", "AtivoCheck");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Perfil", "AtivoCheck", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Perfil", "Descricao", c => c.String());
            RenameTable(name: "dbo.Perfil", newName: "Perfils");
        }
    }
}
