using SisAdot.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SisAdot.Models
{
  public class Usuario
  {
    public Guid IdUsuario;
    public PerfilUsuario PerfilUsuario;
    public string login;
    public string senha;
    public string email;
  }
}