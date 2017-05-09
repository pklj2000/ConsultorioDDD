namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usuario23 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Usuario", "DataUltimoAcesso", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuario", "DataUltimoAcesso", c => c.DateTime(nullable: false));
        }
    }
}
