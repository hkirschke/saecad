using SisAdot.Models.Animal;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SisAdot.Data
{
    public class SisAdotContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public SisAdotContext() : base("name=SisAdot")
        {
        }
        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        public System.Data.Entity.DbSet<SisAdot.Models.Usuario> Usuarios { get; set; }

        public System.Data.Entity.DbSet<SisAdot.Models.Animal.Animal> Animals { get; set; }

        public System.Data.Entity.DbSet<SisAdot.Models.FichaCastracao> FichaCastracaos { get; set; }

        public System.Data.Entity.DbSet<SisAdot.Models.Endereco> Enderecoes { get; set; }

        public System.Data.Entity.DbSet<SisAdot.Models.Pessoa.Pessoa> Pessoas { get; set; }

        /// <summary>
        /// Retorna lista de AnimalViewModel, animais para doação 
        /// </summary>
        /// <returns></returns>
        public List<AnimalViewModel> AnimaisDoacoes()
        {
            List<AnimalViewModel> animaisDoacao = (from animalList in this.Animals.ToList()
                                                   where animalList.Situacao == Enums.Situacao.Disponivel
                                                   select new AnimalViewModel
                                                   {
                                                       AnimalID = animalList.AnimalID,
                                                       Nome = animalList.Nome,
                                                       Idade = animalList.Idade,
                                                       Situacao = animalList.Situacao,
                                                       RacaAnimal = animalList.RacaAnimal,
                                                       TamanhoAnimal = animalList.TamanhoAnimal,
                                                       UsuarioID = animalList.UsuarioID,
                                                       ByteFoto = animalList.Foto,
                                                       Resenha = animalList.Resenha
                                                   }).ToList();
            return animaisDoacao;
        }

        public List<AnimalViewModel> GetAnimaisUsuario(Guid usuarioID)
        {
            List<AnimalViewModel> animaisDoacao = (from animalList in this.Animals.ToList()
                                                   where animalList.UsuarioID == usuarioID
                                                   select new AnimalViewModel
                                                   {
                                                       AnimalID = animalList.AnimalID,
                                                       Nome = animalList.Nome,
                                                       Idade = animalList.Idade,
                                                       Situacao = animalList.Situacao,
                                                       RacaAnimal = animalList.RacaAnimal,
                                                       TamanhoAnimal = animalList.TamanhoAnimal,
                                                       UsuarioID = animalList.UsuarioID
                                                   }).ToList();
            return animaisDoacao;
        }
    }
}
