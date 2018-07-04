namespace BibliotecaGerenciamentoSapatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeCor = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sapatoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeSapato = c.String(),
                        TipoAmarracao = c.String(),
                        Material = c.String(),
                        ValorSapato = c.Double(nullable: false),
                        Cor_Id = c.Int(),
                        Tamanho_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cors", t => t.Cor_Id)
                .ForeignKey("dbo.Tamanhoes", t => t.Tamanho_Id)
                .Index(t => t.Cor_Id)
                .Index(t => t.Tamanho_Id);
            
            CreateTable(
                "dbo.ItemPedidoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantidade = c.Int(nullable: false),
                        Valor = c.Double(nullable: false),
                        Pedido_Id = c.Int(),
                        Sapato_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pedidoes", t => t.Pedido_Id)
                .ForeignKey("dbo.Sapatoes", t => t.Sapato_Id)
                .Index(t => t.Pedido_Id)
                .Index(t => t.Sapato_Id);
            
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Pessoa_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pessoas", t => t.Pessoa_Id)
                .Index(t => t.Pessoa_Id);
            
            CreateTable(
                "dbo.Pessoas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Cpf = c.String(),
                        DataNascimento = c.DateTime(),
                        RazaoSocial = c.String(),
                        Cnpj = c.String(),
                        NomeRua = c.String(),
                        NomeBairro = c.String(),
                        NumeroResidencial = c.String(),
                        NomeCidade = c.String(),
                        NomeEstado = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tamanhoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TamanhoSapato = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sapatoes", "Tamanho_Id", "dbo.Tamanhoes");
            DropForeignKey("dbo.ItemPedidoes", "Sapato_Id", "dbo.Sapatoes");
            DropForeignKey("dbo.Pedidoes", "Pessoa_Id", "dbo.Pessoas");
            DropForeignKey("dbo.ItemPedidoes", "Pedido_Id", "dbo.Pedidoes");
            DropForeignKey("dbo.Sapatoes", "Cor_Id", "dbo.Cors");
            DropIndex("dbo.Pedidoes", new[] { "Pessoa_Id" });
            DropIndex("dbo.ItemPedidoes", new[] { "Sapato_Id" });
            DropIndex("dbo.ItemPedidoes", new[] { "Pedido_Id" });
            DropIndex("dbo.Sapatoes", new[] { "Tamanho_Id" });
            DropIndex("dbo.Sapatoes", new[] { "Cor_Id" });
            DropTable("dbo.Tamanhoes");
            DropTable("dbo.Pessoas");
            DropTable("dbo.Pedidoes");
            DropTable("dbo.ItemPedidoes");
            DropTable("dbo.Sapatoes");
            DropTable("dbo.Cors");
        }
    }
}
