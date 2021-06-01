using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PdomingosTodos.Models
{
    public class TempoGasto
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }

        [Display(Name = "Motivo ou Tipo de Trabalho")]
        [Required(ErrorMessage = "Preenchimento obrigatório")]
        [StringLength(100, ErrorMessage = "Máximo 100 carateres.")]
        public string TempoUsado { get; set; }

        [Required]
        [Display(Name = "Tempo Disponibilizado")]
        [DataType(DataType.Duration)]
        public decimal Minutos { get; set; }

        // Qual o cliente onde foi gasto o tempo
        public int ClienteId { get; set; }
    }
}