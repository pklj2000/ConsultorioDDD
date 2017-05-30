using System;
using System.Data.Entity.Migrations;
namespace Infrastructure.Migrations
{

    
    public partial class v1016 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cargo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 200),
                        DepartamentoId = c.Int(nullable: false),
                        EmpresaId = c.Int(nullable: false),
                        PeriodicidadeId = c.Int(nullable: false),
                        Ativo = c.Int(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departamento", t => t.DepartamentoId)
                .ForeignKey("dbo.Empresa", t => t.EmpresaId)
                .ForeignKey("dbo.Periodicidade", t => t.PeriodicidadeId)
                .Index(t => t.DepartamentoId)
                .Index(t => t.EmpresaId)
                .Index(t => t.PeriodicidadeId);
            
            CreateTable(
                "dbo.CargoExame",
                c => new
                    {
                        CargoId = c.Int(nullable: false),
                        ExameId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CargoId, t.ExameId })
                .ForeignKey("dbo.Cargo", t => t.CargoId, cascadeDelete: true)
                .ForeignKey("dbo.Exame", t => t.ExameId, cascadeDelete: true)
                .Index(t => t.CargoId)
                .Index(t => t.ExameId);
            
            CreateTable(
                "dbo.CargoRisco",
                c => new
                    {
                        CargoId = c.Int(nullable: false),
                        RiscoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CargoId, t.RiscoId })
                .ForeignKey("dbo.Cargo", t => t.CargoId, cascadeDelete: true)
                .ForeignKey("dbo.Risco", t => t.RiscoId, cascadeDelete: true)
                .Index(t => t.CargoId)
                .Index(t => t.RiscoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CargoRisco", "RiscoId", "dbo.Risco");
            DropForeignKey("dbo.CargoRisco", "CargoId", "dbo.Cargo");
            DropForeignKey("dbo.Cargo", "PeriodicidadeId", "dbo.Periodicidade");
            DropForeignKey("dbo.CargoExame", "ExameId", "dbo.Exame");
            DropForeignKey("dbo.CargoExame", "CargoId", "dbo.Cargo");
            DropForeignKey("dbo.Cargo", "EmpresaId", "dbo.Empresa");
            DropForeignKey("dbo.Cargo", "DepartamentoId", "dbo.Departamento");
            DropIndex("dbo.CargoRisco", new[] { "RiscoId" });
            DropIndex("dbo.CargoRisco", new[] { "CargoId" });
            DropIndex("dbo.CargoExame", new[] { "ExameId" });
            DropIndex("dbo.CargoExame", new[] { "CargoId" });
            DropIndex("dbo.Cargo", new[] { "PeriodicidadeId" });
            DropIndex("dbo.Cargo", new[] { "EmpresaId" });
            DropIndex("dbo.Cargo", new[] { "DepartamentoId" });
            DropTable("dbo.CargoRisco");
            DropTable("dbo.CargoExame");
            DropTable("dbo.Cargo");
        }
    }
}
