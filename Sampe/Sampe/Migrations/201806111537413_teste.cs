namespace Sampe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teste : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExpedicaoCopoes",
                c => new
                    {
                        ExpedicaoId = c.Int(nullable: false, identity: true),
                        ValorTotal = c.Single(nullable: false),
                        Vencimento = c.DateTime(nullable: false, precision: 0),
                        ClienteId = c.Int(nullable: false),
                        MarcantiId = c.Int(nullable: false),
                        Venda_VendaId = c.Int(),
                    })
                .PrimaryKey(t => t.ExpedicaoId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Marcantis", t => t.MarcantiId, cascadeDelete: true)
                .ForeignKey("dbo.Vendas", t => t.Venda_VendaId)
                .Index(t => t.ClienteId)
                .Index(t => t.MarcantiId)
                .Index(t => t.Venda_VendaId);
            
            CreateTable(
                "dbo.Vendas",
                c => new
                    {
                        VendaId = c.Int(nullable: false, identity: true),
                        ValorUnitario = c.Single(nullable: false),
                        Subtotal = c.Single(nullable: false),
                        ExpedicaoCopoId = c.Int(nullable: false),
                        EspecificacaoCopoId = c.Int(nullable: false),
                        ExpedicaoCopo_ExpedicaoId = c.Int(),
                    })
                .PrimaryKey(t => t.VendaId)
                .ForeignKey("dbo.EspecificacaoCopoes", t => t.EspecificacaoCopoId, cascadeDelete: true)
                .ForeignKey("dbo.ExpedicaoCopoes", t => t.ExpedicaoCopoId, cascadeDelete: true)
                .ForeignKey("dbo.ExpedicaoCopoes", t => t.ExpedicaoCopo_ExpedicaoId)
                .Index(t => t.ExpedicaoCopoId)
                .Index(t => t.EspecificacaoCopoId)
                .Index(t => t.ExpedicaoCopo_ExpedicaoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vendas", "ExpedicaoCopo_ExpedicaoId", "dbo.ExpedicaoCopoes");
            DropForeignKey("dbo.ExpedicaoCopoes", "Venda_VendaId", "dbo.Vendas");
            DropForeignKey("dbo.Vendas", "ExpedicaoCopoId", "dbo.ExpedicaoCopoes");
            DropForeignKey("dbo.Vendas", "EspecificacaoCopoId", "dbo.EspecificacaoCopoes");
            DropForeignKey("dbo.ExpedicaoCopoes", "MarcantiId", "dbo.Marcantis");
            DropForeignKey("dbo.ExpedicaoCopoes", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Vendas", new[] { "ExpedicaoCopo_ExpedicaoId" });
            DropIndex("dbo.Vendas", new[] { "EspecificacaoCopoId" });
            DropIndex("dbo.Vendas", new[] { "ExpedicaoCopoId" });
            DropIndex("dbo.ExpedicaoCopoes", new[] { "Venda_VendaId" });
            DropIndex("dbo.ExpedicaoCopoes", new[] { "MarcantiId" });
            DropIndex("dbo.ExpedicaoCopoes", new[] { "ClienteId" });
            DropTable("dbo.Vendas");
            DropTable("dbo.ExpedicaoCopoes");
        }
    }
}
