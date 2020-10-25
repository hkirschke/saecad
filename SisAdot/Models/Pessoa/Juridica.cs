using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SisAdot.Models.Pessoa
{
    [Table("PessoaJuridica")]
    public class Juridica : Pessoa
    {
        [Key]
        [Required(ErrorMessage = "Obrigatório")]
        public string CNPJ { get; set; }
        [Required(ErrorMessage = "Obrigatório")]
        public string NomeFantasia { get; set; }
        [Required(ErrorMessage = "Obrigatório")]
        public string RazaoSocial { get; set; }
    }
}