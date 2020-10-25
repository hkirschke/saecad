using SisAdot.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SisAdot.Models.Pessoa
{
    public class Pessoa
    {
        [Key]
        [Required(ErrorMessage = "Obrigatório")]
        public Guid UsuarioID { get; set; }

        public TipoPessoa TipoPessoa { get; set; }
    }
}