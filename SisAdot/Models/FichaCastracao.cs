using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SisAdot.Models
{
    [Table("FichaCastracao")]
    public class FichaCastracao
    {
        [Key]
        public Guid CastracaoID { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
        [Key]
        [ForeignKey("UsuarioID")]
        public ICollection<Guid> UsuarioID { get; set; }
    }
}