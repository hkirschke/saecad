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
    }
}
