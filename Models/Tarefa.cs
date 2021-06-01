using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PdomingosTodos.Models
{
    public class Tarefa
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Data de Início da Tarefa")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataInicio { get; set; }


        [Required]
        [Display(Name = "Data Limite")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataLimite { get; set; }

        [Display(Name = "Descrição da Tarefa")]
        [Required(ErrorMessage = "Preenchimento obrigatório")]
        [StringLength(200, ErrorMessage = "Máximo 200 carateres.")]
        public string DescricaoTarefa { get; set; }


        [Display(Name = "Nome do Funcionário")]
        [Required(ErrorMessage = "Preenchimento obrigatório")]
        public int FuncionarioId { get; set; } // Chave Estrangeira

        public virtual Funcionario Funcionario { get; set; }
    }
}