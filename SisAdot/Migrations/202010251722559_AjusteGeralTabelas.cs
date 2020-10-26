namespace SisAdot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AjusteGeralTabelas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FichaCastracao",
                c => new
                {
                    CastracaoID = c.Guid(nullable: false),
                    DataEntrada = c.DateTime(nullable: false),
                    DataSaida = c.DateTime(nullable: false),
                    UsuarioID = c.Guid(nullable: false)
                })
                .PrimaryKey(t => t.CastracaoID)
                .ForeignKey("Usuario", t => t.UsuarioID);

            DropColumn("dbo.Usuario", "CPF");
            DropColumn("dbo.Usuario", "RG");
            DropColumn("dbo.Usuario", "DataNascimento");
            DropColumn("dbo.Usuario", "Nome");
            DropColumn("dbo.Usuario", "Discriminator");
        }

        public override void Down()
        {
            AddColumn("dbo.Usuario", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Usuario", "Nome", c => c.String());
            AddColumn("dbo.Usuario", "DataNascimento", c => c.DateTime());
            AddColumn("dbo.Usuario", "RG", c => c.String());
            AddColumn("dbo.Usuario", "CPF", c => c.String());
            DropTable("dbo.FichaCastracao");
        }
    }
}
