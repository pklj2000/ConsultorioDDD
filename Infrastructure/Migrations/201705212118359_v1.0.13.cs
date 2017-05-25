namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1013 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Empresa", "Nome", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Empresa", "Nome", c => c.String(maxLength: 200));
        }
    }
}
