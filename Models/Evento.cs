using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PdomingosTodos.Models
{
    public class Evento
    {
        public int Id { get; set; } // Chave Primaria

        [Display(Name = "Data do Evento ou Facto")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataEvento { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Preenchimento obrigatório")]
        [StringLength(100, ErrorMessage = "Máximo 100 carateres.")]
        public string Descricao { get; set; }

        public int FuncionarioId { get; set; } // Chave Estrangeira

        public virtual Funcionario Funcionario { get; set; }

    }
}