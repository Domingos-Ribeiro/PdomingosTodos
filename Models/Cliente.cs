using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PdomingosTodos.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Display(Name = "Nome do Cliente")]
        [Required(ErrorMessage = "Preenchimento obrigatório")]
        [StringLength(50, ErrorMessage = "Máximo 50 carateres.")]
        public string NomeCliente { get; set; }

        [Required]
        [Display(Name = "Morada")]
        public string Morada { get; set; }

        [Display(Name = "Contacto")]
        public string Contacto { get; set; }


        //public int TempoId { get; set; }
        //public int ReuniaoId { get; set; }
        //public int DadosClienteId { get; set; }
        //public int FuncionarioId { get; set; }


    }
}