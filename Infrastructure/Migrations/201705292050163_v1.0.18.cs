namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1018 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Funcionario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 200),
                        EmpresaId = c.Int(nullable: false),
                        DepartamentoId = c.Int(nullable: false),
                        CargoId = c.Int(nullable: false),
                        EstadoCivilId = c.Int(nullable: false),
                        SituacaoFuncionarioId = c.Int(nullable: false),
                        PeriodicidadeId = c.Int(nullable: false),
                        Rg = c.String(nullable: false),
                        Sexo = c.String(),
                        CargoAnterior = c.String(),
                        Naturalidade = c.String(),
                        Nacionalidade = c.String(),
                        DataNascimento = c.DateTime(nullable: false),
                        DataAdmissao = c.DateTime(nullable: false),
                        DataUltimoExame = c.DateTime(nullable: false),
                        DataDemissao = c.DateTime(nullable: false),
                        Ativo = c.Int(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cargo", t => t.CargoId)
                .ForeignKey("dbo.Departamento", t => t.DepartamentoId)
                .ForeignKey("dbo.Empresa", t => t.EmpresaId)
                .ForeignKey("dbo.EstadoCivil", t => t.EstadoCivilId)
                .ForeignKey("dbo.Periodicidade", t => t.PeriodicidadeId)
                .ForeignKey("dbo.SituacaoFuncionario", t => t.SituacaoFuncionarioId)
                .Index(t => t.EmpresaId)
                .Index(t => t.DepartamentoId)
                .Index(t => t.CargoId)
                .Index(t => t.EstadoCivilId)
                .Index(t => t.SituacaoFuncionarioId)
                .Index(t => t.PeriodicidadeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Funcionario", "SituacaoFuncionarioId", "dbo.SituacaoFuncionario");
            DropForeignKey("dbo.Funcionario", "PeriodicidadeId", "dbo.Periodicidade");
            DropForeignKey("dbo.Funcionario", "EstadoCivilId", "dbo.EstadoCivil");
            DropForeignKey("dbo.Funcionario", "EmpresaId", "dbo.Empresa");
            DropForeignKey("dbo.Funcionario", "DepartamentoId", "dbo.Departamento");
            DropForeignKey("dbo.Funcionario", "CargoId", "dbo.Cargo");
            DropIndex("dbo.Funcionario", new[] { "PeriodicidadeId" });
            DropIndex("dbo.Funcionario", new[] { "SituacaoFuncionarioId" });
            DropIndex("dbo.Funcionario", new[] { "EstadoCivilId" });
            DropIndex("dbo.Funcionario", new[] { "CargoId" });
            DropIndex("dbo.Funcionario", new[] { "DepartamentoId" });
            DropIndex("dbo.Funcionario", new[] { "EmpresaId" });
            DropTable("dbo.Funcionario");
        }
    }
}
