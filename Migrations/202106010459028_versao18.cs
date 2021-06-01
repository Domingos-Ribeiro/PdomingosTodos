namespace PdomingosTodos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class versao18 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeCliente = c.String(nullable: false, maxLength: 50),
                        Morada = c.String(nullable: false),
                        Contacto = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DadosClientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DNomeCliente = c.String(),
                        SenhaTipo = c.String(nullable: false, maxLength: 100),
                        MoradaCliente = c.String(),
                        TelefoneCliente = c.String(),
                        EmailCliente = c.String(),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Eventoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataEvento = c.DateTime(nullable: false),
                        Descricao = c.String(nullable: false, maxLength: 100),
                        FuncionarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Funcionarios", t => t.FuncionarioId, cascadeDelete: true)
                .Index(t => t.FuncionarioId);
            
            CreateTable(
                "dbo.Funcionarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeFuncionario = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reuniaos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataReuniao = c.DateTime(nullable: false),
                        Tema = c.String(nullable: false, maxLength: 100),
                        Minutos = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FuncionarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Funcionarios", t => t.FuncionarioId, cascadeDelete: true)
                .Index(t => t.FuncionarioId);
            
            CreateTable(
                "dbo.Tarefas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataInicio = c.DateTime(nullable: false),
                        DataLimite = c.DateTime(nullable: false),
                        DescricaoTarefa = c.String(nullable: false, maxLength: 200),
                        FuncionarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Funcionarios", t => t.FuncionarioId, cascadeDelete: true)
                .Index(t => t.FuncionarioId);
            
            CreateTable(
                "dbo.TempoGastoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        TempoUsado = c.String(nullable: false, maxLength: 100),
                        Minutos = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tarefas", "FuncionarioId", "dbo.Funcionarios");
            DropForeignKey("dbo.Reuniaos", "FuncionarioId", "dbo.Funcionarios");
            DropForeignKey("dbo.Eventoes", "FuncionarioId", "dbo.Funcionarios");
            DropForeignKey("dbo.DadosClientes", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Tarefas", new[] { "FuncionarioId" });
            DropIndex("dbo.Reuniaos", new[] { "FuncionarioId" });
            DropIndex("dbo.Eventoes", new[] { "FuncionarioId" });
            DropIndex("dbo.DadosClientes", new[] { "ClienteId" });
            DropTable("dbo.TempoGastoes");
            DropTable("dbo.Tarefas");
            DropTable("dbo.Reuniaos");
            DropTable("dbo.Funcionarios");
            DropTable("dbo.Eventoes");
            DropTable("dbo.DadosClientes");
            DropTable("dbo.Clientes");
        }
    }
}
