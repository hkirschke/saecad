﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SisAdot.Models.Pessoa
{
    [Table("PessoaFisica")]
    public class Fisica: Pessoa
    {
        [Key]
        [Required(ErrorMessage = "Obrigatório")]
        public string CPF { get; set; }
        public string RG { get; set; }
        public DateTime DataNascimento { get; set; }
        [Required(ErrorMessage = "Obrigatório")]
        public string Nome { get; set; }
    }
}