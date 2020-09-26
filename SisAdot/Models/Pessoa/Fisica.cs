using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SisAdot.Models.Pessoa
{
  public class Fisica : Usuario
  {
    public string nomePessoa;


    private string _nomePessoa;

    public string NomePessoa
    {
      get { return _nomePessoa; }
      set { _nomePessoa = value; }
    }
     
    private string _cpf;

    public string CPF
    {
      get { return _cpf; }
      set { _cpf = value; }
    }

    private string _rg;

    public string RG
    {
      get { return _rg; }
      set { _rg = value; }
    }

    private DateTime _dataNascimento;

    public  DateTime DataNascimento
    {
      get { return _dataNascimento; }
      set { _dataNascimento = value; }
    } 
  }
}