using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PdomingosTodos.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string NomeFuncionario { get; set; }

        
        //[DataType(DataType.Duration)]
        //public decimal TempoTrabalhado { get; set; }

        //public int Faltas { get; set; }

        //public int ClienteId { get; set; }

        //public virtual ICollection<Tarefa> Tarefas { get; set; }
        //public virtual ICollection<Reuniao> Reunioes { get; set; }
        //public virtual ICollection<Evento> Eventos { get; set; }
    }
}