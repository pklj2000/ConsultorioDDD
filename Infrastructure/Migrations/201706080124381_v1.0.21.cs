namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1021 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Profissional",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 200),
                        CRM = c.String(nullable: false, maxLength: 20),
                        Telefone = c.String(maxLength: 500),
                        Ativo = c.Int(nullable: false),
                        Observacao = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Profissional");
        }
    }
}
