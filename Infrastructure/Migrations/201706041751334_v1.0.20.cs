namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1020 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pergunta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 200),
                        Sequencia = c.Int(nullable: false),
                        Ativo = c.Int(nullable: false),
                        PerguntaGrupoId = c.Int(nullable: false),
                        TipoRespostaId = c.Int(nullable: false),
                        RespostaObrigatoria = c.Int(nullable: false),
                        RespostaItem = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                        PerguntaGrupo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PerguntaGrupo", t => t.PerguntaGrupo_Id)
                .ForeignKey("dbo.PerguntaGrupo", t => t.PerguntaGrupoId)
                .Index(t => t.PerguntaGrupoId)
                .Index(t => t.PerguntaGrupo_Id);
            
            CreateTable(
                "dbo.PerguntaGrupo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 200),
                        Sequencia = c.Int(nullable: false),
                        Ativo = c.Int(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pergunta", "PerguntaGrupoId", "dbo.PerguntaGrupo");
            DropForeignKey("dbo.Pergunta", "PerguntaGrupo_Id", "dbo.PerguntaGrupo");
            DropIndex("dbo.Pergunta", new[] { "PerguntaGrupo_Id" });
            DropIndex("dbo.Pergunta", new[] { "PerguntaGrupoId" });
            DropTable("dbo.PerguntaGrupo");
            DropTable("dbo.Pergunta");
        }
    }
}
