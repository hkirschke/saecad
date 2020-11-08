namespace SisAdot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColunaStatusVacina : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Animal", "StatusVacina", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Animal", "StatusVacina");
        }
    }
}
