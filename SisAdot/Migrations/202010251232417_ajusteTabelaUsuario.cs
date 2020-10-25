namespace SisAdot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class ajusteTabelaUsuario : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Usuario", "CPF");
            DropColumn("dbo.Usuario", "RG");
            DropColumn("dbo.Usuario", "DataNascimento");
            DropColumn("dbo.Usuario", "Nome");
        }

        public override void Down()
        {
            AddColumn("dbo.Usuario", "CPF", c => c.String());
            AddColumn("dbo.Usuario", "RG", c => c.String());
            AddColumn("dbo.Usuario", "DataNascimento", c => c.String());
            AddColumn("dbo.Usuario", "Nome", c => c.String());
        }
    }
}