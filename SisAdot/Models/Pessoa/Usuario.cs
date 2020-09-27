using SisAdot.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SisAdot.Models
{
  public class Usuario
  { 

    private Guid _idUsuario;

    public Guid IdUsuario
    {
      get { return _idUsuario; }
      set { _idUsuario = value; }
    }

    private string _perfilUsuario;

    public string PerfilUsuario
    {
      get { return _perfilUsuario; }
      set { _perfilUsuario = value; }
    }

    private string _login;

    public string Login
    {
      get { return _login; }
      set { _login = value; }
    }

    private string _senha;

    public string Senha
    {
      get { return _senha; }
      set { _senha = value; }
    }
     
    private string _email;

    public string Email
    {
      get { return _email; }
      set { _email = value; }
    } 
  }
}