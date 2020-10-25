using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SisAdot.Models
{
    [Table("Endereco")]
    public class Endereco
    {
        [Key]
        public Guid UsuarioID { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string CEP { get; set; }
        public int Numero { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string complemento { get; set; }
    }
}