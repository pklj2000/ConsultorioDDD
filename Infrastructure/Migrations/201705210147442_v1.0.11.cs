namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1011 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.UsuarioPerfil", name: "PerfilId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.UsuarioPerfil", name: "UsuarioId", newName: "PerfilId");
            RenameColumn(table: "dbo.UsuarioPerfil", name: "__mig_tmp__0", newName: "UsuarioId");
            RenameIndex(table: "dbo.UsuarioPerfil", name: "IX_PerfilId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.UsuarioPerfil", name: "IX_UsuarioId", newName: "IX_PerfilId");
            RenameIndex(table: "dbo.UsuarioPerfil", name: "__mig_tmp__0", newName: "IX_UsuarioId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.UsuarioPerfil", name: "IX_UsuarioId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.UsuarioPerfil", name: "IX_PerfilId", newName: "IX_UsuarioId");
            RenameIndex(table: "dbo.UsuarioPerfil", name: "__mig_tmp__0", newName: "IX_PerfilId");
            RenameColumn(table: "dbo.UsuarioPerfil", name: "UsuarioId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.UsuarioPerfil", name: "PerfilId", newName: "UsuarioId");
            RenameColumn(table: "dbo.UsuarioPerfil", name: "__mig_tmp__0", newName: "PerfilId");
        }
    }
}
