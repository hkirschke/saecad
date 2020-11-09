namespace SisAdot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class equipeVeterinario_DatetimeNull : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EquipeVeterinario",
                c => new
                    {
                        EquipeVeterinarioID = c.Guid(nullable: false),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EquipeVeterinarioID);
            
            AddColumn("dbo.FichaCastracao", "EquipeVeterinarioID", c => c.Guid(nullable: false));
            AlterColumn("dbo.FichaCastracao", "DataEntrada", c => c.DateTime());
            AlterColumn("dbo.FichaCastracao", "DataSaida", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FichaCastracao", "DataSaida", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FichaCastracao", "DataEntrada", c => c.DateTime(nullable: false));
            DropColumn("dbo.FichaCastracao", "EquipeVeterinarioID");
            DropTable("dbo.EquipeVeterinario");
        }
    }
}
