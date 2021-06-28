using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PdomingosTodos.Models
{
    public class DadosCliente
    {
        public int Id { get; set; } // Chave Primaria
        public string DNomeCliente { get; set; }

        [Display(Name = "Tipo de Dados")]
        [Required(ErrorMessage = "Preenchimento obrigatório")]
        [StringLength(100, ErrorMessage = "Máximo 100 carateres.")]
        public string SenhaTipo { get; set; }


        public string MoradaCliente { get; set; }
        public string TelefoneCliente { get; set; }
        public string EmailCliente { get; set; }


        public int ClienteId { get; set; } // Chave Estrangeira
        public virtual Cliente Cliente { get; set; }
        
        //teste
    }
}
