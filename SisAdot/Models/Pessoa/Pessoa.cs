using SisAdot.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SisAdot.Models.Pessoa
{
    [Table("Pessoa")]
    public class Pessoa
    {
        [Key] 
        [Required(ErrorMessage = "Obrigatório")]
        public Guid PessoaID { get; set; }


        [Required(ErrorMessage = "Obrigatório")]
        public Guid UsuarioID { get; set; }

        public TipoPessoa TipoPessoa { get; set; }

        [Required(ErrorMessage = "Obrigatório")]
        public string Documento { get; set; }

        /// <summary>
        /// Pessoa Fisíca Nome, Juridica NomeFantasia
        /// </summary>
        [Required(ErrorMessage = "Obrigatório")]
        public string Descricao { get; set; }

        /// <summary>
        /// Pessoa Fisíca RG, Juridica Razão Social
        /// </summary>
        public string ComplementoDoc { get; set; }

        /// <summary>
        /// Pessoa Fisíca RG, Juridica Razão Social
        /// </summary> 
        public DateTime DataNascimento { get; set; }
    }
}