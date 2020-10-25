namespace SisAdot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CrudAnimal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animal",
                c => new
                    {
                        AnimalID = c.Guid(nullable: false),
                        TamanhoAnimal = c.Int(nullable: false),
                        RacaAnimal = c.Int(nullable: false),
                        Nome = c.String(nullable: false),
                        Idade = c.Int(nullable: false),
                        Situacao = c.Int(nullable: false),
                        Resenha = c.String(),
                        Foto = c.Binary(),
                    })
                .PrimaryKey(t => t.AnimalID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Animal");
        }
    }
}
