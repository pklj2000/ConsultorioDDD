namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v107 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Perfils",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Ativo = c.Int(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PerfilTransacao",
                c => new
                    {
                        PerfilId = c.Int(nullable: false),
                        TransacaoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PerfilId, t.TransacaoId })
                .ForeignKey("dbo.Perfils", t => t.PerfilId, cascadeDelete: true)
                .ForeignKey("dbo.Transacao", t => t.TransacaoId, cascadeDelete: true)
                .Index(t => t.PerfilId)
                .Index(t => t.TransacaoId);
            
            CreateTable(
                "dbo.UsuarioPerfil",
                c => new
                    {
                        PerfilId = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PerfilId, t.UsuarioId })
                .ForeignKey("dbo.Usuario", t => t.PerfilId, cascadeDelete: true)
                .ForeignKey("dbo.Perfils", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.PerfilId)
                .Index(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsuarioPerfil", "UsuarioId", "dbo.Perfils");
            DropForeignKey("dbo.UsuarioPerfil", "PerfilId", "dbo.Usuario");
            DropForeignKey("dbo.PerfilTransacao", "TransacaoId", "dbo.Transacao");
            DropForeignKey("dbo.PerfilTransacao", "PerfilId", "dbo.Perfils");
            DropIndex("dbo.UsuarioPerfil", new[] { "UsuarioId" });
            DropIndex("dbo.UsuarioPerfil", new[] { "PerfilId" });
            DropIndex("dbo.PerfilTransacao", new[] { "TransacaoId" });
            DropIndex("dbo.PerfilTransacao", new[] { "PerfilId" });
            DropTable("dbo.UsuarioPerfil");
            DropTable("dbo.PerfilTransacao");
            DropTable("dbo.Perfils");
        }
    }
}
