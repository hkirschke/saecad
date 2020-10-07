namespace SisAdot.Migrations
{
    using SisAdot.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SisAdot.Data.SisAdotContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SisAdot.Data.SisAdotContext context)
        {
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
                new Usuario { Login = "admin", Email = "henrique@teste.com", PerfilUsuario = Enums.PerfilUsuario.Administrador, Senha = "123456", UsuarioID = Guid.NewGuid() },
                new Usuario { Login = "naoadmin", Email = "henrique@teste.com", PerfilUsuario = Enums.PerfilUsuario.Adotante, Senha = "123456", UsuarioID = Guid.NewGuid() }
              );

        }
    }
}
