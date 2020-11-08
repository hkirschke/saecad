namespace SisAdot.Migrations
{
    using SisAdot.Models;
    using SisAdot.Models.Animal;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SisAdot.Data.SisAdotContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            //AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SisAdot.Data.SisAdotContext context)
        {
            var UsuarioAdmin = new Guid("8807B82C-D6AE-464F-B3A8-1904900F7150");
            var UsuarioNaoAdmin = new Guid("E90C50D7-7C58-4A1F-9C7C-2CD446EDDAF3");
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            // 
            context.Usuarios.AddOrUpdate(
              p => p.UsuarioID,
              new Usuario { Login = "admin", Email = "henrique@teste.com", PerfilUsuario = Enums.PerfilUsuario.Administrador, Senha = "123456", UsuarioID = UsuarioAdmin },
              new Usuario { Login = "naoadmin", Email = "henrique@teste.com", PerfilUsuario = Enums.PerfilUsuario.Adotante, Senha = "123456", UsuarioID = UsuarioNaoAdmin }
            );

            context.Animals.AddOrUpdate(
                a => a.UsuarioID,
                new Animal
                {
                    UsuarioID = UsuarioAdmin,
                    Idade = 2,
                    RacaAnimal = Enums.Racas.Viralata,
                    Situacao = Enums.Situacao.DonoProprio,
                    Nome = "Teste",
                    TamanhoAnimal = Enums.PorteAnimal.Medio,
                    Resenha = "Teste",
                    AnimalID = new Guid("8fd7c807-84e7-4791-8e35-ba757df6f068"),
                    StatusVacina = false
                },
               new Animal
               {
                   Idade = 2,
                   RacaAnimal = Enums.Racas.ChowChow,
                   Situacao = Enums.Situacao.Disponível,
                   Nome = "Teste2",
                   TamanhoAnimal = Enums.PorteAnimal.Medio,
                   Resenha = "Teste2",
                   AnimalID = new Guid("d793b9c9-1e7c-4625-8c8d-80ae57db99c5"),
                   StatusVacina = false
               },
                new Animal
                {
                    Idade = 2,
                    RacaAnimal = Enums.Racas.Boxer,
                    Situacao = Enums.Situacao.Disponível,
                    Nome = "Teste3",
                    TamanhoAnimal = Enums.PorteAnimal.Pequeno,
                    Resenha = "Teste3",
                    AnimalID = new Guid("c59270c9-bf04-41f0-891a-4d6bcc5b2c88"),
                    StatusVacina = true
                }
               );
        }
    }
}
