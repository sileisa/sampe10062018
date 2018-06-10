namespace Sampe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sampe09062018 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Marcantis", "Complemento", c => c.String(unicode: false));
            AlterColumn("dbo.Marcantis", "Telefone", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Marcantis", "Telefone", c => c.Int(nullable: false));
            AlterColumn("dbo.Marcantis", "Complemento", c => c.String(nullable: false, unicode: false));
        }
    }
}
