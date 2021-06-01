using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PdomingosTodos.Models;

namespace PdomingosTodos.DAL
{
    public class PdomingosTodosContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<DadosCliente> DadosClientes { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Reuniao> Reunioes { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<TempoGasto> TemposGastos { get; set; }
    }
}