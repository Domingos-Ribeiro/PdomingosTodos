namespace PdomingosTodos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version0 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reuniaos", "FuncionarioId", "dbo.Funcionarios");
            DropIndex("dbo.Reuniaos", new[] { "FuncionarioId" });
            AddColumn("dbo.Reuniaos", "ClienteId", c => c.Int(nullable: false));
            AlterColumn("dbo.Clientes", "NomeCliente", c => c.String());
            CreateIndex("dbo.Reuniaos", "ClienteId");
            AddForeignKey("dbo.Reuniaos", "ClienteId", "dbo.Clientes", "Id", cascadeDelete: true);
            DropColumn("dbo.Clientes", "Morada");
            DropColumn("dbo.Clientes", "Contacto");
            DropColumn("dbo.Reuniaos", "FuncionarioId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reuniaos", "FuncionarioId", c => c.Int(nullable: false));
            AddColumn("dbo.Clientes", "Contacto", c => c.String());
            AddColumn("dbo.Clientes", "Morada", c => c.String(nullable: false));
            DropForeignKey("dbo.Reuniaos", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Reuniaos", new[] { "ClienteId" });
            AlterColumn("dbo.Clientes", "NomeCliente", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Reuniaos", "ClienteId");
            CreateIndex("dbo.Reuniaos", "FuncionarioId");
            AddForeignKey("dbo.Reuniaos", "FuncionarioId", "dbo.Funcionarios", "Id", cascadeDelete: true);
        }
    }
}
