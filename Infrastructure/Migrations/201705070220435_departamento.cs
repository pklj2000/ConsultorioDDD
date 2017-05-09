namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class departamento : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departamento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 200),
                        Responsavel = c.String(),
                        EmpresaId = c.Int(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empresa", t => t.EmpresaId, cascadeDelete: true)
                .Index(t => t.EmpresaId);
            
            AddColumn("dbo.Empresa", "UsuarioId", c => c.Int(nullable: false));
            AddColumn("dbo.Usuario", "UsuarioId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Departamento", "EmpresaId", "dbo.Empresa");
            DropIndex("dbo.Departamento", new[] { "EmpresaId" });
            DropColumn("dbo.Usuario", "UsuarioId");
            DropColumn("dbo.Empresa", "UsuarioId");
            DropTable("dbo.Departamento");
        }
    }
}
