﻿using SisAdot.Enums;
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
    public Guid UsuarioID { get; set; }
    public PerfilUsuario PerfilUsuario { get; set; }
    [Required(ErrorMessage = "Obrigatório")]
    public string Login { get; set; }
    [Required(ErrorMessage = "Obrigatório")]
    public string Senha { get; set; }
    [Required(ErrorMessage = "Obrigatório")]
    [Compare("Senha", ErrorMessage = "Senhas não são correspondentes")]
    public string ConfirmaSenha { get; set; }
    [Required(ErrorMessage = "Obrigatório")]
    [EmailAddress(ErrorMessage = "Endereço de e-mail inválido")]
    public string Email { get; set; }
  }
}