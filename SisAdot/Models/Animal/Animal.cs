using SisAdot.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SisAdot.Models.Animal
{
    [Table("Animal")]
    public class Animal
    {
        [Key]
        public Guid AnimalID { get; set; }
        public Guid UsuarioID { get; set; }
        [Required(ErrorMessage = "Obrigatório")]
        public PorteAnimal TamanhoAnimal { get; set; }
        [Required(ErrorMessage = "Obrigatório")]
        public Racas RacaAnimal { get; set; }
        [Required(ErrorMessage = "Obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Obrigatório")]
        public int Idade { get; set; }
        [Required(ErrorMessage = "Obrigatório")]
        public Situacao Situacao { get; set; }
        public string Resenha { get; set; }
        public byte[] Foto { get; set; }
    }
}