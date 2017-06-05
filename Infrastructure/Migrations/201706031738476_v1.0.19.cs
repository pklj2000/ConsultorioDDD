namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1019 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Funcionario", "DataNascimento", c => c.DateTime());
            AlterColumn("dbo.Funcionario", "DataAdmissao", c => c.DateTime());
            AlterColumn("dbo.Funcionario", "DataUltimoExame", c => c.DateTime());
            AlterColumn("dbo.Funcionario", "DataDemissao", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Funcionario", "DataDemissao", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Funcionario", "DataUltimoExame", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Funcionario", "DataAdmissao", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Funcionario", "DataNascimento", c => c.DateTime(nullable: false));
        }
    }
}
