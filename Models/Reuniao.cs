using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PdomingosTodos.Models
{
    public class Reuniao
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Data da Reunião")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataReuniao { get; set; }

        [Display(Name = "Tema da Reunião")]
        [Required(ErrorMessage = "Preenchimento obrigatório")]
        [StringLength(100, ErrorMessage = "Máximo 100 carateres.")]
        public string Tema { get; set; }

        [Display(Name = "Duração Prevista")]
        [DataType(DataType.Duration)]
        public decimal Minutos { get; set; }

        public int FuncionarioId { get; set; } // Chave Estrangeira
        public virtual Funcionario Funcionario { get; set; }

    }
}