namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v106 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transacao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 200),
                        Janela = c.String(nullable: false, maxLength: 200),
                        Objeto = c.String(maxLength: 200),
                        Ativo = c.Int(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Transacao");
        }
    }
}