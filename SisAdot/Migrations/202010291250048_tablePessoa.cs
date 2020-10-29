namespace SisAdot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tablePessoa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pessoa",
                c => new
                    {
                        PessoaID = c.Guid(nullable: false),
                        UsuarioID = c.Guid(nullable: false),
                        TipoPessoa = c.Int(nullable: false),
                        Documento = c.String(nullable: false),
                        Descricao = c.String(nullable: false),
                        ComplementoDoc = c.String(),
                        DataNascimento = c.DateTime(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.PessoaID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pessoa");
        }
    }
}
