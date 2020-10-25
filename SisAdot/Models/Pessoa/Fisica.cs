using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SisAdot.Models.Pessoa
{
    [Table("PessoaFisica")]
    public class Fisica
    {
        [Key]
        public Guid UsuarioID { get; set; }
        [Key]
        public string CPF { get; set; }
        public string RG { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Nome { get; set; }
    }
}