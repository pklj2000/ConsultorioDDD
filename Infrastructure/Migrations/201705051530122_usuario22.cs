namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usuario22 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Usuarios", newName: "Usuario");
            AlterColumn("dbo.Usuario", "Nome", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuario", "Nome", c => c.String());
            RenameTable(name: "dbo.Usuario", newName: "Usuarios");
        }
    }
}
