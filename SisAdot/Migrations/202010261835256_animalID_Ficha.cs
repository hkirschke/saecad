namespace SisAdot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class animalID_Ficha : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FichaCastracao", "AnimalID", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FichaCastracao", "AnimalID");
        }
    }
}
