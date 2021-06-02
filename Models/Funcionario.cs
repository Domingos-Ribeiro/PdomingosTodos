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


    }
}