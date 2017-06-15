namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1022 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Atendimento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmpresaId = c.Int(nullable: false),
                        DepartamentoId = c.Int(nullable: false),
                        CargoId = c.Int(nullable: false),
                        FuncionarioId = c.Int(nullable: false),
                        TipoExameId = c.Int(nullable: false),
                        Ativo = c.Int(nullable: false),
                        DataAtendimento = c.DateTime(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cargo", t => t.CargoId)
                .ForeignKey("dbo.Departamento", t => t.DepartamentoId)
                .ForeignKey("dbo.Empresa", t => t.EmpresaId)
                .ForeignKey("dbo.Funcionario", t => t.FuncionarioId)
                .ForeignKey("dbo.TipoExame", t => t.TipoExameId)
                .Index(t => t.EmpresaId)
                .Index(t => t.DepartamentoId)
                .Index(t => t.CargoId)
                .Index(t => t.FuncionarioId)
                .Index(t => t.TipoExameId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Atendimento", "TipoExameId", "dbo.TipoExame");
            DropForeignKey("dbo.Atendimento", "FuncionarioId", "dbo.Funcionario");
            DropForeignKey("dbo.Atendimento", "EmpresaId", "dbo.Empresa");
            DropForeignKey("dbo.Atendimento", "DepartamentoId", "dbo.Departamento");
            DropForeignKey("dbo.Atendimento", "CargoId", "dbo.Cargo");
            DropIndex("dbo.Atendimento", new[] { "TipoExameId" });
            DropIndex("dbo.Atendimento", new[] { "FuncionarioId" });
            DropIndex("dbo.Atendimento", new[] { "CargoId" });
            DropIndex("dbo.Atendimento", new[] { "DepartamentoId" });
            DropIndex("dbo.Atendimento", new[] { "EmpresaId" });
            DropTable("dbo.Atendimento");
        }
    }
}
