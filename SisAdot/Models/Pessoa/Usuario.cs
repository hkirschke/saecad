using SisAdot.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SisAdot.Models
{
  [Table("Usuario")]
  public class Usuario
  {
    [Key] 
    public Guid IdUsuario { get; set; }
    public PerfilUsuario PerfilUsuario { get; set; }
    public string Login { get; set; }
    public string Senha { get; set; }
    public string Email { get; set; }
  }
}