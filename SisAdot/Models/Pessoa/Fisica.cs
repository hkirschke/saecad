using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SisAdot.Models.Pessoa
{
  public class Fisica : Usuario
  { 
    public string NomePessoa { get; set; } 
    public string CPF { get; set; }
     
    public string RG { get; set; }
     
    public  DateTime DataNascimento { get; set; }
  }
}