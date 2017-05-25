namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1015 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exame",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 200),
                        EmiteSolicitacaoExame = c.Int(nullable: false),
                        EmitePorPeriodicidade = c.Int(nullable: false),
                        Ativo = c.Int(nullable: false),
                        PeriodicidadeId = c.Int(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Periodicidade", t => t.PeriodicidadeId, cascadeDelete: true)
                .Index(t => t.PeriodicidadeId);
            
            CreateTable(
                "dbo.ExameTipoExame",
                c => new
                    {
                        ExameId = c.Int(nullable: false),
                        TipoExameId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ExameId, t.TipoExameId })
                .ForeignKey("dbo.Exame", t => t.ExameId, cascadeDelete: true)
                .ForeignKey("dbo.TipoExame", t => t.TipoExameId, cascadeDelete: true)
                .Index(t => t.ExameId)
                .Index(t => t.TipoExameId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExameTipoExame", "TipoExameId", "dbo.TipoExame");
            DropForeignKey("dbo.ExameTipoExame", "ExameId", "dbo.Exame");
            DropForeignKey("dbo.Exame", "PeriodicidadeId", "dbo.Periodicidade");
            DropIndex("dbo.ExameTipoExame", new[] { "TipoExameId" });
            DropIndex("dbo.ExameTipoExame", new[] { "ExameId" });
            DropIndex("dbo.Exame", new[] { "PeriodicidadeId" });
            DropTable("dbo.ExameTipoExame");
            DropTable("dbo.Exame");
        }
    }
}
