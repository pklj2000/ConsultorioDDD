namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v5 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.EstadoCivils", newName: "EstadoCivil");
            AlterColumn("dbo.EstadoCivil", "Descricao", c => c.String(nullable: false, maxLength: 200));
            DropColumn("dbo.EstadoCivil", "AtivoCheck");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EstadoCivil", "AtivoCheck", c => c.Boolean(nullable: false));
            AlterColumn("dbo.EstadoCivil", "Descricao", c => c.String());
            RenameTable(name: "dbo.EstadoCivil", newName: "EstadoCivils");
        }
    }
}
