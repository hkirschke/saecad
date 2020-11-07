using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SisAdot.Models
{
    public class FichaCastracaoViewModel
    {
        public Guid CastracaoID { get; set; }
        public string DataEntrada { get; set; }
        public string DataSaida { get; set; }  
        public string NomeAnimal  { get; set; } 
        public Guid AnimalID { get; set; }

        public Guid UsuarioID { get; set; }
    }
}